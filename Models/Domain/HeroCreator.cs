using redimel_server.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace redimel_server.Models.Domain
{
    [NotMapped]
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
        public Boolean Knife { get; set; }
        public Boolean SmokeBall { get; set; }
        public Boolean Poison { get; set; }
        public Boolean MedicPack { get; set; }
        public int Money { get; set; }
        public ArmorType ArmorType { get; set; }
        public Boolean IsArmorExist { get; set; }
        public int ArmorDefence { get; set; }
        public ShieldType ShieldType { get; set; }
        public Boolean IsShieldExist { get; set; }
        public int ShieldDefence { get; set; }
        public WeaponType WeaponType { get; set; }
        public Boolean IsWeaponExist { get; set; }
        public Boolean IsWeaponTwoHand { get; set; }
        public int WeaponAttack { get; set; }
        public int WeaponDefence { get; set; }
        public int WeaponDamage { get; set; }
        public int WeaponRange { get; set; }
        public ThrowingWeaponType ThrowingWeaponType { get; set; }
        public Boolean IsThrowingWeaponExist { get; set; }
        public int ThrowingWeaponAttack { get; set; }
        public int ThrowingWeaponDefence { get; set; }
        public int ThrowingWeaponDamage { get; set; }
        public int ThrowingWeaponRange { get; set; }
        public int ThrowingWeaponQuantity { get; set; }
        public Boolean Survival { get; set; }
        public Boolean Diplomacy { get; set; }
        public Boolean Climbing { get; set; }
        public Boolean Acrobatics { get; set; }
        public Boolean Skill { get; set; }
        public Boolean Guile { get; set; }
        public Boolean SecretKnowledge { get; set; }
        public Boolean Sneak { get; set; }
        public Boolean Elusion { get; set; }
        public Boolean WaterCycle { get; set; }
        public Boolean Melee { get; set; }
        public Boolean NatureSkills { get; set; }
        public Boolean BreakingLocks { get; set; }
        public Boolean Transformation { get; set; }
        public Boolean Spells { get; set; }
        public Boolean Rituals { get; set; }
        public Boolean Traps { get; set; }
        public Boolean Archery { get; set; }
        public Boolean ThrowingKnives { get; set; }
        public Boolean PoisonousNeedles { get; set; }
        public Boolean Stimulants { get; set; }
        public Boolean Wrestling { get; set; }
        public Boolean Observation { get; set; }
        public Boolean ShieldBearer { get; set; }
        public Boolean Leadership { get; set; }
        public Boolean KickFight { get; set; }
        public Boolean DoubleStrike { get; set; }
        public SpecialCombatSkillType SCSName { get; set; }
        public int SCSLevel { get; set; }
        public int SCSEnergy { get; set; }
        public UltimateType UltimateName { get; set; }
        public int UltimateLevel { get; set; }
        public int UltimateEnergy { get; set; }
    }
}
