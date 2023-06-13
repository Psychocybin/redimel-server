using Microsoft.EntityFrameworkCore;
using redimel_server.Models.Domain;

namespace redimel_server.Data
{
    public class RedimelServerDbContext: DbContext
    {
        public RedimelServerDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Abilities> Abilities { get; set; }
        public DbSet<AditionalPoints> AditionalPoints { get; set; }
        public DbSet<Armor> ArmorsAndShields { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<GroupWest> GroupWest { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Indicators> Indicators { get; set; }
        public DbSet<SpecialAbilities> SpecialAbilities { get; set; }
        public DbSet<SpecialCombatSkill> SpecialAbilityPoints { get; set; }
        public DbSet<Talisman> Talismans { get; set; }
        public DbSet<ThrowingWeapon> ThrowingWeapons { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
    }
}
