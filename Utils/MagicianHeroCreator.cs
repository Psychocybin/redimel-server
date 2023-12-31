﻿using redimel_server.Infrastructure;
using redimel_server.Models.Enums;

namespace redimel_server.Utils
{
    public class MagicianHeroCreator : HeroCreator
    {
        public const string NAME = "Lusifera";
        public const HeroClass HEROCLASS = HeroClass.Magician;
        public const HeroType HEROTYPE = HeroType.Mystic;
        public const double BAGGAGECAPACITY = 40.0;
        public const int HEALTH = 50;
        public const int MENTALENERGY = 32;
        public const int MENTALSTRENGTH = 12;
        public const int STRENGTH = 3;
        public const int DEXTERITY = 3;
        public const int AGILITY = 7;
        public const int EVASION = 8;
        public const int ENDURANCE = 3;
        public const Boolean KNIFE = true;
        public const Boolean SMOKEBALL = false;
        public const Boolean POISON = false;
        public const Boolean MEDICPACK = false;
        public const int MONEY = 100;
        public const ArmorType ARMORTYPE = ArmorType.Leather;
        public const Boolean ISARMOREXIST = true;
        public const int ARMORDEFENCE = (int)ARMORTYPE;
        public const ShieldType SHIELDTYPE = ShieldType.None;
        public const Boolean ISSHIELDEXIST = false;
        public const int SHIELDDEFENCE = (int)SHIELDTYPE;
        public const WeaponType WEAPONTYPE = WeaponType.Scepter;
        public const Boolean ISWEAPONEXIST = true;
        public const Boolean ISWEAPONTWOHAND = false;
        public const int WEAPONATTACK = 7;
        public const int WEAPONDEFENCE = 3;
        public const int WEAPONDAMAGE = (int)WEAPONTYPE;
        public const int WEAPONRANGE = 1;
        public const ThrowingWeaponType THROWINGWEAPONTYPE = ThrowingWeaponType.None;
        public const Boolean ISTHROWINGWEAPONEXIST = false;
        public const int THROWINGWEAPONATTACK = 0;
        public const int THROWINGWEAPONDEFENCE = 0;
        public const int THROWINGWEAPONDAMAGE = 0;
        public const int THROWINGWEAPONRANGE = (int)THROWINGWEAPONTYPE;
        public const int THROWINGWEAPONQUANTITY = 0;
        public const Boolean SURVIVAL = false;
        public const Boolean DIPLOMACY = false;
        public const Boolean CLIMBING = false;
        public const Boolean ACROBATICS = false;
        public const Boolean SKILL = false;
        public const Boolean GUILE = false;
        public const Boolean SECRETKNOWLEDGE = true;
        public const Boolean SNEAK = false;
        public const Boolean ELUSION = false;
        public const Boolean WATERCYCLE = false;
        public const Boolean MELEE = false;
        public const Boolean NATURESKILLS = false;
        public const Boolean BREAKINGLOCKS = false;
        public const Boolean TRANSFORMATION = false;
        public const Boolean SPELLS = true;
        public const Boolean RITUALS = false;
        public const Boolean TRAPS = false;
        public const Boolean ARCHERY = false;
        public const Boolean THROWINGKNIVES = false;
        public const Boolean POISONOUSNEEDLES = false;
        public const Boolean STIMULANTS = false;
        public const Boolean WRESTLING = false;
        public const Boolean OBSERVATION = false;
        public const Boolean SHIELDBEARER = false;
        public const Boolean LEADERSHIP = false;
        public const Boolean KICKFIGHT = false;
        public const Boolean DOUBLESTRIKE = false;
        public const SpecialCombatSkillType SCSNAME = SpecialCombatSkillType.MagicianSCS;
        public const int SCSLEVEL = 1;
        public const int SCSENERGY = 5;
        public const UltimateType ULTIMATENAME = UltimateType.MagicianUltimate;
        public const int ULTIMATELEVEL = 1;
        public const int ULTIMATEENERGY = 10;

        public MagicianHeroCreator()
        {
            this.Name = NAME;
            this.HeroClass = HEROCLASS;
            this.HeroType = HEROTYPE;
            this.BaggageCapacity = BAGGAGECAPACITY;
            this.Health = HEALTH;
            this.MentalEnergy = MENTALENERGY;
            this.MentalStrength = MENTALSTRENGTH;
            this.Strength = STRENGTH;
            this.Dexterity = DEXTERITY;
            this.Agility = AGILITY;
            this.Evasion = EVASION;
            this.Endurance = ENDURANCE;
            this.Knife = KNIFE;
            //this.SmokeBall = SMOKEBALL;
            //this.Poison = POISON;
            //this.MedicPack = MEDICPACK;
            this.Money = MONEY;
            this.ArmorType = ARMORTYPE;
            this.IsArmorExist = ISARMOREXIST;
            this.ArmorDefence = ARMORDEFENCE;
            this.ShieldType = SHIELDTYPE;
            //this.IsShieldExist = ISSHIELDEXIST;
            //this.ShieldDefence = SHIELDDEFENCE;
            this.WeaponType = WEAPONTYPE;
            this.IsWeaponExist = ISWEAPONEXIST;
            //this.IsWeaponTwoHand = ISWEAPONTWOHAND;
            this.WeaponAttack = WEAPONATTACK;
            this.WeaponDefence = WEAPONDEFENCE;
            this.WeaponDamage = WEAPONDAMAGE;
            this.WeaponRange = WEAPONRANGE;
            this.ThrowingWeaponType = THROWINGWEAPONTYPE;
            //this.IsThrowingWeaponExist = ISTHROWINGWEAPONEXIST;
            //this.ThrowingWeaponAttack = THROWINGWEAPONATTACK;
            //this.ThrowingWeaponDefence = THROWINGWEAPONDEFENCE;
            //this.ThrowingWeaponDamage = THROWINGWEAPONDAMAGE;
            //this.ThrowingWeaponRange = THROWINGWEAPONRANGE;
            //this.ThrowingWeaponQuantity = THROWINGWEAPONQUANTITY;
            //this.Survival = SURVIVAL;
            //this.Diplomacy = DIPLOMACY;
            //this.Climbing = CLIMBING;
            //this.Acrobatics = ACROBATICS;
            //this.Skill = SKILL;
            //this.Guile = GUILE;
            this.SecretKnowledge = SECRETKNOWLEDGE;
            //this.Sneak = SNEAK;
            //this.Elusion = ELUSION;
            //this.WaterCycle = WATERCYCLE;
            //this.Melee = MELEE;
            //this.NatureSkills = NATURESKILLS;
            //this.BreakingLocks = BREAKINGLOCKS;
            //this.Transformation = TRANSFORMATION;
            this.Spells = SPELLS;
            //this.Rituals = RITUALS;
            //this.Traps = TRAPS;
            //this.Archery = ARCHERY;
            //this.ThrowingKnives = THROWINGKNIVES;
            //this.PoisonousNeedles = POISONOUSNEEDLES;
            //this.Stimulants = STIMULANTS;
            //this.Wrestling = WRESTLING;
            //this.Observation = OBSERVATION;
            //this.ShieldBearer = SHIELDBEARER;
            //this.Leadership = LEADERSHIP;
            //this.KickFight = KICKFIGHT;
            //this.DoubleStrike = DOUBLESTRIKE;
            this.SCSName = SCSNAME;
            this.SCSLevel = SCSLEVEL;
            this.SCSEnergy = SCSENERGY;
            this.UltimateName = ULTIMATENAME;
            this.UltimateLevel = ULTIMATELEVEL;
            this.UltimateEnergy = ULTIMATEENERGY;
        }

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
