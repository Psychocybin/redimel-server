using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Infrastructure;

namespace redimel_server.Repositories
{
    public class SQLAuxiliaryRepository : IAuxiliaryRepository
    {
        private readonly RedimelServerDbContext dbContext;

        public SQLAuxiliaryRepository(RedimelServerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BattlePoint?> ShowBattlePointsAsync(Guid id)
        {
            var hero = await dbContext.Heroes.Where(x => x.Id == id)
                .Include(x => x.Indicators)
                .Include(x => x.Equipments).ThenInclude(x => x.Talismans)
                .Include(x => x.Equipments).ThenInclude(x => x.Weapon)
                .Include(x => x.Equipments).ThenInclude(x => x.Shield)
                .Include(x => x.Equipments).ThenInclude(x => x.ThrowingWeapon)
                .Include(x => x.Equipments).ThenInclude(x => x.Armor)
                .FirstOrDefaultAsync();

            var talismans = hero.Equipments.Talismans.ToList();

            var attackWithHandToHandWeapon = 0;
            var defenceWithHandToHandWeapon = 0;
            var damageWithHandToHandWeapon = 0;
            var attackWithRangedWeapon = 0;
            var defenceWithRangedWeapon = 0;
            var defenceAgainstRangedWeapon = 0;
            var damageWithRangedWeapon = 0;
            var defenceArmor = 0;
            var defenceShield = 0;

            attackWithHandToHandWeapon += hero.Indicators.Strength;
            attackWithHandToHandWeapon += hero.Indicators.Dexterity;
            attackWithHandToHandWeapon += hero.Equipments.Weapon.Attack;

            defenceWithHandToHandWeapon += hero.Indicators.Dexterity;
            defenceWithHandToHandWeapon += hero.Indicators.Evasion;
            defenceWithHandToHandWeapon += hero.Equipments.Weapon.Defence;

            damageWithHandToHandWeapon += hero.Equipments.Weapon.Damage;

            attackWithRangedWeapon += hero.Indicators.Dexterity;
            attackWithRangedWeapon += hero.Equipments.ThrowingWeapon.Attack;

            defenceWithRangedWeapon += hero.Indicators.Evasion;
            defenceWithRangedWeapon += hero.Indicators.Dexterity;
            defenceWithRangedWeapon += hero.Equipments.ThrowingWeapon.Defence;

            defenceAgainstRangedWeapon += hero.Indicators.Dexterity;
            defenceAgainstRangedWeapon += hero.Indicators.Evasion;
            defenceAgainstRangedWeapon += hero.Equipments.Shield.Defence;

            damageWithRangedWeapon += hero.Equipments.ThrowingWeapon.Damage;

            defenceArmor += hero.Equipments.Armor.Defence;

            defenceShield += hero.Equipments.Shield.Defence;

            foreach (var item in talismans)
            {
                if (item.BonusIndicator == "attackWithHandToHandWeapon")
                {
                    attackWithHandToHandWeapon += item.BonusPoints;
                }
                else if (item.BonusIndicator == "defenceWithHandToHandWeapon")
                {
                    defenceWithHandToHandWeapon += item.BonusPoints;
                }
                else if (item.BonusIndicator == "damageWithHandToHandWeapon")
                {
                    damageWithHandToHandWeapon += item.BonusPoints;
                }
                else if (item.BonusIndicator == "attackWithRangedWeapon")
                {
                    attackWithRangedWeapon += item.BonusPoints;
                }
                else if (item.BonusIndicator == "defenceWithRangedWeapon")
                {
                    defenceWithRangedWeapon += item.BonusPoints;
                }
                else if (item.BonusIndicator == "defenceAgainstRangedWeapon")
                {
                    defenceAgainstRangedWeapon += item.BonusPoints;
                }
                else if (item.BonusIndicator == "damageWithRangedWeapon")
                {
                    damageWithRangedWeapon += item.BonusPoints;
                }
                else if (item.BonusIndicator == "defenceArmor")
                {
                    defenceArmor += item.BonusPoints;
                }
                else if (item.BonusIndicator == "defenceShield")
                {
                    defenceShield += item.BonusPoints;
                }


            }

            var battlePoints = new BattlePoint
            {
                AttackWithHandToHandWeapon = attackWithHandToHandWeapon,
                DefenceWithHandToHandWeapon = defenceWithHandToHandWeapon,
                DamageWithHandToHandWeapon = damageWithHandToHandWeapon,
                AttackWithRangedWeapon = attackWithRangedWeapon,
                DefenceWithRangedWeapon = defenceWithRangedWeapon,
                DefenceAgainstRangedWeapon = defenceAgainstRangedWeapon,
                DamageWithRangedWeapon = damageWithRangedWeapon,
                DefenceArmor = defenceArmor,
                DefenceShield = defenceShield
            };

            return battlePoints;
        }
    }
}
