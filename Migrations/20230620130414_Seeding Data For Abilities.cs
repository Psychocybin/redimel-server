using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace redimel_server.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForAbilities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "Id", "Acrobatics", "Archery", "BreakingLocks", "Climbing", "Diplomacy", "Elusion", "Guile", "Melee", "NatureSkills", "Observation", "PoisonousNeedles", "Rituals", "SecretKnowledge", "ShieldBearer", "Skill", "Sneak", "Spells", "Stimulants", "Survival", "ThrowingKnives", "Transformation", "Traps", "WaterCycle", "Wrestling" },
                values: new object[] { new Guid("cd5a3e48-5eb4-49fa-a24d-3c3e861f22b3"), false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: new Guid("cd5a3e48-5eb4-49fa-a24d-3c3e861f22b3"));
        }
    }
}
