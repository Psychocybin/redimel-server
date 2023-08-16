using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using redimel_server.Models.Domain;
using redimel_server.Models.Domain.RedimelDomain;
using redimel_server.Models.Domain.RedimelDomain.MagelandDomain;
using redimel_server.Repositories;

namespace redimel_server.Data
{
    public class RedimelServerDbContext: DbContext
    {

        public RedimelServerDbContext(DbContextOptions<RedimelServerDbContext> dbContextOptions): base(dbContextOptions)
        {
        }

        public DbSet<Ability> Abilities { get; set; }
        public DbSet<AditionalPoint> AditionalPoints { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Baggage> Baggages { get; set; }
        public DbSet<BattleGroup> BattleGroups { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<GroupWest> GroupWests { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Indicator> Indicators { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<NatureSkill> NatureSkills { get; set; }
        public DbSet<Negotiation> Negotiations { get; set; }
        public DbSet<Promise> Promises { get; set; }
        public DbSet<Ritual> Rituals { get; set; }
        public DbSet<Shield> Shields { get; set; }
        public DbSet<SpecialAbility> SpecialAbilities { get; set; }
        public DbSet<SpecialCombatSkill> SpecialCombatSkills { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Talisman> Talismans { get; set; }
        public DbSet<ThrowingWeapon> ThrowingWeapons { get; set; }
        public DbSet<Ultimate> Ultimates { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Redimel> Redimels { get; set; }
        public DbSet<Dikani> Dikanis { get; set; }
        public DbSet<Faegra> Faegras { get; set; }
        public DbSet<NorthernNomads> NorthernNomads { get; set; }
        public DbSet<OutlawTerritory> OutlawTerritories { get; set; }
        public DbSet<SouthernNomads> SouthernNomads { get; set; }
        public DbSet<Stincum> Stincums { get; set; }
        public DbSet<TheBigCity> TheBigCities { get; set; }
        public DbSet<TheEmpire> TheEmpires { get; set; }
        public DbSet<TheForestTribes> TheForestTribes { get; set; }
        public DbSet<TheHigherOnes> TheHigherOnes { get; set; }
        public DbSet<TheHorsePeople> TheHorsePeoples { get; set; }
        public DbSet<TheHunters> TheHunters { get; set; }
        public DbSet<TheIslanders> TheIslanders { get; set; }
        public DbSet<TheOldKingdom> TheOldKingdoms { get; set; }
        public DbSet<ThePirateDomains> ThePirateDomains { get; set; }
        public DbSet<TheShadowWorld> TheShadowWorlds { get; set; }
        public DbSet<TheTradeLeague> TheTradeLeagues { get; set; }
        public DbSet<TheWasteland> TheWastelands { get; set; }
        public DbSet<Tumpridadam> Tumpridadams { get; set; }
        public DbSet<Mageland> Magelands { get; set; }
        public DbSet<MageTown> MageTowns { get; set; }
        public DbSet<MageFields> MageFields { get; set; }
        public DbSet<MageForest> MageForests { get; set; }
        public DbSet<MageSea> MageSeas { get; set; }
        public DbSet<MageHarbor> MageHarbors { get; set; }
        public DbSet<MageTradeRoad> MageTradeRoads { get; set; }
        public DbSet<MageTownTheLibrary> MageTownTheLibraries { get; set; }
        public DbSet<MageTownTheCentralSquare> MageTownTheCentralSquares { get; set; }
        public DbSet<MageTownInnTheOldMagician> MageTownInnTheOldMagicians { get; set; }
        public DbSet<MageTownGuardHill> MageTownGuardHills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorldInfoVariable> WorldInfoVariables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Indicator>()
            //    .HasOne(x => x.Hero)
            //    .WithOne(x => x.Indicators)
            //    .OnDelete(DeleteBehavior.NoAction);

            //seed data for Soldier Hero

            modelBuilder.Entity<Indicator>().HasData(new Indicator
            {
                Id = Guid.Parse("1aa43831-d5b0-4299-9585-a98c527ef9f8"),
                Health = 70,
                MentalEnergy = 20,
                MentalStrength = 6,
                Strength = 12,
                Dexterity = 8,
                Agility = 3,
                Evasion = 5,
                Endurance = 6,
                HeroId = Guid.Parse("a9542e10-30a3-45a8-b2ea-cacef3df468a")
            });

            modelBuilder.Entity<Ability>().HasData(new Ability
            {
                Id = Guid.Parse("cd5a3e48-5eb4-49fa-a24d-3c3e861f22b3"),
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
                HeroId = Guid.Parse("a9542e10-30a3-45a8-b2ea-cacef3df468a")
            });

            modelBuilder.Entity<Armor>().HasData(new Armor
            {
                Id = Guid.Parse("05bee6ad-3556-4d28-b537-ab3fed69ea26"),
                ArmorType = "FullPlate",
                IsExist = true,
                Defence = 11,
                EquipmentId = Guid.Parse("6f58f2e9-7788-43f8-abe1-06a6d96a537b")
            });

            modelBuilder.Entity<Shield>().HasData(new Shield
            {
                Id = Guid.Parse("e87042bf-50c0-4b73-adc5-1da34dfdcd5f"),
                ShieldType = "",
                IsExist = false,
                Defence = 0,
                EquipmentId = Guid.Parse("6f58f2e9-7788-43f8-abe1-06a6d96a537b")
            });

            modelBuilder.Entity<Weapon>().HasData(new Weapon
            {
                Id = Guid.Parse("57006109-51e5-43e3-a8e0-8f3ece262649"),
                WeaponType = "TwoHandSword",
                IsExist = true,
                IsItTwoHandWeapon = true,
                Attack = 12,
                Defence = 3,
                Damage = 15,
                WeaponRange = 3,
                EquipmentId = Guid.Parse("6f58f2e9-7788-43f8-abe1-06a6d96a537b")
            });

            modelBuilder.Entity<ThrowingWeapon>().HasData(new ThrowingWeapon
            {
                Id = Guid.Parse("bcb17f68-b01e-484f-b757-7962129f95f6"),
                ThrowingWeaponType = "",
                IsExist = false,
                Attack = 0,
                Defence = 0,
                Damage = 0,
                Quantity = 0,
                ThrowingWeaponRange = 0,
                EquipmentId = Guid.Parse("6f58f2e9-7788-43f8-abe1-06a6d96a537b")
            });

            modelBuilder.Entity<Equipment>().HasData(new Equipment
            {
                Id = Guid.Parse("6f58f2e9-7788-43f8-abe1-06a6d96a537b"),
                Knife = true,
                SmokeBall = true,
                Poison = false,
                MedicPack = true,
                MoneyBag = 100,
                HeroId = Guid.Parse("a9542e10-30a3-45a8-b2ea-cacef3df468a"),
                ArmorId = Guid.Parse("05bee6ad-3556-4d28-b537-ab3fed69ea26"),
                ShieldId = Guid.Parse("e87042bf-50c0-4b73-adc5-1da34dfdcd5f"),
                WeaponId = Guid.Parse("57006109-51e5-43e3-a8e0-8f3ece262649"),
                ThrowingWeaponId = Guid.Parse("bcb17f68-b01e-484f-b757-7962129f95f6"),
                Talismans = new List<Talisman>()
            });

            modelBuilder.Entity<SpecialCombatSkill>().HasData(new SpecialCombatSkill
            {
                Id = Guid.Parse("d1d752d4-216b-4e3e-b663-6e2f5e849477"),
                Name = "SoldierSCS",
                SkillLevel = 1,
                RequiredMentalEnergy = 4,
                SpecialAbilitiesId = Guid.Parse("bf99b385-56ee-49f9-b7fe-36cc88f829d0")
            });

            modelBuilder.Entity<Ultimate>().HasData(new Ultimate
            {
                Id = Guid.Parse("0d71b738-b538-4e19-aebe-05806ab7d2fd"),
                Name = "SoldierUltimate",
                SkillLevel = 1,
                RequiredMentalEnergy = 5,
                SpecialAbilitiesId = Guid.Parse("bf99b385-56ee-49f9-b7fe-36cc88f829d0")
            });

            modelBuilder.Entity<SpecialAbility>().HasData(new SpecialAbility
            {
                Id = Guid.Parse("bf99b385-56ee-49f9-b7fe-36cc88f829d0"),
                SpecialCombatSkillId = Guid.Parse("d1d752d4-216b-4e3e-b663-6e2f5e849477"),
                UltimateId = Guid.Parse("0d71b738-b538-4e19-aebe-05806ab7d2fd"),
                HeroId = Guid.Parse("a9542e10-30a3-45a8-b2ea-cacef3df468a"),
                Spells = new List<Spell>(),
                Rituals = new List<Ritual>(),
                NatureSkills = new List<NatureSkill>()
            });

            modelBuilder.Entity<Hero>().HasData(new Hero
            {
                Id = Guid.Parse("a9542e10-30a3-45a8-b2ea-cacef3df468a"),
                Name = "Vranko",
                HeroClass = "Soldier",
                BaggageCapacity = 60.0,
                GroupWestId = Guid.Parse("38481e3c-6bad-4014-87d1-dc8fe7a9830c"),
                IndicatorsId = Guid.Parse("1aa43831-d5b0-4299-9585-a98c527ef9f8"),
                EquipmentsId = Guid.Parse("6f58f2e9-7788-43f8-abe1-06a6d96a537b"),
                AbilityId = Guid.Parse("cd5a3e48-5eb4-49fa-a24d-3c3e861f22b3"),
                SpecialAbilityId = Guid.Parse("bf99b385-56ee-49f9-b7fe-36cc88f829d0"),
                Baggages = new List<Baggage>(),
                Promises = new List<Promise>(),
            });

            //seed data for Hunter Hero

            modelBuilder.Entity<Indicator>().HasData(new Indicator
            {
                Id = Guid.Parse("697d4622-b4d9-4b71-85e8-a81bbcd7c0a4"),
                Health = 60,
                MentalEnergy = 24,
                MentalStrength = 8,
                Strength = 7,
                Dexterity = 7,
                Agility = 3,
                Evasion = 3,
                Endurance = 12,
                HeroId = Guid.Parse("e1f39f3c-0fb5-40d4-84d1-b6a46c5c0568")
            });

            modelBuilder.Entity<Ability>().HasData(new Ability
            {
                Id = Guid.Parse("0bd3e733-dcf3-40a3-8f90-e965a72687fd"),
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
                HeroId = Guid.Parse("e1f39f3c-0fb5-40d4-84d1-b6a46c5c0568")
            });

            modelBuilder.Entity<Armor>().HasData(new Armor
            {
                Id = Guid.Parse("9eb3e847-03e3-428d-9f05-976e64465cb8"),
                ArmorType = "WoodArmor",
                IsExist = true,
                Defence = 5,
                EquipmentId = Guid.Parse("6d6e49e8-84b4-4a11-b8f8-c1613e97479a")
            });

            modelBuilder.Entity<Shield>().HasData(new Shield
            {
                Id = Guid.Parse("c5b0bd9c-7840-41b4-bb71-44ab2b883c7d"),
                ShieldType = "",
                IsExist = false,
                Defence = 0,
                EquipmentId = Guid.Parse("6d6e49e8-84b4-4a11-b8f8-c1613e97479a")
            });

            modelBuilder.Entity<Weapon>().HasData(new Weapon
            {
                Id = Guid.Parse("b29503f6-4955-4512-a0d9-619f16127a80"),
                WeaponType = "Axe",
                IsExist = true,
                IsItTwoHandWeapon = false,
                Attack = 11,
                Defence = 2,
                Damage = 10,
                WeaponRange = 2,
                EquipmentId = Guid.Parse("6d6e49e8-84b4-4a11-b8f8-c1613e97479a")
            });

            modelBuilder.Entity<ThrowingWeapon>().HasData(new ThrowingWeapon
            {
                Id = Guid.Parse("666c294d-c0d1-49d1-89a0-88abb3cf05fe"),
                ThrowingWeaponType = "ShortBow",
                IsExist = true,
                Attack = 9,
                Defence = 1,
                Damage = 10,
                Quantity = 20,
                ThrowingWeaponRange = 4,
                EquipmentId = Guid.Parse("6d6e49e8-84b4-4a11-b8f8-c1613e97479a")
            });

            modelBuilder.Entity<Equipment>().HasData(new Equipment
            {
                Id = Guid.Parse("6d6e49e8-84b4-4a11-b8f8-c1613e97479a"),
                Knife = true,
                SmokeBall = false,
                Poison = false,
                MedicPack = true,
                MoneyBag = 100,
                HeroId = Guid.Parse("e1f39f3c-0fb5-40d4-84d1-b6a46c5c0568"),
                ArmorId = Guid.Parse("9eb3e847-03e3-428d-9f05-976e64465cb8"),
                ShieldId = Guid.Parse("c5b0bd9c-7840-41b4-bb71-44ab2b883c7d"),
                WeaponId = Guid.Parse("b29503f6-4955-4512-a0d9-619f16127a80"),
                ThrowingWeaponId = Guid.Parse("666c294d-c0d1-49d1-89a0-88abb3cf05fe"),
                Talismans = new List<Talisman>()
            });

            modelBuilder.Entity<SpecialCombatSkill>().HasData(new SpecialCombatSkill
            {
                Id = Guid.Parse("fdd5bf1d-32c6-460d-b518-570e866f2e7a"),
                Name = "HunterSCS",
                SkillLevel = 1,
                RequiredMentalEnergy = 0,
                SpecialAbilitiesId = Guid.Parse("eb521bf8-1f0e-43da-bfaf-82750308b629")
            });

            modelBuilder.Entity<Ultimate>().HasData(new Ultimate
            {
                Id = Guid.Parse("6d16ec7d-7e95-4c76-a146-7532c2c1f39e"),
                Name = "HunterUltimate",
                SkillLevel = 1,
                RequiredMentalEnergy = 8,
                SpecialAbilitiesId = Guid.Parse("eb521bf8-1f0e-43da-bfaf-82750308b629")
            });

            modelBuilder.Entity<SpecialAbility>().HasData(new SpecialAbility
            {
                Id = Guid.Parse("eb521bf8-1f0e-43da-bfaf-82750308b629"),
                SpecialCombatSkillId = Guid.Parse("fdd5bf1d-32c6-460d-b518-570e866f2e7a"),
                UltimateId = Guid.Parse("6d16ec7d-7e95-4c76-a146-7532c2c1f39e"),
                HeroId = Guid.Parse("e1f39f3c-0fb5-40d4-84d1-b6a46c5c0568"),
                Spells = new List<Spell>(),
                Rituals = new List<Ritual>(),
                NatureSkills = new List<NatureSkill>()
            });

            modelBuilder.Entity<Hero>().HasData(new Hero
            {
                Id = Guid.Parse("e1f39f3c-0fb5-40d4-84d1-b6a46c5c0568"),
                Name = "TheLittleBear",
                HeroClass = "Hunter",
                BaggageCapacity = 50.0,
                GroupWestId = Guid.Parse("38481e3c-6bad-4014-87d1-dc8fe7a9830c"),
                IndicatorsId = Guid.Parse("697d4622-b4d9-4b71-85e8-a81bbcd7c0a4"),
                EquipmentsId = Guid.Parse("6d6e49e8-84b4-4a11-b8f8-c1613e97479a"),
                AbilityId = Guid.Parse("0bd3e733-dcf3-40a3-8f90-e965a72687fd"),
                SpecialAbilityId = Guid.Parse("eb521bf8-1f0e-43da-bfaf-82750308b629"),
                Baggages = new List<Baggage>(),
                Promises = new List<Promise>(),
            });

            //seed data for Mercenary Hero

            modelBuilder.Entity<Indicator>().HasData(new Indicator
            {
                Id = Guid.Parse("f925cafb-f71a-4bca-8f73-87dabdbfe1b2"),
                Health = 60,
                MentalEnergy = 24,
                MentalStrength = 6,
                Strength = 10,
                Dexterity = 10,
                Agility = 4,
                Evasion = 5,
                Endurance = 5,
                HeroId = Guid.Parse("37f54a17-e9f7-4b50-9006-c6ba79105073")
            });

            modelBuilder.Entity<Ability>().HasData(new Ability
            {
                Id = Guid.Parse("edcda087-9b4e-4e18-813e-8b3d02f6e84d"),
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
                HeroId = Guid.Parse("37f54a17-e9f7-4b50-9006-c6ba79105073")
            });

            modelBuilder.Entity<Armor>().HasData(new Armor
            {
                Id = Guid.Parse("b945752d-0733-4f95-8230-e8aa999d6e3b"),
                ArmorType = "ChainMail",
                IsExist = true,
                Defence = 9,
                EquipmentId = Guid.Parse("25b4abaa-3a4e-417a-8182-2b428ab850ca")
            });

            modelBuilder.Entity<Shield>().HasData(new Shield
            {
                Id = Guid.Parse("6630c9f4-5864-46a0-9d68-d50c4e8e54ae"),
                ShieldType = "",
                IsExist = false,
                Defence = 0,
                EquipmentId = Guid.Parse("25b4abaa-3a4e-417a-8182-2b428ab850ca")
            });

            modelBuilder.Entity<Weapon>().HasData(new Weapon
            {
                Id = Guid.Parse("365568f0-745a-4541-9261-59fd68cc4074"),
                WeaponType = "LongSword",
                IsExist = true,
                IsItTwoHandWeapon = true,
                Attack = 12,
                Defence = 6,
                Damage = 11,
                WeaponRange = 3,
                EquipmentId = Guid.Parse("25b4abaa-3a4e-417a-8182-2b428ab850ca")
            });

            modelBuilder.Entity<ThrowingWeapon>().HasData(new ThrowingWeapon
            {
                Id = Guid.Parse("638f70a9-f6bf-47b7-9720-a5f053293a78"),
                ThrowingWeaponType = "",
                IsExist = false,
                Attack = 0,
                Defence = 0,
                Damage = 0,
                Quantity = 0,
                ThrowingWeaponRange = 0,
                EquipmentId = Guid.Parse("25b4abaa-3a4e-417a-8182-2b428ab850ca")
            });

            modelBuilder.Entity<Equipment>().HasData(new Equipment
            {
                Id = Guid.Parse("25b4abaa-3a4e-417a-8182-2b428ab850ca"),
                Knife = true,
                SmokeBall = false,
                Poison = false,
                MedicPack = true,
                MoneyBag = 100,
                HeroId = Guid.Parse("37f54a17-e9f7-4b50-9006-c6ba79105073"),
                ArmorId = Guid.Parse("b945752d-0733-4f95-8230-e8aa999d6e3b"),
                ShieldId = Guid.Parse("6630c9f4-5864-46a0-9d68-d50c4e8e54ae"),
                WeaponId = Guid.Parse("365568f0-745a-4541-9261-59fd68cc4074"),
                ThrowingWeaponId = Guid.Parse("638f70a9-f6bf-47b7-9720-a5f053293a78"),
                Talismans = new List<Talisman>()
            });

            modelBuilder.Entity<SpecialCombatSkill>().HasData(new SpecialCombatSkill
            {
                Id = Guid.Parse("fe691e8c-20bc-489a-b22d-68ec8762d98a"),
                Name = "MercenarySCS",
                SkillLevel = 1,
                RequiredMentalEnergy = 3,
                SpecialAbilitiesId = Guid.Parse("5a36646e-8d6b-4adb-8455-797b083cf516")
            });

            modelBuilder.Entity<Ultimate>().HasData(new Ultimate
            {
                Id = Guid.Parse("8be45ce0-4e07-41d4-824d-7f91e1b55e96"),
                Name = "MercenaryUltimate",
                SkillLevel = 1,
                RequiredMentalEnergy = 6,
                SpecialAbilitiesId = Guid.Parse("5a36646e-8d6b-4adb-8455-797b083cf516")
            });

            modelBuilder.Entity<SpecialAbility>().HasData(new SpecialAbility
            {
                Id = Guid.Parse("5a36646e-8d6b-4adb-8455-797b083cf516"),
                SpecialCombatSkillId = Guid.Parse("fe691e8c-20bc-489a-b22d-68ec8762d98a"),
                UltimateId = Guid.Parse("8be45ce0-4e07-41d4-824d-7f91e1b55e96"),
                HeroId = Guid.Parse("37f54a17-e9f7-4b50-9006-c6ba79105073"),
                Spells = new List<Spell>(),
                Rituals = new List<Ritual>(),
                NatureSkills = new List<NatureSkill>()
            });

            modelBuilder.Entity<Hero>().HasData(new Hero
            {
                Id = Guid.Parse("37f54a17-e9f7-4b50-9006-c6ba79105073"),
                Name = "TheLongDeath",
                HeroClass = "Mercenary",
                BaggageCapacity = 50.0,
                GroupWestId = Guid.Parse("38481e3c-6bad-4014-87d1-dc8fe7a9830c"),
                IndicatorsId = Guid.Parse("f925cafb-f71a-4bca-8f73-87dabdbfe1b2"),
                EquipmentsId = Guid.Parse("25b4abaa-3a4e-417a-8182-2b428ab850ca"),
                AbilityId = Guid.Parse("edcda087-9b4e-4e18-813e-8b3d02f6e84d"),
                SpecialAbilityId = Guid.Parse("5a36646e-8d6b-4adb-8455-797b083cf516"),
                Baggages = new List<Baggage>(),
                Promises = new List<Promise>(),
            });

            //seed data for Gladiator Hero

            modelBuilder.Entity<Indicator>().HasData(new Indicator
            {
                Id = Guid.Parse("da1ebfdf-6ded-4ded-9822-f8b9c38ec62b"),
                Health = 60,
                MentalEnergy = 24,
                MentalStrength = 3,
                Strength = 8,
                Dexterity = 12,
                Agility = 5,
                Evasion = 5,
                Endurance = 7,
                HeroId = Guid.Parse("f62256d9-2f28-4ce1-82d4-7e25625c097c")
            });

            modelBuilder.Entity<Ability>().HasData(new Ability
            {
                Id = Guid.Parse("5488f513-2bc4-46fc-915b-560c05dcad70"),
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
                HeroId = Guid.Parse("f62256d9-2f28-4ce1-82d4-7e25625c097c")
            });

            modelBuilder.Entity<Armor>().HasData(new Armor
            {
                Id = Guid.Parse("56dfcf22-f042-484f-b335-c95758e7e7e2"),
                ArmorType = "IronBreastplate",
                IsExist = true,
                Defence = 7,
                EquipmentId = Guid.Parse("9bca26b6-25b8-4699-9d48-5795bb0b40f2")
            });

            modelBuilder.Entity<Shield>().HasData(new Shield
            {
                Id = Guid.Parse("5cc02844-2a6c-4e1c-8da7-60c77ef32775"),
                ShieldType = "",
                IsExist = false,
                Defence = 0,
                EquipmentId = Guid.Parse("9bca26b6-25b8-4699-9d48-5795bb0b40f2")
            });

            modelBuilder.Entity<Weapon>().HasData(new Weapon
            {
                Id = Guid.Parse("306882a4-6f76-4860-bdac-cf7949b4f7ae"),
                WeaponType = "TwoSwords",
                IsExist = true,
                IsItTwoHandWeapon = true,
                Attack = 10,
                Defence = 6,
                Damage = 10,
                WeaponRange = 2,
                EquipmentId = Guid.Parse("9bca26b6-25b8-4699-9d48-5795bb0b40f2")
            });

            modelBuilder.Entity<ThrowingWeapon>().HasData(new ThrowingWeapon
            {
                Id = Guid.Parse("005da110-c051-46af-b841-481e56fbfc75"),
                ThrowingWeaponType = "",
                IsExist = false,
                Attack = 0,
                Defence = 0,
                Damage = 0,
                Quantity = 0,
                ThrowingWeaponRange = 0,
                EquipmentId = Guid.Parse("9bca26b6-25b8-4699-9d48-5795bb0b40f2")
            });

            modelBuilder.Entity<Equipment>().HasData(new Equipment
            {
                Id = Guid.Parse("9bca26b6-25b8-4699-9d48-5795bb0b40f2"),
                Knife = true,
                SmokeBall = false,
                Poison = false,
                MedicPack = false,
                MoneyBag = 100,
                HeroId = Guid.Parse("f62256d9-2f28-4ce1-82d4-7e25625c097c"),
                ArmorId = Guid.Parse("56dfcf22-f042-484f-b335-c95758e7e7e2"),
                ShieldId = Guid.Parse("5cc02844-2a6c-4e1c-8da7-60c77ef32775"),
                WeaponId = Guid.Parse("306882a4-6f76-4860-bdac-cf7949b4f7ae"),
                ThrowingWeaponId = Guid.Parse("005da110-c051-46af-b841-481e56fbfc75"),
                Talismans = new List<Talisman>()
            });

            modelBuilder.Entity<SpecialCombatSkill>().HasData(new SpecialCombatSkill
            {
                Id = Guid.Parse("cbb18d5d-d024-499d-8599-aefd39603f22"),
                Name = "GladiatorSCS",
                SkillLevel = 1,
                RequiredMentalEnergy = 0,
                SpecialAbilitiesId = Guid.Parse("70433c63-0f45-439e-9925-ceb151499f1f")
            });

            modelBuilder.Entity<Ultimate>().HasData(new Ultimate
            {
                Id = Guid.Parse("4006513c-e014-4d88-a4cd-1a27b4e31166"),
                Name = "GladiatorUltimate",
                SkillLevel = 1,
                RequiredMentalEnergy = 10,
                SpecialAbilitiesId = Guid.Parse("70433c63-0f45-439e-9925-ceb151499f1f")
            });

            modelBuilder.Entity<SpecialAbility>().HasData(new SpecialAbility
            {
                Id = Guid.Parse("70433c63-0f45-439e-9925-ceb151499f1f"),
                SpecialCombatSkillId = Guid.Parse("cbb18d5d-d024-499d-8599-aefd39603f22"),
                UltimateId = Guid.Parse("4006513c-e014-4d88-a4cd-1a27b4e31166"),
                HeroId = Guid.Parse("f62256d9-2f28-4ce1-82d4-7e25625c097c"),
                Spells = new List<Spell>(),
                Rituals = new List<Ritual>(),
                NatureSkills = new List<NatureSkill>()
            });

            modelBuilder.Entity<Hero>().HasData(new Hero
            {
                Id = Guid.Parse("f62256d9-2f28-4ce1-82d4-7e25625c097c"),
                Name = "Surful",
                HeroClass = "Gladiator",
                BaggageCapacity = 50.0,
                GroupWestId = Guid.Parse("38481e3c-6bad-4014-87d1-dc8fe7a9830c"),
                IndicatorsId = Guid.Parse("da1ebfdf-6ded-4ded-9822-f8b9c38ec62b"),
                EquipmentsId = Guid.Parse("9bca26b6-25b8-4699-9d48-5795bb0b40f2"),
                AbilityId = Guid.Parse("5488f513-2bc4-46fc-915b-560c05dcad70"),
                SpecialAbilityId = Guid.Parse("70433c63-0f45-439e-9925-ceb151499f1f"),
                Baggages = new List<Baggage>(),
                Promises = new List<Promise>(),
            });

            //seed data for Pirate Hero









































            //modelBuilder.Entity<Hero>()
            //    .HasOne(x => x.Ability)
            //    .WithOne(x => x.Hero);








            //SEED WITH OWN TYPE - not recommended

            //modelBuilder.Entity<Hero>(h =>
            //{
            //    h.HasData(new
            //    {

            //    });

            //    h.OwnsMany(e => e.Baggages);

            //    h.OwnsMany(e => e.Promises);

            //    h.OwnsOne(e => e.Abilities).HasData(new
            //    {

            //    });

            //    h.OwnsOne(e => e.Indicators).HasData(new
            //    {

            //    });

            //    h.OwnsOne(e => e.SpecialAbilities).HasData(new
            //    {

            //    });

            //    h.OwnsOne(e => e.SpecialAbilities).OwnsMany(s => s.Spells);

            //    h.OwnsOne(e => e.SpecialAbilities).OwnsMany(s => s.Rituals);

            //    h.OwnsOne(e => e.SpecialAbilities).OwnsMany(s => s.NatureSkills);

            //    h.OwnsOne(e => e.SpecialAbilities).OwnsOne(s => s.SpecialCombatSkill).HasData(new
            //    {

            //    });

            //    h.OwnsOne(e => e.SpecialAbilities).OwnsOne(s => s.Ultimate).HasData(new
            //    {

            //    });

            //    h.OwnsOne(e => e.Equipments).HasData(new
            //    {

            //    });

            //    h.OwnsOne(e => e.Equipments).OwnsMany(s => s.Talismans);

            //    h.OwnsOne(e => e.Equipments).OwnsOne(s => s.Armor).HasData(new
            //    {

            //    });

            //    h.OwnsOne(e => e.Equipments).OwnsOne(s => s.Shield).HasData(new
            //    {

            //    });

            //    h.OwnsOne(e => e.Equipments).OwnsOne(s => s.Weapon).HasData(new
            //    {

            //    });

            //    h.OwnsOne(e => e.Equipments).OwnsOne(s => s.ThrowingWeapon).HasData(new
            //    {

            //    });
            //});
        }
    }
}
