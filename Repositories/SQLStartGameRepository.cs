using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;
using redimel_server.Models.Enums;
using redimel_server.Utils;

namespace redimel_server.Repositories
{
    public class SQLStartGameRepository : IStartGameRepository
    {
        private readonly RedimelServerDbContext dbContext;
        private readonly IUserRepository userRepository;

        public SQLStartGameRepository(RedimelServerDbContext dbContext, IUserRepository userRepository)
        {
            this.dbContext = dbContext;
            this.userRepository = userRepository;
        }

        public async Task<Page> GetNextPageAsync(Choice choice)
        {
            var mandatoryChoices = await dbContext.Choices.Where(x => x.AdditionalCheck == false)
                .Where(x => x.PageId == choice.NextPage).ToListAsync();

            var currentUserEmail = userRepository.GetUserEmail();

            var currentUser = await dbContext.Users.Where(x => x.CurrentUserEmail == currentUserEmail)
                .Include(x => x.GroupWest).ThenInclude(x => x.AditionalPoints).ThenInclude(x => x.BattleGroups)
                .Include(x => x.GroupWest).ThenInclude(x => x.AditionalPoints).ThenInclude(x => x.Negotiations)
                .Include(x => x.GroupWest).ThenInclude(x => x.Missions)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Indicators)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Ability)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Baggages)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Promises)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.SpecialAbility).ThenInclude(x => x.SpecialCombatSkill)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.SpecialAbility).ThenInclude(x => x.Ultimate)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.SpecialAbility).ThenInclude(x => x.Spells)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.SpecialAbility).ThenInclude(x => x.Rituals)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.SpecialAbility).ThenInclude(x => x.NatureSkills)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Equipments).ThenInclude(x => x.Weapon)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Equipments).ThenInclude(x => x.Armor)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Equipments).ThenInclude(x => x.Shield)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Equipments).ThenInclude(x => x.ThrowingWeapon)
                .Include(x => x.GroupWest).ThenInclude(x => x.Heroes).ThenInclude(x => x.Equipments).ThenInclude(x => x.Talismans)
                .Include(x => x.WorldInfoVariables).FirstOrDefaultAsync();

            if (choice.PageId != currentUser.CurrentLocation)
            {
                throw new Exception();
            }

            var nextPage = await dbContext.Pages.FirstOrDefaultAsync(x => x.Id == choice.NextPage);

            var choicesList = new List<Choice>();

            foreach (var item in mandatoryChoices)
            {
                choicesList.Add(item);
            }

            var changesList = await dbContext.Changes.Where(x => x.PageId == nextPage.Id).ToListAsync();

            foreach (var change in changesList)
            {
                var currentChoice = PerformChange(currentUser, change).Result;

                if (currentChoice != null)
                {
                    choicesList.Add(currentChoice);
                }
            }

            nextPage.Choices = choicesList;
            currentUser.CurrentLocation = nextPage.Id;

            await dbContext.SaveChangesAsync();

            return nextPage;


        }

        public async Task<Choice> PerformChange(User user, Change change)
        {
            if (change.ClassName == nameof(Ability))
            {
                var hero = user.GroupWest.Heroes.FirstOrDefault(x => x.HeroType == change.HeroType) ?? throw new InvalidOperationException();

                switch (change.PropertyName)
                {
                    case nameof(Ability.Survival):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Survival
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Survival)
                            {
                                hero.Ability.Survival = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.Diplomacy):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Diplomacy
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Diplomacy)
                            {
                                hero.Ability.Diplomacy = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.Climbing):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Climbing
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Climbing)
                            {
                                hero.Ability.Climbing = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.Acrobatics):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Acrobatics
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Acrobatics)
                            {
                                hero.Ability.Acrobatics = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.Skill):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Skill
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Skill)
                            {
                                hero.Ability.Skill = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.Guile):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Guile
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Guile)
                            {
                                hero.Ability.Guile = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.SecretKnowledge):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.SecretKnowledge
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.SecretKnowledge)
                            {
                                hero.Ability.SecretKnowledge = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.Sneak):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Sneak
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Sneak)
                            {
                                hero.Ability.Sneak = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.Elusion):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Elusion
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Elusion)
                            {
                                hero.Ability.Elusion = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.WaterCycle):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.WaterCycle
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.WaterCycle)
                            {
                                hero.Ability.WaterCycle = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.Melee):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Melee
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Melee)
                            {
                                hero.Ability.Melee = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.NatureSkills):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.NatureSkills
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.NatureSkills)
                            {
                                hero.Ability.NatureSkills = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.BreakingLocks):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.BreakingLocks
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.BreakingLocks)
                            {
                                hero.Ability.BreakingLocks = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.Transformation):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Transformation
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Transformation)
                            {
                                hero.Ability.Transformation = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.Spells):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Spells
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Spells)
                            {
                                hero.Ability.Spells = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.Rituals):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Rituals
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Rituals)
                            {
                                hero.Ability.Rituals = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.Traps):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Traps
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Traps)
                            {
                                hero.Ability.Traps = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.Archery):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Archery
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Archery)
                            {
                                hero.Ability.Archery = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.ThrowingKnives):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.ThrowingKnives
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.ThrowingKnives)
                            {
                                hero.Ability.ThrowingKnives = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.PoisonousNeedles):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.PoisonousNeedles
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.PoisonousNeedles)
                            {
                                hero.Ability.PoisonousNeedles = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.Stimulants):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Stimulants
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Stimulants)
                            {
                                hero.Ability.Stimulants = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.Wrestling):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Wrestling
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Wrestling)
                            {
                                hero.Ability.Wrestling = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.Observation):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Observation
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Observation)
                            {
                                hero.Ability.Observation = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.ShieldBearer):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.ShieldBearer
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.ShieldBearer)
                            {
                                hero.Ability.ShieldBearer = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.Leadership):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Leadership
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.Leadership)
                            {
                                hero.Ability.Leadership = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.KickFight):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.KickFight
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.KickFight)
                            {
                                hero.Ability.KickFight = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(Ability.DoubleStrike):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.DoubleStrike
                            };

                            booleanPropertyToCheck = PropertyToCheck(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.DoubleStrike)
                            {
                                hero.Ability.DoubleStrike = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }
                }
            }

            //if (change.ClassName == "AditionalPoints")
            //{
            //    var aditionalPoints = user.GroupWest.AditionalPoints;

            //    if (change.ActionType == "check")
            //    {
            //        switch (change.PropertyName)
            //        {
            //            case "TeamGame":
            //                {
            //                    var teamGame = aditionalPoints.TeamGame;
            //                    return await NewMethod1(change, teamGame);
            //                }

            //            case "ImportantInformation":
            //                {
            //                    var importantInformation = aditionalPoints.ImportantInformation;
            //                    var requiredTeamGame = change.Attack;
            //                    var indicator = change.AdditionalInfo;

            //                    if (indicator == "equal")
            //                    {
            //                        if (importantInformation == requiredTeamGame)
            //                        {
            //                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                            return choice;
            //                        }
            //                    }
            //                    else if (indicator == "bigger")
            //                    {
            //                        if (importantInformation >= requiredTeamGame)
            //                        {
            //                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                            return choice;
            //                        }
            //                    }
            //                    else if (indicator == "less")
            //                    {
            //                        if (importantInformation <= requiredTeamGame)
            //                        {
            //                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                            return choice;
            //                        }
            //                    }

            //                    break;
            //                }

            //            case "SlainMonsters":
            //                {
            //                    var slainMonsters = aditionalPoints.SlainMonsters;
            //                    var requiredTeamGame = change.Attack;
            //                    var indicator = change.AdditionalInfo;

            //                    if (indicator == "equal")
            //                    {
            //                        if (slainMonsters == requiredTeamGame)
            //                        {
            //                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                            return choice;
            //                        }
            //                    }
            //                    else if (indicator == "bigger")
            //                    {
            //                        if (slainMonsters >= requiredTeamGame)
            //                        {
            //                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                            return choice;
            //                        }
            //                    }
            //                    else if (indicator == "less")
            //                    {
            //                        if (slainMonsters <= requiredTeamGame)
            //                        {
            //                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                            return choice;
            //                        }
            //                    }

            //                    break;
            //                }

            //            case "Morals":
            //                {
            //                    var morals = aditionalPoints.Morals;
            //                    var requiredTeamGame = change.Attack;
            //                    var indicator = change.AdditionalInfo;

            //                    if (indicator == "equal")
            //                    {
            //                        if (morals == requiredTeamGame)
            //                        {
            //                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                            return choice;
            //                        }
            //                    }
            //                    else if (indicator == "bigger")
            //                    {
            //                        if (morals >= requiredTeamGame)
            //                        {
            //                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                            return choice;
            //                        }
            //                    }
            //                    else if (indicator == "less")
            //                    {
            //                        if (morals <= requiredTeamGame)
            //                        {
            //                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                            return choice;
            //                        }
            //                    }

            //                    break;
            //                }

            //            case "Cover":
            //                {
            //                    var cover = aditionalPoints.Cover;
            //                    var requiredTeamGame = change.Attack;
            //                    var indicator = change.AdditionalInfo;

            //                    if (indicator == "equal")
            //                    {
            //                        if (cover == requiredTeamGame)
            //                        {
            //                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                            return choice;
            //                        }
            //                    }
            //                    else if (indicator == "bigger")
            //                    {
            //                        if (cover >= requiredTeamGame)
            //                        {
            //                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                            return choice;
            //                        }
            //                    }
            //                    else if (indicator == "less")
            //                    {
            //                        if (cover <= requiredTeamGame)
            //                        {
            //                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                            return choice;
            //                        }
            //                    }

            //                    break;
            //                }

            //            case "TemporaryPoints":
            //                {
            //                    var temporaryPoints = aditionalPoints.TemporaryPoints;
            //                    var requiredTeamGame = change.Attack;
            //                    var indicator = change.AdditionalInfo;

            //                    if (indicator == "equal")
            //                    {
            //                        if (temporaryPoints == requiredTeamGame)
            //                        {
            //                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                            return choice;
            //                        }
            //                    }
            //                    else if (indicator == "bigger")
            //                    {
            //                        if (temporaryPoints >= requiredTeamGame)
            //                        {
            //                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                            return choice;
            //                        }
            //                    }
            //                    else if (indicator == "less")
            //                    {
            //                        if (temporaryPoints <= requiredTeamGame)
            //                        {
            //                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                            return choice;
            //                        }
            //                    }

            //                    break;
            //                }
            //        }
            //    }
            //    else if (change.ActionType.ToString() == "add" || change.ActionType == "remove")
            //    {
            //        aditionalPoints.TeamGame += change.Attack;
            //        aditionalPoints.ImportantInformation += change.Defence;
            //        aditionalPoints.SlainMonsters += change.Damage;
            //        aditionalPoints.Morals += Convert.ToInt32(change.Range);
            //        aditionalPoints.Cover += Convert.ToInt32(change.Quantity);
            //        aditionalPoints.TemporaryPoints += int.Parse(change.AdditionalInfo);
            //    }
            //}

            //if (change.ClassName == "Armors")
            //{
            //    var hero = user.GroupWest.Heroes.FirstOrDefault(x => x.HeroType == change.HeroType);

            //    if (change.ActionType == "check")
            //    {
            //        var IsArmorExist = hero.Equipments.Armor.IsExist;

            //        if (change.TrueOrFalse == true)
            //        {
            //            var heroArmorType = hero.Equipments.Armor.ArmorType;

            //            if (heroArmorType == change.AdditionalInfo)
            //            {
            //                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                return choice;
            //            }

            //            //TO DO when finished enum's
            //        }

            //        if (IsArmorExist == change.ActiveOrNot)
            //        {
            //            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //            return choice;
            //        }
            //    }
            //    else if (change.ActionType == "add")
            //    {
            //        var heroArmor = new Armor
            //        {
            //            ArmorType = change.AdditionalInfo,
            //            IsExist = true,
            //            Defence = change.Defence,
            //            EquipmentId = hero.EquipmentsId
            //        };

            //        hero.Equipments.Armor = heroArmor;
            //    }
            //    else if (change.ActionType == "remove")
            //    {
            //        var heroArmor = new Armor
            //        {
            //            ArmorType = "",
            //            IsExist = false,
            //            Defence = 0,
            //            EquipmentId = hero.EquipmentsId
            //        };

            //        hero.Equipments.Armor = heroArmor;
            //    }
            //    else if (change.ActionType == "update")
            //    {
            //        hero.Equipments.Armor.Defence += change.Defence;
            //    }
            //}

            //if (change.ClassName == "Baggages")
            //{
            //    if (change.ActionType == "check")
            //    {
            //        var wantedItem = change.Name;

            //        if (change.HeroType == "all")
            //        {
            //            List<Hero> heroes = (List<Hero>)user.GroupWest.Heroes;

            //            foreach (var h in heroes)
            //            {
            //                Baggage baggage = (Baggage)h.Baggages.FirstOrDefault(b => b.Name == wantedItem);

            //                if (baggage != null)
            //                {
            //                    var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                    return choice;
            //                }
            //            }

            //            return null;
            //        }

            //        var hero = user.GroupWest.Heroes.FirstOrDefault(x => x.HeroType == change.HeroType);

            //        if (hero != null)
            //        {
            //            Baggage baggage = (Baggage)hero.Baggages.FirstOrDefault(b => b.Name == wantedItem);

            //            if (baggage != null)
            //            {
            //                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                return choice;
            //            }
            //            else
            //            {
            //                return null;
            //            }
            //        }
            //    }
            //    else if (change.ActionType == "add")
            //    {
            //        Hero hero;

            //        if (change.OrderOfBattle <= 5 && change.OrderOfBattle >= 1)
            //        {
            //            hero = user.GroupWest.Heroes.FirstOrDefault(x => x.OrderOfBattle == change.OrderOfBattle);
            //        }
            //        else
            //        {
            //            hero = user.GroupWest.Heroes.FirstOrDefault(x => x.HeroType == change.HeroType);
            //        }

            //        var newBaggage = new Baggage
            //        {
            //            Name = change.Name,
            //            Volume = change.Quantity,
            //            HeroId = hero.Id
            //        };

            //        var currentBaggageCapacity = hero.Baggages.Sum(x => x.Volume) + newBaggage.Volume;

            //        if (currentBaggageCapacity <= hero.BaggageCapacity)
            //        {
            //            hero.Baggages.Add(newBaggage);
            //        }
            //    }
            //    else if (change.ActionType == "remove")
            //    {
            //        var wantedItem = change.Name;

            //        if (change.OrderOfBattle <= 5 && change.OrderOfBattle >= 1)
            //        {
            //            var hero = user.GroupWest.Heroes.FirstOrDefault(x => x.OrderOfBattle == change.OrderOfBattle);

            //            Baggage baggage = (Baggage)hero.Baggages.FirstOrDefault(b => b.Name == wantedItem);

            //            if (baggage != null)
            //            {
            //                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                hero.Baggages.Remove(baggage);
            //                return choice;
            //            }
            //        }
            //        else
            //        {
            //            List<Hero> heroes = (List<Hero>)user.GroupWest.Heroes;

            //            foreach (var h in heroes)
            //            {
            //                Baggage baggage = (Baggage)h.Baggages.FirstOrDefault(b => b.Name == wantedItem);

            //                if (baggage != null)
            //                {
            //                    var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                    h.Baggages.Remove(baggage);
            //                    return choice;
            //                }
            //            }
            //        }
            //    }
            //}

            //if (change.ClassName == "BattleGroups")
            //{
            //    if (change.ActionType == "check")
            //    {
            //        var wantedGroup = change.Name;
            //        var countPeople = change.Attack;

            //        List<BattleGroup> battleGroups = (List<BattleGroup>)user.GroupWest.AditionalPoints.BattleGroups;

            //        foreach (var group in battleGroups)
            //        {
            //            if (group != null)
            //            {
            //                if (group.CountPeople > countPeople)
            //                {
            //                    var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //                    return choice;
            //                }
            //            }
            //        }
            //    }
            //    else if (change.ActionType == "add")
            //    {
            //        var aditionalPoint = user.GroupWest.AditionalPoints;

            //        var battleGroup = new BattleGroup
            //        {
            //            Name = change.Name,
            //            CountPeople = change.Attack,
            //            AditionalPointsId = aditionalPoint.Id
            //        };

            //        aditionalPoint.BattleGroups.Add(battleGroup);
            //    }
            //    else if (change.ActionType == "remove")
            //    {
            //        var wantedGroup = change.Name;
            //        var aditionalPoint = user.GroupWest.AditionalPoints;

            //        var groupToDelete = aditionalPoint.BattleGroups.FirstOrDefault(x => x.Name == wantedGroup);

            //        if (groupToDelete != null)
            //        {
            //            aditionalPoint.BattleGroups.Remove(groupToDelete);
            //            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            //            return choice;
            //        }
            //    }
            //}

            return null;
        }

        private async Task<Choice> NewMethod1(Change change, int teamGame)
        {
            var requiredTeamGame = change.Attack;
            var indicator = change.AdditionalInfo;

            if (indicator == "equal" && teamGame == requiredTeamGame)
            {
                return await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
            }
            else if (indicator == "bigger")
            {
                if (teamGame >= requiredTeamGame)
                {
                    var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                    return choice;
                }
            }
            else if (indicator == "less")
            {
                if (teamGame <= requiredTeamGame)
                {
                    var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                    return choice;
                }
            }

            return null;
        }

        private async Task<BooleanPropertyToCheck> PropertyToCheck(Change change, BooleanPropertyToCheck booleanPropertyToCheck)
        {
            var result = new BooleanPropertyToCheck();

            if (change.ActionType == ActionType.Check)
            {
                if (booleanPropertyToCheck.ResearchedValue == true)
                {
                    var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                    result.ResearchedValue = booleanPropertyToCheck.ResearchedValue;
                    result.Choice = choice;
                    return result;
                }
            }
            else if (change.ActionType == ActionType.Add)
            {
                result.ResearchedValue = true;
            }
            else if (change.ActionType == ActionType.Remove)
            {
                result.ResearchedValue = false;
            }
            else
            {
                return null;
            }

            return result;
        }
    }
}
