﻿using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Infrastructure;
using redimel_server.Models.Domain;

namespace redimel_server.Repositories
{
    public class SQLAuxiliaryRepository : IAuxiliaryRepository
    {
        private readonly RedimelServerDbContext dbContext;
        private readonly IUserRepository userRepository;

        public SQLAuxiliaryRepository(RedimelServerDbContext dbContext, IUserRepository userRepository)
        {
            this.dbContext = dbContext;
            this.userRepository = userRepository;
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
                switch (item.BonusIndicator)
                {
                    case "attackWithHandToHandWeapon":
                        attackWithHandToHandWeapon += item.BonusPoints;
                        break;
                    case "defenceWithHandToHandWeapon":
                        defenceWithHandToHandWeapon += item.BonusPoints;
                        break;
                    case "damageWithHandToHandWeapon":
                        damageWithHandToHandWeapon += item.BonusPoints;
                        break;
                    case "attackWithRangedWeapon":
                        attackWithRangedWeapon += item.BonusPoints;
                        break;
                    case "defenceWithRangedWeapon":
                        defenceWithRangedWeapon += item.BonusPoints;
                        break;
                    case "defenceAgainstRangedWeapon":
                        defenceAgainstRangedWeapon += item.BonusPoints;
                        break;
                    case "damageWithRangedWeapon":
                        damageWithRangedWeapon += item.BonusPoints;
                        break;
                    case "defenceArmor":
                        defenceArmor += item.BonusPoints;
                        break;
                    case "defenceShield":
                        defenceShield += item.BonusPoints;
                        break;
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
                DefenceShield = defenceShield,
                HeroId = id
            };

            return battlePoints;
        }

        public async Task<User?> GetUserAndGroupWestHeroesAsync()
        {
            var currentUserEmail = userRepository.GetUserEmail();

            var currentUser = await dbContext.Users.Where(x => x.CurrentUserEmail == currentUserEmail)
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
                .FirstOrDefaultAsync()
                    ?? throw new Exception("This user cannot be found!");

            return currentUser;
        }
    }
}
