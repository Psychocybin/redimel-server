using Microsoft.EntityFrameworkCore;
using redimel_server.Models.Domain;

namespace redimel_server.Data
{
    public class RedimelServerDbContext : DbContext
    {

        public RedimelServerDbContext(DbContextOptions<RedimelServerDbContext> dbContextOptions) : base(dbContextOptions)
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
            //   38481e3c-6bad-4014-87d1-dc8fe7a9830c

            //modelBuilder.Entity<Indicator>().HasData(new Indicator
            //{
            //    Id = Guid.Parse("1aa43831-d5b0-4299-9585-a98c527ef9f8"),
            //    Health = 70,
            //    MentalEnergy = 20,
            //    MentalStrength = 6,
            //    Strength = 12,
            //    Dexterity = 8,
            //    Agility = 3,
            //    Evasion = 5,
            //    Endurance = 6,
            //    HeroId = Guid.Parse("a9542e10-30a3-45a8-b2ea-cacef3df468a")
            //});

            //modelBuilder.Entity<Ability>().HasData(new Ability
            //{
            //    Id = Guid.Parse("cd5a3e48-5eb4-49fa-a24d-3c3e861f22b3"),
            //    Survival = false,
            //    Diplomacy = false,
            //    Climbing = false,
            //    Acrobatics = false,
            //    Skill = false,
            //    Guile = false,
            //    SecretKnowledge = false,
            //    Sneak = false,
            //    Elusion = false,
            //    WaterCycle = false,
            //    Melee = false,
            //    NatureSkills = false,
            //    BreakingLocks = false,
            //    Transformation = false,
            //    Spells = false,
            //    Rituals = false,
            //    Traps = false,
            //    Archery = false,
            //    ThrowingKnives = false,
            //    PoisonousNeedles = false,
            //    Stimulants = false,
            //    Wrestling = true,
            //    Observation = false,
            //    ShieldBearer = false,
            //    HeroId = Guid.Parse("a9542e10-30a3-45a8-b2ea-cacef3df468a")
            //});

            //modelBuilder.Entity<Armor>().HasData(new Armor
            //{
            //    Id = Guid.Parse("05bee6ad-3556-4d28-b537-ab3fed69ea26"),
            //    ArmorType = "FullPlate",
            //    IsExist = true,
            //    Defence = 11,
            //    EquipmentId = Guid.Parse("6f58f2e9-7788-43f8-abe1-06a6d96a537b")
            //});

            //modelBuilder.Entity<Shield>().HasData(new Shield
            //{
            //    Id = Guid.Parse("e87042bf-50c0-4b73-adc5-1da34dfdcd5f"),
            //    ShieldType = "",
            //    IsExist = false,
            //    Defence = 0,
            //    EquipmentId = Guid.Parse("6f58f2e9-7788-43f8-abe1-06a6d96a537b")
            //});

            //modelBuilder.Entity<Weapon>().HasData(new Weapon
            //{
            //    Id = Guid.Parse("57006109-51e5-43e3-a8e0-8f3ece262649"),
            //    WeaponType = "TwoHandSword",
            //    IsExist = true,
            //    IsItTwoHandWeapon = true,
            //    Attack = 12,
            //    Defence = 3,
            //    Damage = 15,
            //    WeaponRange = 3,
            //    EquipmentId = Guid.Parse("6f58f2e9-7788-43f8-abe1-06a6d96a537b")
            //});

            //modelBuilder.Entity<ThrowingWeapon>().HasData(new ThrowingWeapon
            //{
            //    Id = Guid.Parse("bcb17f68-b01e-484f-b757-7962129f95f6"),
            //    ThrowingWeaponType = "",
            //    IsExist = false,
            //    Attack = 0,
            //    Defence = 0,
            //    Damage = 0,
            //    Quantity = 0,
            //    ThrowingWeaponRange = 0,
            //    EquipmentId = Guid.Parse("6f58f2e9-7788-43f8-abe1-06a6d96a537b")
            //});

            //modelBuilder.Entity<Equipment>().HasData(new Equipment
            //{
            //    Id = Guid.Parse("6f58f2e9-7788-43f8-abe1-06a6d96a537b"),
            //    Knife = true,
            //    SmokeBall = true,
            //    Poison = false,
            //    MedicPack = true,
            //    MoneyBag = 100,
            //    HeroId = Guid.Parse("a9542e10-30a3-45a8-b2ea-cacef3df468a"),
            //    ArmorId = Guid.Parse("05bee6ad-3556-4d28-b537-ab3fed69ea26"),
            //    ShieldId = Guid.Parse("e87042bf-50c0-4b73-adc5-1da34dfdcd5f"),
            //    WeaponId = Guid.Parse("57006109-51e5-43e3-a8e0-8f3ece262649"),
            //    ThrowingWeaponId = Guid.Parse("bcb17f68-b01e-484f-b757-7962129f95f6"),
            //    Talismans = new List<Talisman>()
            //});

            //modelBuilder.Entity<SpecialCombatSkill>().HasData(new SpecialCombatSkill
            //{
            //    Id = Guid.Parse("d1d752d4-216b-4e3e-b663-6e2f5e849477"),
            //    Name = "SoldierSCS",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 4,
            //    SpecialAbilitiesId = Guid.Parse("bf99b385-56ee-49f9-b7fe-36cc88f829d0")
            //});

            //modelBuilder.Entity<Ultimate>().HasData(new Ultimate
            //{
            //    Id = Guid.Parse("0d71b738-b538-4e19-aebe-05806ab7d2fd"),
            //    Name = "SoldierUltimate",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 5,
            //    SpecialAbilitiesId = Guid.Parse("bf99b385-56ee-49f9-b7fe-36cc88f829d0")
            //});

            //modelBuilder.Entity<SpecialAbility>().HasData(new SpecialAbility
            //{
            //    Id = Guid.Parse("bf99b385-56ee-49f9-b7fe-36cc88f829d0"),
            //    SpecialCombatSkillId = Guid.Parse("d1d752d4-216b-4e3e-b663-6e2f5e849477"),
            //    UltimateId = Guid.Parse("0d71b738-b538-4e19-aebe-05806ab7d2fd"),
            //    HeroId = Guid.Parse("a9542e10-30a3-45a8-b2ea-cacef3df468a"),
            //    Spells = new List<Spell>(),
            //    Rituals = new List<Ritual>(),
            //    NatureSkills = new List<NatureSkill>()
            //});

            //modelBuilder.Entity<Hero>().HasData(new Hero
            //{
            //    Id = Guid.Parse("a9542e10-30a3-45a8-b2ea-cacef3df468a"),
            //    Name = "Vranko",
            //    HeroClass = "Soldier",
            //    BaggageCapacity = 60.0,
            //    GroupWestId = Guid.Parse("44A06217-58EC-4DCE-BB7D-5A951E2BEF9E"),
            //    IndicatorsId = Guid.Parse("1aa43831-d5b0-4299-9585-a98c527ef9f8"),
            //    EquipmentsId = Guid.Parse("6f58f2e9-7788-43f8-abe1-06a6d96a537b"),
            //    AbilityId = Guid.Parse("cd5a3e48-5eb4-49fa-a24d-3c3e861f22b3"),
            //    SpecialAbilityId = Guid.Parse("bf99b385-56ee-49f9-b7fe-36cc88f829d0"),
            //    Baggages = new List<Baggage>(),
            //    Promises = new List<Promise>(),
            //});

            //seed data for Hunter Hero

            //modelBuilder.Entity<Indicator>().HasData(new Indicator
            //{
            //    Id = Guid.Parse("697d4622-b4d9-4b71-85e8-a81bbcd7c0a4"),
            //    Health = 60,
            //    MentalEnergy = 24,
            //    MentalStrength = 8,
            //    Strength = 7,
            //    Dexterity = 7,
            //    Agility = 3,
            //    Evasion = 3,
            //    Endurance = 12,
            //    HeroId = Guid.Parse("e1f39f3c-0fb5-40d4-84d1-b6a46c5c0568")
            //});

            //modelBuilder.Entity<Ability>().HasData(new Ability
            //{
            //    Id = Guid.Parse("0bd3e733-dcf3-40a3-8f90-e965a72687fd"),
            //    Survival = true,
            //    Diplomacy = false,
            //    Climbing = false,
            //    Acrobatics = false,
            //    Skill = false,
            //    Guile = false,
            //    SecretKnowledge = false,
            //    Sneak = false,
            //    Elusion = false,
            //    WaterCycle = false,
            //    Melee = false,
            //    NatureSkills = false,
            //    BreakingLocks = false,
            //    Transformation = false,
            //    Spells = false,
            //    Rituals = false,
            //    Traps = false,
            //    Archery = true,
            //    ThrowingKnives = false,
            //    PoisonousNeedles = false,
            //    Stimulants = false,
            //    Wrestling = false,
            //    Observation = false,
            //    ShieldBearer = false,
            //    HeroId = Guid.Parse("e1f39f3c-0fb5-40d4-84d1-b6a46c5c0568")
            //});

            //modelBuilder.Entity<Armor>().HasData(new Armor
            //{
            //    Id = Guid.Parse("9eb3e847-03e3-428d-9f05-976e64465cb8"),
            //    ArmorType = "WoodArmor",
            //    IsExist = true,
            //    Defence = 5,
            //    EquipmentId = Guid.Parse("6d6e49e8-84b4-4a11-b8f8-c1613e97479a")
            //});

            //modelBuilder.Entity<Shield>().HasData(new Shield
            //{
            //    Id = Guid.Parse("c5b0bd9c-7840-41b4-bb71-44ab2b883c7d"),
            //    ShieldType = "",
            //    IsExist = false,
            //    Defence = 0,
            //    EquipmentId = Guid.Parse("6d6e49e8-84b4-4a11-b8f8-c1613e97479a")
            //});

            //modelBuilder.Entity<Weapon>().HasData(new Weapon
            //{
            //    Id = Guid.Parse("b29503f6-4955-4512-a0d9-619f16127a80"),
            //    WeaponType = "Axe",
            //    IsExist = true,
            //    IsItTwoHandWeapon = false,
            //    Attack = 11,
            //    Defence = 2,
            //    Damage = 10,
            //    WeaponRange = 2,
            //    EquipmentId = Guid.Parse("6d6e49e8-84b4-4a11-b8f8-c1613e97479a")
            //});

            //modelBuilder.Entity<ThrowingWeapon>().HasData(new ThrowingWeapon
            //{
            //    Id = Guid.Parse("666c294d-c0d1-49d1-89a0-88abb3cf05fe"),
            //    ThrowingWeaponType = "ShortBow",
            //    IsExist = true,
            //    Attack = 9,
            //    Defence = 1,
            //    Damage = 10,
            //    Quantity = 20,
            //    ThrowingWeaponRange = 4,
            //    EquipmentId = Guid.Parse("6d6e49e8-84b4-4a11-b8f8-c1613e97479a")
            //});

            //modelBuilder.Entity<Equipment>().HasData(new Equipment
            //{
            //    Id = Guid.Parse("6d6e49e8-84b4-4a11-b8f8-c1613e97479a"),
            //    Knife = true,
            //    SmokeBall = false,
            //    Poison = false,
            //    MedicPack = true,
            //    MoneyBag = 100,
            //    HeroId = Guid.Parse("e1f39f3c-0fb5-40d4-84d1-b6a46c5c0568"),
            //    ArmorId = Guid.Parse("9eb3e847-03e3-428d-9f05-976e64465cb8"),
            //    ShieldId = Guid.Parse("c5b0bd9c-7840-41b4-bb71-44ab2b883c7d"),
            //    WeaponId = Guid.Parse("b29503f6-4955-4512-a0d9-619f16127a80"),
            //    ThrowingWeaponId = Guid.Parse("666c294d-c0d1-49d1-89a0-88abb3cf05fe"),
            //    Talismans = new List<Talisman>()
            //});

            //modelBuilder.Entity<SpecialCombatSkill>().HasData(new SpecialCombatSkill
            //{
            //    Id = Guid.Parse("fdd5bf1d-32c6-460d-b518-570e866f2e7a"),
            //    Name = "HunterSCS",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 0,
            //    SpecialAbilitiesId = Guid.Parse("eb521bf8-1f0e-43da-bfaf-82750308b629")
            //});

            //modelBuilder.Entity<Ultimate>().HasData(new Ultimate
            //{
            //    Id = Guid.Parse("6d16ec7d-7e95-4c76-a146-7532c2c1f39e"),
            //    Name = "HunterUltimate",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 8,
            //    SpecialAbilitiesId = Guid.Parse("eb521bf8-1f0e-43da-bfaf-82750308b629")
            //});

            //modelBuilder.Entity<SpecialAbility>().HasData(new SpecialAbility
            //{
            //    Id = Guid.Parse("eb521bf8-1f0e-43da-bfaf-82750308b629"),
            //    SpecialCombatSkillId = Guid.Parse("fdd5bf1d-32c6-460d-b518-570e866f2e7a"),
            //    UltimateId = Guid.Parse("6d16ec7d-7e95-4c76-a146-7532c2c1f39e"),
            //    HeroId = Guid.Parse("e1f39f3c-0fb5-40d4-84d1-b6a46c5c0568"),
            //    Spells = new List<Spell>(),
            //    Rituals = new List<Ritual>(),
            //    NatureSkills = new List<NatureSkill>()
            //});

            //modelBuilder.Entity<Hero>().HasData(new Hero
            //{
            //    Id = Guid.Parse("e1f39f3c-0fb5-40d4-84d1-b6a46c5c0568"),
            //    Name = "TheLittleBear",
            //    HeroClass = "Hunter",
            //    BaggageCapacity = 50.0,
            //    GroupWestId = Guid.Parse("44A06217-58EC-4DCE-BB7D-5A951E2BEF9E"),
            //    IndicatorsId = Guid.Parse("697d4622-b4d9-4b71-85e8-a81bbcd7c0a4"),
            //    EquipmentsId = Guid.Parse("6d6e49e8-84b4-4a11-b8f8-c1613e97479a"),
            //    AbilityId = Guid.Parse("0bd3e733-dcf3-40a3-8f90-e965a72687fd"),
            //    SpecialAbilityId = Guid.Parse("eb521bf8-1f0e-43da-bfaf-82750308b629"),
            //    Baggages = new List<Baggage>(),
            //    Promises = new List<Promise>(),
            //});

            //seed data for Mercenary Hero

            //modelBuilder.Entity<Indicator>().HasData(new Indicator
            //{
            //    Id = Guid.Parse("f925cafb-f71a-4bca-8f73-87dabdbfe1b2"),
            //    Health = 60,
            //    MentalEnergy = 24,
            //    MentalStrength = 6,
            //    Strength = 10,
            //    Dexterity = 10,
            //    Agility = 4,
            //    Evasion = 5,
            //    Endurance = 5,
            //    HeroId = Guid.Parse("37f54a17-e9f7-4b50-9006-c6ba79105073")
            //});

            //modelBuilder.Entity<Ability>().HasData(new Ability
            //{
            //    Id = Guid.Parse("edcda087-9b4e-4e18-813e-8b3d02f6e84d"),
            //    Survival = false,
            //    Diplomacy = false,
            //    Climbing = false,
            //    Acrobatics = false,
            //    Skill = false,
            //    Guile = false,
            //    SecretKnowledge = false,
            //    Sneak = false,
            //    Elusion = true,
            //    WaterCycle = false,
            //    Melee = true,
            //    NatureSkills = false,
            //    BreakingLocks = false,
            //    Transformation = false,
            //    Spells = false,
            //    Rituals = false,
            //    Traps = false,
            //    Archery = false,
            //    ThrowingKnives = false,
            //    PoisonousNeedles = false,
            //    Stimulants = false,
            //    Wrestling = false,
            //    Observation = false,
            //    ShieldBearer = false,
            //    HeroId = Guid.Parse("37f54a17-e9f7-4b50-9006-c6ba79105073")
            //});

            //modelBuilder.Entity<Armor>().HasData(new Armor
            //{
            //    Id = Guid.Parse("b945752d-0733-4f95-8230-e8aa999d6e3b"),
            //    ArmorType = "ChainMail",
            //    IsExist = true,
            //    Defence = 9,
            //    EquipmentId = Guid.Parse("25b4abaa-3a4e-417a-8182-2b428ab850ca")
            //});

            //modelBuilder.Entity<Shield>().HasData(new Shield
            //{
            //    Id = Guid.Parse("6630c9f4-5864-46a0-9d68-d50c4e8e54ae"),
            //    ShieldType = "",
            //    IsExist = false,
            //    Defence = 0,
            //    EquipmentId = Guid.Parse("25b4abaa-3a4e-417a-8182-2b428ab850ca")
            //});

            //modelBuilder.Entity<Weapon>().HasData(new Weapon
            //{
            //    Id = Guid.Parse("365568f0-745a-4541-9261-59fd68cc4074"),
            //    WeaponType = "LongSword",
            //    IsExist = true,
            //    IsItTwoHandWeapon = true,
            //    Attack = 12,
            //    Defence = 6,
            //    Damage = 11,
            //    WeaponRange = 3,
            //    EquipmentId = Guid.Parse("25b4abaa-3a4e-417a-8182-2b428ab850ca")
            //});

            //modelBuilder.Entity<ThrowingWeapon>().HasData(new ThrowingWeapon
            //{
            //    Id = Guid.Parse("638f70a9-f6bf-47b7-9720-a5f053293a78"),
            //    ThrowingWeaponType = "",
            //    IsExist = false,
            //    Attack = 0,
            //    Defence = 0,
            //    Damage = 0,
            //    Quantity = 0,
            //    ThrowingWeaponRange = 0,
            //    EquipmentId = Guid.Parse("25b4abaa-3a4e-417a-8182-2b428ab850ca")
            //});

            //modelBuilder.Entity<Equipment>().HasData(new Equipment
            //{
            //    Id = Guid.Parse("25b4abaa-3a4e-417a-8182-2b428ab850ca"),
            //    Knife = true,
            //    SmokeBall = false,
            //    Poison = false,
            //    MedicPack = true,
            //    MoneyBag = 100,
            //    HeroId = Guid.Parse("37f54a17-e9f7-4b50-9006-c6ba79105073"),
            //    ArmorId = Guid.Parse("b945752d-0733-4f95-8230-e8aa999d6e3b"),
            //    ShieldId = Guid.Parse("6630c9f4-5864-46a0-9d68-d50c4e8e54ae"),
            //    WeaponId = Guid.Parse("365568f0-745a-4541-9261-59fd68cc4074"),
            //    ThrowingWeaponId = Guid.Parse("638f70a9-f6bf-47b7-9720-a5f053293a78"),
            //    Talismans = new List<Talisman>()
            //});

            //modelBuilder.Entity<SpecialCombatSkill>().HasData(new SpecialCombatSkill
            //{
            //    Id = Guid.Parse("fe691e8c-20bc-489a-b22d-68ec8762d98a"),
            //    Name = "MercenarySCS",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 3,
            //    SpecialAbilitiesId = Guid.Parse("5a36646e-8d6b-4adb-8455-797b083cf516")
            //});

            //modelBuilder.Entity<Ultimate>().HasData(new Ultimate
            //{
            //    Id = Guid.Parse("8be45ce0-4e07-41d4-824d-7f91e1b55e96"),
            //    Name = "MercenaryUltimate",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 6,
            //    SpecialAbilitiesId = Guid.Parse("5a36646e-8d6b-4adb-8455-797b083cf516")
            //});

            //modelBuilder.Entity<SpecialAbility>().HasData(new SpecialAbility
            //{
            //    Id = Guid.Parse("5a36646e-8d6b-4adb-8455-797b083cf516"),
            //    SpecialCombatSkillId = Guid.Parse("fe691e8c-20bc-489a-b22d-68ec8762d98a"),
            //    UltimateId = Guid.Parse("8be45ce0-4e07-41d4-824d-7f91e1b55e96"),
            //    HeroId = Guid.Parse("37f54a17-e9f7-4b50-9006-c6ba79105073"),
            //    Spells = new List<Spell>(),
            //    Rituals = new List<Ritual>(),
            //    NatureSkills = new List<NatureSkill>()
            //});

            //modelBuilder.Entity<Hero>().HasData(new Hero
            //{
            //    Id = Guid.Parse("37f54a17-e9f7-4b50-9006-c6ba79105073"),
            //    Name = "TheLongDeath",
            //    HeroClass = "Mercenary",
            //    BaggageCapacity = 50.0,
            //    GroupWestId = Guid.Parse("44A06217-58EC-4DCE-BB7D-5A951E2BEF9E"),
            //    IndicatorsId = Guid.Parse("f925cafb-f71a-4bca-8f73-87dabdbfe1b2"),
            //    EquipmentsId = Guid.Parse("25b4abaa-3a4e-417a-8182-2b428ab850ca"),
            //    AbilityId = Guid.Parse("edcda087-9b4e-4e18-813e-8b3d02f6e84d"),
            //    SpecialAbilityId = Guid.Parse("5a36646e-8d6b-4adb-8455-797b083cf516"),
            //    Baggages = new List<Baggage>(),
            //    Promises = new List<Promise>(),
            //});

            //seed data for Gladiator Hero

            //modelBuilder.Entity<Indicator>().HasData(new Indicator
            //{
            //    Id = Guid.Parse("da1ebfdf-6ded-4ded-9822-f8b9c38ec62b"),
            //    Health = 60,
            //    MentalEnergy = 24,
            //    MentalStrength = 3,
            //    Strength = 8,
            //    Dexterity = 12,
            //    Agility = 5,
            //    Evasion = 5,
            //    Endurance = 7,
            //    HeroId = Guid.Parse("f62256d9-2f28-4ce1-82d4-7e25625c097c")
            //});

            //modelBuilder.Entity<Ability>().HasData(new Ability
            //{
            //    Id = Guid.Parse("5488f513-2bc4-46fc-915b-560c05dcad70"),
            //    Survival = false,
            //    Diplomacy = false,
            //    Climbing = false,
            //    Acrobatics = false,
            //    Skill = true,
            //    Guile = false,
            //    SecretKnowledge = false,
            //    Sneak = false,
            //    Elusion = false,
            //    WaterCycle = false,
            //    Melee = false,
            //    NatureSkills = false,
            //    BreakingLocks = false,
            //    Transformation = false,
            //    Spells = false,
            //    Rituals = false,
            //    Traps = false,
            //    Archery = false,
            //    ThrowingKnives = false,
            //    PoisonousNeedles = false,
            //    Stimulants = false,
            //    Wrestling = false,
            //    Observation = false,
            //    ShieldBearer = false,
            //    HeroId = Guid.Parse("f62256d9-2f28-4ce1-82d4-7e25625c097c")
            //});

            //modelBuilder.Entity<Armor>().HasData(new Armor
            //{
            //    Id = Guid.Parse("56dfcf22-f042-484f-b335-c95758e7e7e2"),
            //    ArmorType = "IronBreastplate",
            //    IsExist = true,
            //    Defence = 7,
            //    EquipmentId = Guid.Parse("9bca26b6-25b8-4699-9d48-5795bb0b40f2")
            //});

            //modelBuilder.Entity<Shield>().HasData(new Shield
            //{
            //    Id = Guid.Parse("5cc02844-2a6c-4e1c-8da7-60c77ef32775"),
            //    ShieldType = "",
            //    IsExist = false,
            //    Defence = 0,
            //    EquipmentId = Guid.Parse("9bca26b6-25b8-4699-9d48-5795bb0b40f2")
            //});

            //modelBuilder.Entity<Weapon>().HasData(new Weapon
            //{
            //    Id = Guid.Parse("306882a4-6f76-4860-bdac-cf7949b4f7ae"),
            //    WeaponType = "TwoSwords",
            //    IsExist = true,
            //    IsItTwoHandWeapon = true,
            //    Attack = 10,
            //    Defence = 6,
            //    Damage = 10,
            //    WeaponRange = 2,
            //    EquipmentId = Guid.Parse("9bca26b6-25b8-4699-9d48-5795bb0b40f2")
            //});

            //modelBuilder.Entity<ThrowingWeapon>().HasData(new ThrowingWeapon
            //{
            //    Id = Guid.Parse("005da110-c051-46af-b841-481e56fbfc75"),
            //    ThrowingWeaponType = "",
            //    IsExist = false,
            //    Attack = 0,
            //    Defence = 0,
            //    Damage = 0,
            //    Quantity = 0,
            //    ThrowingWeaponRange = 0,
            //    EquipmentId = Guid.Parse("9bca26b6-25b8-4699-9d48-5795bb0b40f2")
            //});

            //modelBuilder.Entity<Equipment>().HasData(new Equipment
            //{
            //    Id = Guid.Parse("9bca26b6-25b8-4699-9d48-5795bb0b40f2"),
            //    Knife = true,
            //    SmokeBall = false,
            //    Poison = false,
            //    MedicPack = false,
            //    MoneyBag = 100,
            //    HeroId = Guid.Parse("f62256d9-2f28-4ce1-82d4-7e25625c097c"),
            //    ArmorId = Guid.Parse("56dfcf22-f042-484f-b335-c95758e7e7e2"),
            //    ShieldId = Guid.Parse("5cc02844-2a6c-4e1c-8da7-60c77ef32775"),
            //    WeaponId = Guid.Parse("306882a4-6f76-4860-bdac-cf7949b4f7ae"),
            //    ThrowingWeaponId = Guid.Parse("005da110-c051-46af-b841-481e56fbfc75"),
            //    Talismans = new List<Talisman>()
            //});

            //modelBuilder.Entity<SpecialCombatSkill>().HasData(new SpecialCombatSkill
            //{
            //    Id = Guid.Parse("cbb18d5d-d024-499d-8599-aefd39603f22"),
            //    Name = "GladiatorSCS",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 0,
            //    SpecialAbilitiesId = Guid.Parse("70433c63-0f45-439e-9925-ceb151499f1f")
            //});

            //modelBuilder.Entity<Ultimate>().HasData(new Ultimate
            //{
            //    Id = Guid.Parse("4006513c-e014-4d88-a4cd-1a27b4e31166"),
            //    Name = "GladiatorUltimate",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 10,
            //    SpecialAbilitiesId = Guid.Parse("70433c63-0f45-439e-9925-ceb151499f1f")
            //});

            //modelBuilder.Entity<SpecialAbility>().HasData(new SpecialAbility
            //{
            //    Id = Guid.Parse("70433c63-0f45-439e-9925-ceb151499f1f"),
            //    SpecialCombatSkillId = Guid.Parse("cbb18d5d-d024-499d-8599-aefd39603f22"),
            //    UltimateId = Guid.Parse("4006513c-e014-4d88-a4cd-1a27b4e31166"),
            //    HeroId = Guid.Parse("f62256d9-2f28-4ce1-82d4-7e25625c097c"),
            //    Spells = new List<Spell>(),
            //    Rituals = new List<Ritual>(),
            //    NatureSkills = new List<NatureSkill>()
            //});

            //modelBuilder.Entity<Hero>().HasData(new Hero
            //{
            //    Id = Guid.Parse("f62256d9-2f28-4ce1-82d4-7e25625c097c"),
            //    Name = "Surful",
            //    HeroClass = "Gladiator",
            //    BaggageCapacity = 50.0,
            //    GroupWestId = Guid.Parse("44A06217-58EC-4DCE-BB7D-5A951E2BEF9E"),
            //    IndicatorsId = Guid.Parse("da1ebfdf-6ded-4ded-9822-f8b9c38ec62b"),
            //    EquipmentsId = Guid.Parse("9bca26b6-25b8-4699-9d48-5795bb0b40f2"),
            //    AbilityId = Guid.Parse("5488f513-2bc4-46fc-915b-560c05dcad70"),
            //    SpecialAbilityId = Guid.Parse("70433c63-0f45-439e-9925-ceb151499f1f"),
            //    Baggages = new List<Baggage>(),
            //    Promises = new List<Promise>(),
            //});

            //seed data for Pirate Hero

            //modelBuilder.Entity<Indicator>().HasData(new Indicator
            //{
            //    Id = Guid.Parse("b30b4027-a343-4855-904b-03372c5b7d08"),
            //    Health = 60,
            //    MentalEnergy = 24,
            //    MentalStrength = 2,
            //    Strength = 7,
            //    Dexterity = 7,
            //    Agility = 10,
            //    Evasion = 4,
            //    Endurance = 10,
            //    HeroId = Guid.Parse("844cb085-2f8d-49c5-8d74-5fea0ca23f2a")
            //});

            //modelBuilder.Entity<Ability>().HasData(new Ability
            //{
            //    Id = Guid.Parse("49ef925c-5b35-45c7-a6ca-e8330580f02c"),
            //    Survival = false,
            //    Diplomacy = false,
            //    Climbing = false,
            //    Acrobatics = false,
            //    Skill = false,
            //    Guile = false,
            //    SecretKnowledge = false,
            //    Sneak = false,
            //    Elusion = false,
            //    WaterCycle = true,
            //    Melee = false,
            //    NatureSkills = false,
            //    BreakingLocks = false,
            //    Transformation = false,
            //    Spells = false,
            //    Rituals = false,
            //    Traps = false,
            //    Archery = false,
            //    ThrowingKnives = true,
            //    PoisonousNeedles = false,
            //    Stimulants = false,
            //    Wrestling = false,
            //    Observation = false,
            //    ShieldBearer = false,
            //    HeroId = Guid.Parse("844cb085-2f8d-49c5-8d74-5fea0ca23f2a")
            //});

            //modelBuilder.Entity<Armor>().HasData(new Armor
            //{
            //    Id = Guid.Parse("639f8703-82e0-4e1b-afb0-5c3e288518d5"),
            //    ArmorType = "Leather",
            //    IsExist = true,
            //    Defence = 3,
            //    EquipmentId = Guid.Parse("62bc02ca-1e01-4c1a-8599-e62429a05ade")
            //});

            //modelBuilder.Entity<Shield>().HasData(new Shield
            //{
            //    Id = Guid.Parse("ebdba61a-60da-46bc-b4a7-37a504ce83ae"),
            //    ShieldType = "",
            //    IsExist = false,
            //    Defence = 0,
            //    EquipmentId = Guid.Parse("62bc02ca-1e01-4c1a-8599-e62429a05ade")
            //});

            //modelBuilder.Entity<Weapon>().HasData(new Weapon
            //{
            //    Id = Guid.Parse("e5ddbbe0-8875-4aef-8111-ca96035e213a"),
            //    WeaponType = "Mace",
            //    IsExist = true,
            //    IsItTwoHandWeapon = false,
            //    Attack = 11,
            //    Defence = 1,
            //    Damage = 12,
            //    WeaponRange = 2,
            //    EquipmentId = Guid.Parse("62bc02ca-1e01-4c1a-8599-e62429a05ade")
            //});

            //modelBuilder.Entity<ThrowingWeapon>().HasData(new ThrowingWeapon
            //{
            //    Id = Guid.Parse("d94eb3eb-a546-4759-a9f9-1849841f9e4f"),
            //    ThrowingWeaponType = "Knives",
            //    IsExist = true,
            //    Attack = 8,
            //    Defence = 0,
            //    Damage = 8,
            //    Quantity = 10,
            //    ThrowingWeaponRange = 3,
            //    EquipmentId = Guid.Parse("62bc02ca-1e01-4c1a-8599-e62429a05ade")
            //});

            //modelBuilder.Entity<Equipment>().HasData(new Equipment
            //{
            //    Id = Guid.Parse("62bc02ca-1e01-4c1a-8599-e62429a05ade"),
            //    Knife = true,
            //    SmokeBall = true,
            //    Poison = false,
            //    MedicPack = false,
            //    MoneyBag = 100,
            //    HeroId = Guid.Parse("844cb085-2f8d-49c5-8d74-5fea0ca23f2a"),
            //    ArmorId = Guid.Parse("639f8703-82e0-4e1b-afb0-5c3e288518d5"),
            //    ShieldId = Guid.Parse("ebdba61a-60da-46bc-b4a7-37a504ce83ae"),
            //    WeaponId = Guid.Parse("e5ddbbe0-8875-4aef-8111-ca96035e213a"),
            //    ThrowingWeaponId = Guid.Parse("d94eb3eb-a546-4759-a9f9-1849841f9e4f"),
            //    Talismans = new List<Talisman>()
            //});

            //modelBuilder.Entity<SpecialCombatSkill>().HasData(new SpecialCombatSkill
            //{
            //    Id = Guid.Parse("2dc6c9ae-62c7-441f-8706-40f3c4078bd8"),
            //    Name = "PirateSCS",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 0,
            //    SpecialAbilitiesId = Guid.Parse("3d79772f-0da0-4b54-b421-5b91330a4009")
            //});

            //modelBuilder.Entity<Ultimate>().HasData(new Ultimate
            //{
            //    Id = Guid.Parse("31b71319-c444-4aad-9e77-7081a208768f"),
            //    Name = "PirateUltimate",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 6,
            //    SpecialAbilitiesId = Guid.Parse("3d79772f-0da0-4b54-b421-5b91330a4009")
            //});

            //modelBuilder.Entity<SpecialAbility>().HasData(new SpecialAbility
            //{
            //    Id = Guid.Parse("3d79772f-0da0-4b54-b421-5b91330a4009"),
            //    SpecialCombatSkillId = Guid.Parse("2dc6c9ae-62c7-441f-8706-40f3c4078bd8"),
            //    UltimateId = Guid.Parse("31b71319-c444-4aad-9e77-7081a208768f"),
            //    HeroId = Guid.Parse("844cb085-2f8d-49c5-8d74-5fea0ca23f2a"),
            //    Spells = new List<Spell>(),
            //    Rituals = new List<Ritual>(),
            //    NatureSkills = new List<NatureSkill>()
            //});

            //modelBuilder.Entity<Hero>().HasData(new Hero
            //{
            //    Id = Guid.Parse("844cb085-2f8d-49c5-8d74-5fea0ca23f2a"),
            //    Name = "CrazyWater",
            //    HeroClass = "Pirate",
            //    BaggageCapacity = 40.0,
            //    GroupWestId = Guid.Parse("44A06217-58EC-4DCE-BB7D-5A951E2BEF9E"),
            //    IndicatorsId = Guid.Parse("b30b4027-a343-4855-904b-03372c5b7d08"),
            //    EquipmentsId = Guid.Parse("62bc02ca-1e01-4c1a-8599-e62429a05ade"),
            //    AbilityId = Guid.Parse("49ef925c-5b35-45c7-a6ca-e8330580f02c"),
            //    SpecialAbilityId = Guid.Parse("3d79772f-0da0-4b54-b421-5b91330a4009"),
            //    Baggages = new List<Baggage>(),
            //    Promises = new List<Promise>(),
            //});

            //seed data for MonsterSlayer Hero

            //modelBuilder.Entity<Indicator>().HasData(new Indicator
            //{
            //    Id = Guid.Parse("0f5a970a-e22f-4be4-8a42-3c5635879d92"),
            //    Health = 60,
            //    MentalEnergy = 20,
            //    MentalStrength = 6,
            //    Strength = 10,
            //    Dexterity = 6,
            //    Agility = 6,
            //    Evasion = 6,
            //    Endurance = 10,
            //    HeroId = Guid.Parse("a4616c1b-ba59-4d9a-8131-a1859bbb9e43")
            //});

            //modelBuilder.Entity<Ability>().HasData(new Ability
            //{
            //    Id = Guid.Parse("b9aed5b3-93a8-448e-9cd0-217780e3c69c"),
            //    Survival = false,
            //    Diplomacy = false,
            //    Climbing = false,
            //    Acrobatics = false,
            //    Skill = false,
            //    Guile = false,
            //    SecretKnowledge = false,
            //    Sneak = false,
            //    Elusion = false,
            //    WaterCycle = false,
            //    Melee = false,
            //    NatureSkills = false,
            //    BreakingLocks = false,
            //    Transformation = false,
            //    Spells = false,
            //    Rituals = false,
            //    Traps = false,
            //    Archery = false,
            //    ThrowingKnives = false,
            //    PoisonousNeedles = false,
            //    Stimulants = false,
            //    Wrestling = false,
            //    Observation = false,
            //    ShieldBearer = true,
            //    HeroId = Guid.Parse("a4616c1b-ba59-4d9a-8131-a1859bbb9e43")
            //});

            //modelBuilder.Entity<Armor>().HasData(new Armor
            //{
            //    Id = Guid.Parse("5e436105-a64c-494b-ba57-aa2236ece339"),
            //    ArmorType = "ChainMail",
            //    IsExist = true,
            //    Defence = 9,
            //    EquipmentId = Guid.Parse("8e635418-416b-4d61-89f8-e2c29609412e")
            //});

            //modelBuilder.Entity<Shield>().HasData(new Shield
            //{
            //    Id = Guid.Parse("91dce2e1-18fb-43d8-b441-ba388ee439bd"),
            //    ShieldType = "Heater",
            //    IsExist = true,
            //    Defence = 6,
            //    EquipmentId = Guid.Parse("8e635418-416b-4d61-89f8-e2c29609412e")
            //});

            //modelBuilder.Entity<Weapon>().HasData(new Weapon
            //{
            //    Id = Guid.Parse("9ff312ff-d17b-4713-9662-f69abdeff14c"),
            //    WeaponType = "WarHammer",
            //    IsExist = true,
            //    IsItTwoHandWeapon = false,
            //    Attack = 10,
            //    Defence = 1,
            //    Damage = 10,
            //    WeaponRange = 2,
            //    EquipmentId = Guid.Parse("8e635418-416b-4d61-89f8-e2c29609412e")
            //});

            //modelBuilder.Entity<ThrowingWeapon>().HasData(new ThrowingWeapon
            //{
            //    Id = Guid.Parse("5d5cf237-00ae-4f34-a1a2-4dca3b579279"),
            //    ThrowingWeaponType = "",
            //    IsExist = false,
            //    Attack = 0,
            //    Defence = 0,
            //    Damage = 0,
            //    Quantity = 0,
            //    ThrowingWeaponRange = 0,
            //    EquipmentId = Guid.Parse("8e635418-416b-4d61-89f8-e2c29609412e")
            //});

            //modelBuilder.Entity<Equipment>().HasData(new Equipment
            //{
            //    Id = Guid.Parse("8e635418-416b-4d61-89f8-e2c29609412e"),
            //    Knife = true,
            //    SmokeBall = false,
            //    Poison = false,
            //    MedicPack = true,
            //    MoneyBag = 100,
            //    HeroId = Guid.Parse("a4616c1b-ba59-4d9a-8131-a1859bbb9e43"),
            //    ArmorId = Guid.Parse("5e436105-a64c-494b-ba57-aa2236ece339"),
            //    ShieldId = Guid.Parse("91dce2e1-18fb-43d8-b441-ba388ee439bd"),
            //    WeaponId = Guid.Parse("9ff312ff-d17b-4713-9662-f69abdeff14c"),
            //    ThrowingWeaponId = Guid.Parse("5d5cf237-00ae-4f34-a1a2-4dca3b579279"),
            //    Talismans = new List<Talisman>()
            //});

            //modelBuilder.Entity<SpecialCombatSkill>().HasData(new SpecialCombatSkill
            //{
            //    Id = Guid.Parse("a05f95a2-1a2e-43cf-a9b9-06e179a681f5"),
            //    Name = "MonsterHunterSCS",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 4,
            //    SpecialAbilitiesId = Guid.Parse("910d2c5c-cc7f-4463-8fdb-01ccecf6dc20")
            //});

            //modelBuilder.Entity<Ultimate>().HasData(new Ultimate
            //{
            //    Id = Guid.Parse("c3c8daf7-520e-46d9-bf50-e72623aee449"),
            //    Name = "MonsterHunterUltimate",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 9,
            //    SpecialAbilitiesId = Guid.Parse("910d2c5c-cc7f-4463-8fdb-01ccecf6dc20")
            //});

            //modelBuilder.Entity<SpecialAbility>().HasData(new SpecialAbility
            //{
            //    Id = Guid.Parse("910d2c5c-cc7f-4463-8fdb-01ccecf6dc20"),
            //    SpecialCombatSkillId = Guid.Parse("a05f95a2-1a2e-43cf-a9b9-06e179a681f5"),
            //    UltimateId = Guid.Parse("c3c8daf7-520e-46d9-bf50-e72623aee449"),
            //    HeroId = Guid.Parse("a4616c1b-ba59-4d9a-8131-a1859bbb9e43"),
            //    Spells = new List<Spell>(),
            //    Rituals = new List<Ritual>(),
            //    NatureSkills = new List<NatureSkill>()
            //});

            //modelBuilder.Entity<Hero>().HasData(new Hero
            //{
            //    Id = Guid.Parse("a4616c1b-ba59-4d9a-8131-a1859bbb9e43"),
            //    Name = "MonsterSlayer",
            //    HeroClass = "MonsterSlayer",
            //    BaggageCapacity = 50.0,
            //    GroupWestId = Guid.Parse("44A06217-58EC-4DCE-BB7D-5A951E2BEF9E"),
            //    IndicatorsId = Guid.Parse("0f5a970a-e22f-4be4-8a42-3c5635879d92"),
            //    EquipmentsId = Guid.Parse("8e635418-416b-4d61-89f8-e2c29609412e"),
            //    AbilityId = Guid.Parse("b9aed5b3-93a8-448e-9cd0-217780e3c69c"),
            //    SpecialAbilityId = Guid.Parse("910d2c5c-cc7f-4463-8fdb-01ccecf6dc20"),
            //    Baggages = new List<Baggage>(),
            //    Promises = new List<Promise>(),
            //});

            //seed data for Acrobat Hero

            //modelBuilder.Entity<Indicator>().HasData(new Indicator
            //{
            //    Id = Guid.Parse("cb22a55c-33c7-4d95-aba2-df319f674d21"),
            //    Health = 60,
            //    MentalEnergy = 24,
            //    MentalStrength = 3,
            //    Strength = 5,
            //    Dexterity = 5,
            //    Agility = 12,
            //    Evasion = 7,
            //    Endurance = 8,
            //    HeroId = Guid.Parse("30db0c63-7526-42d1-bfeb-1bf4fd12fbbc")
            //});

            //modelBuilder.Entity<Ability>().HasData(new Ability
            //{
            //    Id = Guid.Parse("574e9188-d698-4b8f-9309-36f10db08d1c"),
            //    Survival = false,
            //    Diplomacy = false,
            //    Climbing = false,
            //    Acrobatics = true,
            //    Skill = false,
            //    Guile = false,
            //    SecretKnowledge = false,
            //    Sneak = false,
            //    Elusion = false,
            //    WaterCycle = false,
            //    Melee = false,
            //    NatureSkills = false,
            //    BreakingLocks = false,
            //    Transformation = true,
            //    Spells = false,
            //    Rituals = false,
            //    Traps = false,
            //    Archery = false,
            //    ThrowingKnives = false,
            //    PoisonousNeedles = false,
            //    Stimulants = false,
            //    Wrestling = false,
            //    Observation = false,
            //    ShieldBearer = false,
            //    HeroId = Guid.Parse("30db0c63-7526-42d1-bfeb-1bf4fd12fbbc")
            //});

            //modelBuilder.Entity<Armor>().HasData(new Armor
            //{
            //    Id = Guid.Parse("2fb8d39b-97cb-492a-aeb5-229b7c4a2274"),
            //    ArmorType = "Fabric",
            //    IsExist = true,
            //    Defence = 1,
            //    EquipmentId = Guid.Parse("1004649d-2d53-4ea4-bd88-6b8521dec22b")
            //});

            //modelBuilder.Entity<Shield>().HasData(new Shield
            //{
            //    Id = Guid.Parse("7a51fa8d-71c3-43b6-935c-3c2c51f05e6e"),
            //    ShieldType = "",
            //    IsExist = false,
            //    Defence = 0,
            //    EquipmentId = Guid.Parse("1004649d-2d53-4ea4-bd88-6b8521dec22b")
            //});

            //modelBuilder.Entity<Weapon>().HasData(new Weapon
            //{
            //    Id = Guid.Parse("305ba8d3-f1ed-4ec9-9404-d74489e65658"),
            //    WeaponType = "Saber",
            //    IsExist = true,
            //    IsItTwoHandWeapon = false,
            //    Attack = 9,
            //    Defence = 5,
            //    Damage = 9,
            //    WeaponRange = 2,
            //    EquipmentId = Guid.Parse("1004649d-2d53-4ea4-bd88-6b8521dec22b")
            //});

            //modelBuilder.Entity<ThrowingWeapon>().HasData(new ThrowingWeapon
            //{
            //    Id = Guid.Parse("7f38d2e1-8d71-4052-8bc4-8d693d7d5597"),
            //    ThrowingWeaponType = "",
            //    IsExist = false,
            //    Attack = 0,
            //    Defence = 0,
            //    Damage = 0,
            //    Quantity = 0,
            //    ThrowingWeaponRange = 0,
            //    EquipmentId = Guid.Parse("1004649d-2d53-4ea4-bd88-6b8521dec22b")
            //});

            //modelBuilder.Entity<Equipment>().HasData(new Equipment
            //{
            //    Id = Guid.Parse("1004649d-2d53-4ea4-bd88-6b8521dec22b"),
            //    Knife = true,
            //    SmokeBall = false,
            //    Poison = true,
            //    MedicPack = true,
            //    MoneyBag = 100,
            //    HeroId = Guid.Parse("30db0c63-7526-42d1-bfeb-1bf4fd12fbbc"),
            //    ArmorId = Guid.Parse("2fb8d39b-97cb-492a-aeb5-229b7c4a2274"),
            //    ShieldId = Guid.Parse("7a51fa8d-71c3-43b6-935c-3c2c51f05e6e"),
            //    WeaponId = Guid.Parse("305ba8d3-f1ed-4ec9-9404-d74489e65658"),
            //    ThrowingWeaponId = Guid.Parse("7f38d2e1-8d71-4052-8bc4-8d693d7d5597"),
            //    Talismans = new List<Talisman>()
            //});

            //modelBuilder.Entity<SpecialCombatSkill>().HasData(new SpecialCombatSkill
            //{
            //    Id = Guid.Parse("9bde1689-c4e5-4ca7-8d29-56b4480c9410"),
            //    Name = "AcrobatSCS",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 2,
            //    SpecialAbilitiesId = Guid.Parse("c027a89f-deb7-4fc5-999a-a71f1659bc7f")
            //});

            //modelBuilder.Entity<Ultimate>().HasData(new Ultimate
            //{
            //    Id = Guid.Parse("09580b14-12ef-42f3-930a-c85acce005e6"),
            //    Name = "AcrobatUltimate",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 7,
            //    SpecialAbilitiesId = Guid.Parse("c027a89f-deb7-4fc5-999a-a71f1659bc7f")
            //});

            //modelBuilder.Entity<SpecialAbility>().HasData(new SpecialAbility
            //{
            //    Id = Guid.Parse("c027a89f-deb7-4fc5-999a-a71f1659bc7f"),
            //    SpecialCombatSkillId = Guid.Parse("9bde1689-c4e5-4ca7-8d29-56b4480c9410"),
            //    UltimateId = Guid.Parse("09580b14-12ef-42f3-930a-c85acce005e6"),
            //    HeroId = Guid.Parse("30db0c63-7526-42d1-bfeb-1bf4fd12fbbc"),
            //    Spells = new List<Spell>(),
            //    Rituals = new List<Ritual>(),
            //    NatureSkills = new List<NatureSkill>()
            //});

            //modelBuilder.Entity<Hero>().HasData(new Hero
            //{
            //    Id = Guid.Parse("30db0c63-7526-42d1-bfeb-1bf4fd12fbbc"),
            //    Name = "Gigi",
            //    HeroClass = "Acrobat",
            //    BaggageCapacity = 50.0,
            //    GroupWestId = Guid.Parse("44A06217-58EC-4DCE-BB7D-5A951E2BEF9E"),
            //    IndicatorsId = Guid.Parse("cb22a55c-33c7-4d95-aba2-df319f674d21"),
            //    EquipmentsId = Guid.Parse("1004649d-2d53-4ea4-bd88-6b8521dec22b"),
            //    AbilityId = Guid.Parse("574e9188-d698-4b8f-9309-36f10db08d1c"),
            //    SpecialAbilityId = Guid.Parse("c027a89f-deb7-4fc5-999a-a71f1659bc7f"),
            //    Baggages = new List<Baggage>(),
            //    Promises = new List<Promise>(),
            //});

            //seed data for Merchant Hero

            //modelBuilder.Entity<Indicator>().HasData(new Indicator
            //{
            //    Id = Guid.Parse("c0931e47-6555-4593-ae67-331b28fa456a"),
            //    Health = 50,
            //    MentalEnergy = 20,
            //    MentalStrength = 5,
            //    Strength = 2,
            //    Dexterity = 10,
            //    Agility = 7,
            //    Evasion = 10,
            //    Endurance = 2,
            //    HeroId = Guid.Parse("e49a0977-591a-44f4-aa32-b42f97e4723e")
            //});

            //modelBuilder.Entity<Ability>().HasData(new Ability
            //{
            //    Id = Guid.Parse("8a944d71-7ef9-4da8-99d9-cf1e6d3a129b"),
            //    Survival = false,
            //    Diplomacy = false,
            //    Climbing = false,
            //    Acrobatics = false,
            //    Skill = false,
            //    Guile = true,
            //    SecretKnowledge = false,
            //    Sneak = false,
            //    Elusion = false,
            //    WaterCycle = false,
            //    Melee = false,
            //    NatureSkills = false,
            //    BreakingLocks = false,
            //    Transformation = false,
            //    Spells = false,
            //    Rituals = false,
            //    Traps = false,
            //    Archery = false,
            //    ThrowingKnives = false,
            //    PoisonousNeedles = false,
            //    Stimulants = false,
            //    Wrestling = false,
            //    Observation = true,
            //    ShieldBearer = false,
            //    HeroId = Guid.Parse("e49a0977-591a-44f4-aa32-b42f97e4723e")
            //});

            //modelBuilder.Entity<Armor>().HasData(new Armor
            //{
            //    Id = Guid.Parse("5e64ef68-942e-405a-bad4-0075b53db464"),
            //    ArmorType = "Fabric",
            //    IsExist = true,
            //    Defence = 1,
            //    EquipmentId = Guid.Parse("dafd7d85-068d-4833-bb8e-586ae86f532e")
            //});

            //modelBuilder.Entity<Shield>().HasData(new Shield
            //{
            //    Id = Guid.Parse("7974b3cf-0dfc-4038-ae30-c5bd88bda48c"),
            //    ShieldType = "",
            //    IsExist = false,
            //    Defence = 0,
            //    EquipmentId = Guid.Parse("dafd7d85-068d-4833-bb8e-586ae86f532e")
            //});

            //modelBuilder.Entity<Weapon>().HasData(new Weapon
            //{
            //    Id = Guid.Parse("2b36d35c-10e9-4e4b-8747-948a3f4573cd"),
            //    WeaponType = "Rapier",
            //    IsExist = true,
            //    IsItTwoHandWeapon = false,
            //    Attack = 9,
            //    Defence = 5,
            //    Damage = 8,
            //    WeaponRange = 2,
            //    EquipmentId = Guid.Parse("dafd7d85-068d-4833-bb8e-586ae86f532e")
            //});

            //modelBuilder.Entity<ThrowingWeapon>().HasData(new ThrowingWeapon
            //{
            //    Id = Guid.Parse("6ee15efd-f405-4cf0-91de-5b90ece07dbc"),
            //    ThrowingWeaponType = "",
            //    IsExist = false,
            //    Attack = 0,
            //    Defence = 0,
            //    Damage = 0,
            //    Quantity = 0,
            //    ThrowingWeaponRange = 0,
            //    EquipmentId = Guid.Parse("dafd7d85-068d-4833-bb8e-586ae86f532e")
            //});

            //modelBuilder.Entity<Equipment>().HasData(new Equipment
            //{
            //    Id = Guid.Parse("dafd7d85-068d-4833-bb8e-586ae86f532e"),
            //    Knife = true,
            //    SmokeBall = false,
            //    Poison = false,
            //    MedicPack = false,
            //    MoneyBag = 200,
            //    HeroId = Guid.Parse("e49a0977-591a-44f4-aa32-b42f97e4723e"),
            //    ArmorId = Guid.Parse("5e64ef68-942e-405a-bad4-0075b53db464"),
            //    ShieldId = Guid.Parse("7974b3cf-0dfc-4038-ae30-c5bd88bda48c"),
            //    WeaponId = Guid.Parse("2b36d35c-10e9-4e4b-8747-948a3f4573cd"),
            //    ThrowingWeaponId = Guid.Parse("6ee15efd-f405-4cf0-91de-5b90ece07dbc"),
            //    Talismans = new List<Talisman>()
            //});

            //modelBuilder.Entity<SpecialCombatSkill>().HasData(new SpecialCombatSkill
            //{
            //    Id = Guid.Parse("81152f9c-25de-4544-8c37-a0288960dba6"),
            //    Name = "MerchantSCS",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 2,
            //    SpecialAbilitiesId = Guid.Parse("8c6d2f89-40a6-46da-b68b-cd4c12f5ee6d")
            //});

            //modelBuilder.Entity<Ultimate>().HasData(new Ultimate
            //{
            //    Id = Guid.Parse("686d8bc0-b470-4e52-b202-0224796f2e0e"),
            //    Name = "MerchantUltimate",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 7,
            //    SpecialAbilitiesId = Guid.Parse("8c6d2f89-40a6-46da-b68b-cd4c12f5ee6d")
            //});

            //modelBuilder.Entity<SpecialAbility>().HasData(new SpecialAbility
            //{
            //    Id = Guid.Parse("8c6d2f89-40a6-46da-b68b-cd4c12f5ee6d"),
            //    SpecialCombatSkillId = Guid.Parse("81152f9c-25de-4544-8c37-a0288960dba6"),
            //    UltimateId = Guid.Parse("686d8bc0-b470-4e52-b202-0224796f2e0e"),
            //    HeroId = Guid.Parse("e49a0977-591a-44f4-aa32-b42f97e4723e"),
            //    Spells = new List<Spell>(),
            //    Rituals = new List<Ritual>(),
            //    NatureSkills = new List<NatureSkill>()
            //});

            //modelBuilder.Entity<Hero>().HasData(new Hero
            //{
            //    Id = Guid.Parse("e49a0977-591a-44f4-aa32-b42f97e4723e"),
            //    Name = "KirguainTheThird",
            //    HeroClass = "Merchant",
            //    BaggageCapacity = 40.0,
            //    GroupWestId = Guid.Parse("44A06217-58EC-4DCE-BB7D-5A951E2BEF9E"),
            //    IndicatorsId = Guid.Parse("c0931e47-6555-4593-ae67-331b28fa456a"),
            //    EquipmentsId = Guid.Parse("dafd7d85-068d-4833-bb8e-586ae86f532e"),
            //    AbilityId = Guid.Parse("8a944d71-7ef9-4da8-99d9-cf1e6d3a129b"),
            //    SpecialAbilityId = Guid.Parse("8c6d2f89-40a6-46da-b68b-cd4c12f5ee6d"),
            //    Baggages = new List<Baggage>(),
            //    Promises = new List<Promise>(),
            //});

            //seed data for Thief Hero

            //modelBuilder.Entity<Indicator>().HasData(new Indicator
            //{
            //    Id = Guid.Parse("ef796426-a3bc-4654-bea3-c89866dc685c"),
            //    Health = 50,
            //    MentalEnergy = 24,
            //    MentalStrength = 5,
            //    Strength = 4,
            //    Dexterity = 5,
            //    Agility = 8,
            //    Evasion = 12,
            //    Endurance = 6,
            //    HeroId = Guid.Parse("099fb0a9-f3e7-4565-b2f6-86fe0667b457")
            //});

            //modelBuilder.Entity<Ability>().HasData(new Ability
            //{
            //    Id = Guid.Parse("66277117-ea3b-409a-9b09-a6433405a439"),
            //    Survival = false,
            //    Diplomacy = false,
            //    Climbing = true,
            //    Acrobatics = false,
            //    Skill = false,
            //    Guile = false,
            //    SecretKnowledge = false,
            //    Sneak = true,
            //    Elusion = false,
            //    WaterCycle = false,
            //    Melee = false,
            //    NatureSkills = false,
            //    BreakingLocks = true,
            //    Transformation = false,
            //    Spells = false,
            //    Rituals = false,
            //    Traps = false,
            //    Archery = false,
            //    ThrowingKnives = false,
            //    PoisonousNeedles = false,
            //    Stimulants = false,
            //    Wrestling = false,
            //    Observation = false,
            //    ShieldBearer = false,
            //    HeroId = Guid.Parse("099fb0a9-f3e7-4565-b2f6-86fe0667b457")
            //});

            //modelBuilder.Entity<Armor>().HasData(new Armor
            //{
            //    Id = Guid.Parse("2d6dd0ec-7003-418b-b19f-0bea1521c0bc"),
            //    ArmorType = "Leather",
            //    IsExist = true,
            //    Defence = 3,
            //    EquipmentId = Guid.Parse("f160750e-ccc8-4ddf-8dee-d9989d86b941")
            //});

            //modelBuilder.Entity<Shield>().HasData(new Shield
            //{
            //    Id = Guid.Parse("a39432d6-3571-4ad2-8388-1fb88e626eee"),
            //    ShieldType = "",
            //    IsExist = false,
            //    Defence = 0,
            //    EquipmentId = Guid.Parse("f160750e-ccc8-4ddf-8dee-d9989d86b941")
            //});

            //modelBuilder.Entity<Weapon>().HasData(new Weapon
            //{
            //    Id = Guid.Parse("dadf105d-04f4-42b2-a946-65284f17a83e"),
            //    WeaponType = "Dagger",
            //    IsExist = true,
            //    IsItTwoHandWeapon = false,
            //    Attack = 7,
            //    Defence = 2,
            //    Damage = 7,
            //    WeaponRange = 1,
            //    EquipmentId = Guid.Parse("f160750e-ccc8-4ddf-8dee-d9989d86b941")
            //});

            //modelBuilder.Entity<ThrowingWeapon>().HasData(new ThrowingWeapon
            //{
            //    Id = Guid.Parse("974e987a-9d3c-42d6-9ee9-b98b266d46a0"),
            //    ThrowingWeaponType = "",
            //    IsExist = false,
            //    Attack = 0,
            //    Defence = 0,
            //    Damage = 0,
            //    Quantity = 0,
            //    ThrowingWeaponRange = 0,
            //    EquipmentId = Guid.Parse("f160750e-ccc8-4ddf-8dee-d9989d86b941")
            //});

            //modelBuilder.Entity<Equipment>().HasData(new Equipment
            //{
            //    Id = Guid.Parse("f160750e-ccc8-4ddf-8dee-d9989d86b941"),
            //    Knife = false,
            //    SmokeBall = false,
            //    Poison = true,
            //    MedicPack = false,
            //    MoneyBag = 100,
            //    HeroId = Guid.Parse("099fb0a9-f3e7-4565-b2f6-86fe0667b457"),
            //    ArmorId = Guid.Parse("2d6dd0ec-7003-418b-b19f-0bea1521c0bc"),
            //    ShieldId = Guid.Parse("a39432d6-3571-4ad2-8388-1fb88e626eee"),
            //    WeaponId = Guid.Parse("dadf105d-04f4-42b2-a946-65284f17a83e"),
            //    ThrowingWeaponId = Guid.Parse("974e987a-9d3c-42d6-9ee9-b98b266d46a0"),
            //    Talismans = new List<Talisman>()
            //});

            //modelBuilder.Entity<SpecialCombatSkill>().HasData(new SpecialCombatSkill
            //{
            //    Id = Guid.Parse("482755fa-b4d4-4046-b789-709e588909b3"),
            //    Name = "ThiefSCS",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 3,
            //    SpecialAbilitiesId = Guid.Parse("e7bc34c7-97f2-4635-9f33-ced703eb4f99")
            //});

            //modelBuilder.Entity<Ultimate>().HasData(new Ultimate
            //{
            //    Id = Guid.Parse("73a071b6-530b-48f6-8d03-80d913cafb67"),
            //    Name = "ThiefUltimate",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 9,
            //    SpecialAbilitiesId = Guid.Parse("e7bc34c7-97f2-4635-9f33-ced703eb4f99")
            //});

            //modelBuilder.Entity<SpecialAbility>().HasData(new SpecialAbility
            //{
            //    Id = Guid.Parse("e7bc34c7-97f2-4635-9f33-ced703eb4f99"),
            //    SpecialCombatSkillId = Guid.Parse("482755fa-b4d4-4046-b789-709e588909b3"),
            //    UltimateId = Guid.Parse("73a071b6-530b-48f6-8d03-80d913cafb67"),
            //    HeroId = Guid.Parse("099fb0a9-f3e7-4565-b2f6-86fe0667b457"),
            //    Spells = new List<Spell>(),
            //    Rituals = new List<Ritual>(),
            //    NatureSkills = new List<NatureSkill>()
            //});

            //modelBuilder.Entity<Hero>().HasData(new Hero
            //{
            //    Id = Guid.Parse("099fb0a9-f3e7-4565-b2f6-86fe0667b457"),
            //    Name = "TheSonOfTheShadow",
            //    HeroClass = "Thief",
            //    BaggageCapacity = 40.0,
            //    GroupWestId = Guid.Parse("44A06217-58EC-4DCE-BB7D-5A951E2BEF9E"),
            //    IndicatorsId = Guid.Parse("ef796426-a3bc-4654-bea3-c89866dc685c"),
            //    EquipmentsId = Guid.Parse("f160750e-ccc8-4ddf-8dee-d9989d86b941"),
            //    AbilityId = Guid.Parse("66277117-ea3b-409a-9b09-a6433405a439"),
            //    SpecialAbilityId = Guid.Parse("e7bc34c7-97f2-4635-9f33-ced703eb4f99"),
            //    Baggages = new List<Baggage>(),
            //    Promises = new List<Promise>(),
            //});

            //seed data for Missionary Hero

            //modelBuilder.Entity<Indicator>().HasData(new Indicator
            //{
            //    Id = Guid.Parse("ac91c453-48e4-4852-b3f8-2c4790ff2a34"),
            //    Health = 60,
            //    MentalEnergy = 28,
            //    MentalStrength = 10,
            //    Strength = 5,
            //    Dexterity = 4,
            //    Agility = 10,
            //    Evasion = 7,
            //    Endurance = 4,
            //    HeroId = Guid.Parse("2438f748-935a-498f-b7fd-fcffcb6ca327")
            //});

            //modelBuilder.Entity<Ability>().HasData(new Ability
            //{
            //    Id = Guid.Parse("1e3c754b-4283-4625-b709-b273d1b2611d"),
            //    Survival = false,
            //    Diplomacy = true,
            //    Climbing = false,
            //    Acrobatics = false,
            //    Skill = false,
            //    Guile = false,
            //    SecretKnowledge = false,
            //    Sneak = false,
            //    Elusion = false,
            //    WaterCycle = false,
            //    Melee = false,
            //    NatureSkills = true,
            //    BreakingLocks = false,
            //    Transformation = false,
            //    Spells = false,
            //    Rituals = false,
            //    Traps = false,
            //    Archery = false,
            //    ThrowingKnives = false,
            //    PoisonousNeedles = false,
            //    Stimulants = false,
            //    Wrestling = false,
            //    Observation = false,
            //    ShieldBearer = false,
            //    HeroId = Guid.Parse("2438f748-935a-498f-b7fd-fcffcb6ca327")
            //});

            //modelBuilder.Entity<Armor>().HasData(new Armor
            //{
            //    Id = Guid.Parse("805e00c3-098f-4a0e-bff8-d8d3ce8147b2"),
            //    ArmorType = "Fabric",
            //    IsExist = true,
            //    Defence = 1,
            //    EquipmentId = Guid.Parse("00e3ea88-62ae-48b8-b46f-7ac191f23be0")
            //});

            //modelBuilder.Entity<Shield>().HasData(new Shield
            //{
            //    Id = Guid.Parse("d547a5a6-cc53-4dfc-a7b3-3f99f2c74fb4"),
            //    ShieldType = "",
            //    IsExist = false,
            //    Defence = 0,
            //    EquipmentId = Guid.Parse("00e3ea88-62ae-48b8-b46f-7ac191f23be0")
            //});

            //modelBuilder.Entity<Weapon>().HasData(new Weapon
            //{
            //    Id = Guid.Parse("ff50b848-19ba-412e-8a8f-f813059017be"),
            //    WeaponType = "WarClub",
            //    IsExist = true,
            //    IsItTwoHandWeapon = true,
            //    Attack = 8,
            //    Defence = 4,
            //    Damage = 8,
            //    WeaponRange = 3,
            //    EquipmentId = Guid.Parse("00e3ea88-62ae-48b8-b46f-7ac191f23be0")
            //});

            //modelBuilder.Entity<ThrowingWeapon>().HasData(new ThrowingWeapon
            //{
            //    Id = Guid.Parse("c6203e74-b9b1-497a-8252-292c63b8ab5e"),
            //    ThrowingWeaponType = "",
            //    IsExist = false,
            //    Attack = 0,
            //    Defence = 0,
            //    Damage = 0,
            //    Quantity = 0,
            //    ThrowingWeaponRange = 0,
            //    EquipmentId = Guid.Parse("00e3ea88-62ae-48b8-b46f-7ac191f23be0")
            //});

            //modelBuilder.Entity<Equipment>().HasData(new Equipment
            //{
            //    Id = Guid.Parse("00e3ea88-62ae-48b8-b46f-7ac191f23be0"),
            //    Knife = true,
            //    SmokeBall = false,
            //    Poison = false,
            //    MedicPack = true,
            //    MoneyBag = 100,
            //    HeroId = Guid.Parse("2438f748-935a-498f-b7fd-fcffcb6ca327"),
            //    ArmorId = Guid.Parse("805e00c3-098f-4a0e-bff8-d8d3ce8147b2"),
            //    ShieldId = Guid.Parse("d547a5a6-cc53-4dfc-a7b3-3f99f2c74fb4"),
            //    WeaponId = Guid.Parse("ff50b848-19ba-412e-8a8f-f813059017be"),
            //    ThrowingWeaponId = Guid.Parse("c6203e74-b9b1-497a-8252-292c63b8ab5e"),
            //    Talismans = new List<Talisman>()
            //});

            //modelBuilder.Entity<SpecialCombatSkill>().HasData(new SpecialCombatSkill
            //{
            //    Id = Guid.Parse("2cdac5a5-3fbd-4cb2-b6a6-211bf517086a"),
            //    Name = "MissionarySCS",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 4,
            //    SpecialAbilitiesId = Guid.Parse("c191dbd6-ddb0-4152-98bf-90985e047dda")
            //});

            //modelBuilder.Entity<Ultimate>().HasData(new Ultimate
            //{
            //    Id = Guid.Parse("cbdc5cd3-331c-49af-97c5-3a1ec77a3af2"),
            //    Name = "MissionaryUltimate",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 8,
            //    SpecialAbilitiesId = Guid.Parse("c191dbd6-ddb0-4152-98bf-90985e047dda")
            //});

            //modelBuilder.Entity<SpecialAbility>().HasData(new SpecialAbility
            //{
            //    Id = Guid.Parse("c191dbd6-ddb0-4152-98bf-90985e047dda"),
            //    SpecialCombatSkillId = Guid.Parse("2cdac5a5-3fbd-4cb2-b6a6-211bf517086a"),
            //    UltimateId = Guid.Parse("cbdc5cd3-331c-49af-97c5-3a1ec77a3af2"),
            //    HeroId = Guid.Parse("2438f748-935a-498f-b7fd-fcffcb6ca327"),
            //    Spells = new List<Spell>(),
            //    Rituals = new List<Ritual>(),
            //    NatureSkills = new List<NatureSkill>()
            //});

            //modelBuilder.Entity<Hero>().HasData(new Hero
            //{
            //    Id = Guid.Parse("2438f748-935a-498f-b7fd-fcffcb6ca327"),
            //    Name = "AbrakanaMaye",
            //    HeroClass = "Missionary",
            //    BaggageCapacity = 50.0,
            //    GroupWestId = Guid.Parse("44A06217-58EC-4DCE-BB7D-5A951E2BEF9E"),
            //    IndicatorsId = Guid.Parse("ac91c453-48e4-4852-b3f8-2c4790ff2a34"),
            //    EquipmentsId = Guid.Parse("00e3ea88-62ae-48b8-b46f-7ac191f23be0"),
            //    AbilityId = Guid.Parse("1e3c754b-4283-4625-b709-b273d1b2611d"),
            //    SpecialAbilityId = Guid.Parse("c191dbd6-ddb0-4152-98bf-90985e047dda"),
            //    Baggages = new List<Baggage>(),
            //    Promises = new List<Promise>(),
            //});

            //seed data for Magician Hero

            //modelBuilder.Entity<Indicator>().HasData(new Indicator
            //{
            //    Id = Guid.Parse("e9cecc35-e7a9-4f14-bb71-50071b091136"),
            //    Health = 50,
            //    MentalEnergy = 32,
            //    MentalStrength = 12,
            //    Strength = 3,
            //    Dexterity = 3,
            //    Agility = 7,
            //    Evasion = 8,
            //    Endurance = 3,
            //    HeroId = Guid.Parse("b29a383e-4152-41b4-8ab6-64c23a9532bf")
            //});

            //modelBuilder.Entity<Ability>().HasData(new Ability
            //{
            //    Id = Guid.Parse("22e845c2-517e-435d-b17e-9ec48a9eb85d"),
            //    Survival = false,
            //    Diplomacy = false,
            //    Climbing = false,
            //    Acrobatics = false,
            //    Skill = false,
            //    Guile = false,
            //    SecretKnowledge = true,
            //    Sneak = false,
            //    Elusion = false,
            //    WaterCycle = false,
            //    Melee = false,
            //    NatureSkills = false,
            //    BreakingLocks = false,
            //    Transformation = false,
            //    Spells = true,
            //    Rituals = false,
            //    Traps = false,
            //    Archery = false,
            //    ThrowingKnives = false,
            //    PoisonousNeedles = false,
            //    Stimulants = false,
            //    Wrestling = false,
            //    Observation = false,
            //    ShieldBearer = false,
            //    HeroId = Guid.Parse("b29a383e-4152-41b4-8ab6-64c23a9532bf")
            //});

            //modelBuilder.Entity<Armor>().HasData(new Armor
            //{
            //    Id = Guid.Parse("ae69aafb-ebc1-4ce2-9042-974b91487845"),
            //    ArmorType = "Leather",
            //    IsExist = true,
            //    Defence = 3,
            //    EquipmentId = Guid.Parse("a12e8407-4c24-46fe-a2f6-6134fb874131")
            //});

            //modelBuilder.Entity<Shield>().HasData(new Shield
            //{
            //    Id = Guid.Parse("9013b479-3cbc-43e8-8206-4929d3654a4d"),
            //    ShieldType = "",
            //    IsExist = false,
            //    Defence = 0,
            //    EquipmentId = Guid.Parse("a12e8407-4c24-46fe-a2f6-6134fb874131")
            //});

            //modelBuilder.Entity<Weapon>().HasData(new Weapon
            //{
            //    Id = Guid.Parse("f6814c17-062a-41e0-b06f-83d62a8e9558"),
            //    WeaponType = "Scepter",
            //    IsExist = true,
            //    IsItTwoHandWeapon = false,
            //    Attack = 7,
            //    Defence = 3,
            //    Damage = 7,
            //    WeaponRange = 1,
            //    EquipmentId = Guid.Parse("a12e8407-4c24-46fe-a2f6-6134fb874131")
            //});

            //modelBuilder.Entity<ThrowingWeapon>().HasData(new ThrowingWeapon
            //{
            //    Id = Guid.Parse("1e73f091-d0e6-41d1-b229-3559c4a609f8"),
            //    ThrowingWeaponType = "",
            //    IsExist = false,
            //    Attack = 0,
            //    Defence = 0,
            //    Damage = 0,
            //    Quantity = 0,
            //    ThrowingWeaponRange = 0,
            //    EquipmentId = Guid.Parse("a12e8407-4c24-46fe-a2f6-6134fb874131")
            //});

            //modelBuilder.Entity<Equipment>().HasData(new Equipment
            //{
            //    Id = Guid.Parse("a12e8407-4c24-46fe-a2f6-6134fb874131"),
            //    Knife = true,
            //    SmokeBall = false,
            //    Poison = false,
            //    MedicPack = false,
            //    MoneyBag = 100,
            //    HeroId = Guid.Parse("b29a383e-4152-41b4-8ab6-64c23a9532bf"),
            //    ArmorId = Guid.Parse("ae69aafb-ebc1-4ce2-9042-974b91487845"),
            //    ShieldId = Guid.Parse("9013b479-3cbc-43e8-8206-4929d3654a4d"),
            //    WeaponId = Guid.Parse("f6814c17-062a-41e0-b06f-83d62a8e9558"),
            //    ThrowingWeaponId = Guid.Parse("1e73f091-d0e6-41d1-b229-3559c4a609f8"),
            //    Talismans = new List<Talisman>()
            //});

            //modelBuilder.Entity<SpecialCombatSkill>().HasData(new SpecialCombatSkill
            //{
            //    Id = Guid.Parse("9c8d14a7-814b-43d7-860a-28fd9ab68e6f"),
            //    Name = "MagicianSCS",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 5,
            //    SpecialAbilitiesId = Guid.Parse("4088458b-2479-40aa-a09a-030fcc066d49")
            //});

            //modelBuilder.Entity<Ultimate>().HasData(new Ultimate
            //{
            //    Id = Guid.Parse("a6ef3799-1711-4436-9ef6-f23b7efe3e28"),
            //    Name = "MagicianUltimate",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 10,
            //    SpecialAbilitiesId = Guid.Parse("4088458b-2479-40aa-a09a-030fcc066d49")
            //});

            //modelBuilder.Entity<SpecialAbility>().HasData(new SpecialAbility
            //{
            //    Id = Guid.Parse("4088458b-2479-40aa-a09a-030fcc066d49"),
            //    SpecialCombatSkillId = Guid.Parse("9c8d14a7-814b-43d7-860a-28fd9ab68e6f"),
            //    UltimateId = Guid.Parse("a6ef3799-1711-4436-9ef6-f23b7efe3e28"),
            //    HeroId = Guid.Parse("b29a383e-4152-41b4-8ab6-64c23a9532bf"),
            //    Spells = new List<Spell>(),
            //    Rituals = new List<Ritual>(),
            //    NatureSkills = new List<NatureSkill>()
            //});

            //modelBuilder.Entity<Hero>().HasData(new Hero
            //{
            //    Id = Guid.Parse("b29a383e-4152-41b4-8ab6-64c23a9532bf"),
            //    Name = "Lusiferat",
            //    HeroClass = "Magician",
            //    BaggageCapacity = 40.0,
            //    GroupWestId = Guid.Parse("44A06217-58EC-4DCE-BB7D-5A951E2BEF9E"),
            //    IndicatorsId = Guid.Parse("e9cecc35-e7a9-4f14-bb71-50071b091136"),
            //    EquipmentsId = Guid.Parse("a12e8407-4c24-46fe-a2f6-6134fb874131"),
            //    AbilityId = Guid.Parse("22e845c2-517e-435d-b17e-9ec48a9eb85d"),
            //    SpecialAbilityId = Guid.Parse("4088458b-2479-40aa-a09a-030fcc066d49"),
            //    Baggages = new List<Baggage>(),
            //    Promises = new List<Promise>(),
            //});

            //seed data for Librarian Hero

            //modelBuilder.Entity<Indicator>().HasData(new Indicator
            //{
            //    Id = Guid.Parse("f5d58a29-83c4-48f4-8a92-b75f03961b5d"),
            //    Health = 50,
            //    MentalEnergy = 32,
            //    MentalStrength = 10,
            //    Strength = 5,
            //    Dexterity = 6,
            //    Agility = 7,
            //    Evasion = 10,
            //    Endurance = 2,
            //    HeroId = Guid.Parse("276d4957-0a26-4748-8c9e-793b33165a46")
            //});

            //modelBuilder.Entity<Ability>().HasData(new Ability
            //{
            //    Id = Guid.Parse("00832bf5-8bab-4077-afd3-e18970e043e2"),
            //    Survival = false,
            //    Diplomacy = false,
            //    Climbing = false,
            //    Acrobatics = false,
            //    Skill = false,
            //    Guile = false,
            //    SecretKnowledge = true,
            //    Sneak = false,
            //    Elusion = false,
            //    WaterCycle = false,
            //    Melee = false,
            //    NatureSkills = false,
            //    BreakingLocks = false,
            //    Transformation = false,
            //    Spells = false,
            //    Rituals = true,
            //    Traps = false,
            //    Archery = false,
            //    ThrowingKnives = false,
            //    PoisonousNeedles = false,
            //    Stimulants = false,
            //    Wrestling = false,
            //    Observation = false,
            //    ShieldBearer = false,
            //    HeroId = Guid.Parse("276d4957-0a26-4748-8c9e-793b33165a46")
            //});

            //modelBuilder.Entity<Armor>().HasData(new Armor
            //{
            //    Id = Guid.Parse("29aecc99-698f-4d6e-a378-6715a3a1394e"),
            //    ArmorType = "IronBreastplate",
            //    IsExist = true,
            //    Defence = 7,
            //    EquipmentId = Guid.Parse("62d75779-d8c2-4006-bdaa-94739a76f04c")
            //});

            //modelBuilder.Entity<Shield>().HasData(new Shield
            //{
            //    Id = Guid.Parse("850f6bc5-f24e-441c-910b-ec3f3da4430f"),
            //    ShieldType = "",
            //    IsExist = false,
            //    Defence = 0,
            //    EquipmentId = Guid.Parse("62d75779-d8c2-4006-bdaa-94739a76f04c")
            //});

            //modelBuilder.Entity<Weapon>().HasData(new Weapon
            //{
            //    Id = Guid.Parse("427b9b64-5c01-4ded-bd84-af4848658040"),
            //    WeaponType = "ShortSword",
            //    IsExist = true,
            //    IsItTwoHandWeapon = false,
            //    Attack = 8,
            //    Defence = 4,
            //    Damage = 8,
            //    WeaponRange = 2,
            //    EquipmentId = Guid.Parse("62d75779-d8c2-4006-bdaa-94739a76f04c")
            //});

            //modelBuilder.Entity<ThrowingWeapon>().HasData(new ThrowingWeapon
            //{
            //    Id = Guid.Parse("60aeb917-3b3f-42bb-98ab-beb25bc931fb"),
            //    ThrowingWeaponType = "",
            //    IsExist = false,
            //    Attack = 0,
            //    Defence = 0,
            //    Damage = 0,
            //    Quantity = 0,
            //    ThrowingWeaponRange = 0,
            //    EquipmentId = Guid.Parse("62d75779-d8c2-4006-bdaa-94739a76f04c")
            //});

            //modelBuilder.Entity<Equipment>().HasData(new Equipment
            //{
            //    Id = Guid.Parse("62d75779-d8c2-4006-bdaa-94739a76f04c"),
            //    Knife = true,
            //    SmokeBall = false,
            //    Poison = true,
            //    MedicPack = true,
            //    MoneyBag = 100,
            //    HeroId = Guid.Parse("276d4957-0a26-4748-8c9e-793b33165a46"),
            //    ArmorId = Guid.Parse("29aecc99-698f-4d6e-a378-6715a3a1394e"),
            //    ShieldId = Guid.Parse("850f6bc5-f24e-441c-910b-ec3f3da4430f"),
            //    WeaponId = Guid.Parse("427b9b64-5c01-4ded-bd84-af4848658040"),
            //    ThrowingWeaponId = Guid.Parse("60aeb917-3b3f-42bb-98ab-beb25bc931fb"),
            //    Talismans = new List<Talisman>()
            //});

            //modelBuilder.Entity<SpecialCombatSkill>().HasData(new SpecialCombatSkill
            //{
            //    Id = Guid.Parse("5a22a248-91d9-4f30-8624-77aaec53d1d2"),
            //    Name = "LibrarianSCS",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 4,
            //    SpecialAbilitiesId = Guid.Parse("36853c17-c335-4135-b692-142f5468b5a3")
            //});

            //modelBuilder.Entity<Ultimate>().HasData(new Ultimate
            //{
            //    Id = Guid.Parse("a745e595-02ae-424d-bf07-4b5ab368c53a"),
            //    Name = "LibrarianUltimate",
            //    SkillLevel = 1,
            //    RequiredMentalEnergy = 8,
            //    SpecialAbilitiesId = Guid.Parse("36853c17-c335-4135-b692-142f5468b5a3")
            //});

            //modelBuilder.Entity<SpecialAbility>().HasData(new SpecialAbility
            //{
            //    Id = Guid.Parse("36853c17-c335-4135-b692-142f5468b5a3"),
            //    SpecialCombatSkillId = Guid.Parse("5a22a248-91d9-4f30-8624-77aaec53d1d2"),
            //    UltimateId = Guid.Parse("a745e595-02ae-424d-bf07-4b5ab368c53a"),
            //    HeroId = Guid.Parse("276d4957-0a26-4748-8c9e-793b33165a46"),
            //    Spells = new List<Spell>(),
            //    Rituals = new List<Ritual>(),
            //    NatureSkills = new List<NatureSkill>()
            //});

            //modelBuilder.Entity<Hero>().HasData(new Hero
            //{
            //    Id = Guid.Parse("276d4957-0a26-4748-8c9e-793b33165a46"),
            //    Name = "Rhamzeda",
            //    HeroClass = "Librarian",
            //    BaggageCapacity = 45.0,
            //    GroupWestId = Guid.Parse("44A06217-58EC-4DCE-BB7D-5A951E2BEF9E"),
            //    IndicatorsId = Guid.Parse("f5d58a29-83c4-48f4-8a92-b75f03961b5d"),
            //    EquipmentsId = Guid.Parse("62d75779-d8c2-4006-bdaa-94739a76f04c"),
            //    AbilityId = Guid.Parse("00832bf5-8bab-4077-afd3-e18970e043e2"),
            //    SpecialAbilityId = Guid.Parse("36853c17-c335-4135-b692-142f5468b5a3"),
            //    Baggages = new List<Baggage>(),
            //    Promises = new List<Promise>(),
            //});

            //seed data for Basic Admin User

            //modelBuilder.Entity<AditionalPoint>().HasData(new AditionalPoint
            //{
            //    Id = Guid.Parse("3fe3097b-07f0-4060-92ef-9b16e32bcebb"),
            //    TeamGame = 0,
            //    ImportantInformation = 0,
            //    SlainMonsters = 0,
            //    Morals = 0,
            //    Cover = 0,
            //    GroupWestId = Guid.Parse("44A06217-58EC-4DCE-BB7D-5A951E2BEF9E"),
            //    BattleGroups = new List<BattleGroup>(),
            //    Negotiations = new List<Negotiation>()
            //});

            //modelBuilder.Entity<GroupWest>().HasData(new GroupWest
            //{
            //    Id = Guid.Parse("44A06217-58EC-4DCE-BB7D-5A951E2BEF9E"),
            //    ActualMission = "",
            //    UserId = Guid.Parse("0a9e125e-9701-4160-9a51-89a56c6fbeda"),
            //    AditionalPointsId = Guid.Parse("3fe3097b-07f0-4060-92ef-9b16e32bcebb"),
            //    Missions = new List<Mission>(),
            //    Heroes = new List<Hero>()
            //});

            //modelBuilder.Entity<User>().HasData(new User
            //{
            //    Id = Guid.Parse("0a9e125e-9701-4160-9a51-89a56c6fbeda"),
            //    CurrentUserEmail = "",
            //    RedimelId = Guid.Parse("929f57b4-ded0-483f-bdd5-1a4dcf30194b"),
            //    GroupWestId = Guid.Parse("44A06217-58EC-4DCE-BB7D-5A951E2BEF9E")
            //});






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
