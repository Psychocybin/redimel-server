using AutoMapper;
using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;
using redimel_server.Models.Enums;
using redimel_server.Utils;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace redimel_server.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly ClaimsPrincipal user;
        private readonly RedimelServerDbContext dbContext;
        private readonly IMapper mapper;

        public SQLUserRepository(RedimelServerDbContext dbContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            this.user = httpContextAccessor.HttpContext?.User;
            this.dbContext = dbContext;
            this.mapper = mapper;
            //var userMail = httpContextAccessor.HttpContext?.User.Claims.Single(a => a.Type == ClaimTypes.Email).Value;
        }

        public async Task<User> CreateUserAsync(string heroEmail, GroupWestHeroes groupWestHeroes)
        {
            var currentsImeils = await dbContext.Users.Select(x => x.CurrentUserEmail).ToListAsync();

            foreach (var email in currentsImeils)
            {
                if (email == heroEmail)
                {
                    throw new Exception("This user already have battle group");
                }
            }

            var newUserId = Guid.NewGuid();
            var groupWestId = Guid.NewGuid();
            var aditionalPointsId = Guid.NewGuid();

            var newUser = new User
            {
                Id = newUserId,
                CurrentUserEmail = heroEmail,
                GroupWestId = groupWestId,
                GroupWest = new GroupWest
                {
                    Id = groupWestId,
                    UserId = newUserId,
                    ActualMission = string.Empty,
                    AditionalPointsId = aditionalPointsId,
                    AditionalPoints = new AditionalPoint
                    {
                        Id = aditionalPointsId,
                        GroupWestId = groupWestId
                    },
                },
            };

            var heroesList = new List<Hero>
            {
                CreateHero(groupWestHeroes.Warrior, groupWestId),
                CreateHero(groupWestHeroes.Fighter, groupWestId),
                CreateHero(groupWestHeroes.Defender, groupWestId),
                CreateHero(groupWestHeroes.Helper, groupWestId),
                CreateHero(groupWestHeroes.Mystic, groupWestId)
            };

            //heroesList = GetOrderOfBattle(heroesList);
            newUser.GroupWest.Heroes = heroesList;

            await dbContext.Users.AddAsync(newUser);
            await dbContext.SaveChangesAsync();

            return newUser;
        }

        public async Task<User?> DeleteAsync(Guid id)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            dbContext.Users.Remove(existingUser);
            await dbContext.SaveChangesAsync();

            return existingUser;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();

        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        }

        public string GetUserEmail()
        {
            var currentUserEmail = this.user?.FindFirstValue(ClaimTypes.Email);
            return currentUserEmail;
        }

        public async Task<User?> UpdateAsync(Guid id, User user)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(i => i.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.Checkpoint = user.Checkpoint;
            existingUser.CurrentLocation = user.CurrentLocation;
            existingUser.CurrentUserEmail = user.CurrentUserEmail;
            existingUser.GroupWestId = user.GroupWestId;
            existingUser.TimeCounter = user.TimeCounter;

            await dbContext.SaveChangesAsync();

            return existingUser;
        }

        private Hero CreateHero(string heroClass, Guid groupWestId)
        {
            if (heroClass == RedimelConstants.CREATESOLDIER)
            {
                var newHero = new SoldierHero();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEHUNTER)
            {
                var newHero = new HunterHero();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEMERCENARY)
            {
                var newHero = new MercenaryHero();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEGLADIATOR)
            {
                var newHero = new GladiatorHero();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEPIRATE)
            {
                var newHero = new PirateHero();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEMONSTERSLAYER)
            {
                var newHero = new MonsterSlayerHero();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEACROBAT)
            {
                var newHero = new AcrobatHero();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEMERCHANT)
            {
                var newHero = new MerchantHero();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATETHIEF)
            {
                var newHero = new ThiefHero();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEMISSIONARY)
            {
                var newHero = new MissionaryHero();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEMAGICIAN)
            {
                var newHero = new MagicianHero();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATELIBRARIAN)
            {
                var newHero = new LibrarianHero();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEKNIGHT)
            {
                var newHero = new KnightHero();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATESAVAGE)
            {
                var newHero = new SavageHero();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEROBBER)
            {
                var newHero = new RobberHero();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            return null;
        }

        private static Hero CreateSingleHero(Guid groupWestId, HeroCreator heroCreator)
        {
            var heroId = Guid.NewGuid();
            var indicatorsId = Guid.NewGuid();
            var equipmentsId = Guid.NewGuid();
            var abilityId = Guid.NewGuid();
            var specialAbilityId = Guid.NewGuid();
            var specialCombatSkillId = Guid.NewGuid();
            var ultimateId = Guid.NewGuid();
            var armorId = Guid.NewGuid();
            var shieldId = Guid.NewGuid();
            var weaponId = Guid.NewGuid();
            var throwingWeaponId = Guid.NewGuid();

            var newHero = new Hero
            {
                Id = heroId,
                Name = heroCreator.Name,
                HeroClass = heroCreator.HeroClass,
                HeroType = heroCreator.HeroType,
                BaggageCapacity = heroCreator.BaggageCapacity,
                GroupWestId = groupWestId,
                IndicatorsId = indicatorsId,
                EquipmentsId = equipmentsId,
                AbilityId = abilityId,
                SpecialAbilityId = specialAbilityId,
                Indicators = new Indicator
                {
                    Id = indicatorsId,
                    Health = heroCreator.Health,
                    MentalEnergy = heroCreator.MentalEnergy,
                    MentalStrength = heroCreator.MentalStrength,
                    Strength = heroCreator.Strength,
                    Dexterity = heroCreator.Dexterity,
                    Agility = heroCreator.Agility,
                    Evasion = heroCreator.Evasion,
                    Endurance = heroCreator.Endurance,
                    HeroId = heroId
                },
                Equipments = new Equipment
                {
                    Id = equipmentsId,
                    Knife = heroCreator.Knife,
                    SmokeBall = heroCreator.SmokeBall,
                    Poison = heroCreator.Poison,
                    MedicPack = heroCreator.MedicPack,
                    MoneyBag = heroCreator.Money,
                    HeroId = heroId,
                    ArmorId = armorId,
                    ShieldId = shieldId,
                    WeaponId = weaponId,
                    ThrowingWeaponId = throwingWeaponId,
                    Armor = new Armor
                    {
                        Id = armorId,
                        ArmorType = heroCreator.ArmorType,
                        IsExist = heroCreator.IsArmorExist,
                        Defence = heroCreator.ArmorDefence,
                        EquipmentId = equipmentsId
                    },
                    Shield = new Shield
                    {
                        Id = shieldId,
                        ShieldType = heroCreator.ShieldType,
                        IsExist = heroCreator.IsShieldExist,
                        Defence = heroCreator.ShieldDefence,
                        EquipmentId = equipmentsId
                    },
                    Weapon = new Weapon
                    {
                        Id = weaponId,
                        WeaponType = heroCreator.WeaponType,
                        IsExist = heroCreator.IsWeaponExist,
                        IsItTwoHandWeapon = heroCreator.IsWeaponTwoHand,
                        Attack = heroCreator.WeaponAttack,
                        Defence = heroCreator.WeaponDefence,
                        Damage = heroCreator.WeaponDamage,
                        WeaponRange = heroCreator.WeaponRange,
                        EquipmentId = equipmentsId
                    },
                    ThrowingWeapon = new ThrowingWeapon
                    {
                        Id = throwingWeaponId,
                        ThrowingWeaponType = heroCreator.ThrowingWeaponType,
                        IsExist = heroCreator.IsThrowingWeaponExist,
                        Attack = heroCreator.ThrowingWeaponAttack,
                        Defence = heroCreator.ThrowingWeaponDefence,
                        Damage = heroCreator.ThrowingWeaponDamage,
                        Quantity = heroCreator.ThrowingWeaponQuantity,
                        ThrowingWeaponRange = heroCreator.ThrowingWeaponRange,
                        EquipmentId = equipmentsId
                    },
                },
                Ability = new Ability
                {
                    Id = abilityId,
                    Survival = heroCreator.Survival,
                    Diplomacy = heroCreator.Diplomacy,
                    Climbing = heroCreator.Climbing,
                    Acrobatics = heroCreator.Acrobatics,
                    Skill = heroCreator.Skill,
                    Guile = heroCreator.Guile,
                    SecretKnowledge = heroCreator.SecretKnowledge,
                    Sneak = heroCreator.Sneak,
                    Elusion = heroCreator.Elusion,
                    WaterCycle = heroCreator.WaterCycle,
                    Melee = heroCreator.Melee,
                    NatureSkills = heroCreator.NatureSkills,
                    BreakingLocks = heroCreator.BreakingLocks,
                    Transformation = heroCreator.Transformation,
                    Spells = heroCreator.Spells,
                    Rituals = heroCreator.Rituals,
                    Traps = heroCreator.Traps,
                    Archery = heroCreator.Archery,
                    ThrowingKnives = heroCreator.ThrowingKnives,
                    PoisonousNeedles = heroCreator.PoisonousNeedles,
                    Stimulants = heroCreator.Stimulants,
                    Wrestling = heroCreator.Wrestling,
                    Observation = heroCreator.Observation,
                    ShieldBearer = heroCreator.ShieldBearer,
                    Leadership = heroCreator.Leadership,
                    KickFight = heroCreator.KickFight,
                    DoubleStrike = heroCreator.DoubleStrike,
                    HeroId = heroId
                },
                SpecialAbility = new SpecialAbility
                {
                    Id = specialAbilityId,
                    HeroId = heroId,
                    SpecialCombatSkillId = specialCombatSkillId,
                    UltimateId = ultimateId,
                    SpecialCombatSkill = new SpecialCombatSkill
                    {
                        Id = specialCombatSkillId,
                        Name = heroCreator.SCSName,
                        SkillLevel = heroCreator.SCSLevel,
                        RequiredMentalEnergy = heroCreator.SCSEnergy,
                        SpecialAbilitiesId = specialAbilityId
                    },
                    Ultimate = new Ultimate
                    {
                        Id = ultimateId,
                        Name = heroCreator.UltimateName,
                        SkillLevel = heroCreator.UltimateLevel,
                        RequiredMentalEnergy = heroCreator.UltimateEnergy,
                        SpecialAbilitiesId = specialAbilityId
                    },
                },
            };

            return newHero;
        }

        //private static List<Hero> GetOrderOfBattle(List<Hero> heroesList)
        //{
        //    var helper = heroesList.FirstOrDefault(x => x.HeroType == "Helper");
        //    var mystic = heroesList.FirstOrDefault(x => x.HeroType == "Mystic");
        //    var warrior = heroesList.FirstOrDefault(x => x.HeroType == "Warrior");
        //    var fighter = heroesList.FirstOrDefault(x => x.HeroType == "Fighter");
        //    var defender = heroesList.FirstOrDefault(x => x.HeroType == "Defender");

        //    if (helper.HeroClass == "Acrobat")
        //    {
        //        //if (mystic.HeroClass == "Magician")
        //        //{
        //        //    AddSkills(helper, mystic, warrior, fighter, defender);
        //        //}
        //        if (mystic.HeroClass == "Missionary")
        //        {
        //            warrior.OrderOfBattle = 2;
        //            fighter.OrderOfBattle = 3;
        //            defender.OrderOfBattle = 1;
        //            helper.OrderOfBattle = 5;
        //            mystic.OrderOfBattle = 4;
        //        }
        //        else if (mystic.HeroClass == "Librarian")
        //        {
        //            warrior.OrderOfBattle = 2;
        //            fighter.OrderOfBattle = 1;
        //            defender.OrderOfBattle = 5;
        //            helper.OrderOfBattle = 3;
        //            mystic.OrderOfBattle = 4;
        //        }
        //    }
        //    else if (helper.HeroClass == "Merchant")
        //    {
        //        if (mystic.HeroClass == "Magician")
        //        {
        //            warrior.OrderOfBattle = 5;
        //            fighter.OrderOfBattle = 4;
        //            defender.OrderOfBattle = 1;
        //            helper.OrderOfBattle = 3;
        //            mystic.OrderOfBattle = 2;
        //        }
        //        else if (mystic.HeroClass == "Missionary")
        //        {
        //            warrior.OrderOfBattle = 3;
        //            fighter.OrderOfBattle = 1;
        //            defender.OrderOfBattle = 2;
        //            helper.OrderOfBattle = 4;
        //            mystic.OrderOfBattle = 5;
        //        }
        //        else if (mystic.HeroClass == "Librarian")
        //        {
        //            warrior.OrderOfBattle = 1;
        //            fighter.OrderOfBattle = 5;
        //            defender.OrderOfBattle = 4;
        //            helper.OrderOfBattle = 3;
        //            mystic.OrderOfBattle = 2;
        //        }
        //    }
        //    else if (helper.HeroClass == "Thief")
        //    {
        //        if (mystic.HeroClass == "Magician")
        //        {
        //            warrior.OrderOfBattle = 4;
        //            fighter.OrderOfBattle = 5;
        //            defender.OrderOfBattle = 1;
        //            helper.OrderOfBattle = 3;
        //            mystic.OrderOfBattle = 2;
        //        }
        //        else if (mystic.HeroClass == "Missionary")
        //        {
        //            warrior.OrderOfBattle = 1;
        //            fighter.OrderOfBattle = 3;
        //            defender.OrderOfBattle = 5;
        //            helper.OrderOfBattle = 4;
        //            mystic.OrderOfBattle = 2;
        //        }
        //        else if (mystic.HeroClass == "Librarian")
        //        {
        //            warrior.OrderOfBattle = 1;
        //            fighter.OrderOfBattle = 2;
        //            defender.OrderOfBattle = 3;
        //            helper.OrderOfBattle = 5;
        //            mystic.OrderOfBattle = 4;
        //        }
        //    }

        //    var heroListResponse = new List<Hero>
        //    {
        //        warrior,
        //        fighter,
        //        defender,
        //        helper,
        //        mystic
        //    };

        //    return heroListResponse;
        //}

        //private static void AddSkills(int helper, Hero? mystic, Hero? warrior, Hero? fighter, Hero? defender, herolist// )
        //{
        //    warrior.OrderOfBattle = 1;// magic numbers
        //    fighter.OrderOfBattle = 5;
        //    defender.OrderOfBattle = 2;
        //    helper.OrderOfBattle = 4;
        //    mystic.OrderOfBattle = 3;
        //}

        //private void Text()
        //{
        //    var heroId = Guid.NewGuid();
        //    var indicatorsId = Guid.NewGuid();
        //    var equipmentsId = Guid.NewGuid();
        //    var abilityId = Guid.NewGuid();
        //    var specialAbilityId = Guid.NewGuid();
        //    var specialCombatSkillId = Guid.NewGuid();
        //    var ultimateId = Guid.NewGuid();
        //    var armorId = Guid.NewGuid();
        //    var shieldId = Guid.NewGuid();
        //    var weaponId = Guid.NewGuid();
        //    var throwingWeaponId = Guid.NewGuid();

        //    var newHero = new Hero
        //    {
        //        Id = heroId,
        //        Name = heroCreator.NAME,
        //        HeroClass = SavageConstants.HEROCLASS,
        //        HeroType = SavageConstants.HEROTYPE,
        //        BaggageCapacity = SavageConstants.BAGGAGECAPACITY,
        //        GroupWestId = groupWestId,
        //        IndicatorsId = indicatorsId,
        //        EquipmentsId = equipmentsId,
        //        AbilityId = abilityId,
        //        SpecialAbilityId = specialAbilityId,
        //        Indicators = new Indicator
        //        {
        //            Id = indicatorsId,
        //            Health = SavageConstants.HEALTH,
        //            MentalEnergy = SavageConstants.MENTALENERGY,
        //            MentalStrength = SavageConstants.MENTALSTRENGTH,
        //            Strength = SavageConstants.STRENGTH,
        //            Dexterity = SavageConstants.DEXTERITY,
        //            Agility = SavageConstants.AGILITY,
        //            Evasion = SavageConstants.EVASION,
        //            Endurance = SavageConstants.ENDURANCE,
        //            HeroId = heroId
        //        },
        //        Equipments = new Equipment
        //        {
        //            Id = equipmentsId,
        //            Knife = SavageConstants.KNIFE,
        //            SmokeBall = SavageConstants.SMOKEBALL,
        //            Poison = SavageConstants.POISON,
        //            MedicPack = SavageConstants.MEDICPACK,
        //            MoneyBag = SavageConstants.MONEY,
        //            HeroId = heroId,
        //            ArmorId = armorId,
        //            ShieldId = shieldId,
        //            WeaponId = weaponId,
        //            ThrowingWeaponId = throwingWeaponId,
        //            Armor = new Armor
        //            {
        //                Id = armorId,
        //                ArmorType = SavageConstants.ARMORTYPE,
        //                IsExist = SavageConstants.ISARMOREXIST,
        //                Defence = SavageConstants.ARMORDEFENCE,
        //                EquipmentId = equipmentsId
        //            },
        //            Shield = new Shield
        //            {
        //                Id = shieldId,
        //                ShieldType = SavageConstants.SHIELDTYPE,
        //                IsExist = SavageConstants.ISSHIELDEXIST,
        //                Defence = SavageConstants.SHIELDDEFENCE,
        //                EquipmentId = equipmentsId
        //            },
        //            Weapon = new Weapon
        //            {
        //                Id = weaponId,
        //                WeaponType = SavageConstants.WEAPONTYPE,
        //                IsExist = SavageConstants.ISWEAPONEXIST,
        //                IsItTwoHandWeapon = SavageConstants.ISWEAPONTWOHAND,
        //                Attack = SavageConstants.WEAPONATTACK,
        //                Defence = SavageConstants.WEAPONDEFENCE,
        //                Damage = SavageConstants.WEAPONDAMAGE,
        //                WeaponRange = SavageConstants.WEAPONRANGE,
        //                EquipmentId = equipmentsId
        //            },
        //            ThrowingWeapon = new ThrowingWeapon
        //            {
        //                Id = throwingWeaponId,
        //                ThrowingWeaponType = SavageConstants.THROWINGWEAPONTYPE,
        //                IsExist = SavageConstants.ISTHROWINGWEAPONEXIST,
        //                Attack = SavageConstants.THROWINGWEAPONATTACK,
        //                Defence = SavageConstants.THROWINGWEAPONDEFENCE,
        //                Damage = SavageConstants.THROWINGWEAPONDAMAGE,
        //                Quantity = SavageConstants.THROWINGWEAPONQUANTITY,
        //                ThrowingWeaponRange = SavageConstants.THROWINGWEAPONRANGE,
        //                EquipmentId = equipmentsId
        //            },
        //        },
        //        Ability = new Ability
        //        {
        //            Id = abilityId,
        //            PoisonousNeedles = SavageConstants.POISONOUSNEEDLES,
        //            Stimulants = SavageConstants.STIMULANTS,
        //            HeroId = heroId
        //        },
        //        SpecialAbility = new SpecialAbility
        //        {
        //            Id = specialAbilityId,
        //            HeroId = heroId,
        //            SpecialCombatSkillId = specialCombatSkillId,
        //            UltimateId = ultimateId,
        //            SpecialCombatSkill = new SpecialCombatSkill
        //            {
        //                Id = specialCombatSkillId,
        //                Name = SavageConstants.SCSNAME,
        //                SkillLevel = SavageConstants.SCSLEVEL,
        //                RequiredMentalEnergy = SavageConstants.SCSENERGY,
        //                SpecialAbilitiesId = specialAbilityId
        //            },
        //            Ultimate = new Ultimate
        //            {
        //                Id = ultimateId,
        //                Name = SavageConstants.ULTIMATENAME,
        //                SkillLevel = SavageConstants.ULTIMATELEVEL,
        //                RequiredMentalEnergy = SavageConstants.ULTIMATEENERGY,
        //                SpecialAbilitiesId = specialAbilityId
        //            },
        //        },
        //    };

        //    return newHero;
        //}
    }
}
