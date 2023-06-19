using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace redimel_server.Migrations
{
    /// <inheritdoc />
    public partial class RenameClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleGroups_AditionalPoints_AditionalPointsId",
                table: "BattleGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Armors_ArmorId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Shields_ShieldId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_ThrowingWeapons_ThrowingWeaponId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Weapons_WeaponId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Equipments_EquipmentId",
                table: "Heroes");

            migrationBuilder.DropForeignKey(
                name: "FK_NatureSkills_SpecialAbilities_SpecialAbilitiesId",
                table: "NatureSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_Negotiations_AditionalPoints_AditionalPointsId",
                table: "Negotiations");

            migrationBuilder.DropForeignKey(
                name: "FK_Rituals_SpecialAbilities_SpecialAbilitiesId",
                table: "Rituals");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialAbilities_SpecialCombatSkills_SpecialCombatSkillId",
                table: "SpecialAbilities");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialAbilities_Ultimates_UltimateId",
                table: "SpecialAbilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Spells_SpecialAbilities_SpecialAbilitiesId",
                table: "Spells");

            migrationBuilder.RenameColumn(
                name: "SpecialAbilitiesId",
                table: "Spells",
                newName: "SpecialAbilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Spells_SpecialAbilitiesId",
                table: "Spells",
                newName: "IX_Spells_SpecialAbilityId");

            migrationBuilder.RenameColumn(
                name: "UltimateId",
                table: "SpecialAbilities",
                newName: "UltimatesId");

            migrationBuilder.RenameColumn(
                name: "SpecialCombatSkillId",
                table: "SpecialAbilities",
                newName: "SpecialCombatSkillsId");

            migrationBuilder.RenameIndex(
                name: "IX_SpecialAbilities_UltimateId",
                table: "SpecialAbilities",
                newName: "IX_SpecialAbilities_UltimatesId");

            migrationBuilder.RenameIndex(
                name: "IX_SpecialAbilities_SpecialCombatSkillId",
                table: "SpecialAbilities",
                newName: "IX_SpecialAbilities_SpecialCombatSkillsId");

            migrationBuilder.RenameColumn(
                name: "SpecialAbilitiesId",
                table: "Rituals",
                newName: "SpecialAbilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Rituals_SpecialAbilitiesId",
                table: "Rituals",
                newName: "IX_Rituals_SpecialAbilityId");

            migrationBuilder.RenameColumn(
                name: "AditionalPointsId",
                table: "Negotiations",
                newName: "AditionalPointId");

            migrationBuilder.RenameIndex(
                name: "IX_Negotiations_AditionalPointsId",
                table: "Negotiations",
                newName: "IX_Negotiations_AditionalPointId");

            migrationBuilder.RenameColumn(
                name: "SpecialAbilitiesId",
                table: "NatureSkills",
                newName: "SpecialAbilityId");

            migrationBuilder.RenameIndex(
                name: "IX_NatureSkills_SpecialAbilitiesId",
                table: "NatureSkills",
                newName: "IX_NatureSkills_SpecialAbilityId");

            migrationBuilder.RenameColumn(
                name: "EquipmentId",
                table: "Heroes",
                newName: "EquipmentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Heroes_EquipmentId",
                table: "Heroes",
                newName: "IX_Heroes_EquipmentsId");

            migrationBuilder.RenameColumn(
                name: "WeaponId",
                table: "Equipments",
                newName: "WeaponsId");

            migrationBuilder.RenameColumn(
                name: "ThrowingWeaponId",
                table: "Equipments",
                newName: "ThrowingWeaponsId");

            migrationBuilder.RenameColumn(
                name: "ShieldId",
                table: "Equipments",
                newName: "ShieldsId");

            migrationBuilder.RenameColumn(
                name: "ArmorId",
                table: "Equipments",
                newName: "ArmorsId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_WeaponId",
                table: "Equipments",
                newName: "IX_Equipments_WeaponsId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_ThrowingWeaponId",
                table: "Equipments",
                newName: "IX_Equipments_ThrowingWeaponsId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_ShieldId",
                table: "Equipments",
                newName: "IX_Equipments_ShieldsId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_ArmorId",
                table: "Equipments",
                newName: "IX_Equipments_ArmorsId");

            migrationBuilder.RenameColumn(
                name: "AditionalPointsId",
                table: "BattleGroups",
                newName: "AditionalPointId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleGroups_AditionalPointsId",
                table: "BattleGroups",
                newName: "IX_BattleGroups_AditionalPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleGroups_AditionalPoints_AditionalPointId",
                table: "BattleGroups",
                column: "AditionalPointId",
                principalTable: "AditionalPoints",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Armors_ArmorsId",
                table: "Equipments",
                column: "ArmorsId",
                principalTable: "Armors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Shields_ShieldsId",
                table: "Equipments",
                column: "ShieldsId",
                principalTable: "Shields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_ThrowingWeapons_ThrowingWeaponsId",
                table: "Equipments",
                column: "ThrowingWeaponsId",
                principalTable: "ThrowingWeapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Weapons_WeaponsId",
                table: "Equipments",
                column: "WeaponsId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Equipments_EquipmentsId",
                table: "Heroes",
                column: "EquipmentsId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NatureSkills_SpecialAbilities_SpecialAbilityId",
                table: "NatureSkills",
                column: "SpecialAbilityId",
                principalTable: "SpecialAbilities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Negotiations_AditionalPoints_AditionalPointId",
                table: "Negotiations",
                column: "AditionalPointId",
                principalTable: "AditionalPoints",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rituals_SpecialAbilities_SpecialAbilityId",
                table: "Rituals",
                column: "SpecialAbilityId",
                principalTable: "SpecialAbilities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialAbilities_SpecialCombatSkills_SpecialCombatSkillsId",
                table: "SpecialAbilities",
                column: "SpecialCombatSkillsId",
                principalTable: "SpecialCombatSkills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialAbilities_Ultimates_UltimatesId",
                table: "SpecialAbilities",
                column: "UltimatesId",
                principalTable: "Ultimates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spells_SpecialAbilities_SpecialAbilityId",
                table: "Spells",
                column: "SpecialAbilityId",
                principalTable: "SpecialAbilities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleGroups_AditionalPoints_AditionalPointId",
                table: "BattleGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Armors_ArmorsId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Shields_ShieldsId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_ThrowingWeapons_ThrowingWeaponsId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Weapons_WeaponsId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Equipments_EquipmentsId",
                table: "Heroes");

            migrationBuilder.DropForeignKey(
                name: "FK_NatureSkills_SpecialAbilities_SpecialAbilityId",
                table: "NatureSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_Negotiations_AditionalPoints_AditionalPointId",
                table: "Negotiations");

            migrationBuilder.DropForeignKey(
                name: "FK_Rituals_SpecialAbilities_SpecialAbilityId",
                table: "Rituals");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialAbilities_SpecialCombatSkills_SpecialCombatSkillsId",
                table: "SpecialAbilities");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialAbilities_Ultimates_UltimatesId",
                table: "SpecialAbilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Spells_SpecialAbilities_SpecialAbilityId",
                table: "Spells");

            migrationBuilder.RenameColumn(
                name: "SpecialAbilityId",
                table: "Spells",
                newName: "SpecialAbilitiesId");

            migrationBuilder.RenameIndex(
                name: "IX_Spells_SpecialAbilityId",
                table: "Spells",
                newName: "IX_Spells_SpecialAbilitiesId");

            migrationBuilder.RenameColumn(
                name: "UltimatesId",
                table: "SpecialAbilities",
                newName: "UltimateId");

            migrationBuilder.RenameColumn(
                name: "SpecialCombatSkillsId",
                table: "SpecialAbilities",
                newName: "SpecialCombatSkillId");

            migrationBuilder.RenameIndex(
                name: "IX_SpecialAbilities_UltimatesId",
                table: "SpecialAbilities",
                newName: "IX_SpecialAbilities_UltimateId");

            migrationBuilder.RenameIndex(
                name: "IX_SpecialAbilities_SpecialCombatSkillsId",
                table: "SpecialAbilities",
                newName: "IX_SpecialAbilities_SpecialCombatSkillId");

            migrationBuilder.RenameColumn(
                name: "SpecialAbilityId",
                table: "Rituals",
                newName: "SpecialAbilitiesId");

            migrationBuilder.RenameIndex(
                name: "IX_Rituals_SpecialAbilityId",
                table: "Rituals",
                newName: "IX_Rituals_SpecialAbilitiesId");

            migrationBuilder.RenameColumn(
                name: "AditionalPointId",
                table: "Negotiations",
                newName: "AditionalPointsId");

            migrationBuilder.RenameIndex(
                name: "IX_Negotiations_AditionalPointId",
                table: "Negotiations",
                newName: "IX_Negotiations_AditionalPointsId");

            migrationBuilder.RenameColumn(
                name: "SpecialAbilityId",
                table: "NatureSkills",
                newName: "SpecialAbilitiesId");

            migrationBuilder.RenameIndex(
                name: "IX_NatureSkills_SpecialAbilityId",
                table: "NatureSkills",
                newName: "IX_NatureSkills_SpecialAbilitiesId");

            migrationBuilder.RenameColumn(
                name: "EquipmentsId",
                table: "Heroes",
                newName: "EquipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Heroes_EquipmentsId",
                table: "Heroes",
                newName: "IX_Heroes_EquipmentId");

            migrationBuilder.RenameColumn(
                name: "WeaponsId",
                table: "Equipments",
                newName: "WeaponId");

            migrationBuilder.RenameColumn(
                name: "ThrowingWeaponsId",
                table: "Equipments",
                newName: "ThrowingWeaponId");

            migrationBuilder.RenameColumn(
                name: "ShieldsId",
                table: "Equipments",
                newName: "ShieldId");

            migrationBuilder.RenameColumn(
                name: "ArmorsId",
                table: "Equipments",
                newName: "ArmorId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_WeaponsId",
                table: "Equipments",
                newName: "IX_Equipments_WeaponId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_ThrowingWeaponsId",
                table: "Equipments",
                newName: "IX_Equipments_ThrowingWeaponId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_ShieldsId",
                table: "Equipments",
                newName: "IX_Equipments_ShieldId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_ArmorsId",
                table: "Equipments",
                newName: "IX_Equipments_ArmorId");

            migrationBuilder.RenameColumn(
                name: "AditionalPointId",
                table: "BattleGroups",
                newName: "AditionalPointsId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleGroups_AditionalPointId",
                table: "BattleGroups",
                newName: "IX_BattleGroups_AditionalPointsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleGroups_AditionalPoints_AditionalPointsId",
                table: "BattleGroups",
                column: "AditionalPointsId",
                principalTable: "AditionalPoints",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Armors_ArmorId",
                table: "Equipments",
                column: "ArmorId",
                principalTable: "Armors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Shields_ShieldId",
                table: "Equipments",
                column: "ShieldId",
                principalTable: "Shields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_ThrowingWeapons_ThrowingWeaponId",
                table: "Equipments",
                column: "ThrowingWeaponId",
                principalTable: "ThrowingWeapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Weapons_WeaponId",
                table: "Equipments",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Equipments_EquipmentId",
                table: "Heroes",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NatureSkills_SpecialAbilities_SpecialAbilitiesId",
                table: "NatureSkills",
                column: "SpecialAbilitiesId",
                principalTable: "SpecialAbilities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Negotiations_AditionalPoints_AditionalPointsId",
                table: "Negotiations",
                column: "AditionalPointsId",
                principalTable: "AditionalPoints",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rituals_SpecialAbilities_SpecialAbilitiesId",
                table: "Rituals",
                column: "SpecialAbilitiesId",
                principalTable: "SpecialAbilities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialAbilities_SpecialCombatSkills_SpecialCombatSkillId",
                table: "SpecialAbilities",
                column: "SpecialCombatSkillId",
                principalTable: "SpecialCombatSkills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialAbilities_Ultimates_UltimateId",
                table: "SpecialAbilities",
                column: "UltimateId",
                principalTable: "Ultimates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spells_SpecialAbilities_SpecialAbilitiesId",
                table: "Spells",
                column: "SpecialAbilitiesId",
                principalTable: "SpecialAbilities",
                principalColumn: "Id");
        }
    }
}
