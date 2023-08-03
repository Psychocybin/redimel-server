using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using redimel_server.Models.Domain;

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
                WeaponType = "TwoHand",
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
                HeroClass = "Barbarian",
                BaggageCapacity = 60.0,
                GroupWestId = Guid.Parse("44a06217-58ec-4dce-bb7d-5a951e2bef9e"),
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
                WeaponType = "OneHand",
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
                GroupWestId = Guid.Parse("44a06217-58ec-4dce-bb7d-5a951e2bef9e"),
                IndicatorsId = Guid.Parse("697d4622-b4d9-4b71-85e8-a81bbcd7c0a4"),
                EquipmentsId = Guid.Parse("6d6e49e8-84b4-4a11-b8f8-c1613e97479a"),
                AbilityId = Guid.Parse("0bd3e733-dcf3-40a3-8f90-e965a72687fd"),
                SpecialAbilityId = Guid.Parse("eb521bf8-1f0e-43da-bfaf-82750308b629"),
                Baggages = new List<Baggage>(),
                Promises = new List<Promise>(),
            });

            //seed data for GroupWest

            modelBuilder.Entity<AditionalPoint>().HasData(new AditionalPoint
            {
                Id = Guid.Parse("8db8e341-9d6e-42e8-8504-45b5f56eac5f"),
                TeamGame = 0,
                ImportantInformation = 0,
                SlainMonsters = 0,
                Morals = 2,
                Cover = 2,
                GroupWestId = Guid.Parse("44a06217-58ec-4dce-bb7d-5a951e2bef9e"),
                BattleGroups = new List<BattleGroup>(),
                Negotiations = new List<Negotiation>()
            });

            modelBuilder.Entity<GroupWest>().HasData(new GroupWest
            {
                Id = Guid.Parse("44a06217-58ec-4dce-bb7d-5a951e2bef9e"),
                ActualMission = "",
                AditionalPointsId = Guid.Parse("8db8e341-9d6e-42e8-8504-45b5f56eac5f"),
                Missions = new List<Mission>(),
                Heroes = new List<Hero>(),

            });

            










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
