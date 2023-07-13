using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace redimel_server.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForHunterHero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "Id", "Acrobatics", "Archery", "BreakingLocks", "Climbing", "Diplomacy", "Elusion", "Guile", "HeroId", "Melee", "NatureSkills", "Observation", "PoisonousNeedles", "Rituals", "SecretKnowledge", "ShieldBearer", "Skill", "Sneak", "Spells", "Stimulants", "Survival", "ThrowingKnives", "Transformation", "Traps", "WaterCycle", "Wrestling" },
                values: new object[] { new Guid("0bd3e733-dcf3-40a3-8f90-e965a72687fd"), false, true, false, false, false, false, false, new Guid("e1f39f3c-0fb5-40d4-84d1-b6a46c5c0568"), false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false });

            migrationBuilder.InsertData(
                table: "Armors",
                columns: new[] { "Id", "ArmorType", "Defence", "EquipmentId", "IsExist" },
                values: new object[] { new Guid("9eb3e847-03e3-428d-9f05-976e64465cb8"), "WoodArmor", 5, new Guid("6d6e49e8-84b4-4a11-b8f8-c1613e97479a"), true });

            migrationBuilder.InsertData(
                table: "Indicators",
                columns: new[] { "Id", "Agility", "Dexterity", "Endurance", "Evasion", "Health", "HeroId", "MentalEnergy", "MentalStrength", "Strength" },
                values: new object[] { new Guid("697d4622-b4d9-4b71-85e8-a81bbcd7c0a4"), 3, 7, 12, 3, 60, new Guid("e1f39f3c-0fb5-40d4-84d1-b6a46c5c0568"), 24, 8, 7 });

            migrationBuilder.InsertData(
                table: "Shields",
                columns: new[] { "Id", "Defence", "EquipmentId", "IsExist", "ShieldType" },
                values: new object[] { new Guid("c5b0bd9c-7840-41b4-bb71-44ab2b883c7d"), 0, new Guid("6d6e49e8-84b4-4a11-b8f8-c1613e97479a"), false, "" });

            migrationBuilder.InsertData(
                table: "SpecialCombatSkills",
                columns: new[] { "Id", "Name", "RequiredMentalEnergy", "SkillLevel", "SpecialAbilitiesId" },
                values: new object[] { new Guid("fdd5bf1d-32c6-460d-b518-570e866f2e7a"), "HunterSCS", 0, 1, new Guid("eb521bf8-1f0e-43da-bfaf-82750308b629") });

            migrationBuilder.InsertData(
                table: "ThrowingWeapons",
                columns: new[] { "Id", "Attack", "Damage", "Defence", "EquipmentId", "IsExist", "Quantity", "ThrowingWeaponRange", "ThrowingWeaponType" },
                values: new object[] { new Guid("666c294d-c0d1-49d1-89a0-88abb3cf05fe"), 9, 10, 1, new Guid("6d6e49e8-84b4-4a11-b8f8-c1613e97479a"), true, 20, 4, "ShortBow" });

            migrationBuilder.InsertData(
                table: "Ultimates",
                columns: new[] { "Id", "Name", "RequiredMentalEnergy", "SkillLevel", "SpecialAbilitiesId" },
                values: new object[] { new Guid("6d16ec7d-7e95-4c76-a146-7532c2c1f39e"), "HunterUltimate", 8, 1, new Guid("eb521bf8-1f0e-43da-bfaf-82750308b629") });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "Attack", "Damage", "Defence", "EquipmentId", "IsExist", "IsItTwoHandWeapon", "WeaponRange", "WeaponType" },
                values: new object[] { new Guid("b29503f6-4955-4512-a0d9-619f16127a80"), 11, 10, 2, new Guid("6d6e49e8-84b4-4a11-b8f8-c1613e97479a"), true, false, 2, "OneHand" });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "ArmorId", "HeroId", "Knife", "MedicPack", "MoneyBag", "Poison", "ShieldId", "SmokeBall", "ThrowingWeaponId", "WeaponId" },
                values: new object[] { new Guid("6d6e49e8-84b4-4a11-b8f8-c1613e97479a"), new Guid("9eb3e847-03e3-428d-9f05-976e64465cb8"), new Guid("e1f39f3c-0fb5-40d4-84d1-b6a46c5c0568"), true, true, 100, false, new Guid("c5b0bd9c-7840-41b4-bb71-44ab2b883c7d"), false, new Guid("666c294d-c0d1-49d1-89a0-88abb3cf05fe"), new Guid("b29503f6-4955-4512-a0d9-619f16127a80") });

            migrationBuilder.InsertData(
                table: "SpecialAbilities",
                columns: new[] { "Id", "HeroId", "SpecialCombatSkillId", "UltimateId" },
                values: new object[] { new Guid("eb521bf8-1f0e-43da-bfaf-82750308b629"), new Guid("e1f39f3c-0fb5-40d4-84d1-b6a46c5c0568"), new Guid("fdd5bf1d-32c6-460d-b518-570e866f2e7a"), new Guid("6d16ec7d-7e95-4c76-a146-7532c2c1f39e") });

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "AbilityId", "BaggageCapacity", "EquipmentsId", "GroupWestId", "HeroClass", "IndicatorsId", "Name", "SpecialAbilityId" },
                values: new object[] { new Guid("e1f39f3c-0fb5-40d4-84d1-b6a46c5c0568"), new Guid("0bd3e733-dcf3-40a3-8f90-e965a72687fd"), 50.0, new Guid("6d6e49e8-84b4-4a11-b8f8-c1613e97479a"), new Guid("44a06217-58ec-4dce-bb7d-5a951e2bef9e"), "Hunter", new Guid("697d4622-b4d9-4b71-85e8-a81bbcd7c0a4"), "TheLittleBear", new Guid("eb521bf8-1f0e-43da-bfaf-82750308b629") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: new Guid("e1f39f3c-0fb5-40d4-84d1-b6a46c5c0568"));

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: new Guid("0bd3e733-dcf3-40a3-8f90-e965a72687fd"));

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: new Guid("6d6e49e8-84b4-4a11-b8f8-c1613e97479a"));

            migrationBuilder.DeleteData(
                table: "Indicators",
                keyColumn: "Id",
                keyValue: new Guid("697d4622-b4d9-4b71-85e8-a81bbcd7c0a4"));

            migrationBuilder.DeleteData(
                table: "SpecialAbilities",
                keyColumn: "Id",
                keyValue: new Guid("eb521bf8-1f0e-43da-bfaf-82750308b629"));

            migrationBuilder.DeleteData(
                table: "Armors",
                keyColumn: "Id",
                keyValue: new Guid("9eb3e847-03e3-428d-9f05-976e64465cb8"));

            migrationBuilder.DeleteData(
                table: "Shields",
                keyColumn: "Id",
                keyValue: new Guid("c5b0bd9c-7840-41b4-bb71-44ab2b883c7d"));

            migrationBuilder.DeleteData(
                table: "SpecialCombatSkills",
                keyColumn: "Id",
                keyValue: new Guid("fdd5bf1d-32c6-460d-b518-570e866f2e7a"));

            migrationBuilder.DeleteData(
                table: "ThrowingWeapons",
                keyColumn: "Id",
                keyValue: new Guid("666c294d-c0d1-49d1-89a0-88abb3cf05fe"));

            migrationBuilder.DeleteData(
                table: "Ultimates",
                keyColumn: "Id",
                keyValue: new Guid("6d16ec7d-7e95-4c76-a146-7532c2c1f39e"));

            migrationBuilder.DeleteData(
                table: "Weapons",
                keyColumn: "Id",
                keyValue: new Guid("b29503f6-4955-4512-a0d9-619f16127a80"));
        }
    }
}
