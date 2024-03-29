﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using redimel_server.Data;
using redimel_server.Infrastructure;
using redimel_server.Models.Domain;
using redimel_server.Models.Enums;

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
                .Include(x => x.Location)
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
                .Include(x => x.WorldInfoVariables).FirstOrDefaultAsync()
                    ?? throw new Exception("This user cannot be found!");

            if (choice.PageId != currentUser.Location.PageId)
            {
                throw new Exception("You are on wrong page!");
            }

            var nextPage = await dbContext.Pages.AsNoTracking().FirstOrDefaultAsync(x => x.Id == choice.NextPage) 
                ?? throw new Exception("This page not exist!");

            var changesList = await dbContext.Changes.Where(x => x.PageId == nextPage.Id).ToListAsync();
            List<Choice> choicesToAdd = new();
            string changeNoticeToAdd = "";

            foreach (var change in changesList)
            {
                var changeResponse = await PerformChange(currentUser, change);

                if (changeResponse.Choice != null)
                {
                    choicesToAdd.Add(changeResponse.Choice);
                }

                if (!changeResponse.ChangeNotice.IsNullOrEmpty())
                {
                    changeNoticeToAdd = $"{changeNoticeToAdd}   {changeResponse.ChangeNotice}";
                }
            }

            foreach (var item in mandatoryChoices)
            {
                nextPage.Choices.Add(item);
            }

            foreach (var item in choicesToAdd)
            {
                nextPage.Choices.Add(item);
            }

            nextPage.ChangeNotices = changeNoticeToAdd;

            var location = await SaveCurrentLocation(nextPage, currentUser.Location.Id);

            currentUser.Location = location;

            await dbContext.SaveChangesAsync();

            return nextPage;
        }

        public async Task<ChangeResponse> PerformChange(User user, Change change)
        {
            if (change.ClassName == nameof(Ability))
            {
                Hero hero = GetHero(user, change) ?? throw new InvalidOperationException("Hero is null");

                switch (change.PropertyName)
                {
                    case nameof(Ability.Survival):
                        {
                            var isHeroAbilityExist = hero.Ability.Survival;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Survival = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.Diplomacy):
                        {
                            var isHeroAbilityExist = hero.Ability.Diplomacy;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Diplomacy = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.Climbing):
                        {
                            var isHeroAbilityExist = hero.Ability.Climbing;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Climbing = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.Acrobatics):
                        {
                            var isHeroAbilityExist = hero.Ability.Acrobatics;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Acrobatics = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.Skill):
                        {
                            var isHeroAbilityExist = hero.Ability.Skill;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Skill = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.Guile):
                        {
                            var isHeroAbilityExist = hero.Ability.Guile;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Guile = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.SecretKnowledge):
                        {
                            var isHeroAbilityExist = hero.Ability.SecretKnowledge;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.SecretKnowledge = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.Sneak):
                        {
                            var isHeroAbilityExist = hero.Ability.Sneak;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Sneak = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.Elusion):
                        {
                            var isHeroAbilityExist = hero.Ability.Elusion;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Elusion = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.WaterCycle):
                        {
                            var isHeroAbilityExist = hero.Ability.WaterCycle;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.WaterCycle = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.Melee):
                        {
                            var isHeroAbilityExist = hero.Ability.Melee;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Melee = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.NatureSkills):
                        {
                            var isHeroAbilityExist = hero.Ability.NatureSkills;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.NatureSkills = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.BreakingLocks):
                        {
                            var isHeroAbilityExist = hero.Ability.BreakingLocks;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.BreakingLocks = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.Transformation):
                        {
                            var isHeroAbilityExist = hero.Ability.Transformation;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Transformation = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.Spells):
                        {
                            var isHeroAbilityExist = hero.Ability.Spells;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Spells = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.Rituals):
                        {
                            var isHeroAbilityExist = hero.Ability.Rituals;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Rituals = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.Traps):
                        {
                            var isHeroAbilityExist = hero.Ability.Traps;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Traps = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.Archery):
                        {
                            var isHeroAbilityExist = hero.Ability.Archery;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Archery = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.ThrowingKnives):
                        {
                            var isHeroAbilityExist = hero.Ability.ThrowingKnives;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.ThrowingKnives = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.PoisonousNeedles):
                        {
                            var isHeroAbilityExist = hero.Ability.PoisonousNeedles;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.PoisonousNeedles = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.Stimulants):
                        {
                            var isHeroAbilityExist = hero.Ability.Stimulants;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Stimulants = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.Wrestling):
                        {
                            var isHeroAbilityExist = hero.Ability.Wrestling;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Wrestling = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.Observation):
                        {
                            var isHeroAbilityExist = hero.Ability.Observation;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Observation = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.ShieldBearer):
                        {
                            var isHeroAbilityExist = hero.Ability.ShieldBearer;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.ShieldBearer = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.Leadership):
                        {
                            var isHeroAbilityExist = hero.Ability.Leadership;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.Leadership = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.KickFight):
                        {
                            var isHeroAbilityExist = hero.Ability.KickFight;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.KickFight = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
                        }

                    case nameof(Ability.DoubleStrike):
                        {
                            var isHeroAbilityExist = hero.Ability.DoubleStrike;

                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = isHeroAbilityExist
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            hero.Ability.DoubleStrike = booleanPropertyToCheck.ResearchedValue;

                            return AbilityResponse(change, hero, isHeroAbilityExist, booleanPropertyToCheck);
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

                            intPropertyToCheck = await CheckIntProperty(change, intPropertyToCheck);

                            var changeResponse = new ChangeResponse
                            {
                                Choice = intPropertyToCheck.Choice
                            };

                            if (intPropertyToCheck.ResearchedValue != aditionalPoints.TeamGame)
                            {
                                aditionalPoints.TeamGame = intPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = NumberNoticeResponse(change, null);
                            }

                            return changeResponse;
                        }

                    case nameof(aditionalPoints.ImportantInformation):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = aditionalPoints.ImportantInformation
                            };

                            intPropertyToCheck = await CheckIntProperty(change, intPropertyToCheck);

                            var changeResponse = new ChangeResponse
                            {
                                Choice = intPropertyToCheck.Choice
                            };

                            if (intPropertyToCheck.ResearchedValue != aditionalPoints.ImportantInformation)
                            {
                                aditionalPoints.ImportantInformation = intPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = NumberNoticeResponse(change, null);
                            }

                            return changeResponse;
                        }

                    case nameof(aditionalPoints.SlainMonsters):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = aditionalPoints.SlainMonsters
                            };

                            intPropertyToCheck = await CheckIntProperty(change, intPropertyToCheck);

                            var changeResponse = new ChangeResponse
                            {
                                Choice = intPropertyToCheck.Choice
                            };

                            if (intPropertyToCheck.ResearchedValue != aditionalPoints.SlainMonsters)
                            {
                                aditionalPoints.SlainMonsters = intPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = NumberNoticeResponse(change, null);
                            }

                            return changeResponse;
                        }

                    case nameof(aditionalPoints.Morals):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = aditionalPoints.Morals
                            };

                            intPropertyToCheck = await CheckIntProperty(change, intPropertyToCheck);

                            var changeResponse = new ChangeResponse
                            {
                                Choice = intPropertyToCheck.Choice
                            };

                            if (intPropertyToCheck.ResearchedValue != aditionalPoints.Morals)
                            {
                                aditionalPoints.Morals = intPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = NumberNoticeResponse(change, null);
                            }

                            return changeResponse;
                        }

                    case nameof(aditionalPoints.Cover):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = aditionalPoints.Cover
                            };

                            intPropertyToCheck = await CheckIntProperty(change, intPropertyToCheck);

                            var changeResponse = new ChangeResponse
                            {
                                Choice = intPropertyToCheck.Choice
                            };

                            if (intPropertyToCheck.ResearchedValue != aditionalPoints.Cover)
                            {
                                aditionalPoints.Cover = intPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = NumberNoticeResponse(change, null);
                            }

                            return changeResponse;
                        }

                    case nameof(aditionalPoints.TemporaryPoints):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = aditionalPoints.TemporaryPoints
                            };

                            intPropertyToCheck = await CheckIntProperty(change, intPropertyToCheck);

                            var changeResponse = new ChangeResponse
                            {
                                Choice = intPropertyToCheck.Choice
                            };

                            if (intPropertyToCheck.ResearchedValue != aditionalPoints.TemporaryPoints)
                            {
                                aditionalPoints.TemporaryPoints = intPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = NumberNoticeResponse(change, null);
                            }

                            return changeResponse;
                        }
                }
            }

            if (change.ClassName == nameof(Armor))
            {
                Hero hero = GetHero(user, change) ?? throw new InvalidOperationException("Hero is null");
                var changeResponse = new ChangeResponse();

                if (change.ActionType == ActionType.Check)
                {
                    if (change.TrueOrFalse == true)
                    {
                        if (hero.Equipments.Armor.ArmorType.ToString() == change.AdditionalInfo)
                        {
                            changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return changeResponse;
                        }

                        //TO DO with ComparisonMark

                        return changeResponse;
                    }

                    var IsArmorExist = hero.Equipments.Armor.IsExist;

                    if (IsArmorExist == change.ActiveOrNot)
                    {
                        changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                        return changeResponse;
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
                        changeResponse.ChangeNotice = AddObjNoticeResponse(change.HeroClass.ToString(), change.ClassName);

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
                    changeResponse.ChangeNotice = RemoveObjNoticeResponse(change.HeroClass.ToString(), change.ClassName);

                    //TO DO The old armor must be deleted
                }
                else if (change.ActionType == ActionType.Update)
                {
                    hero.Equipments.Armor.Defence += change.Defence;
                    changeResponse.ChangeNotice = UpdateObjNoticeResponse(change.HeroClass.ToString(), change.ClassName);
                }

                return changeResponse;
            }

            if (change.ClassName == nameof(Baggage))
            {
                var changeResponse = new ChangeResponse();

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
                                changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                return changeResponse;
                            }
                        }

                        return changeResponse;
                    }

                    Hero hero = GetHero(user, change) ?? throw new InvalidOperationException("Hero is null");

                    Baggage heroBaggage = (Baggage)hero.Baggages.FirstOrDefault(b => b.Name == wantedItem);

                    if (heroBaggage != null)
                    {
                        changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                        return changeResponse;
                    }

                    return changeResponse;
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
                        changeResponse.ChangeNotice = AddObjNoticeResponse(change.HeroClass.ToString(), change.ClassName);
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
                                h.Baggages.Remove(baggage);
                                changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                                changeResponse.ChangeNotice = RemoveObjNoticeResponse(change.HeroClass.ToString(), change.ClassName);
                            }
                        }
                    }
                    else if (change.OrderOfBattle <= OrderOfBattle.Fifth && change.OrderOfBattle >= OrderOfBattle.First)
                    {
                        var hero = user.GroupWest.Heroes.FirstOrDefault(x => x.OrderOfBattle == change.OrderOfBattle);

                        Baggage baggage = (Baggage)hero.Baggages.FirstOrDefault(b => b.Name == wantedItem);

                        if (baggage != null)
                        {
                            hero.Baggages.Remove(baggage);
                            changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            changeResponse.ChangeNotice = UpdateObjNoticeResponse(change.HeroClass.ToString(), change.ClassName);
                        }
                    }

                    return changeResponse;
                }
            }

            if (change.ClassName == nameof(BattleGroup))
            {
                var changeResponse = new ChangeResponse();

                if (change.ActionType == ActionType.Check)
                {
                    var wantedGroup = change.Name;
                    var countPeople = change.Attack;

                    List<BattleGroup> battleGroups = (List<BattleGroup>)user.GroupWest.AditionalPoints.BattleGroups;

                    foreach (var group in battleGroups)
                    {
                        if (group.CountPeople > countPeople)
                        {
                            changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
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
                    changeResponse.ChangeNotice = AddObjNoticeResponse(change.HeroClass.ToString(), change.ClassName);
                }
                else if (change.ActionType == ActionType.Remove)
                {
                    var wantedGroup = change.Name;
                    var aditionalPoint = user.GroupWest.AditionalPoints;

                    var groupToDelete = aditionalPoint.BattleGroups.FirstOrDefault(x => x.Name == wantedGroup);

                    if (groupToDelete != null)
                    {
                        aditionalPoint.BattleGroups.Remove(groupToDelete);
                        changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                        changeResponse.ChangeNotice = RemoveObjNoticeResponse(change.HeroClass.ToString(), change.ClassName);
                    }
                }

                return changeResponse;
            }

            if (change.ClassName == nameof(Equipment))
            {
                Hero hero = GetHero(user, change) ?? throw new InvalidOperationException("Hero is null");
                var changeResponse = new ChangeResponse();

                switch (change.PropertyName)
                {
                    case nameof(hero.Equipments.Knife):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Equipments.Knife
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            if (booleanPropertyToCheck.ResearchedValue != hero.Equipments.Knife)
                            {
                                hero.Equipments.Knife = booleanPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = hero.Equipments.Knife == true
                                                                ? AddObjNoticeResponse(hero.HeroClass.ToString(), change.PropertyName)
                                                                : RemoveObjNoticeResponse(hero.HeroClass.ToString(), change.PropertyName);
                            }

                            changeResponse.Choice = booleanPropertyToCheck.Choice;
                            return changeResponse;
                        }

                    case nameof(hero.Equipments.SmokeBall):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Equipments.SmokeBall
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            if (booleanPropertyToCheck.ResearchedValue != hero.Equipments.SmokeBall)
                            {
                                hero.Equipments.SmokeBall = booleanPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = hero.Equipments.Knife == true
                                                                ? AddObjNoticeResponse(hero.HeroClass.ToString(), change.PropertyName)
                                                                : RemoveObjNoticeResponse(hero.HeroClass.ToString(), change.PropertyName);
                            }

                            changeResponse.Choice = booleanPropertyToCheck.Choice;
                            return changeResponse;
                        }

                    case nameof(hero.Equipments.Poison):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Equipments.Poison
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            if (booleanPropertyToCheck.ResearchedValue != hero.Equipments.Poison)
                            {
                                hero.Equipments.Poison = booleanPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = hero.Equipments.Knife == true
                                                                ? AddObjNoticeResponse(hero.HeroClass.ToString(), change.PropertyName)
                                                                : RemoveObjNoticeResponse(hero.HeroClass.ToString(), change.PropertyName);
                            }

                            changeResponse.Choice = booleanPropertyToCheck.Choice;
                            return changeResponse;
                        }

                    case nameof(hero.Equipments.MedicPack):
                        {
                            var booleanPropertyToCheck = new BooleanPropertyToCheck
                            {
                                ResearchedValue = hero.Equipments.MedicPack
                            };

                            booleanPropertyToCheck = await CheckBooleanProperty(change, booleanPropertyToCheck);

                            if (booleanPropertyToCheck.ResearchedValue != hero.Equipments.MedicPack)
                            {
                                hero.Equipments.MedicPack = booleanPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = hero.Equipments.Knife == true
                                                                ? AddObjNoticeResponse(hero.HeroClass.ToString(), change.PropertyName)
                                                                : RemoveObjNoticeResponse(hero.HeroClass.ToString(), change.PropertyName);
                            }

                            changeResponse.Choice = booleanPropertyToCheck.Choice;
                            return changeResponse;
                        }

                    case nameof(hero.Equipments.MoneyBag):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = hero.Equipments.MoneyBag
                            };

                            intPropertyToCheck = await CheckIntProperty(change, intPropertyToCheck);

                            if (intPropertyToCheck.ResearchedValue != hero.Equipments.MoneyBag)
                            {
                                hero.Equipments.MoneyBag = intPropertyToCheck.ResearchedValue;
                                if (change.Attack > 0)
                                {
                                    changeResponse.ChangeNotice = $"{hero.HeroClass} - added {change.Attack} gold coins";
                                }
                                else
                                {
                                    changeResponse.ChangeNotice = $"{hero.HeroClass} - removed {change.Attack} gold coins";
                                }
                            }

                            changeResponse.Choice = intPropertyToCheck.Choice;
                            return changeResponse;
                        }

                }

                return changeResponse;
            }

            if (change.ClassName == nameof(GroupWest))
            {
                var groupWest = user.GroupWest;

                switch (change.PropertyName)
                {
                    case nameof(groupWest.ActualMission):
                        {
                            var changeResponse = new ChangeResponse();

                            var stringPropertyToCheck = new StringPropertyToCheck
                            {
                                ResearchedValue = groupWest.ActualMission
                            };

                            stringPropertyToCheck = CheckStringProperty(change, stringPropertyToCheck).Result;

                            if (stringPropertyToCheck.ResearchedValue != groupWest.ActualMission)
                            {
                                groupWest.ActualMission = stringPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = $"Group West - the actual mission has been changed to {groupWest.ActualMission}";
                            }

                            return changeResponse;
                        }
                }
            }

            if (change.ClassName == nameof(Hero))
            {
                var changeResponse = new ChangeResponse();

                if (change.OrderOfBattle >= OrderOfBattle.First && change.OrderOfBattle <= OrderOfBattle.Fifth)
                {
                    Hero hero = user.GroupWest.Heroes.FirstOrDefault(x => x.OrderOfBattle == change.OrderOfBattle) ?? throw new InvalidOperationException("Hero is null");

                    if (change.HeroClass == HeroClass.All)
                    {
                        if (hero.HeroType == change.HeroType)
                        {
                            changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                        }
                    }
                    else if (hero.HeroClass == change.HeroClass)
                    {
                        changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                    }
                }
                else if (change.OrderOfBattle == OrderOfBattle.All)
                {
                    List<Hero> heroes = (List<Hero>)user.GroupWest.Heroes;

                    foreach (var h in heroes)
                    {
                        if (h.HeroClass == change.HeroClass)
                        {
                            changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                        }
                    }
                }

                return changeResponse;
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

                            intPropertyToCheck = await CheckIntProperty(change, intPropertyToCheck);

                            var changeResponse = new ChangeResponse
                            {
                                Choice = intPropertyToCheck.Choice
                            };

                            if (intPropertyToCheck.ResearchedValue != hero.Indicators.Health)
                            {
                                hero.Indicators.Health = intPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = NumberNoticeResponse(change, hero);
                            }

                            return changeResponse;
                        }

                    case nameof(hero.Indicators.MentalEnergy):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = hero.Indicators.MentalEnergy
                            };

                            intPropertyToCheck = await CheckIntProperty(change, intPropertyToCheck);

                            var changeResponse = new ChangeResponse
                            {
                                Choice = intPropertyToCheck.Choice
                            };

                            if (intPropertyToCheck.ResearchedValue != hero.Indicators.MentalEnergy)
                            {
                                hero.Indicators.MentalEnergy = intPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = NumberNoticeResponse(change, hero);
                            }

                            return changeResponse;
                        }

                    case nameof(hero.Indicators.MentalStrength):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = hero.Indicators.MentalStrength
                            };

                            intPropertyToCheck = (await CheckIntProperty(change, intPropertyToCheck));

                            var changeResponse = new ChangeResponse
                            {
                                Choice = intPropertyToCheck.Choice
                            };

                            if (intPropertyToCheck.ResearchedValue != hero.Indicators.MentalStrength)
                            {
                                hero.Indicators.MentalStrength = intPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = NumberNoticeResponse(change, hero);
                            }

                            return changeResponse;
                        }

                    case nameof(hero.Indicators.Strength):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = hero.Indicators.Strength
                            };

                            intPropertyToCheck = await CheckIntProperty(change, intPropertyToCheck);

                            var changeResponse = new ChangeResponse
                            {
                                Choice = intPropertyToCheck.Choice
                            };

                            if (intPropertyToCheck.ResearchedValue != hero.Indicators.Strength)
                            {
                                hero.Indicators.Strength = intPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = NumberNoticeResponse(change, hero);
                            }

                            return changeResponse;
                        }

                    case nameof(hero.Indicators.Dexterity):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = hero.Indicators.Dexterity
                            };

                            intPropertyToCheck = await CheckIntProperty(change, intPropertyToCheck);

                            var changeResponse = new ChangeResponse
                            {
                                Choice = intPropertyToCheck.Choice
                            };

                            if (intPropertyToCheck.ResearchedValue != hero.Indicators.Dexterity)
                            {
                                hero.Indicators.Dexterity = intPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = NumberNoticeResponse(change, hero);
                            }

                            return changeResponse;
                        }

                    case nameof(hero.Indicators.Agility):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = hero.Indicators.Agility
                            };

                            intPropertyToCheck = await CheckIntProperty(change, intPropertyToCheck);

                            var changeResponse = new ChangeResponse
                            {
                                Choice = intPropertyToCheck.Choice
                            };

                            if (intPropertyToCheck.ResearchedValue != hero.Indicators.Agility)
                            {
                                hero.Indicators.Agility = intPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = NumberNoticeResponse(change, hero);
                            }

                            return changeResponse;
                        }

                    case nameof(hero.Indicators.Evasion):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = hero.Indicators.Evasion
                            };

                            intPropertyToCheck = await CheckIntProperty(change, intPropertyToCheck);

                            var changeResponse = new ChangeResponse
                            {
                                Choice = intPropertyToCheck.Choice
                            };

                            if (intPropertyToCheck.ResearchedValue != hero.Indicators.Evasion)
                            {
                                hero.Indicators.Evasion = intPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = NumberNoticeResponse(change, hero);
                            }

                            return changeResponse;
                        }

                    case nameof(hero.Indicators.Endurance):
                        {
                            var intPropertyToCheck = new IntPropertyToCheck
                            {
                                ResearchedValue = hero.Indicators.Endurance
                            };

                            intPropertyToCheck = await CheckIntProperty(change, intPropertyToCheck);

                            var changeResponse = new ChangeResponse
                            {
                                Choice = intPropertyToCheck.Choice
                            };

                            if (intPropertyToCheck.ResearchedValue != hero.Indicators.Endurance)
                            {
                                hero.Indicators.Endurance = intPropertyToCheck.ResearchedValue;
                                changeResponse.ChangeNotice = NumberNoticeResponse(change, hero);
                            }

                            return changeResponse;
                        }
                }
            }

            if (change.ClassName == nameof(Mission))
            {
                List<Mission> missions = (List<Mission>)user.GroupWest.Missions;
                var changeResponse = new ChangeResponse();

                if (change.ActionType == ActionType.Check)
                {
                    var mission = missions.Where(x => x.Name == change.Name).FirstOrDefault();

                    if (change.TrueOrFalse == true)
                    {
                        if (mission != null && mission.IsItDone == change.ActiveOrNot)
                        {
                            changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                        }
                    }
                    else
                    {
                        if (mission != null)
                        {
                            changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                        }
                    }
                }
                else if (change.ActionType == ActionType.Add)
                {
                    var mission = new Mission
                    {
                        Name = change.Name,
                        GroupWestId = user.GroupWestId,
                    };

                    missions.Add(mission);
                    changeResponse.ChangeNotice = AddObjNoticeResponse("", change.ClassName);
                }
                else if (change.ActionType == ActionType.Remove)
                {
                    var mission = missions.Where(x => x.Name == change.Name).FirstOrDefault();

                    if (mission != null)
                    {
                        missions.Remove(mission);
                        changeResponse.ChangeNotice = RemoveObjNoticeResponse("", change.ClassName);
                    }
                }
                else if (change.ActionType == ActionType.Update)
                {
                    var mission = missions.Where(x => x.Name == change.Name).FirstOrDefault();

                    if (mission != null)
                    {
                        mission.IsItDone = true;
                        changeResponse.ChangeNotice = UpdateObjNoticeResponse("", change.ClassName);
                    }
                }

                return changeResponse;
            }

            if (change.ClassName == nameof(NatureSkill))
            {
                Hero hero = GetHero(user, change) ?? throw new InvalidOperationException("Hero is null");
                var changeResponse = new ChangeResponse();

                if (change.ActionType == ActionType.Check)
                {
                    var natureSkill = hero.SpecialAbility.NatureSkills.Where(x => x.Name == change.Name).FirstOrDefault();

                    if (natureSkill != null && natureSkill.SkillLevel >= change.Attack)
                    {
                        changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                    }
                }
                else if (change.ActionType == ActionType.Add)
                {
                    var natureSkill = new NatureSkill
                    {
                        Name = change.Name,
                        SkillLevel = change.Attack,
                        RequiredMentalEnergy = change.Defence,
                        SpecialAbilityId = hero.SpecialAbilityId
                    };

                    hero.SpecialAbility.NatureSkills.Add(natureSkill);
                    changeResponse.ChangeNotice = AddObjNoticeResponse(hero.HeroClass.ToString(), change.ClassName);
                }
                else if (change.ActionType == ActionType.Remove)
                {
                    var natureSkill = hero.SpecialAbility.NatureSkills.Where(x => x.Name == change.Name).FirstOrDefault();

                    if (natureSkill != null)
                    {
                        hero.SpecialAbility.NatureSkills.Remove(natureSkill);
                        changeResponse.ChangeNotice = RemoveObjNoticeResponse(hero.HeroClass.ToString(), change.ClassName);
                    }
                }
                else if (change.ActionType == ActionType.Update)
                {
                    var natureSkill = hero.SpecialAbility.NatureSkills.Where(x => x.Name == change.Name).FirstOrDefault();

                    if (natureSkill != null)
                    {
                        natureSkill.SkillLevel++;
                        changeResponse.ChangeNotice = UpdateObjNoticeResponse(hero.HeroClass.ToString(), change.ClassName);
                    }
                }

                return changeResponse;
            }

            if (change.ClassName == nameof(Negotiation))
            {
                var changeResponse = new ChangeResponse();

                if (change.ActionType == ActionType.Check)
                {
                    var negotiation = user.GroupWest.AditionalPoints.Negotiations.Where(x => x.Name == change.Name).FirstOrDefault();

                    if (negotiation != null)
                    {
                        changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                    }
                }
                else if (change.ActionType == ActionType.Add)
                {
                    var newNegotiation = new Negotiation
                    {
                        Name = change.Name,
                        AditionalPointsId = user.GroupWest.AditionalPointsId
                    };

                    user.GroupWest.AditionalPoints.Negotiations.Add(newNegotiation);
                    changeResponse.ChangeNotice = AddObjNoticeResponse("", change.ClassName);
                }

                return changeResponse;
            }

            if (change.ClassName == nameof(Promise))
            {
                Hero hero = GetHero(user, change) ?? throw new InvalidOperationException("Hero is null");
                var changeResponse = new ChangeResponse();

                if (change.ActionType == ActionType.Check)
                {
                    var promise = hero.Promises.FirstOrDefault(x => x.Name == change.Name);

                    if (promise != null)
                    {
                        if (change.ActiveOrNot == true)
                        {
                            changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                            return changeResponse;
                        }

                        if (promise.IsItDone == change.TrueOrFalse)
                        {
                            changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                        }
                        else
                        {
                            changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                        }
                    }
                }
                else if (change.ActionType == ActionType.Add)
                {
                    var newPromise = new Promise
                    {
                        Name = change.Name,
                        HeroId = hero.Id
                    };

                    hero.Promises.Add(newPromise);
                    changeResponse.ChangeNotice = AddObjNoticeResponse(hero.HeroClass.ToString(), change.ClassName);
                }
                else if (change.ActionType == ActionType.Remove)
                {
                    var promise = hero.Promises.FirstOrDefault(x => x.Name == change.Name);

                    if (promise != null)
                    {
                        hero.Promises.Remove(promise);
                        changeResponse.ChangeNotice = RemoveObjNoticeResponse(hero.HeroClass.ToString(), change.ClassName);
                    }
                }
                else if (change.ActionType == ActionType.Update)
                {
                    var promise = hero.Promises.FirstOrDefault(x => x.Name == change.Name);

                    if (promise != null)
                    {
                        promise.IsItDone = true;
                        changeResponse.ChangeNotice = UpdateObjNoticeResponse(hero.HeroClass.ToString(), change.ClassName);
                    }
                }

                return changeResponse;
            }

            if (change.ClassName == nameof(Ritual))
            {
                Hero hero = GetHero(user, change) ?? throw new InvalidOperationException("Hero is null");
                var changeResponse = new ChangeResponse();

                if (change.ActionType == ActionType.Check)
                {
                    var ritual = hero.SpecialAbility.Rituals.Where(x => x.Name == change.Name).FirstOrDefault();

                    if (ritual != null && ritual.SkillLevel >= change.Attack)
                    {
                        changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                    }
                }
                else if (change.ActionType == ActionType.Add)
                {
                    var ritual = new Ritual
                    {
                        Name = change.Name,
                        SkillLevel = change.Attack,
                        RequiredMentalEnergy = change.Defence,
                        SpecialAbilityId = hero.SpecialAbilityId
                    };

                    hero.SpecialAbility.Rituals.Add(ritual);
                    changeResponse.ChangeNotice = AddObjNoticeResponse(hero.HeroClass.ToString(), change.ClassName);
                }
                else if (change.ActionType == ActionType.Remove)
                {
                    var ritual = hero.SpecialAbility.Rituals.Where(x => x.Name == change.Name).FirstOrDefault();

                    if (ritual != null)
                    {
                        hero.SpecialAbility.Rituals.Remove(ritual);
                        changeResponse.ChangeNotice = RemoveObjNoticeResponse(hero.HeroClass.ToString(), change.ClassName);
                    }
                }
                else if (change.ActionType == ActionType.Update)
                {
                    var ritual = hero.SpecialAbility.Rituals.Where(x => x.Name == change.Name).FirstOrDefault();

                    if (ritual != null)
                    {
                        ritual.SkillLevel++;
                        changeResponse.ChangeNotice = UpdateObjNoticeResponse(hero.HeroClass.ToString(), change.ClassName);
                    }
                }

                return changeResponse;
            }

            if (change.ClassName == nameof(Spell))
            {
                Hero hero = GetHero(user, change) ?? throw new InvalidOperationException("Hero is null");
                var changeResponse = new ChangeResponse();

                if (change.ActionType == ActionType.Check)
                {
                    var spell = hero.SpecialAbility.Spells.Where(x => x.Name == change.Name).FirstOrDefault();

                    if (spell != null && spell.SkillLevel >= change.Attack)
                    {
                        changeResponse.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                    }
                }
                else if (change.ActionType == ActionType.Add)
                {
                    var spell = new Spell
                    {
                        Name = change.Name,
                        SkillLevel = change.Attack,
                        RequiredMentalEnergy = change.Defence,
                        SpecialAbilityId = hero.SpecialAbilityId
                    };

                    hero.SpecialAbility.Spells.Add(spell);
                    changeResponse.ChangeNotice = AddObjNoticeResponse(hero.HeroClass.ToString(), change.ClassName);
                }
                else if (change.ActionType == ActionType.Remove)
                {
                    var spell = hero.SpecialAbility.Spells.Where(x => x.Name == change.Name).FirstOrDefault();

                    if (spell != null)
                    {
                        hero.SpecialAbility.Spells.Remove(spell);
                        changeResponse.ChangeNotice = RemoveObjNoticeResponse(hero.HeroClass.ToString(), change.ClassName);
                    }
                }
                else if (change.ActionType == ActionType.Update)
                {
                    var spell = hero.SpecialAbility.Spells.Where(x => x.Name == change.Name).FirstOrDefault();

                    if (spell != null)
                    {
                        spell.SkillLevel++;
                        changeResponse.ChangeNotice = UpdateObjNoticeResponse(hero.HeroClass.ToString(), change.ClassName);
                    }
                }

                return changeResponse;
            }

            return null;
        }

        public async Task<Page> GetCurrentLocation()
        {
            var currentUserEmail = userRepository.GetUserEmail();

            var currentUser = await dbContext.Users.Where(x => x.CurrentUserEmail == currentUserEmail)
                .Include(x => x.Location).FirstOrDefaultAsync() ?? throw new Exception("This user not exist!");

            var location = currentUser.Location;

            var page = await dbContext.Pages.AsNoTracking().FirstOrDefaultAsync(x => x.Id == location.PageId)
                ?? throw new Exception("This page not exist!");

            if (location.PageId == "redmagtowlib001")
            {
                var mandatoryChoices = await dbContext.Choices.Where(x => x.AdditionalCheck == false)
                    .Where(x => x.PageId == location.PageId).ToListAsync();

                page.Choices = mandatoryChoices;
            }
            else
            {
                page.ChangeNotices = location.ChangeNotice;
                var choices = location.ChoicesId.Split(',', StringSplitOptions.RemoveEmptyEntries);
                List<Choice> choicesToAdd = new();
                var images = location.ImagesId.Split(',', StringSplitOptions.RemoveEmptyEntries);
                List<Image> imagesToAdd = new();

                for (int i = 0; i < choices.Length; i++)
                {
                    var choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id.ToString() == choices[i]);

                    if (choice != null)
                    {
                        choicesToAdd.Add(choice);
                    }
                }

                for (int i = 0; i < images.Length; i++)
                {
                    var image = await dbContext.Images.FirstOrDefaultAsync(x => x.Id.ToString() == images[i]);

                    if (image != null)
                    {
                        imagesToAdd.Add(image);
                    }
                }

                page.Choices = new List<Choice>(choicesToAdd);
                page.Images = new List<Image>(imagesToAdd);
            }

            return page;
        }

        public async Task<Location> SaveCurrentLocation(Page page, Guid locationId)
        {
            var location = await dbContext.Locations.FirstOrDefaultAsync(x => x.Id == locationId)
                ?? throw new Exception("This page not exist!");

            location.PageId = page.Id;
            location.ChangeNotice = page.ChangeNotices;
            location.ChoicesId = string.Join(",", page.Choices.Select(x => x.Id));
            location.ImagesId = string.Join(",", page.Images.Select(x => x.Id));

            return location;
        }

        private static string NumberNoticeResponse(Change change, Hero? hero)
        {
            if (hero == null)
            {
                return $"GroupWest - {change.PropertyName} is changed by {change.Attack}";
            }
            else
            {
                return $"{hero.HeroClass} - {change.PropertyName} is changed by {change.Attack}!";
            }
        }

        private static string AddObjNoticeResponse(string heroClass, string className)
        {
            if (heroClass.IsNullOrEmpty())
            {
                return $"Group West - Added new {className}!";
            }
            else
            {
                return $"{heroClass} - Added new {className}!";
            }
        }

        private static string RemoveObjNoticeResponse(string heroClass, string className)
        {
            if (heroClass.IsNullOrEmpty())
            {
                return $"Group West - {className} was removed!!";
            }
            else
            {
                return $"{heroClass} - {className} was removed!";
            }
        }

        private static string UpdateObjNoticeResponse(string heroClass, string className)
        {
            if (heroClass.IsNullOrEmpty())
            {
                return $"Group West - {className} was updated!";
            }
            else
            {
                return $"{heroClass} - {className} was updated!";
            }
        }

        private static ChangeResponse AbilityResponse(Change change, Hero hero, bool isHeroAbilityExist, BooleanPropertyToCheck booleanPropertyToCheck)
        {
            var changeResponse = new ChangeResponse
            {
                Choice = booleanPropertyToCheck.Choice
            };

            if (booleanPropertyToCheck.ResearchedValue != isHeroAbilityExist)
            {
                changeResponse.ChangeNotice = isHeroAbilityExist 
                    ? $"{hero.HeroClass} - You gain a {change.PropertyName} ability!"
                    : $"{hero.HeroClass} - {change.PropertyName} ability is dropped!";
            }

            return changeResponse;
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
            var requiredValue = change.TrueOrFalse;
            var booleanPropertyToCheckResult = new BooleanPropertyToCheck();

            if (change.ActionType == ActionType.Check)
            {
                if (booleanPropertyToCheck.ResearchedValue == requiredValue)
                {
                    booleanPropertyToCheckResult.Choice = await dbContext.Choices.FirstOrDefaultAsync(x => x.Id == change.ChoiceId);
                }

                booleanPropertyToCheckResult.ResearchedValue = booleanPropertyToCheck.ResearchedValue;
                return booleanPropertyToCheckResult;
            }
            else if (change.ActionType == ActionType.Add)
            {
                booleanPropertyToCheckResult.ResearchedValue = true;
                return booleanPropertyToCheckResult;
            }
            else if (change.ActionType == ActionType.Remove)
            {
                booleanPropertyToCheckResult.ResearchedValue = false;
                return booleanPropertyToCheckResult;
            }

            return null;
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
