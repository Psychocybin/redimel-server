using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Infrastructure;
using redimel_server.Models.Domain;
using redimel_server.Models.Enums;
using redimel_server.Utils;
using System.Linq;

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
                var hero = new Hero();

                if (change.OrderOfBattle >= OrderOfBattle.First && change.OrderOfBattle <= OrderOfBattle.Fifth)
                {
                    hero = user.GroupWest.Heroes.FirstOrDefault(x => x.OrderOfBattle == change.OrderOfBattle)
                        ?? throw new InvalidOperationException("Hero is null");
                }
                else
                {
                    hero = user.GroupWest.Heroes.FirstOrDefault(x => x.HeroType == change.HeroType) 
                        ?? throw new InvalidOperationException("Hero is null");
                }

                switch (change.PropertyName)
                {
                    case nameof(Ability.Survival):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Ability.Survival
                            };

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

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

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Ability.DoubleStrike)
                            {
                                hero.Ability.DoubleStrike = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }
                }
            }

            if (change.ClassName == nameof(AditionalPoint))
            {
                var aditionalPoints = user.GroupWest.AditionalPoints ?? throw new InvalidOperationException("AditionalPoint is null");

                switch (change.PropertyName)
                {
                    case nameof(aditionalPoints.TeamGame):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = aditionalPoints.TeamGame
                            };

                            intPropertyToCheck = CheckIntProperty(change, intPropertyToCheck).Result;

                            if (intPropertyToCheck.ResearchedValue != aditionalPoints.TeamGame)
                            {
                                aditionalPoints.TeamGame = intPropertyToCheck.ResearchedValue;
                            }

                            return intPropertyToCheck.Choice;
                        }

                    case nameof(aditionalPoints.ImportantInformation):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = aditionalPoints.ImportantInformation
                            };

                            intPropertyToCheck = CheckIntProperty(change, intPropertyToCheck).Result;

                            if (intPropertyToCheck.ResearchedValue != aditionalPoints.ImportantInformation)
                            {
                                aditionalPoints.ImportantInformation = intPropertyToCheck.ResearchedValue;
                            }

                            return intPropertyToCheck.Choice;
                        }

                    case nameof(aditionalPoints.SlainMonsters):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = aditionalPoints.SlainMonsters
                            };

                            intPropertyToCheck = CheckIntProperty(change, intPropertyToCheck).Result;

                            if (intPropertyToCheck.ResearchedValue != aditionalPoints.SlainMonsters)
                            {
                                aditionalPoints.SlainMonsters = intPropertyToCheck.ResearchedValue;
                            }

                            return intPropertyToCheck.Choice;
                        }

                    case nameof(aditionalPoints.Morals):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = aditionalPoints.Morals
                            };

                            intPropertyToCheck = CheckIntProperty(change, intPropertyToCheck).Result;

                            if (intPropertyToCheck.ResearchedValue != aditionalPoints.Morals)
                            {
                                aditionalPoints.Morals = intPropertyToCheck.ResearchedValue;
                            }

                            return intPropertyToCheck.Choice;
                        }

                    case nameof(aditionalPoints.Cover):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = aditionalPoints.Cover
                            };

                            intPropertyToCheck = CheckIntProperty(change, intPropertyToCheck).Result;

                            if (intPropertyToCheck.ResearchedValue != aditionalPoints.Cover)
                            {
                                aditionalPoints.Cover = intPropertyToCheck.ResearchedValue;
                            }

                            return intPropertyToCheck.Choice;
                        }

                    case nameof(aditionalPoints.TemporaryPoints):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = aditionalPoints.TemporaryPoints
                            };

                            intPropertyToCheck = CheckIntProperty(change, intPropertyToCheck).Result;

                            if (intPropertyToCheck.ResearchedValue != aditionalPoints.TemporaryPoints)
                            {
                                aditionalPoints.TemporaryPoints = intPropertyToCheck.ResearchedValue;
                            }

                            return intPropertyToCheck.Choice;
                        }
                }
            }

            if (change.ClassName == nameof(Armor))
            {
                var hero = new Hero();

                if (change.OrderOfBattle >= OrderOfBattle.First && change.OrderOfBattle <= OrderOfBattle.Fifth)
                {
                    hero = user.GroupWest.Heroes.FirstOrDefault(x => x.OrderOfBattle == change.OrderOfBattle)
                        ?? throw new InvalidOperationException("Hero is null");
                }
                else
                {
                    hero = user.GroupWest.Heroes.FirstOrDefault(x => x.HeroType == change.HeroType)
                        ?? throw new InvalidOperationException("Hero is null");
                }

                if (change.ActionType == ActionType.Check)
                {
                    if (change.TrueOrFalse == true)
                    {
                        if (hero.Equipments.Armor.ArmorType.ToString() == change.AdditionalInfo)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }

                        //TO DO with ComparisonMark

                        return null;
                    }

                    var IsArmorExist = hero.Equipments.Armor.IsExist;

                    if (IsArmorExist == change.ActiveOrNot)
                    {
                        var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                        return choice;
                    }
                }
                else if (change.ActionType == ActionType.Add)
                {
                    if (Enum.TryParse(change.AdditionalInfo, out ArmorType armorType))
                    {
                        var heroArmor = new Armor
                        {
                            ArmorType = armorType,
                            IsExist = true,
                            Defence = change.Defence,
                            EquipmentId = hero.EquipmentsId
                        };

                        hero.Equipments.Armor = heroArmor;

                        //TO DO The old armor must be deleted
                    }
                }
                else if (change.ActionType == ActionType.Remove)
                {
                    var heroArmor = new Armor
                    {
                        ArmorType = ArmorType.None,
                        IsExist = false,
                        Defence = 0,
                        EquipmentId = hero.EquipmentsId
                    };

                    hero.Equipments.Armor = heroArmor;

                    //TO DO The old armor must be deleted
                }
                else if (change.ActionType == ActionType.Update)
                {
                    hero.Equipments.Armor.Defence += change.Defence;
                }

                return null;
            }

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

        private async Task<IntPropertyToCheck> CheckIntProperty(Change change, IntPropertyToCheck intPropertyToCheckInput)
        {
            var requiredValue = change.Attack;

            var intPropertToCheckResult = new IntPropertyToCheck();

            if (change.ActionType == ActionType.Check)
            {
                if (change.ComparisonMark == ComparisonMark.Equal && intPropertyToCheckInput.ResearchedValue == requiredValue)
                {
                    intPropertToCheckResult.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                }
                else if (change.ComparisonMark == ComparisonMark.Bigger && intPropertyToCheckInput.ResearchedValue >= requiredValue)
                {
                    intPropertToCheckResult.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                }
                else if (change.ComparisonMark == ComparisonMark.Less && intPropertyToCheckInput.ResearchedValue <= requiredValue)
                {
                    intPropertToCheckResult.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                }

                intPropertToCheckResult.ResearchedValue = requiredValue;
                return intPropertToCheckResult;
            }
            else if (change.ActionType == ActionType.Add || change.ActionType == ActionType.Remove)
            {
                intPropertToCheckResult.ResearchedValue = intPropertyToCheckInput.ResearchedValue + requiredValue;
                return intPropertToCheckResult;
            }

            return null;
        }

        private async Task<BooleanPropertyToCheck> CheckBooleanProperty(Change change, BooleanPropertyToCheck booleanPropertyToCheck)
        {
            var result = new BooleanPropertyToCheck();

            if (change.ActionType == ActionType.Check)
            {
                if (booleanPropertyToCheck.ResearchedValue == true)
                {
                    result.ResearchedValue = booleanPropertyToCheck.ResearchedValue;
                    result.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
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
