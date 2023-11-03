using redimel_server.Models.Enums;

namespace redimel_server.Infrastructure
{
    public class HeroCreator
    {
        public string Name { get; set; }
        public HeroClass HeroClass { get; set; }
        public HeroType HeroType { get; set; }
        public double BaggageCapacity { get; set; }
        public int Health { get; set; }
        public int MentalEnergy { get; set; }
        public int MentalStrength { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Agility { get; set; }
        public int Evasion { get; set; }
        public int Endurance { get; set; }
        public bool Knife { get; set; }
        public bool SmokeBall { get; set; }
        public bool Poison { get; set; }
        public bool MedicPack { get; set; }
        public int Money { get; set; }
        public ArmorType ArmorType { get; set; }
        public bool IsArmorExist { get; set; }
        public int ArmorDefence { get; set; }
        public ShieldType ShieldType { get; set; }
        public bool IsShieldExist { get; set; }
        public int ShieldDefence { get; set; }
        public WeaponType WeaponType { get; set; }
        public bool IsWeaponExist { get; set; }
        public bool IsWeaponTwoHand { get; set; }
        public int WeaponAttack { get; set; }
        public int WeaponDefence { get; set; }
        public int WeaponDamage { get; set; }
        public int WeaponRange { get; set; }
        public ThrowingWeaponType ThrowingWeaponType { get; set; }
        public bool IsThrowingWeaponExist { get; set; }
        public int ThrowingWeaponAttack { get; set; }
        public int ThrowingWeaponDefence { get; set; }
        public int ThrowingWeaponDamage { get; set; }
        public int ThrowingWeaponRange { get; set; }
        public int ThrowingWeaponQuantity { get; set; }
        public bool Survival { get; set; }
        public bool Diplomacy { get; set; }
        public bool Climbing { get; set; }
        public bool Acrobatics { get; set; }
        public bool Skill { get; set; }
        public bool Guile { get; set; }
        public bool SecretKnowledge { get; set; }
        public bool Sneak { get; set; }
        public bool Elusion { get; set; }
        public bool WaterCycle { get; set; }
        public bool Melee { get; set; }
        public bool NatureSkills { get; set; }
        public bool BreakingLocks { get; set; }
        public bool Transformation { get; set; }
        public bool Spells { get; set; }
        public bool Rituals { get; set; }
        public bool Traps { get; set; }
        public bool Archery { get; set; }
        public bool ThrowingKnives { get; set; }
        public bool PoisonousNeedles { get; set; }
        public bool Stimulants { get; set; }
        public bool Wrestling { get; set; }
        public bool Observation { get; set; }
        public bool ShieldBearer { get; set; }
        public bool Leadership { get; set; }
        public bool KickFight { get; set; }
        public bool DoubleStrike { get; set; }
        public SpecialCombatSkillType SCSName { get; set; }
        public int SCSLevel { get; set; }
        public int SCSEnergy { get; set; }
        public UltimateType UltimateName { get; set; }
        public int UltimateLevel { get; set; }
        public int UltimateEnergy { get; set; }
    }
}
