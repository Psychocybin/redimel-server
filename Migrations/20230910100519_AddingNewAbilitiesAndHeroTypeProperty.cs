using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace redimel_server.Migrations
{
    /// <inheritdoc />
    public partial class AddingNewAbilitiesAndHeroTypeProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeroType",
                table: "Heroes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "DoubleStrike",
                table: "Abilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "KickFight",
                table: "Abilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Leadership",
                table: "Abilities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeroType",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "DoubleStrike",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "KickFight",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "Leadership",
                table: "Abilities");
        }
    }
}
