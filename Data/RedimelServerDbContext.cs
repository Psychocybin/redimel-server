using Microsoft.EntityFrameworkCore;
using redimel_server.Models.Domain;

namespace redimel_server.Data
{
    public class RedimelServerDbContext: DbContext
    {
        public RedimelServerDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
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
    }
}
