using AutoMapper;
using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Infrastructure;
using redimel_server.Models.Domain;
using redimel_server.Models.Enums;
using redimel_server.Utils;
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
            var locationId = Guid.NewGuid();

            var newUser = new User
            {
                Id = newUserId,
                CurrentUserEmail = heroEmail,
                GroupWestId = groupWestId,
                LocationId = locationId,
                Location = new Location
                {
                    Id = locationId,
                    UserId = newUserId
                },
                GroupWest = new GroupWest
                {
                    Id = groupWestId,
                    UserId = newUserId,
                    AditionalPointsId = aditionalPointsId,
                    ActualMission = "",
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

            heroesList = GetOrderOfBattle(heroesList);
            newUser.GroupWest.Heroes = heroesList;

            await dbContext.Users.AddAsync(newUser);
            await dbContext.SaveChangesAsync();

            return newUser;
        }

        public async Task<string?> RemoveBattleGroup(string heroEmail)
        {
            var currentUser = await dbContext.Users.Where(x => x.CurrentUserEmail == heroEmail).FirstOrDefaultAsync();

            if (currentUser == null)
            {
                return null;
            }

            var newEmail = "OLD" + currentUser.CurrentUserEmail;
            currentUser.CurrentUserEmail = newEmail;

            await dbContext.SaveChangesAsync();

            return "You have successfully removed the battle group";
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
            var existingUser = await dbContext.Users.Include(x => x.Location).FirstOrDefaultAsync(i => i.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.Checkpoint = user.Checkpoint;
            existingUser.Location.PageId = user.Location.PageId;
            //existingUser.CurrentLocation = user.CurrentLocation;
            existingUser.CurrentUserEmail = user.CurrentUserEmail;
            existingUser.GroupWestId = user.GroupWestId;
            existingUser.LocationId = user.LocationId;
            existingUser.TimeCounter = user.TimeCounter;

            await dbContext.SaveChangesAsync();

            return existingUser;
        }

        private Hero CreateHero(string heroClass, Guid groupWestId)
        {
            //CHECK PROPERTIES!!!
            if (heroClass == RedimelConstants.CREATESOLDIER)
            {   
                var newHero = new SoldierHeroCreator();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEHUNTER)
            {
                var newHero = new HunterHeroCreator();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEMERCENARY)
            {
                var newHero = new MercenaryHeroCreator();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEGLADIATOR)
            {
                var newHero = new GladiatorHeroCreator();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEPIRATE)
            {
                var newHero = new PirateHeroCreator();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEMONSTERSLAYER)
            {
                var newHero = new MonsterSlayerHeroCreator();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEACROBAT)
            {
                var newHero = new AcrobatHeroCreator();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEMERCHANT)
            {
                var newHero = new MerchantHeroCreator();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATETHIEF)
            {
                var newHero = new ThiefHeroCreator();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEMISSIONARY)
            {
                var newHero = new MissionaryHeroCreator();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEMAGICIAN)
            {
                var newHero = new MagicianHeroCreator();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATELIBRARIAN)
            {
                var newHero = new LibrarianHeroCreator();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEKNIGHT)
            {
                var newHero = new KnightHeroCreator();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATESAVAGE)
            {
                var newHero = new SavageHeroCreator();
                var heroCreator = mapper.Map<HeroCreator>(newHero);

                return CreateSingleHero(groupWestId, heroCreator);
            }

            if (heroClass == RedimelConstants.CREATEROBBER)
            {
                var newHero = new RobberHeroCreator();
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

        private static List<Hero> GetOrderOfBattle(List<Hero> heroesList)
        {
            var helper = heroesList.FirstOrDefault(x => x.HeroType == HeroType.Helper);
            var mystic = heroesList.FirstOrDefault(x => x.HeroType == HeroType.Mystic);
            var warrior = heroesList.FirstOrDefault(x => x.HeroType == HeroType.Warrior);
            var fighter = heroesList.FirstOrDefault(x => x.HeroType == HeroType.Fighter);
            var defender = heroesList.FirstOrDefault(x => x.HeroType == HeroType.Defender);

            if (helper == null || mystic == null || warrior == null || fighter == null || defender == null)
            {
                throw new Exception("Hero is null!");
            }

            if (helper.HeroClass == HeroClass.Acrobat)
            {
                if (mystic.HeroClass == HeroClass.Missionary)
                {
                    return GetTheSortedHeroes(defender, warrior, fighter, mystic, helper);
                }
                else if (mystic.HeroClass == HeroClass.Magician)
                {
                    return GetTheSortedHeroes(warrior, defender, mystic, helper, fighter);
                }
                else if (mystic.HeroClass == HeroClass.Librarian)
                {
                    return GetTheSortedHeroes(fighter, warrior, helper, mystic, defender);
                }
            }
            else if (helper.HeroClass == HeroClass.Merchant)
            {
                if (mystic.HeroClass == HeroClass.Magician)
                {
                    return GetTheSortedHeroes(defender, mystic, helper, fighter, warrior);
                }
                else if (mystic.HeroClass == HeroClass.Missionary)
                {
                    return GetTheSortedHeroes(fighter, defender, warrior, helper, mystic);
                }
                else if (mystic.HeroClass == HeroClass.Librarian)
                {
                    return GetTheSortedHeroes(warrior, mystic, helper, defender, fighter);
                }
            }
            else if (helper.HeroClass == HeroClass.Thief)
            {
                if (mystic.HeroClass == HeroClass.Magician)
                {
                    return GetTheSortedHeroes(defender, mystic, helper, warrior, fighter);
                }
                else if (mystic.HeroClass == HeroClass.Missionary)
                {
                    return GetTheSortedHeroes(warrior, mystic, fighter, helper, defender);
                }
                else if (mystic.HeroClass == HeroClass.Librarian)
                {
                    return GetTheSortedHeroes(warrior, fighter, defender, helper, mystic);
                }
            }

            return null;
        }

        private static List<Hero> GetTheSortedHeroes(Hero first, Hero second, Hero third, Hero fourth, Hero fifth)
        {
            first.OrderOfBattle = OrderOfBattle.First;
            second.OrderOfBattle = OrderOfBattle.Second;
            third.OrderOfBattle = OrderOfBattle.Third;
            fourth.OrderOfBattle = OrderOfBattle.Fourth;
            fifth.OrderOfBattle = OrderOfBattle.Fifth;
            
            var heroListResponse = new List<Hero>
            {
                first,
                second,
                third,
                fourth,
                fifth
            };

            return heroListResponse;
        }
    }
}
