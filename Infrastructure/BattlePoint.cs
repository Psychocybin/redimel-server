﻿namespace redimel_server.Infrastructure
{
    public class BattlePoint
    {
        public int AttackWithHandToHandWeapon { get; set; }
        public int DefenceWithHandToHandWeapon { get; set; }
        public int DamageWithHandToHandWeapon { get; set; }
        public int AttackWithRangedWeapon { get; set; }
        public int DefenceWithRangedWeapon { get; set; }
        public int DefenceAgainstRangedWeapon { get; set; }
        public int DamageWithRangedWeapon { get; set; }
        public int DefenceArmor { get; set; }
        public int DefenceShield { get; set; }
        public Guid HeroId { get; set; }
    }
}
