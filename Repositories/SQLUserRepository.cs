using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Models.Domain;
using System.Security.Claims;

namespace redimel_server.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly ClaimsPrincipal user;
        private readonly RedimelServerDbContext dbContext;

        public SQLUserRepository(RedimelServerDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.user = httpContextAccessor.HttpContext?.User;
            this.dbContext = dbContext;
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
            var redimelId = Guid.NewGuid();
            var groupWestId = Guid.NewGuid();

            var magelandId = Guid.NewGuid();
            var theHorsePeopleId = Guid.NewGuid();
            var dikaniId = Guid.NewGuid();
            var tumpridadamId = Guid.NewGuid();
            var theOldKingdomId = Guid.NewGuid();
            var theHigherOnesId = Guid.NewGuid();
            var theTradeLeagueId = Guid.NewGuid();
            var faegraId = Guid.NewGuid();
            var theEmpireId = Guid.NewGuid();
            var theBigCityId = Guid.NewGuid();
            var stincumId = Guid.NewGuid();
            var thePirateDomainsId = Guid.NewGuid();
            var theIslandersId = Guid.NewGuid();
            var theForestTribesId = Guid.NewGuid();
            var southernNomadsId = Guid.NewGuid();
            var northernNomadsId = Guid.NewGuid();
            var theHuntersId = Guid.NewGuid();
            var outlawTerritoryId = Guid.NewGuid();
            var theWastelandId = Guid.NewGuid();
            var theShadowWorldId = Guid.NewGuid();

            var mageTownId = Guid.NewGuid();
            var mageTradeRoadId = Guid.NewGuid();
            var mageSeaId = Guid.NewGuid();
            var mageHarborId = Guid.NewGuid();
            var mageForestId = Guid.NewGuid();
            var mageFieldsId = Guid.NewGuid();
            var mageTownTheCentralSquareId = Guid.NewGuid();
            var mageTownInnTheOldMagicianId = Guid.NewGuid();
            var mageTownTheLibraryId = Guid.NewGuid();
            var mageTownGuardHillId = Guid.NewGuid();

            var aditionalPointsId = Guid.NewGuid();

            var newUser = new User
            {
                Id = newUserId,
                CurrentLocation = "redmagtowlib001",
                Checkpoint = "redmagtowlib001",
                TimeCounter = 1,
                CurrentUserEmail = heroEmail,
                GroupWestId = groupWestId,
                GroupWest = new GroupWest
                {
                    Id = groupWestId,
                    UserId = newUserId,
                    ActualMission = "",
                    AditionalPointsId = aditionalPointsId,
                    AditionalPoints = new AditionalPoint
                    {
                        Id = aditionalPointsId,
                        TeamGame = 0,
                        ImportantInformation = 0,
                        SlainMonsters = 0,
                        Morals = 0,
                        Cover = 0,
                        GroupWestId = groupWestId,
                        BattleGroups = new List<BattleGroup>(),
                        Negotiations = new List<Negotiation>()
                    },
                    Missions = new List<Mission>(),
                    Heroes = new List<Hero>()
                },
                WorldInfoVariables = new List<WorldInfoVariable>()
            };

            var heroesList = new List<Hero>
            {
                await CreateHero(groupWestHeroes.FirstHero, groupWestId),
                await CreateHero(groupWestHeroes.SecondHero, groupWestId),
                await CreateHero(groupWestHeroes.ThirdHero, groupWestId),
                await CreateHero(groupWestHeroes.FourthHero, groupWestId),
                await CreateHero(groupWestHeroes.FifthHero, groupWestId)
            };

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

        private async Task<Hero> CreateHero(string heroClass, Guid groupWestId)
        {
            //var originalHero = await dbContext.Heroes.Include(x => x.Indicators).Include(x => x.Ability)
            //    .Include(x => x.Equipments).ThenInclude(x => x.Weapon)
            //    .Include(x => x.Equipments).ThenInclude(x => x.Shield)
            //    .Include(x => x.Equipments).ThenInclude(x => x.ThrowingWeapon)
            //    .Include(x => x.Equipments).ThenInclude(x => x.Armor)
            //    .Include(x => x.SpecialAbility).ThenInclude(x => x.SpecialCombatSkill)
            //    .Include(x => x.SpecialAbility).ThenInclude(x => x.Ultimate)
            //    .FirstOrDefaultAsync(x => x.HeroClass == heroClass);

            if (heroClass == "Soldier")
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
                    Name = "Vranko",
                    HeroClass = heroClass,
                    OrderOfBattle = 0,
                    BaggageCapacity = 60.0,
                    GroupWestId = groupWestId,
                    IndicatorsId = indicatorsId,
                    EquipmentsId = equipmentsId,
                    AbilityId = abilityId,
                    SpecialAbilityId = specialAbilityId,
                    Indicators = new Indicator
                    {
                        Id = indicatorsId,
                        Health = 70,
                        MentalEnergy = 20,
                        MentalStrength = 6,
                        Strength = 12,
                        Dexterity = 8,
                        Agility = 3,
                        Evasion = 5,
                        Endurance = 6,
                        HeroId = heroId
                    },
                    Equipments = new Equipment
                    {
                        Id = equipmentsId,
                        Knife = true,
                        SmokeBall = true,
                        Poison = false,
                        MedicPack = true,
                        MoneyBag = 100,
                        HeroId = heroId,
                        ArmorId = armorId,
                        ShieldId = shieldId,
                        WeaponId = weaponId,
                        ThrowingWeaponId = throwingWeaponId,
                        Armor = new Armor
                        {
                            Id = armorId,
                            ArmorType = "FullPlate",
                            IsExist = true,
                            Defence = 11,
                            EquipmentId = equipmentsId
                        },
                        Shield = new Shield
                        {
                            Id = shieldId,
                            ShieldType = "",
                            IsExist = false,
                            Defence = 0,
                            EquipmentId = equipmentsId
                        },
                        Weapon = new Weapon
                        {
                            Id = weaponId,
                            WeaponType = "TwoHandSword",
                            IsExist = true,
                            IsItTwoHandWeapon = true,
                            Attack = 12,
                            Defence = 3,
                            Damage = 15,
                            WeaponRange = 3,
                            EquipmentId = equipmentsId
                        },
                        ThrowingWeapon = new ThrowingWeapon
                        {
                            Id = throwingWeaponId,
                            ThrowingWeaponType = "",
                            IsExist = false,
                            Attack = 0,
                            Defence = 0,
                            Damage = 0,
                            Quantity = 0,
                            ThrowingWeaponRange = 0,
                            EquipmentId = equipmentsId
                        },
                        Talismans = new List<Talisman>()
                    },
                    Ability = new Ability
                    {
                        Id = abilityId,
                        Survival = false,
                        Diplomacy = false,
                        Climbing = false,
                        Acrobatics = false,
                        Skill = false,
                        Guile = false,
                        SecretKnowledge = false,
                        Sneak = false,
                        Elusion = false,
                        WaterCycle = false,
                        Melee = false,
                        NatureSkills = false,
                        BreakingLocks = false,
                        Transformation = false,
                        Spells = false,
                        Rituals = false,
                        Traps = false,
                        Archery = false,
                        ThrowingKnives = false,
                        PoisonousNeedles = false,
                        Stimulants = false,
                        Wrestling = true,
                        Observation = false,
                        ShieldBearer = false,
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
                            Name = "SoldierSCS",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 4,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Ultimate = new Ultimate
                        {
                            Id = ultimateId,
                            Name = "SoldierUltimate",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 5,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Spells = new List<Spell>(),
                        Rituals = new List<Ritual>(),
                        NatureSkills = new List<NatureSkill>()
                    },
                    Baggages = new List<Baggage>(),
                    Promises = new List<Promise>()
                };

                return newHero;
            }

            if (heroClass == "Hunter")
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
                    Name = "TheLittleBear",
                    HeroClass = heroClass,
                    OrderOfBattle = 0,
                    BaggageCapacity = 50.0,
                    GroupWestId = groupWestId,
                    IndicatorsId = indicatorsId,
                    EquipmentsId = equipmentsId,
                    AbilityId = abilityId,
                    SpecialAbilityId = specialAbilityId,
                    Indicators = new Indicator
                    {
                        Id = indicatorsId,
                        Health = 60,
                        MentalEnergy = 24,
                        MentalStrength = 8,
                        Strength = 7,
                        Dexterity = 7,
                        Agility = 3,
                        Evasion = 3,
                        Endurance = 12,
                        HeroId = heroId
                    },
                    Equipments = new Equipment
                    {
                        Id = equipmentsId,
                        Knife = true,
                        SmokeBall = false,
                        Poison = false,
                        MedicPack = true,
                        MoneyBag = 100,
                        HeroId = heroId,
                        ArmorId = armorId,
                        ShieldId = shieldId,
                        WeaponId = weaponId,
                        ThrowingWeaponId = throwingWeaponId,
                        Armor = new Armor
                        {
                            Id = armorId,
                            ArmorType = "WoodArmor",
                            IsExist = true,
                            Defence = 5,
                            EquipmentId = equipmentsId
                        },
                        Shield = new Shield
                        {
                            Id = shieldId,
                            ShieldType = "",
                            IsExist = false,
                            Defence = 0,
                            EquipmentId = equipmentsId
                        },
                        Weapon = new Weapon
                        {
                            Id = weaponId,
                            WeaponType = "Axe",
                            IsExist = true,
                            IsItTwoHandWeapon = false,
                            Attack = 11,
                            Defence = 2,
                            Damage = 10,
                            WeaponRange = 2,
                            EquipmentId = equipmentsId
                        },
                        ThrowingWeapon = new ThrowingWeapon
                        {
                            Id = throwingWeaponId,
                            ThrowingWeaponType = "ShortBow",
                            IsExist = true,
                            Attack = 9,
                            Defence = 1,
                            Damage = 10,
                            Quantity = 20,
                            ThrowingWeaponRange = 4,
                            EquipmentId = equipmentsId
                        },
                        Talismans = new List<Talisman>()
                    },
                    Ability = new Ability
                    {
                        Id = abilityId,
                        Survival = true,
                        Diplomacy = false,
                        Climbing = false,
                        Acrobatics = false,
                        Skill = false,
                        Guile = false,
                        SecretKnowledge = false,
                        Sneak = false,
                        Elusion = false,
                        WaterCycle = false,
                        Melee = false,
                        NatureSkills = false,
                        BreakingLocks = false,
                        Transformation = false,
                        Spells = false,
                        Rituals = false,
                        Traps = false,
                        Archery = true,
                        ThrowingKnives = false,
                        PoisonousNeedles = false,
                        Stimulants = false,
                        Wrestling = false,
                        Observation = false,
                        ShieldBearer = false,
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
                            Name = "HunterSCS",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 0,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Ultimate = new Ultimate
                        {
                            Id = ultimateId,
                            Name = "HunterUltimate",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 8,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Spells = new List<Spell>(),
                        Rituals = new List<Ritual>(),
                        NatureSkills = new List<NatureSkill>()
                    },
                    Baggages = new List<Baggage>(),
                    Promises = new List<Promise>()
                };

                return newHero;
            }

            if (heroClass == "Mercenary")
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
                    Name = "TheLongDeath",
                    HeroClass = heroClass,
                    OrderOfBattle = 0,
                    BaggageCapacity = 50.0,
                    GroupWestId = groupWestId,
                    IndicatorsId = indicatorsId,
                    EquipmentsId = equipmentsId,
                    AbilityId = abilityId,
                    SpecialAbilityId = specialAbilityId,
                    Indicators = new Indicator
                    {
                        Id = indicatorsId,
                        Health = 60,
                        MentalEnergy = 24,
                        MentalStrength = 6,
                        Strength = 10,
                        Dexterity = 10,
                        Agility = 4,
                        Evasion = 5,
                        Endurance = 5,
                        HeroId = heroId
                    },
                    Equipments = new Equipment
                    {
                        Id = equipmentsId,
                        Knife = true,
                        SmokeBall = false,
                        Poison = false,
                        MedicPack = true,
                        MoneyBag = 100,
                        HeroId = heroId,
                        ArmorId = armorId,
                        ShieldId = shieldId,
                        WeaponId = weaponId,
                        ThrowingWeaponId = throwingWeaponId,
                        Armor = new Armor
                        {
                            Id = armorId,
                            ArmorType = "ChainMail",
                            IsExist = true,
                            Defence = 9,
                            EquipmentId = equipmentsId
                        },
                        Shield = new Shield
                        {
                            Id = shieldId,
                            ShieldType = "",
                            IsExist = false,
                            Defence = 0,
                            EquipmentId = equipmentsId
                        },
                        Weapon = new Weapon
                        {
                            Id = weaponId,
                            WeaponType = "LongSword",
                            IsExist = true,
                            IsItTwoHandWeapon = true,
                            Attack = 12,
                            Defence = 6,
                            Damage = 11,
                            WeaponRange = 3,
                            EquipmentId = equipmentsId
                        },
                        ThrowingWeapon = new ThrowingWeapon
                        {
                            Id = throwingWeaponId,
                            ThrowingWeaponType = "",
                            IsExist = false,
                            Attack = 0,
                            Defence = 0,
                            Damage = 0,
                            Quantity = 0,
                            ThrowingWeaponRange = 0,
                            EquipmentId = equipmentsId
                        },
                        Talismans = new List<Talisman>()
                    },
                    Ability = new Ability
                    {
                        Id = abilityId,
                        Survival = false,
                        Diplomacy = false,
                        Climbing = false,
                        Acrobatics = false,
                        Skill = false,
                        Guile = false,
                        SecretKnowledge = false,
                        Sneak = false,
                        Elusion = true,
                        WaterCycle = false,
                        Melee = true,
                        NatureSkills = false,
                        BreakingLocks = false,
                        Transformation = false,
                        Spells = false,
                        Rituals = false,
                        Traps = false,
                        Archery = false,
                        ThrowingKnives = false,
                        PoisonousNeedles = false,
                        Stimulants = false,
                        Wrestling = false,
                        Observation = false,
                        ShieldBearer = false,
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
                            Name = "MercenarySCS",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 3,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Ultimate = new Ultimate
                        {
                            Id = ultimateId,
                            Name = "MercenaryUltimate",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 6,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Spells = new List<Spell>(),
                        Rituals = new List<Ritual>(),
                        NatureSkills = new List<NatureSkill>()
                    },
                    Baggages = new List<Baggage>(),
                    Promises = new List<Promise>()
                };

                return newHero;
            }

            if (heroClass == "Gladiator")
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
                    Name = "Surful",
                    HeroClass = heroClass,
                    OrderOfBattle = 0,
                    BaggageCapacity = 50.0,
                    GroupWestId = groupWestId,
                    IndicatorsId = indicatorsId,
                    EquipmentsId = equipmentsId,
                    AbilityId = abilityId,
                    SpecialAbilityId = specialAbilityId,
                    Indicators = new Indicator
                    {
                        Id = indicatorsId,
                        Health = 60,
                        MentalEnergy = 24,
                        MentalStrength = 3,
                        Strength = 8,
                        Dexterity = 12,
                        Agility = 5,
                        Evasion = 5,
                        Endurance = 7,
                        HeroId = heroId
                    },
                    Equipments = new Equipment
                    {
                        Id = equipmentsId,
                        Knife = true,
                        SmokeBall = false,
                        Poison = false,
                        MedicPack = false,
                        MoneyBag = 100,
                        HeroId = heroId,
                        ArmorId = armorId,
                        ShieldId = shieldId,
                        WeaponId = weaponId,
                        ThrowingWeaponId = throwingWeaponId,
                        Armor = new Armor
                        {
                            Id = armorId,
                            ArmorType = "IronBreastplate",
                            IsExist = true,
                            Defence = 7,
                            EquipmentId = equipmentsId
                        },
                        Shield = new Shield
                        {
                            Id = shieldId,
                            ShieldType = "",
                            IsExist = false,
                            Defence = 0,
                            EquipmentId = equipmentsId
                        },
                        Weapon = new Weapon
                        {
                            Id = weaponId,
                            WeaponType = "TwoSwords",
                            IsExist = true,
                            IsItTwoHandWeapon = true,
                            Attack = 10,
                            Defence = 6,
                            Damage = 10,
                            WeaponRange = 2,
                            EquipmentId = equipmentsId
                        },
                        ThrowingWeapon = new ThrowingWeapon
                        {
                            Id = throwingWeaponId,
                            ThrowingWeaponType = "",
                            IsExist = false,
                            Attack = 0,
                            Defence = 0,
                            Damage = 0,
                            Quantity = 0,
                            ThrowingWeaponRange = 0,
                            EquipmentId = equipmentsId
                        },
                        Talismans = new List<Talisman>()
                    },
                    Ability = new Ability
                    {
                        Id = abilityId,
                        Survival = false,
                        Diplomacy = false,
                        Climbing = false,
                        Acrobatics = false,
                        Skill = true,
                        Guile = false,
                        SecretKnowledge = false,
                        Sneak = false,
                        Elusion = false,
                        WaterCycle = false,
                        Melee = false,
                        NatureSkills = false,
                        BreakingLocks = false,
                        Transformation = false,
                        Spells = false,
                        Rituals = false,
                        Traps = false,
                        Archery = false,
                        ThrowingKnives = false,
                        PoisonousNeedles = false,
                        Stimulants = false,
                        Wrestling = false,
                        Observation = false,
                        ShieldBearer = false,
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
                            Name = "GladiatorSCS",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 0,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Ultimate = new Ultimate
                        {
                            Id = ultimateId,
                            Name = "GladiatorUltimate",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 10,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Spells = new List<Spell>(),
                        Rituals = new List<Ritual>(),
                        NatureSkills = new List<NatureSkill>()
                    },
                    Baggages = new List<Baggage>(),
                    Promises = new List<Promise>()
                };

                return newHero;
            }

            if (heroClass == "Pirate")
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
                    Name = "CrazyWater",
                    HeroClass = heroClass,
                    OrderOfBattle = 0,
                    BaggageCapacity = 40.0,
                    GroupWestId = groupWestId,
                    IndicatorsId = indicatorsId,
                    EquipmentsId = equipmentsId,
                    AbilityId = abilityId,
                    SpecialAbilityId = specialAbilityId,
                    Indicators = new Indicator
                    {
                        Id = indicatorsId,
                        Health = 60,
                        MentalEnergy = 24,
                        MentalStrength = 2,
                        Strength = 7,
                        Dexterity = 7,
                        Agility = 10,
                        Evasion = 4,
                        Endurance = 10,
                        HeroId = heroId
                    },
                    Equipments = new Equipment
                    {
                        Id = equipmentsId,
                        Knife = true,
                        SmokeBall = true,
                        Poison = false,
                        MedicPack = false,
                        MoneyBag = 100,
                        HeroId = heroId,
                        ArmorId = armorId,
                        ShieldId = shieldId,
                        WeaponId = weaponId,
                        ThrowingWeaponId = throwingWeaponId,
                        Armor = new Armor
                        {
                            Id = armorId,
                            ArmorType = "Leather",
                            IsExist = true,
                            Defence = 3,
                            EquipmentId = equipmentsId
                        },
                        Shield = new Shield
                        {
                            Id = shieldId,
                            ShieldType = "",
                            IsExist = false,
                            Defence = 0,
                            EquipmentId = equipmentsId
                        },
                        Weapon = new Weapon
                        {
                            Id = weaponId,
                            WeaponType = "Mace",
                            IsExist = true,
                            IsItTwoHandWeapon = false,
                            Attack = 11,
                            Defence = 1,
                            Damage = 12,
                            WeaponRange = 2,
                            EquipmentId = equipmentsId
                        },
                        ThrowingWeapon = new ThrowingWeapon
                        {
                            Id = throwingWeaponId,
                            ThrowingWeaponType = "Knives",
                            IsExist = true,
                            Attack = 8,
                            Defence = 0,
                            Damage = 8,
                            Quantity = 10,
                            ThrowingWeaponRange = 3,
                            EquipmentId = equipmentsId
                        },
                        Talismans = new List<Talisman>()
                    },
                    Ability = new Ability
                    {
                        Id = abilityId,
                        Survival = false,
                        Diplomacy = false,
                        Climbing = false,
                        Acrobatics = false,
                        Skill = false,
                        Guile = false,
                        SecretKnowledge = false,
                        Sneak = false,
                        Elusion = false,
                        WaterCycle = true,
                        Melee = false,
                        NatureSkills = false,
                        BreakingLocks = false,
                        Transformation = false,
                        Spells = false,
                        Rituals = false,
                        Traps = false,
                        Archery = false,
                        ThrowingKnives = true,
                        PoisonousNeedles = false,
                        Stimulants = false,
                        Wrestling = false,
                        Observation = false,
                        ShieldBearer = false,
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
                            Name = "PirateSCS",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 0,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Ultimate = new Ultimate
                        {
                            Id = ultimateId,
                            Name = "PirateUltimate",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 6,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Spells = new List<Spell>(),
                        Rituals = new List<Ritual>(),
                        NatureSkills = new List<NatureSkill>()
                    },
                    Baggages = new List<Baggage>(),
                    Promises = new List<Promise>()
                };

                return newHero;
            }

            if (heroClass == "MonsterSlayer")
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
                    Name = "MonsterSlayer",
                    HeroClass = heroClass,
                    OrderOfBattle = 0,
                    BaggageCapacity = 50.0,
                    GroupWestId = groupWestId,
                    IndicatorsId = indicatorsId,
                    EquipmentsId = equipmentsId,
                    AbilityId = abilityId,
                    SpecialAbilityId = specialAbilityId,
                    Indicators = new Indicator
                    {
                        Id = indicatorsId,
                        Health = 60,
                        MentalEnergy = 20,
                        MentalStrength = 6,
                        Strength = 10,
                        Dexterity = 6,
                        Agility = 6,
                        Evasion = 6,
                        Endurance = 10,
                        HeroId = heroId
                    },
                    Equipments = new Equipment
                    {
                        Id = equipmentsId,
                        Knife = true,
                        SmokeBall = true,
                        Poison = false,
                        MedicPack = true,
                        MoneyBag = 100,
                        HeroId = heroId,
                        ArmorId = armorId,
                        ShieldId = shieldId,
                        WeaponId = weaponId,
                        ThrowingWeaponId = throwingWeaponId,
                        Armor = new Armor
                        {
                            Id = armorId,
                            ArmorType = "ChainMail",
                            IsExist = true,
                            Defence = 9,
                            EquipmentId = equipmentsId
                        },
                        Shield = new Shield
                        {
                            Id = shieldId,
                            ShieldType = "Heater",
                            IsExist = true,
                            Defence = 6,
                            EquipmentId = equipmentsId
                        },
                        Weapon = new Weapon
                        {
                            Id = weaponId,
                            WeaponType = "WarHammer",
                            IsExist = true,
                            IsItTwoHandWeapon = false,
                            Attack = 10,
                            Defence = 1,
                            Damage = 10,
                            WeaponRange = 2,
                            EquipmentId = equipmentsId
                        },
                        ThrowingWeapon = new ThrowingWeapon
                        {
                            Id = throwingWeaponId,
                            ThrowingWeaponType = "",
                            IsExist = false,
                            Attack = 0,
                            Defence = 0,
                            Damage = 0,
                            Quantity = 0,
                            ThrowingWeaponRange = 0,
                            EquipmentId = equipmentsId
                        },
                        Talismans = new List<Talisman>()
                    },
                    Ability = new Ability
                    {
                        Id = abilityId,
                        Survival = false,
                        Diplomacy = false,
                        Climbing = false,
                        Acrobatics = false,
                        Skill = false,
                        Guile = false,
                        SecretKnowledge = false,
                        Sneak = false,
                        Elusion = false,
                        WaterCycle = false,
                        Melee = false,
                        NatureSkills = false,
                        BreakingLocks = false,
                        Transformation = false,
                        Spells = false,
                        Rituals = false,
                        Traps = false,
                        Archery = false,
                        ThrowingKnives = false,
                        PoisonousNeedles = false,
                        Stimulants = false,
                        Wrestling = false,
                        Observation = false,
                        ShieldBearer = true,
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
                            Name = "MonsterHunterSCS",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 4,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Ultimate = new Ultimate
                        {
                            Id = ultimateId,
                            Name = "MonsterHunterUltimate",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 9,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Spells = new List<Spell>(),
                        Rituals = new List<Ritual>(),
                        NatureSkills = new List<NatureSkill>()
                    },
                    Baggages = new List<Baggage>(),
                    Promises = new List<Promise>()
                };

                return newHero;
            }

            if (heroClass == "Acrobat")
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
                    Name = "Gigi",
                    HeroClass = heroClass,
                    OrderOfBattle = 0,
                    BaggageCapacity = 50.0,
                    GroupWestId = groupWestId,
                    IndicatorsId = indicatorsId,
                    EquipmentsId = equipmentsId,
                    AbilityId = abilityId,
                    SpecialAbilityId = specialAbilityId,
                    Indicators = new Indicator
                    {
                        Id = indicatorsId,
                        Health = 60,
                        MentalEnergy = 24,
                        MentalStrength = 3,
                        Strength = 5,
                        Dexterity = 5,
                        Agility = 12,
                        Evasion = 7,
                        Endurance = 8,
                        HeroId = heroId
                    },
                    Equipments = new Equipment
                    {
                        Id = equipmentsId,
                        Knife = true,
                        SmokeBall = false,
                        Poison = true,
                        MedicPack = true,
                        MoneyBag = 100,
                        HeroId = heroId,
                        ArmorId = armorId,
                        ShieldId = shieldId,
                        WeaponId = weaponId,
                        ThrowingWeaponId = throwingWeaponId,
                        Armor = new Armor
                        {
                            Id = armorId,
                            ArmorType = "Fabric",
                            IsExist = true,
                            Defence = 1,
                            EquipmentId = equipmentsId
                        },
                        Shield = new Shield
                        {
                            Id = shieldId,
                            ShieldType = "",
                            IsExist = false,
                            Defence = 0,
                            EquipmentId = equipmentsId
                        },
                        Weapon = new Weapon
                        {
                            Id = weaponId,
                            WeaponType = "Saber",
                            IsExist = true,
                            IsItTwoHandWeapon = false,
                            Attack = 9,
                            Defence = 5,
                            Damage = 9,
                            WeaponRange = 2,
                            EquipmentId = equipmentsId
                        },
                        ThrowingWeapon = new ThrowingWeapon
                        {
                            Id = throwingWeaponId,
                            ThrowingWeaponType = "",
                            IsExist = false,
                            Attack = 0,
                            Defence = 0,
                            Damage = 0,
                            Quantity = 0,
                            ThrowingWeaponRange = 0,
                            EquipmentId = equipmentsId
                        },
                        Talismans = new List<Talisman>()
                    },
                    Ability = new Ability
                    {
                        Id = abilityId,
                        Survival = false,
                        Diplomacy = false,
                        Climbing = false,
                        Acrobatics = true,
                        Skill = false,
                        Guile = false,
                        SecretKnowledge = false,
                        Sneak = false,
                        Elusion = false,
                        WaterCycle = false,
                        Melee = false,
                        NatureSkills = false,
                        BreakingLocks = false,
                        Transformation = true,
                        Spells = false,
                        Rituals = false,
                        Traps = false,
                        Archery = false,
                        ThrowingKnives = false,
                        PoisonousNeedles = false,
                        Stimulants = false,
                        Wrestling = false,
                        Observation = false,
                        ShieldBearer = false,
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
                            Name = "AcrobatSCS",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 2,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Ultimate = new Ultimate
                        {
                            Id = ultimateId,
                            Name = "AcrobatUltimate",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 7,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Spells = new List<Spell>(),
                        Rituals = new List<Ritual>(),
                        NatureSkills = new List<NatureSkill>()
                    },
                    Baggages = new List<Baggage>(),
                    Promises = new List<Promise>()
                };

                return newHero;
            }

            if (heroClass == "Merchant")
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
                    Name = "KirguainTheThird",
                    HeroClass = heroClass,
                    OrderOfBattle = 0,
                    BaggageCapacity = 40.0,
                    GroupWestId = groupWestId,
                    IndicatorsId = indicatorsId,
                    EquipmentsId = equipmentsId,
                    AbilityId = abilityId,
                    SpecialAbilityId = specialAbilityId,
                    Indicators = new Indicator
                    {
                        Id = indicatorsId,
                        Health = 50,
                        MentalEnergy = 20,
                        MentalStrength = 5,
                        Strength = 2,
                        Dexterity = 10,
                        Agility = 7,
                        Evasion = 10,
                        Endurance = 2,
                        HeroId = heroId
                    },
                    Equipments = new Equipment
                    {
                        Id = equipmentsId,
                        Knife = true,
                        SmokeBall = true,
                        Poison = false,
                        MedicPack = true,
                        MoneyBag = 200,
                        HeroId = heroId,
                        ArmorId = armorId,
                        ShieldId = shieldId,
                        WeaponId = weaponId,
                        ThrowingWeaponId = throwingWeaponId,
                        Armor = new Armor
                        {
                            Id = armorId,
                            ArmorType = "Fabric",
                            IsExist = true,
                            Defence = 1,
                            EquipmentId = equipmentsId
                        },
                        Shield = new Shield
                        {
                            Id = shieldId,
                            ShieldType = "",
                            IsExist = false,
                            Defence = 0,
                            EquipmentId = equipmentsId
                        },
                        Weapon = new Weapon
                        {
                            Id = weaponId,
                            WeaponType = "Rapier",
                            IsExist = true,
                            IsItTwoHandWeapon = false,
                            Attack = 9,
                            Defence = 5,
                            Damage = 8,
                            WeaponRange = 2,
                            EquipmentId = equipmentsId
                        },
                        ThrowingWeapon = new ThrowingWeapon
                        {
                            Id = throwingWeaponId,
                            ThrowingWeaponType = "",
                            IsExist = false,
                            Attack = 0,
                            Defence = 0,
                            Damage = 0,
                            Quantity = 0,
                            ThrowingWeaponRange = 0,
                            EquipmentId = equipmentsId
                        },
                        Talismans = new List<Talisman>()
                    },
                    Ability = new Ability
                    {
                        Id = abilityId,
                        Survival = false,
                        Diplomacy = false,
                        Climbing = false,
                        Acrobatics = false,
                        Skill = false,
                        Guile = true,
                        SecretKnowledge = false,
                        Sneak = false,
                        Elusion = false,
                        WaterCycle = false,
                        Melee = false,
                        NatureSkills = false,
                        BreakingLocks = false,
                        Transformation = false,
                        Spells = false,
                        Rituals = false,
                        Traps = false,
                        Archery = false,
                        ThrowingKnives = false,
                        PoisonousNeedles = false,
                        Stimulants = false,
                        Wrestling = false,
                        Observation = true,
                        ShieldBearer = false,
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
                            Name = "MerchantSCS",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 2,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Ultimate = new Ultimate
                        {
                            Id = ultimateId,
                            Name = "MerchantUltimate",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 7,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Spells = new List<Spell>(),
                        Rituals = new List<Ritual>(),
                        NatureSkills = new List<NatureSkill>()
                    },
                    Baggages = new List<Baggage>(),
                    Promises = new List<Promise>()
                };

                return newHero;
            }

            if (heroClass == "Thief")
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
                    Name = "TheSonOfTheShadow",
                    HeroClass = heroClass,
                    OrderOfBattle = 0,
                    BaggageCapacity = 40.0,
                    GroupWestId = groupWestId,
                    IndicatorsId = indicatorsId,
                    EquipmentsId = equipmentsId,
                    AbilityId = abilityId,
                    SpecialAbilityId = specialAbilityId,
                    Indicators = new Indicator
                    {
                        Id = indicatorsId,
                        Health = 50,
                        MentalEnergy = 24,
                        MentalStrength = 5,
                        Strength = 4,
                        Dexterity = 5,
                        Agility = 8,
                        Evasion = 12,
                        Endurance = 6,
                        HeroId = heroId
                    },
                    Equipments = new Equipment
                    {
                        Id = equipmentsId,
                        Knife = false,
                        SmokeBall = false,
                        Poison = true,
                        MedicPack = false,
                        MoneyBag = 100,
                        HeroId = heroId,
                        ArmorId = armorId,
                        ShieldId = shieldId,
                        WeaponId = weaponId,
                        ThrowingWeaponId = throwingWeaponId,
                        Armor = new Armor
                        {
                            Id = armorId,
                            ArmorType = "Leather",
                            IsExist = true,
                            Defence = 3,
                            EquipmentId = equipmentsId
                        },
                        Shield = new Shield
                        {
                            Id = shieldId,
                            ShieldType = "",
                            IsExist = false,
                            Defence = 0,
                            EquipmentId = equipmentsId
                        },
                        Weapon = new Weapon
                        {
                            Id = weaponId,
                            WeaponType = "Dagger",
                            IsExist = true,
                            IsItTwoHandWeapon = false,
                            Attack = 7,
                            Defence = 2,
                            Damage = 7,
                            WeaponRange = 1,
                            EquipmentId = equipmentsId
                        },
                        ThrowingWeapon = new ThrowingWeapon
                        {
                            Id = throwingWeaponId,
                            ThrowingWeaponType = "",
                            IsExist = false,
                            Attack = 0,
                            Defence = 0,
                            Damage = 0,
                            Quantity = 0,
                            ThrowingWeaponRange = 0,
                            EquipmentId = equipmentsId
                        },
                        Talismans = new List<Talisman>()
                    },
                    Ability = new Ability
                    {
                        Id = abilityId,
                        Survival = false,
                        Diplomacy = false,
                        Climbing = true,
                        Acrobatics = false,
                        Skill = false,
                        Guile = false,
                        SecretKnowledge = false,
                        Sneak = true,
                        Elusion = false,
                        WaterCycle = false,
                        Melee = false,
                        NatureSkills = false,
                        BreakingLocks = true,
                        Transformation = false,
                        Spells = false,
                        Rituals = false,
                        Traps = false,
                        Archery = false,
                        ThrowingKnives = false,
                        PoisonousNeedles = false,
                        Stimulants = false,
                        Wrestling = false,
                        Observation = false,
                        ShieldBearer = false,
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
                            Name = "ThiefSCS",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 3,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Ultimate = new Ultimate
                        {
                            Id = ultimateId,
                            Name = "ThiefUltimate",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 9,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Spells = new List<Spell>(),
                        Rituals = new List<Ritual>(),
                        NatureSkills = new List<NatureSkill>()
                    },
                    Baggages = new List<Baggage>(),
                    Promises = new List<Promise>()
                };

                return newHero;
            }

            if (heroClass == "Missionary")
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
                    Name = "AbrakanaMaye",
                    HeroClass = heroClass,
                    OrderOfBattle = 0,
                    BaggageCapacity = 50.0,
                    GroupWestId = groupWestId,
                    IndicatorsId = indicatorsId,
                    EquipmentsId = equipmentsId,
                    AbilityId = abilityId,
                    SpecialAbilityId = specialAbilityId,
                    Indicators = new Indicator
                    {
                        Id = indicatorsId,
                        Health = 60,
                        MentalEnergy = 28,
                        MentalStrength = 10,
                        Strength = 5,
                        Dexterity = 4,
                        Agility = 10,
                        Evasion = 7,
                        Endurance = 4,
                        HeroId = heroId
                    },
                    Equipments = new Equipment
                    {
                        Id = equipmentsId,
                        Knife = true,
                        SmokeBall = false,
                        Poison = false,
                        MedicPack = true,
                        MoneyBag = 100,
                        HeroId = heroId,
                        ArmorId = armorId,
                        ShieldId = shieldId,
                        WeaponId = weaponId,
                        ThrowingWeaponId = throwingWeaponId,
                        Armor = new Armor
                        {
                            Id = armorId,
                            ArmorType = "Fabric",
                            IsExist = true,
                            Defence = 1,
                            EquipmentId = equipmentsId
                        },
                        Shield = new Shield
                        {
                            Id = shieldId,
                            ShieldType = "",
                            IsExist = false,
                            Defence = 0,
                            EquipmentId = equipmentsId
                        },
                        Weapon = new Weapon
                        {
                            Id = weaponId,
                            WeaponType = "WarClub",
                            IsExist = true,
                            IsItTwoHandWeapon = true,
                            Attack = 8,
                            Defence = 4,
                            Damage = 8,
                            WeaponRange = 3,
                            EquipmentId = equipmentsId
                        },
                        ThrowingWeapon = new ThrowingWeapon
                        {
                            Id = throwingWeaponId,
                            ThrowingWeaponType = "",
                            IsExist = false,
                            Attack = 0,
                            Defence = 0,
                            Damage = 0,
                            Quantity = 0,
                            ThrowingWeaponRange = 0,
                            EquipmentId = equipmentsId
                        },
                        Talismans = new List<Talisman>()
                    },
                    Ability = new Ability
                    {
                        Id = abilityId,
                        Survival = false,
                        Diplomacy = true,
                        Climbing = false,
                        Acrobatics = false,
                        Skill = false,
                        Guile = false,
                        SecretKnowledge = false,
                        Sneak = false,
                        Elusion = false,
                        WaterCycle = false,
                        Melee = false,
                        NatureSkills = true,
                        BreakingLocks = false,
                        Transformation = false,
                        Spells = false,
                        Rituals = false,
                        Traps = false,
                        Archery = false,
                        ThrowingKnives = false,
                        PoisonousNeedles = false,
                        Stimulants = false,
                        Wrestling = false,
                        Observation = false,
                        ShieldBearer = false,
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
                            Name = "MissionarySCS",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 4,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Ultimate = new Ultimate
                        {
                            Id = ultimateId,
                            Name = "MissionaryUltimate",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 8,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Spells = new List<Spell>(),
                        Rituals = new List<Ritual>(),
                        NatureSkills = new List<NatureSkill>()
                    },
                    Baggages = new List<Baggage>(),
                    Promises = new List<Promise>()
                };

                return newHero;
            }

            if (heroClass == "Magician")
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
                    Name = "Lusiferat",
                    HeroClass = heroClass,
                    OrderOfBattle = 0,
                    BaggageCapacity = 40.0,
                    GroupWestId = groupWestId,
                    IndicatorsId = indicatorsId,
                    EquipmentsId = equipmentsId,
                    AbilityId = abilityId,
                    SpecialAbilityId = specialAbilityId,
                    Indicators = new Indicator
                    {
                        Id = indicatorsId,
                        Health = 50,
                        MentalEnergy = 32,
                        MentalStrength = 12,
                        Strength = 3,
                        Dexterity = 3,
                        Agility = 7,
                        Evasion = 8,
                        Endurance = 3,
                        HeroId = heroId
                    },
                    Equipments = new Equipment
                    {
                        Id = equipmentsId,
                        Knife = true,
                        SmokeBall = false,
                        Poison = false,
                        MedicPack = false,
                        MoneyBag = 100,
                        HeroId = heroId,
                        ArmorId = armorId,
                        ShieldId = shieldId,
                        WeaponId = weaponId,
                        ThrowingWeaponId = throwingWeaponId,
                        Armor = new Armor
                        {
                            Id = armorId,
                            ArmorType = "Leather",
                            IsExist = true,
                            Defence = 3,
                            EquipmentId = equipmentsId
                        },
                        Shield = new Shield
                        {
                            Id = shieldId,
                            ShieldType = "",
                            IsExist = false,
                            Defence = 0,
                            EquipmentId = equipmentsId
                        },
                        Weapon = new Weapon
                        {
                            Id = weaponId,
                            WeaponType = "Scepter",
                            IsExist = true,
                            IsItTwoHandWeapon = false,
                            Attack = 7,
                            Defence = 3,
                            Damage = 7,
                            WeaponRange = 1,
                            EquipmentId = equipmentsId
                        },
                        ThrowingWeapon = new ThrowingWeapon
                        {
                            Id = throwingWeaponId,
                            ThrowingWeaponType = "",
                            IsExist = false,
                            Attack = 0,
                            Defence = 0,
                            Damage = 0,
                            Quantity = 0,
                            ThrowingWeaponRange = 0,
                            EquipmentId = equipmentsId
                        },
                        Talismans = new List<Talisman>()
                    },
                    Ability = new Ability
                    {
                        Id = abilityId,
                        Survival = false,
                        Diplomacy = false,
                        Climbing = false,
                        Acrobatics = false,
                        Skill = false,
                        Guile = false,
                        SecretKnowledge = true,
                        Sneak = false,
                        Elusion = false,
                        WaterCycle = false,
                        Melee = false,
                        NatureSkills = false,
                        BreakingLocks = false,
                        Transformation = false,
                        Spells = true,
                        Rituals = false,
                        Traps = false,
                        Archery = false,
                        ThrowingKnives = false,
                        PoisonousNeedles = false,
                        Stimulants = false,
                        Wrestling = false,
                        Observation = false,
                        ShieldBearer = false,
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
                            Name = "MagicianSCS",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 5,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Ultimate = new Ultimate
                        {
                            Id = ultimateId,
                            Name = "MagicianUltimate",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 10,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Spells = new List<Spell>(),
                        Rituals = new List<Ritual>(),
                        NatureSkills = new List<NatureSkill>()
                    },
                    Baggages = new List<Baggage>(),
                    Promises = new List<Promise>()
                };

                return newHero;
            }

            if (heroClass == "Librarian")
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
                    Name = "Rhamzeda",
                    HeroClass = heroClass,
                    OrderOfBattle = 0,
                    BaggageCapacity = 45.0,
                    GroupWestId = groupWestId,
                    IndicatorsId = indicatorsId,
                    EquipmentsId = equipmentsId,
                    AbilityId = abilityId,
                    SpecialAbilityId = specialAbilityId,
                    Indicators = new Indicator
                    {
                        Id = indicatorsId,
                        Health = 50,
                        MentalEnergy = 32,
                        MentalStrength = 10,
                        Strength = 5,
                        Dexterity = 6,
                        Agility = 7,
                        Evasion = 10,
                        Endurance = 2,
                        HeroId = heroId
                    },
                    Equipments = new Equipment
                    {
                        Id = equipmentsId,
                        Knife = true,
                        SmokeBall = false,
                        Poison = true,
                        MedicPack = true,
                        MoneyBag = 100,
                        HeroId = heroId,
                        ArmorId = armorId,
                        ShieldId = shieldId,
                        WeaponId = weaponId,
                        ThrowingWeaponId = throwingWeaponId,
                        Armor = new Armor
                        {
                            Id = armorId,
                            ArmorType = "IronBreastplate",
                            IsExist = true,
                            Defence = 7,
                            EquipmentId = equipmentsId
                        },
                        Shield = new Shield
                        {
                            Id = shieldId,
                            ShieldType = "",
                            IsExist = false,
                            Defence = 0,
                            EquipmentId = equipmentsId
                        },
                        Weapon = new Weapon
                        {
                            Id = weaponId,
                            WeaponType = "ShortSword",
                            IsExist = true,
                            IsItTwoHandWeapon = false,
                            Attack = 8,
                            Defence = 4,
                            Damage = 8,
                            WeaponRange = 2,
                            EquipmentId = equipmentsId
                        },
                        ThrowingWeapon = new ThrowingWeapon
                        {
                            Id = throwingWeaponId,
                            ThrowingWeaponType = "",
                            IsExist = false,
                            Attack = 0,
                            Defence = 0,
                            Damage = 0,
                            Quantity = 0,
                            ThrowingWeaponRange = 0,
                            EquipmentId = equipmentsId
                        },
                        Talismans = new List<Talisman>()
                    },
                    Ability = new Ability
                    {
                        Id = abilityId,
                        Survival = false,
                        Diplomacy = false,
                        Climbing = false,
                        Acrobatics = false,
                        Skill = false,
                        Guile = false,
                        SecretKnowledge = true,
                        Sneak = false,
                        Elusion = false,
                        WaterCycle = false,
                        Melee = false,
                        NatureSkills = false,
                        BreakingLocks = false,
                        Transformation = false,
                        Spells = false,
                        Rituals = true,
                        Traps = false,
                        Archery = false,
                        ThrowingKnives = false,
                        PoisonousNeedles = false,
                        Stimulants = false,
                        Wrestling = false,
                        Observation = false,
                        ShieldBearer = false,
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
                            Name = "LibrarianSCS",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 4,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Ultimate = new Ultimate
                        {
                            Id = ultimateId,
                            Name = "LibrarianUltimate",
                            SkillLevel = 1,
                            RequiredMentalEnergy = 8,
                            SpecialAbilitiesId = specialAbilityId
                        },
                        Spells = new List<Spell>(),
                        Rituals = new List<Ritual>(),
                        NatureSkills = new List<NatureSkill>()
                    },
                    Baggages = new List<Baggage>(),
                    Promises = new List<Promise>()
                };

                return newHero;
            }

            return null; ;
        }

        //private int GetOrderOfBattle(string orderInput)
        //{
        //    int orderResult = 0;

        //    if (orderInput == "first")
        //    {
        //        orderResult = 1;
        //        return orderResult;
        //    }
        //    else if (orderInput == "second")
        //    {
        //        orderResult = 2;
        //        return orderResult;
        //    }
        //    else if (orderInput == "third")
        //    {
        //        orderResult = 3;
        //        return orderResult;
        //    }
        //    else if (orderInput == "fourth")
        //    {
        //        orderResult = 4;
        //        return orderResult;
        //    }

        //    return orderResult;
        //}
    }
}
