using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace redimel_server.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesForRedimelWorldCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dikanis_Redimels_RedimelId",
                table: "Dikanis");

            migrationBuilder.DropForeignKey(
                name: "FK_Faegras_Redimels_RedimelId",
                table: "Faegras");

            migrationBuilder.DropForeignKey(
                name: "FK_MageFields_Magelands_MagelandId",
                table: "MageFields");

            migrationBuilder.DropForeignKey(
                name: "FK_MageForests_Magelands_MagelandId",
                table: "MageForests");

            migrationBuilder.DropForeignKey(
                name: "FK_MageHarbors_Magelands_MagelandId",
                table: "MageHarbors");

            migrationBuilder.DropForeignKey(
                name: "FK_Magelands_Redimels_RedimelId",
                table: "Magelands");

            migrationBuilder.DropForeignKey(
                name: "FK_MageSeas_Magelands_MagelandId",
                table: "MageSeas");

            migrationBuilder.DropForeignKey(
                name: "FK_MageTownGuardHills_MageTowns_MageTownId",
                table: "MageTownGuardHills");

            migrationBuilder.DropForeignKey(
                name: "FK_MageTownInnTheOldMagicians_MageTowns_MageTownId",
                table: "MageTownInnTheOldMagicians");

            migrationBuilder.DropForeignKey(
                name: "FK_MageTowns_Magelands_MagelandId",
                table: "MageTowns");

            migrationBuilder.DropForeignKey(
                name: "FK_MageTownTheCentralSquares_MageTowns_MageTownId",
                table: "MageTownTheCentralSquares");

            migrationBuilder.DropForeignKey(
                name: "FK_MageTownTheLibraries_MageTowns_MageTownId",
                table: "MageTownTheLibraries");

            migrationBuilder.DropForeignKey(
                name: "FK_MageTradeRoads_Magelands_MagelandId",
                table: "MageTradeRoads");

            migrationBuilder.DropForeignKey(
                name: "FK_NorthernNomads_Redimels_RedimelId",
                table: "NorthernNomads");

            migrationBuilder.DropForeignKey(
                name: "FK_OutlawTerritories_Redimels_RedimelId",
                table: "OutlawTerritories");

            migrationBuilder.DropForeignKey(
                name: "FK_SouthernNomads_Redimels_RedimelId",
                table: "SouthernNomads");

            migrationBuilder.DropForeignKey(
                name: "FK_Stincums_Redimels_RedimelId",
                table: "Stincums");

            migrationBuilder.DropForeignKey(
                name: "FK_TheBigCities_Redimels_RedimelId",
                table: "TheBigCities");

            migrationBuilder.DropForeignKey(
                name: "FK_TheEmpires_Redimels_RedimelId",
                table: "TheEmpires");

            migrationBuilder.DropForeignKey(
                name: "FK_TheForestTribes_Redimels_RedimelId",
                table: "TheForestTribes");

            migrationBuilder.DropForeignKey(
                name: "FK_TheHigherOnes_Redimels_RedimelId",
                table: "TheHigherOnes");

            migrationBuilder.DropForeignKey(
                name: "FK_TheHorsePeoples_Redimels_RedimelId",
                table: "TheHorsePeoples");

            migrationBuilder.DropForeignKey(
                name: "FK_TheHunters_Redimels_RedimelId",
                table: "TheHunters");

            migrationBuilder.DropForeignKey(
                name: "FK_TheIslanders_Redimels_RedimelId",
                table: "TheIslanders");

            migrationBuilder.DropForeignKey(
                name: "FK_TheOldKingdoms_Redimels_RedimelId",
                table: "TheOldKingdoms");

            migrationBuilder.DropForeignKey(
                name: "FK_ThePirateDomains_Redimels_RedimelId",
                table: "ThePirateDomains");

            migrationBuilder.DropForeignKey(
                name: "FK_TheShadowWorlds_Redimels_RedimelId",
                table: "TheShadowWorlds");

            migrationBuilder.DropForeignKey(
                name: "FK_TheTradeLeagues_Redimels_RedimelId",
                table: "TheTradeLeagues");

            migrationBuilder.DropForeignKey(
                name: "FK_TheWastelands_Redimels_RedimelId",
                table: "TheWastelands");

            migrationBuilder.DropForeignKey(
                name: "FK_Tumpridadams_Redimels_RedimelId",
                table: "Tumpridadams");

            migrationBuilder.DropIndex(
                name: "IX_Tumpridadams_RedimelId",
                table: "Tumpridadams");

            migrationBuilder.DropIndex(
                name: "IX_TheWastelands_RedimelId",
                table: "TheWastelands");

            migrationBuilder.DropIndex(
                name: "IX_TheTradeLeagues_RedimelId",
                table: "TheTradeLeagues");

            migrationBuilder.DropIndex(
                name: "IX_TheShadowWorlds_RedimelId",
                table: "TheShadowWorlds");

            migrationBuilder.DropIndex(
                name: "IX_ThePirateDomains_RedimelId",
                table: "ThePirateDomains");

            migrationBuilder.DropIndex(
                name: "IX_TheOldKingdoms_RedimelId",
                table: "TheOldKingdoms");

            migrationBuilder.DropIndex(
                name: "IX_TheIslanders_RedimelId",
                table: "TheIslanders");

            migrationBuilder.DropIndex(
                name: "IX_TheHunters_RedimelId",
                table: "TheHunters");

            migrationBuilder.DropIndex(
                name: "IX_TheHorsePeoples_RedimelId",
                table: "TheHorsePeoples");

            migrationBuilder.DropIndex(
                name: "IX_TheHigherOnes_RedimelId",
                table: "TheHigherOnes");

            migrationBuilder.DropIndex(
                name: "IX_TheForestTribes_RedimelId",
                table: "TheForestTribes");

            migrationBuilder.DropIndex(
                name: "IX_TheEmpires_RedimelId",
                table: "TheEmpires");

            migrationBuilder.DropIndex(
                name: "IX_TheBigCities_RedimelId",
                table: "TheBigCities");

            migrationBuilder.DropIndex(
                name: "IX_Stincums_RedimelId",
                table: "Stincums");

            migrationBuilder.DropIndex(
                name: "IX_SouthernNomads_RedimelId",
                table: "SouthernNomads");

            migrationBuilder.DropIndex(
                name: "IX_OutlawTerritories_RedimelId",
                table: "OutlawTerritories");

            migrationBuilder.DropIndex(
                name: "IX_NorthernNomads_RedimelId",
                table: "NorthernNomads");

            migrationBuilder.DropIndex(
                name: "IX_MageTradeRoads_MagelandId",
                table: "MageTradeRoads");

            migrationBuilder.DropIndex(
                name: "IX_MageTownTheLibraries_MageTownId",
                table: "MageTownTheLibraries");

            migrationBuilder.DropIndex(
                name: "IX_MageTownTheCentralSquares_MageTownId",
                table: "MageTownTheCentralSquares");

            migrationBuilder.DropIndex(
                name: "IX_MageTowns_MagelandId",
                table: "MageTowns");

            migrationBuilder.DropIndex(
                name: "IX_MageTownInnTheOldMagicians_MageTownId",
                table: "MageTownInnTheOldMagicians");

            migrationBuilder.DropIndex(
                name: "IX_MageTownGuardHills_MageTownId",
                table: "MageTownGuardHills");

            migrationBuilder.DropIndex(
                name: "IX_MageSeas_MagelandId",
                table: "MageSeas");

            migrationBuilder.DropIndex(
                name: "IX_Magelands_RedimelId",
                table: "Magelands");

            migrationBuilder.DropIndex(
                name: "IX_MageHarbors_MagelandId",
                table: "MageHarbors");

            migrationBuilder.DropIndex(
                name: "IX_MageForests_MagelandId",
                table: "MageForests");

            migrationBuilder.DropIndex(
                name: "IX_MageFields_MagelandId",
                table: "MageFields");

            migrationBuilder.DropIndex(
                name: "IX_Faegras_RedimelId",
                table: "Faegras");

            migrationBuilder.DropIndex(
                name: "IX_Dikanis_RedimelId",
                table: "Dikanis");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "Tumpridadams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheWastelands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheTradeLeagues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheShadowWorlds",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "ThePirateDomains",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheOldKingdoms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheIslanders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheHunters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheHorsePeoples",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheHigherOnes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheForestTribes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheEmpires",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheBigCities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "Stincums",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "SouthernNomads",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DikaniId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FaegraId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MagelandId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MagelandsId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NorthernNomadsId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OutlawTerritoryId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SouthernNomadsId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StincumId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TheBigCityId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TheEmpireId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TheForestTribesId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TheHigherOnesId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TheHorsePeopleId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TheHuntersId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TheIslandersId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TheOldKingdomId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ThePirateDomainsId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TheShadowWorldId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TheTradeLeagueId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TheWastelandId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TumpridadamId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "OutlawTerritories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "NorthernNomads",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MagelandId",
                table: "MageTradeRoads",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTheGuardAlive",
                table: "MageTownTheLibraries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "MageTownId",
                table: "MageTownTheCentralSquares",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MageTownGuardHillId",
                table: "MageTowns",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MageTownInnTheOldMagicianId",
                table: "MageTowns",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MageTownTheCentralSquareId",
                table: "MageTowns",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MageTownTheLibraryId",
                table: "MageTowns",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "MageTownId",
                table: "MageTownInnTheOldMagicians",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MageTownId",
                table: "MageTownGuardHills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MagelandId",
                table: "MageSeas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MageFieldsId",
                table: "Magelands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MageForestId",
                table: "Magelands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MageHarborId",
                table: "Magelands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MageSeaId",
                table: "Magelands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MageTownId",
                table: "Magelands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MageTradeRoadId",
                table: "Magelands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "MagelandId",
                table: "MageHarbors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MagelandId",
                table: "MageForests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MagelandId",
                table: "MageFields",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "Faegras",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "Dikanis",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_DikaniId",
                table: "Redimels",
                column: "DikaniId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_FaegraId",
                table: "Redimels",
                column: "FaegraId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_MagelandsId",
                table: "Redimels",
                column: "MagelandsId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_NorthernNomadsId",
                table: "Redimels",
                column: "NorthernNomadsId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_OutlawTerritoryId",
                table: "Redimels",
                column: "OutlawTerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_SouthernNomadsId",
                table: "Redimels",
                column: "SouthernNomadsId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_StincumId",
                table: "Redimels",
                column: "StincumId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_TheBigCityId",
                table: "Redimels",
                column: "TheBigCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_TheEmpireId",
                table: "Redimels",
                column: "TheEmpireId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_TheForestTribesId",
                table: "Redimels",
                column: "TheForestTribesId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_TheHigherOnesId",
                table: "Redimels",
                column: "TheHigherOnesId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_TheHorsePeopleId",
                table: "Redimels",
                column: "TheHorsePeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_TheHuntersId",
                table: "Redimels",
                column: "TheHuntersId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_TheIslandersId",
                table: "Redimels",
                column: "TheIslandersId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_TheOldKingdomId",
                table: "Redimels",
                column: "TheOldKingdomId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_ThePirateDomainsId",
                table: "Redimels",
                column: "ThePirateDomainsId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_TheShadowWorldId",
                table: "Redimels",
                column: "TheShadowWorldId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_TheTradeLeagueId",
                table: "Redimels",
                column: "TheTradeLeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_TheWastelandId",
                table: "Redimels",
                column: "TheWastelandId");

            migrationBuilder.CreateIndex(
                name: "IX_Redimels_TumpridadamId",
                table: "Redimels",
                column: "TumpridadamId");

            migrationBuilder.CreateIndex(
                name: "IX_MageTowns_MageTownGuardHillId",
                table: "MageTowns",
                column: "MageTownGuardHillId");

            migrationBuilder.CreateIndex(
                name: "IX_MageTowns_MageTownInnTheOldMagicianId",
                table: "MageTowns",
                column: "MageTownInnTheOldMagicianId");

            migrationBuilder.CreateIndex(
                name: "IX_MageTowns_MageTownTheCentralSquareId",
                table: "MageTowns",
                column: "MageTownTheCentralSquareId");

            migrationBuilder.CreateIndex(
                name: "IX_MageTowns_MageTownTheLibraryId",
                table: "MageTowns",
                column: "MageTownTheLibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Magelands_MageFieldsId",
                table: "Magelands",
                column: "MageFieldsId");

            migrationBuilder.CreateIndex(
                name: "IX_Magelands_MageForestId",
                table: "Magelands",
                column: "MageForestId");

            migrationBuilder.CreateIndex(
                name: "IX_Magelands_MageHarborId",
                table: "Magelands",
                column: "MageHarborId");

            migrationBuilder.CreateIndex(
                name: "IX_Magelands_MageSeaId",
                table: "Magelands",
                column: "MageSeaId");

            migrationBuilder.CreateIndex(
                name: "IX_Magelands_MageTownId",
                table: "Magelands",
                column: "MageTownId");

            migrationBuilder.CreateIndex(
                name: "IX_Magelands_MageTradeRoadId",
                table: "Magelands",
                column: "MageTradeRoadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Magelands_MageFields_MageFieldsId",
                table: "Magelands",
                column: "MageFieldsId",
                principalTable: "MageFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Magelands_MageForests_MageForestId",
                table: "Magelands",
                column: "MageForestId",
                principalTable: "MageForests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Magelands_MageHarbors_MageHarborId",
                table: "Magelands",
                column: "MageHarborId",
                principalTable: "MageHarbors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Magelands_MageSeas_MageSeaId",
                table: "Magelands",
                column: "MageSeaId",
                principalTable: "MageSeas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Magelands_MageTowns_MageTownId",
                table: "Magelands",
                column: "MageTownId",
                principalTable: "MageTowns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Magelands_MageTradeRoads_MageTradeRoadId",
                table: "Magelands",
                column: "MageTradeRoadId",
                principalTable: "MageTradeRoads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MageTowns_MageTownGuardHills_MageTownGuardHillId",
                table: "MageTowns",
                column: "MageTownGuardHillId",
                principalTable: "MageTownGuardHills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MageTowns_MageTownInnTheOldMagicians_MageTownInnTheOldMagicianId",
                table: "MageTowns",
                column: "MageTownInnTheOldMagicianId",
                principalTable: "MageTownInnTheOldMagicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MageTowns_MageTownTheCentralSquares_MageTownTheCentralSquareId",
                table: "MageTowns",
                column: "MageTownTheCentralSquareId",
                principalTable: "MageTownTheCentralSquares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MageTowns_MageTownTheLibraries_MageTownTheLibraryId",
                table: "MageTowns",
                column: "MageTownTheLibraryId",
                principalTable: "MageTownTheLibraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_Dikanis_DikaniId",
                table: "Redimels",
                column: "DikaniId",
                principalTable: "Dikanis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_Faegras_FaegraId",
                table: "Redimels",
                column: "FaegraId",
                principalTable: "Faegras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_Magelands_MagelandsId",
                table: "Redimels",
                column: "MagelandsId",
                principalTable: "Magelands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_NorthernNomads_NorthernNomadsId",
                table: "Redimels",
                column: "NorthernNomadsId",
                principalTable: "NorthernNomads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_OutlawTerritories_OutlawTerritoryId",
                table: "Redimels",
                column: "OutlawTerritoryId",
                principalTable: "OutlawTerritories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_SouthernNomads_SouthernNomadsId",
                table: "Redimels",
                column: "SouthernNomadsId",
                principalTable: "SouthernNomads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_Stincums_StincumId",
                table: "Redimels",
                column: "StincumId",
                principalTable: "Stincums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_TheBigCities_TheBigCityId",
                table: "Redimels",
                column: "TheBigCityId",
                principalTable: "TheBigCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_TheEmpires_TheEmpireId",
                table: "Redimels",
                column: "TheEmpireId",
                principalTable: "TheEmpires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_TheForestTribes_TheForestTribesId",
                table: "Redimels",
                column: "TheForestTribesId",
                principalTable: "TheForestTribes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_TheHigherOnes_TheHigherOnesId",
                table: "Redimels",
                column: "TheHigherOnesId",
                principalTable: "TheHigherOnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_TheHorsePeoples_TheHorsePeopleId",
                table: "Redimels",
                column: "TheHorsePeopleId",
                principalTable: "TheHorsePeoples",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_TheHunters_TheHuntersId",
                table: "Redimels",
                column: "TheHuntersId",
                principalTable: "TheHunters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_TheIslanders_TheIslandersId",
                table: "Redimels",
                column: "TheIslandersId",
                principalTable: "TheIslanders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_TheOldKingdoms_TheOldKingdomId",
                table: "Redimels",
                column: "TheOldKingdomId",
                principalTable: "TheOldKingdoms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_ThePirateDomains_ThePirateDomainsId",
                table: "Redimels",
                column: "ThePirateDomainsId",
                principalTable: "ThePirateDomains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_TheShadowWorlds_TheShadowWorldId",
                table: "Redimels",
                column: "TheShadowWorldId",
                principalTable: "TheShadowWorlds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_TheTradeLeagues_TheTradeLeagueId",
                table: "Redimels",
                column: "TheTradeLeagueId",
                principalTable: "TheTradeLeagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_TheWastelands_TheWastelandId",
                table: "Redimels",
                column: "TheWastelandId",
                principalTable: "TheWastelands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redimels_Tumpridadams_TumpridadamId",
                table: "Redimels",
                column: "TumpridadamId",
                principalTable: "Tumpridadams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Magelands_MageFields_MageFieldsId",
                table: "Magelands");

            migrationBuilder.DropForeignKey(
                name: "FK_Magelands_MageForests_MageForestId",
                table: "Magelands");

            migrationBuilder.DropForeignKey(
                name: "FK_Magelands_MageHarbors_MageHarborId",
                table: "Magelands");

            migrationBuilder.DropForeignKey(
                name: "FK_Magelands_MageSeas_MageSeaId",
                table: "Magelands");

            migrationBuilder.DropForeignKey(
                name: "FK_Magelands_MageTowns_MageTownId",
                table: "Magelands");

            migrationBuilder.DropForeignKey(
                name: "FK_Magelands_MageTradeRoads_MageTradeRoadId",
                table: "Magelands");

            migrationBuilder.DropForeignKey(
                name: "FK_MageTowns_MageTownGuardHills_MageTownGuardHillId",
                table: "MageTowns");

            migrationBuilder.DropForeignKey(
                name: "FK_MageTowns_MageTownInnTheOldMagicians_MageTownInnTheOldMagicianId",
                table: "MageTowns");

            migrationBuilder.DropForeignKey(
                name: "FK_MageTowns_MageTownTheCentralSquares_MageTownTheCentralSquareId",
                table: "MageTowns");

            migrationBuilder.DropForeignKey(
                name: "FK_MageTowns_MageTownTheLibraries_MageTownTheLibraryId",
                table: "MageTowns");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_Dikanis_DikaniId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_Faegras_FaegraId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_Magelands_MagelandsId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_NorthernNomads_NorthernNomadsId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_OutlawTerritories_OutlawTerritoryId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_SouthernNomads_SouthernNomadsId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_Stincums_StincumId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_TheBigCities_TheBigCityId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_TheEmpires_TheEmpireId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_TheForestTribes_TheForestTribesId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_TheHigherOnes_TheHigherOnesId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_TheHorsePeoples_TheHorsePeopleId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_TheHunters_TheHuntersId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_TheIslanders_TheIslandersId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_TheOldKingdoms_TheOldKingdomId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_ThePirateDomains_ThePirateDomainsId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_TheShadowWorlds_TheShadowWorldId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_TheTradeLeagues_TheTradeLeagueId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_TheWastelands_TheWastelandId",
                table: "Redimels");

            migrationBuilder.DropForeignKey(
                name: "FK_Redimels_Tumpridadams_TumpridadamId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_DikaniId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_FaegraId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_MagelandsId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_NorthernNomadsId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_OutlawTerritoryId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_SouthernNomadsId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_StincumId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_TheBigCityId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_TheEmpireId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_TheForestTribesId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_TheHigherOnesId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_TheHorsePeopleId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_TheHuntersId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_TheIslandersId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_TheOldKingdomId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_ThePirateDomainsId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_TheShadowWorldId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_TheTradeLeagueId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_TheWastelandId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_Redimels_TumpridadamId",
                table: "Redimels");

            migrationBuilder.DropIndex(
                name: "IX_MageTowns_MageTownGuardHillId",
                table: "MageTowns");

            migrationBuilder.DropIndex(
                name: "IX_MageTowns_MageTownInnTheOldMagicianId",
                table: "MageTowns");

            migrationBuilder.DropIndex(
                name: "IX_MageTowns_MageTownTheCentralSquareId",
                table: "MageTowns");

            migrationBuilder.DropIndex(
                name: "IX_MageTowns_MageTownTheLibraryId",
                table: "MageTowns");

            migrationBuilder.DropIndex(
                name: "IX_Magelands_MageFieldsId",
                table: "Magelands");

            migrationBuilder.DropIndex(
                name: "IX_Magelands_MageForestId",
                table: "Magelands");

            migrationBuilder.DropIndex(
                name: "IX_Magelands_MageHarborId",
                table: "Magelands");

            migrationBuilder.DropIndex(
                name: "IX_Magelands_MageSeaId",
                table: "Magelands");

            migrationBuilder.DropIndex(
                name: "IX_Magelands_MageTownId",
                table: "Magelands");

            migrationBuilder.DropIndex(
                name: "IX_Magelands_MageTradeRoadId",
                table: "Magelands");

            migrationBuilder.DropColumn(
                name: "DikaniId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "FaegraId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "MagelandId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "MagelandsId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "NorthernNomadsId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "OutlawTerritoryId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "SouthernNomadsId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "StincumId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "TheBigCityId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "TheEmpireId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "TheForestTribesId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "TheHigherOnesId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "TheHorsePeopleId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "TheHuntersId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "TheIslandersId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "TheOldKingdomId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "ThePirateDomainsId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "TheShadowWorldId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "TheTradeLeagueId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "TheWastelandId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "TumpridadamId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "IsTheGuardAlive",
                table: "MageTownTheLibraries");

            migrationBuilder.DropColumn(
                name: "MageTownGuardHillId",
                table: "MageTowns");

            migrationBuilder.DropColumn(
                name: "MageTownInnTheOldMagicianId",
                table: "MageTowns");

            migrationBuilder.DropColumn(
                name: "MageTownTheCentralSquareId",
                table: "MageTowns");

            migrationBuilder.DropColumn(
                name: "MageTownTheLibraryId",
                table: "MageTowns");

            migrationBuilder.DropColumn(
                name: "MageFieldsId",
                table: "Magelands");

            migrationBuilder.DropColumn(
                name: "MageForestId",
                table: "Magelands");

            migrationBuilder.DropColumn(
                name: "MageHarborId",
                table: "Magelands");

            migrationBuilder.DropColumn(
                name: "MageSeaId",
                table: "Magelands");

            migrationBuilder.DropColumn(
                name: "MageTownId",
                table: "Magelands");

            migrationBuilder.DropColumn(
                name: "MageTradeRoadId",
                table: "Magelands");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "Tumpridadams",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheWastelands",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheTradeLeagues",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheShadowWorlds",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "ThePirateDomains",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheOldKingdoms",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheIslanders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheHunters",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheHorsePeoples",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheHigherOnes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheForestTribes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheEmpires",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "TheBigCities",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "Stincums",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "SouthernNomads",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "OutlawTerritories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "NorthernNomads",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MagelandId",
                table: "MageTradeRoads",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MageTownId",
                table: "MageTownTheCentralSquares",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MageTownId",
                table: "MageTownInnTheOldMagicians",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MageTownId",
                table: "MageTownGuardHills",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MagelandId",
                table: "MageSeas",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MagelandId",
                table: "MageHarbors",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MagelandId",
                table: "MageForests",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "MagelandId",
                table: "MageFields",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "Faegras",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "Dikanis",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Tumpridadams_RedimelId",
                table: "Tumpridadams",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheWastelands_RedimelId",
                table: "TheWastelands",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheTradeLeagues_RedimelId",
                table: "TheTradeLeagues",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheShadowWorlds_RedimelId",
                table: "TheShadowWorlds",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_ThePirateDomains_RedimelId",
                table: "ThePirateDomains",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheOldKingdoms_RedimelId",
                table: "TheOldKingdoms",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheIslanders_RedimelId",
                table: "TheIslanders",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheHunters_RedimelId",
                table: "TheHunters",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheHorsePeoples_RedimelId",
                table: "TheHorsePeoples",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheHigherOnes_RedimelId",
                table: "TheHigherOnes",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheForestTribes_RedimelId",
                table: "TheForestTribes",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheEmpires_RedimelId",
                table: "TheEmpires",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheBigCities_RedimelId",
                table: "TheBigCities",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_Stincums_RedimelId",
                table: "Stincums",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_SouthernNomads_RedimelId",
                table: "SouthernNomads",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_OutlawTerritories_RedimelId",
                table: "OutlawTerritories",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_NorthernNomads_RedimelId",
                table: "NorthernNomads",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_MageTradeRoads_MagelandId",
                table: "MageTradeRoads",
                column: "MagelandId");

            migrationBuilder.CreateIndex(
                name: "IX_MageTownTheLibraries_MageTownId",
                table: "MageTownTheLibraries",
                column: "MageTownId");

            migrationBuilder.CreateIndex(
                name: "IX_MageTownTheCentralSquares_MageTownId",
                table: "MageTownTheCentralSquares",
                column: "MageTownId");

            migrationBuilder.CreateIndex(
                name: "IX_MageTowns_MagelandId",
                table: "MageTowns",
                column: "MagelandId");

            migrationBuilder.CreateIndex(
                name: "IX_MageTownInnTheOldMagicians_MageTownId",
                table: "MageTownInnTheOldMagicians",
                column: "MageTownId");

            migrationBuilder.CreateIndex(
                name: "IX_MageTownGuardHills_MageTownId",
                table: "MageTownGuardHills",
                column: "MageTownId");

            migrationBuilder.CreateIndex(
                name: "IX_MageSeas_MagelandId",
                table: "MageSeas",
                column: "MagelandId");

            migrationBuilder.CreateIndex(
                name: "IX_Magelands_RedimelId",
                table: "Magelands",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_MageHarbors_MagelandId",
                table: "MageHarbors",
                column: "MagelandId");

            migrationBuilder.CreateIndex(
                name: "IX_MageForests_MagelandId",
                table: "MageForests",
                column: "MagelandId");

            migrationBuilder.CreateIndex(
                name: "IX_MageFields_MagelandId",
                table: "MageFields",
                column: "MagelandId");

            migrationBuilder.CreateIndex(
                name: "IX_Faegras_RedimelId",
                table: "Faegras",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_Dikanis_RedimelId",
                table: "Dikanis",
                column: "RedimelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dikanis_Redimels_RedimelId",
                table: "Dikanis",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Faegras_Redimels_RedimelId",
                table: "Faegras",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MageFields_Magelands_MagelandId",
                table: "MageFields",
                column: "MagelandId",
                principalTable: "Magelands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MageForests_Magelands_MagelandId",
                table: "MageForests",
                column: "MagelandId",
                principalTable: "Magelands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MageHarbors_Magelands_MagelandId",
                table: "MageHarbors",
                column: "MagelandId",
                principalTable: "Magelands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Magelands_Redimels_RedimelId",
                table: "Magelands",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MageSeas_Magelands_MagelandId",
                table: "MageSeas",
                column: "MagelandId",
                principalTable: "Magelands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MageTownGuardHills_MageTowns_MageTownId",
                table: "MageTownGuardHills",
                column: "MageTownId",
                principalTable: "MageTowns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MageTownInnTheOldMagicians_MageTowns_MageTownId",
                table: "MageTownInnTheOldMagicians",
                column: "MageTownId",
                principalTable: "MageTowns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MageTowns_Magelands_MagelandId",
                table: "MageTowns",
                column: "MagelandId",
                principalTable: "Magelands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MageTownTheCentralSquares_MageTowns_MageTownId",
                table: "MageTownTheCentralSquares",
                column: "MageTownId",
                principalTable: "MageTowns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MageTownTheLibraries_MageTowns_MageTownId",
                table: "MageTownTheLibraries",
                column: "MageTownId",
                principalTable: "MageTowns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MageTradeRoads_Magelands_MagelandId",
                table: "MageTradeRoads",
                column: "MagelandId",
                principalTable: "Magelands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NorthernNomads_Redimels_RedimelId",
                table: "NorthernNomads",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutlawTerritories_Redimels_RedimelId",
                table: "OutlawTerritories",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SouthernNomads_Redimels_RedimelId",
                table: "SouthernNomads",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stincums_Redimels_RedimelId",
                table: "Stincums",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TheBigCities_Redimels_RedimelId",
                table: "TheBigCities",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TheEmpires_Redimels_RedimelId",
                table: "TheEmpires",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TheForestTribes_Redimels_RedimelId",
                table: "TheForestTribes",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TheHigherOnes_Redimels_RedimelId",
                table: "TheHigherOnes",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TheHorsePeoples_Redimels_RedimelId",
                table: "TheHorsePeoples",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TheHunters_Redimels_RedimelId",
                table: "TheHunters",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TheIslanders_Redimels_RedimelId",
                table: "TheIslanders",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TheOldKingdoms_Redimels_RedimelId",
                table: "TheOldKingdoms",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThePirateDomains_Redimels_RedimelId",
                table: "ThePirateDomains",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TheShadowWorlds_Redimels_RedimelId",
                table: "TheShadowWorlds",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TheTradeLeagues_Redimels_RedimelId",
                table: "TheTradeLeagues",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TheWastelands_Redimels_RedimelId",
                table: "TheWastelands",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tumpridadams_Redimels_RedimelId",
                table: "Tumpridadams",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");
        }
    }
}
