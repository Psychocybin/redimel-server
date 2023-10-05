using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Infrastructure;
using redimel_server.Models.Domain;
using redimel_server.Models.Enums;
using redimel_server.Utils;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

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
                Hero hero = GetHero(user, change) ?? throw new InvalidOperationException("Hero is null");

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
                Hero hero = GetHero(user, change) ?? throw new InvalidOperationException("Hero is null");

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

            if (change.ClassName == nameof(Baggage))
            {
                if (change.ActionType == ActionType.Check)
                {
                    var wantedItem = change.Name;

                    if (change.HeroType == HeroType.All)
                    {
                        List<Hero> heroes = (List<Hero>)user.GroupWest.Heroes;

                        foreach (var h in heroes)
                        {
                            Baggage baggage = (Baggage)h.Baggages.FirstOrDefault(b => b.Name == wantedItem);

                            if (baggage != null)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return choice;
                            }
                        }

                        return null;
                    }

                    Hero hero = GetHero(user, change) ?? throw new InvalidOperationException("Hero is null");

                    Baggage heroBaggage = (Baggage)hero.Baggages.FirstOrDefault(b => b.Name == wantedItem);

                    if (heroBaggage != null)
                    {
                        var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                        return choice;
                    }
                    
                    return null;
                }
                else if (change.ActionType == ActionType.Add)
                {
                    Hero hero = GetHero(user, change) ?? throw new InvalidOperationException("Hero is null");

                    var newBaggage = new Baggage
                    {
                        Name = change.Name,
                        Volume = change.Quantity,
                        HeroId = hero.Id
                    };

                    var currentBaggageCapacity = hero.Baggages.Sum(x => x.Volume) + newBaggage.Volume;

                    if (currentBaggageCapacity <= hero.BaggageCapacity)
                    {
                        hero.Baggages.Add(newBaggage);
                    }
                }
                else if (change.ActionType == ActionType.Remove)
                {
                    var wantedItem = change.Name;

                    if (change.OrderOfBattle == OrderOfBattle.All)
                    {
                        List<Hero> heroes = (List<Hero>)user.GroupWest.Heroes;

                        foreach (var h in heroes)
                        {
                            Baggage baggage = (Baggage)h.Baggages.FirstOrDefault(b => b.Name == wantedItem);

                            if (baggage != null)
                            {
                                var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                h.Baggages.Remove(baggage);
                                return choice;
                            }
                        }
                    }
                    else if (change.OrderOfBattle <= OrderOfBattle.Fifth && change.OrderOfBattle >= OrderOfBattle.First)
                    {
                        var hero = user.GroupWest.Heroes.FirstOrDefault(x => x.OrderOfBattle == change.OrderOfBattle);

                        Baggage baggage = (Baggage)hero.Baggages.FirstOrDefault(b => b.Name == wantedItem);

                        if (baggage != null)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            hero.Baggages.Remove(baggage);
                            return choice;
                        }
                    }

                    return null;
                }
            }

            if (change.ClassName == nameof(BattleGroup))
            {
                if (change.ActionType == ActionType.Check)
                {
                    var wantedGroup = change.Name;
                    var countPeople = change.Attack;

                    List<BattleGroup> battleGroups = (List<BattleGroup>)user.GroupWest.AditionalPoints.BattleGroups;

                    foreach (var group in battleGroups)
                    {
                        if (group.CountPeople > countPeople)
                        {
                            var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return choice;
                        }
                    }
                }
                else if (change.ActionType == ActionType.Add)
                {
                    var aditionalPoint = user.GroupWest.AditionalPoints;

                    var battleGroup = new BattleGroup
                    {
                        Name = change.Name,
                        CountPeople = change.Attack,
                        AditionalPointsId = aditionalPoint.Id
                    };

                    aditionalPoint.BattleGroups.Add(battleGroup);
                }
                else if (change.ActionType == ActionType.Remove)
                {
                    var wantedGroup = change.Name;
                    var aditionalPoint = user.GroupWest.AditionalPoints;

                    var groupToDelete = aditionalPoint.BattleGroups.FirstOrDefault(x => x.Name == wantedGroup);

                    if (groupToDelete != null)
                    {
                        aditionalPoint.BattleGroups.Remove(groupToDelete);
                        var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                        return choice;
                    }
                }
            }

            if (change.ClassName == nameof(Equipment))

            {
                Hero hero = GetHero(user, change) ?? throw new InvalidOperationException("Hero is null");

                switch (change.PropertyName)
                {
                    case nameof(hero.Equipments.Knife):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Equipments.Knife
                            };

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Equipments.Knife)
                            {
                                hero.Equipments.Knife = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(hero.Equipments.SmokeBall):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Equipments.SmokeBall
                            };

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Equipments.SmokeBall)
                            {
                                hero.Equipments.SmokeBall = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(hero.Equipments.Poison):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Equipments.Poison
                            };

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Equipments.Poison)
                            {
                                hero.Equipments.Poison = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(hero.Equipments.MedicPack):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Equipments.MedicPack
                            };

                            booleanPropertyToCheck = CheckBooleanProperty(change, booleanPropertyToCheck).Result;

                            if (booleanPropertyToCheck.ResearchedValue != hero.Equipments.MedicPack)
                            {
                                hero.Equipments.MedicPack = booleanPropertyToCheck.ResearchedValue;
                            }

                            return booleanPropertyToCheck.Choice;
                        }

                    case nameof(hero.Equipments.MoneyBag):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = hero.Equipments.MoneyBag
                            };

                            intPropertyToCheck = CheckIntProperty(change, intPropertyToCheck).Result;

                            if (intPropertyToCheck.ResearchedValue != hero.Equipments.MoneyBag)
                            {
                                hero.Equipments.MoneyBag = intPropertyToCheck.ResearchedValue;
                            }

                            return intPropertyToCheck.Choice;
                        }

                }
            }

            if (change.ClassName == nameof(GroupWest))
            {
                var groupWest = user.GroupWest;

                switch (change.PropertyName)
                {
                    case nameof(groupWest.ActualMission):
                        {
                            var stringPropertyToCheck = new StringPropertyToCheck
                            {
                                ResearchedValue = groupWest.ActualMission
                            };

                            stringPropertyToCheck = CheckStringProperty(change, stringPropertyToCheck).Result;

                            if (stringPropertyToCheck.ResearchedValue != groupWest.ActualMission)
                            {
                                groupWest.ActualMission = stringPropertyToCheck.ResearchedValue;
                            }

                            return stringPropertyToCheck.Choice;
                        }
                }
            }

            if (change.ClassName == nameof(Hero))
            {
                if (change.OrderOfBattle >= OrderOfBattle.First && change.OrderOfBattle <= OrderOfBattle.Fifth)
                {
                    Hero hero = user.GroupWest.Heroes.FirstOrDefault(x => x.OrderOfBattle == change.OrderOfBattle) ?? throw new InvalidOperationException("Hero is null");

                    if (change.HeroClass == HeroClass.All)
                    {
                        if (hero.HeroType == change.HeroType)
                        {
                            return await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                        }
                    }
                    else if (hero.HeroClass == change.HeroClass )
                    {
                        return await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                    }
                }
                else if (change.OrderOfBattle == OrderOfBattle.All)
                {
                    List<Hero> heroes = (List<Hero>)user.GroupWest.Heroes;

                    foreach (var h in heroes)
                    {
                        if (h.HeroClass == change.HeroClass)
                        {
                            return await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                        }
                    }
                }

                //TO DO HeroType options?
            }

            if (change.ClassName == nameof(Indicator))
            {
                Hero hero = GetHero(user, change) ?? throw new InvalidOperationException("Hero is null");

                switch (change.PropertyName)
                {
                    case nameof(hero.Indicators.Health):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = hero.Indicators.Health
                            };

                            intPropertyToCheck = CheckIntProperty(change, intPropertyToCheck).Result;

                            if (intPropertyToCheck.ResearchedValue != hero.Indicators.Health)
                            {
                                hero.Indicators.Health = intPropertyToCheck.ResearchedValue;
                            }

                            return intPropertyToCheck.Choice;
                        }

                    case nameof(hero.Indicators.MentalEnergy):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = hero.Indicators.MentalEnergy
                            };

                            intPropertyToCheck = CheckIntProperty(change, intPropertyToCheck).Result;

                            if (intPropertyToCheck.ResearchedValue != hero.Indicators.MentalEnergy)
                            {
                                hero.Indicators.MentalEnergy = intPropertyToCheck.ResearchedValue;
                            }

                            return intPropertyToCheck.Choice;
                        }

                    case nameof(hero.Indicators.MentalStrength):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = hero.Indicators.MentalStrength
                            };

                            intPropertyToCheck = CheckIntProperty(change, intPropertyToCheck).Result;

                            if (intPropertyToCheck.ResearchedValue != hero.Indicators.MentalStrength)
                            {
                                hero.Indicators.MentalStrength = intPropertyToCheck.ResearchedValue;
                            }

                            return intPropertyToCheck.Choice;
                        }

                    case nameof(hero.Indicators.Strength):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = hero.Indicators.Strength
                            };

                            intPropertyToCheck = CheckIntProperty(change, intPropertyToCheck).Result;

                            if (intPropertyToCheck.ResearchedValue != hero.Indicators.Strength)
                            {
                                hero.Indicators.Strength = intPropertyToCheck.ResearchedValue;
                            }

                            return intPropertyToCheck.Choice;
                        }

                    case nameof(hero.Indicators.Dexterity):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = hero.Indicators.Dexterity
                            };

                            intPropertyToCheck = CheckIntProperty(change, intPropertyToCheck).Result;

                            if (intPropertyToCheck.ResearchedValue != hero.Indicators.Dexterity)
                            {
                                hero.Indicators.Dexterity = intPropertyToCheck.ResearchedValue;
                            }

                            return intPropertyToCheck.Choice;
                        }

                    case nameof(hero.Indicators.Agility):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = hero.Indicators.Agility
                            };

                            intPropertyToCheck = CheckIntProperty(change, intPropertyToCheck).Result;

                            if (intPropertyToCheck.ResearchedValue != hero.Indicators.Agility)
                            {
                                hero.Indicators.Agility = intPropertyToCheck.ResearchedValue;
                            }

                            return intPropertyToCheck.Choice;
                        }

                    case nameof(hero.Indicators.Evasion):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = hero.Indicators.Evasion
                            };

                            intPropertyToCheck = CheckIntProperty(change, intPropertyToCheck).Result;

                            if (intPropertyToCheck.ResearchedValue != hero.Indicators.Evasion)
                            {
                                hero.Indicators.Evasion = intPropertyToCheck.ResearchedValue;
                            }

                            return intPropertyToCheck.Choice;
                        }

                    case nameof(hero.Indicators.Endurance):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = hero.Indicators.Endurance
                            };

                            intPropertyToCheck = CheckIntProperty(change, intPropertyToCheck).Result;

                            if (intPropertyToCheck.ResearchedValue != hero.Indicators.Endurance)
                            {
                                hero.Indicators.Endurance = intPropertyToCheck.ResearchedValue;
                            }

                            return intPropertyToCheck.Choice;
                        }
                }
            }

            return null;
        }

        private static Hero GetHero(User user, Change change)
        {
            var hero = new Hero();

            if (change.OrderOfBattle >= OrderOfBattle.First && change.OrderOfBattle <= OrderOfBattle.Fifth)
            {
                hero = user.GroupWest.Heroes.FirstOrDefault(x => x.OrderOfBattle == change.OrderOfBattle);
            }
            else
            {
                hero = user.GroupWest.Heroes.FirstOrDefault(x => x.HeroType == change.HeroType);
            }

            return hero;
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

                intPropertToCheckResult.ResearchedValue = intPropertyToCheckInput.ResearchedValue;
                return intPropertToCheckResult;
            }
            else if (change.ActionType == ActionType.Add || change.ActionType == ActionType.Remove)
            {
                intPropertToCheckResult.ResearchedValue = intPropertyToCheckInput.ResearchedValue + requiredValue;
                return intPropertToCheckResult;
            }
            else if (change.ActionType == ActionType.Update)
            {
                intPropertToCheckResult.ResearchedValue = requiredValue;
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

        private async Task<StringPropertyToCheck> CheckStringProperty(Change change, StringPropertyToCheck stringPropertyToCheck)
        {
            var requiredValue = change.Name;

            var stringPropertToCheckResult = new StringPropertyToCheck();

            if (change.ActionType == ActionType.Check)
            {
                if (stringPropertyToCheck.ResearchedValue == requiredValue)
                {
                    stringPropertToCheckResult.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                }

                stringPropertToCheckResult.ResearchedValue = stringPropertyToCheck.ResearchedValue;
                return stringPropertToCheckResult;
            }
            else if (change.ActionType == ActionType.Add)
            {
                stringPropertToCheckResult.ResearchedValue = stringPropertyToCheck.ResearchedValue + requiredValue;
                return stringPropertToCheckResult;
            }
            else if (change.ActionType == ActionType.Remove)
            {
                stringPropertToCheckResult.ResearchedValue = "";
                return stringPropertToCheckResult;
            }
            else if (change.ActionType == ActionType.Update)
            {
                stringPropertToCheckResult.ResearchedValue = requiredValue;
                return stringPropertToCheckResult;
            }

            return null;
        }
    }
}
