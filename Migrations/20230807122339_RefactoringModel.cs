using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace redimel_server.Migrations
{
    /// <inheritdoc />
    public partial class RefactoringModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_Dikanis_DikaniId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_Faegras_FaegraId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_MageFields_MageFieldsId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_MageForests_MageForestId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_MageHarbors_MageHarborId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_MageSeas_MageSeaId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_MageTownGuardHills_MageTownGuardHillId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_MageTownInnTheOldMagicians_MageTownInnTheOldMagicianId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_MageTownTheCentralSquares_MageTownTheCentralSquareId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_MageTownTheLibraries_MageTownTheLibraryId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_MageTowns_MageTownId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_MageTradeRoads_MageTradeRoadId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_Magelands_MagelandId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_NorthernNomads_NorthernNomadsId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_OutlawTerritories_OutlawTerritoryId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_Redimels_RedimelId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_SouthernNomads_SouthernNomadsId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_Stincums_StincumId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_TheBigCities_TheBigCityId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_TheEmpires_TheEmpireId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_TheForestTribes_TheForestTribesId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_TheHigherOnes_TheHigherOnesId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_TheHorsePeoples_TheHorsePeopleId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_TheHunters_TheHuntersId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_TheIslanders_TheIslandersId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_TheOldKingdoms_TheOldKingdomId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_ThePirateDomains_ThePirateDomainsId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_TheShadowWorlds_TheShadowWorldId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_TheTradeLeagues_TheTradeLeagueId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_TheWastelands_TheWastelandId",
                table: "WorldInfoVariable");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariable_Tumpridadams_TumpridadamId",
                table: "WorldInfoVariable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorldInfoVariable",
                table: "WorldInfoVariable");

            migrationBuilder.RenameTable(
                name: "WorldInfoVariable",
                newName: "WorldInfoVariables");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_TumpridadamId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_TumpridadamId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_TheWastelandId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_TheWastelandId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_TheTradeLeagueId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_TheTradeLeagueId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_TheShadowWorldId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_TheShadowWorldId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_ThePirateDomainsId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_ThePirateDomainsId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_TheOldKingdomId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_TheOldKingdomId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_TheIslandersId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_TheIslandersId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_TheHuntersId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_TheHuntersId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_TheHorsePeopleId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_TheHorsePeopleId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_TheHigherOnesId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_TheHigherOnesId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_TheForestTribesId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_TheForestTribesId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_TheEmpireId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_TheEmpireId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_TheBigCityId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_TheBigCityId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_StincumId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_StincumId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_SouthernNomadsId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_SouthernNomadsId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_RedimelId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_RedimelId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_OutlawTerritoryId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_OutlawTerritoryId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_NorthernNomadsId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_NorthernNomadsId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_MageTradeRoadId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_MageTradeRoadId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_MageTownTheLibraryId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_MageTownTheLibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_MageTownTheCentralSquareId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_MageTownTheCentralSquareId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_MageTownInnTheOldMagicianId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_MageTownInnTheOldMagicianId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_MageTownId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_MageTownId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_MageTownGuardHillId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_MageTownGuardHillId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_MageSeaId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_MageSeaId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_MagelandId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_MagelandId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_MageHarborId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_MageHarborId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_MageForestId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_MageForestId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_MageFieldsId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_MageFieldsId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_FaegraId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_FaegraId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariable_DikaniId",
                table: "WorldInfoVariables",
                newName: "IX_WorldInfoVariables_DikaniId");

            migrationBuilder.AddColumn<int>(
                name: "OrderOfBattle",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorldInfoVariables",
                table: "WorldInfoVariables",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: new Guid("a9542e10-30a3-45a8-b2ea-cacef3df468a"),
                column: "OrderOfBattle",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: new Guid("e1f39f3c-0fb5-40d4-84d1-b6a46c5c0568"),
                column: "OrderOfBattle",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_Dikanis_DikaniId",
                table: "WorldInfoVariables",
                column: "DikaniId",
                principalTable: "Dikanis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_Faegras_FaegraId",
                table: "WorldInfoVariables",
                column: "FaegraId",
                principalTable: "Faegras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_MageFields_MageFieldsId",
                table: "WorldInfoVariables",
                column: "MageFieldsId",
                principalTable: "MageFields",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_MageForests_MageForestId",
                table: "WorldInfoVariables",
                column: "MageForestId",
                principalTable: "MageForests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_MageHarbors_MageHarborId",
                table: "WorldInfoVariables",
                column: "MageHarborId",
                principalTable: "MageHarbors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_MageSeas_MageSeaId",
                table: "WorldInfoVariables",
                column: "MageSeaId",
                principalTable: "MageSeas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_MageTownGuardHills_MageTownGuardHillId",
                table: "WorldInfoVariables",
                column: "MageTownGuardHillId",
                principalTable: "MageTownGuardHills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_MageTownInnTheOldMagicians_MageTownInnTheOldMagicianId",
                table: "WorldInfoVariables",
                column: "MageTownInnTheOldMagicianId",
                principalTable: "MageTownInnTheOldMagicians",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_MageTownTheCentralSquares_MageTownTheCentralSquareId",
                table: "WorldInfoVariables",
                column: "MageTownTheCentralSquareId",
                principalTable: "MageTownTheCentralSquares",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_MageTownTheLibraries_MageTownTheLibraryId",
                table: "WorldInfoVariables",
                column: "MageTownTheLibraryId",
                principalTable: "MageTownTheLibraries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_MageTowns_MageTownId",
                table: "WorldInfoVariables",
                column: "MageTownId",
                principalTable: "MageTowns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_MageTradeRoads_MageTradeRoadId",
                table: "WorldInfoVariables",
                column: "MageTradeRoadId",
                principalTable: "MageTradeRoads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_Magelands_MagelandId",
                table: "WorldInfoVariables",
                column: "MagelandId",
                principalTable: "Magelands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_NorthernNomads_NorthernNomadsId",
                table: "WorldInfoVariables",
                column: "NorthernNomadsId",
                principalTable: "NorthernNomads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_OutlawTerritories_OutlawTerritoryId",
                table: "WorldInfoVariables",
                column: "OutlawTerritoryId",
                principalTable: "OutlawTerritories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_Redimels_RedimelId",
                table: "WorldInfoVariables",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_SouthernNomads_SouthernNomadsId",
                table: "WorldInfoVariables",
                column: "SouthernNomadsId",
                principalTable: "SouthernNomads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_Stincums_StincumId",
                table: "WorldInfoVariables",
                column: "StincumId",
                principalTable: "Stincums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_TheBigCities_TheBigCityId",
                table: "WorldInfoVariables",
                column: "TheBigCityId",
                principalTable: "TheBigCities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_TheEmpires_TheEmpireId",
                table: "WorldInfoVariables",
                column: "TheEmpireId",
                principalTable: "TheEmpires",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_TheForestTribes_TheForestTribesId",
                table: "WorldInfoVariables",
                column: "TheForestTribesId",
                principalTable: "TheForestTribes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_TheHigherOnes_TheHigherOnesId",
                table: "WorldInfoVariables",
                column: "TheHigherOnesId",
                principalTable: "TheHigherOnes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_TheHorsePeoples_TheHorsePeopleId",
                table: "WorldInfoVariables",
                column: "TheHorsePeopleId",
                principalTable: "TheHorsePeoples",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_TheHunters_TheHuntersId",
                table: "WorldInfoVariables",
                column: "TheHuntersId",
                principalTable: "TheHunters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_TheIslanders_TheIslandersId",
                table: "WorldInfoVariables",
                column: "TheIslandersId",
                principalTable: "TheIslanders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_TheOldKingdoms_TheOldKingdomId",
                table: "WorldInfoVariables",
                column: "TheOldKingdomId",
                principalTable: "TheOldKingdoms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_ThePirateDomains_ThePirateDomainsId",
                table: "WorldInfoVariables",
                column: "ThePirateDomainsId",
                principalTable: "ThePirateDomains",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_TheShadowWorlds_TheShadowWorldId",
                table: "WorldInfoVariables",
                column: "TheShadowWorldId",
                principalTable: "TheShadowWorlds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_TheTradeLeagues_TheTradeLeagueId",
                table: "WorldInfoVariables",
                column: "TheTradeLeagueId",
                principalTable: "TheTradeLeagues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_TheWastelands_TheWastelandId",
                table: "WorldInfoVariables",
                column: "TheWastelandId",
                principalTable: "TheWastelands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariables_Tumpridadams_TumpridadamId",
                table: "WorldInfoVariables",
                column: "TumpridadamId",
                principalTable: "Tumpridadams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_Dikanis_DikaniId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_Faegras_FaegraId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_MageFields_MageFieldsId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_MageForests_MageForestId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_MageHarbors_MageHarborId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_MageSeas_MageSeaId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_MageTownGuardHills_MageTownGuardHillId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_MageTownInnTheOldMagicians_MageTownInnTheOldMagicianId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_MageTownTheCentralSquares_MageTownTheCentralSquareId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_MageTownTheLibraries_MageTownTheLibraryId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_MageTowns_MageTownId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_MageTradeRoads_MageTradeRoadId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_Magelands_MagelandId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_NorthernNomads_NorthernNomadsId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_OutlawTerritories_OutlawTerritoryId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_Redimels_RedimelId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_SouthernNomads_SouthernNomadsId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_Stincums_StincumId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_TheBigCities_TheBigCityId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_TheEmpires_TheEmpireId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_TheForestTribes_TheForestTribesId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_TheHigherOnes_TheHigherOnesId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_TheHorsePeoples_TheHorsePeopleId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_TheHunters_TheHuntersId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_TheIslanders_TheIslandersId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_TheOldKingdoms_TheOldKingdomId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_ThePirateDomains_ThePirateDomainsId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_TheShadowWorlds_TheShadowWorldId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_TheTradeLeagues_TheTradeLeagueId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_TheWastelands_TheWastelandId",
                table: "WorldInfoVariables");

            migrationBuilder.DropForeignKey(
                name: "FK_WorldInfoVariables_Tumpridadams_TumpridadamId",
                table: "WorldInfoVariables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorldInfoVariables",
                table: "WorldInfoVariables");

            migrationBuilder.DropColumn(
                name: "OrderOfBattle",
                table: "Heroes");

            migrationBuilder.RenameTable(
                name: "WorldInfoVariables",
                newName: "WorldInfoVariable");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_TumpridadamId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_TumpridadamId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_TheWastelandId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_TheWastelandId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_TheTradeLeagueId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_TheTradeLeagueId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_TheShadowWorldId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_TheShadowWorldId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_ThePirateDomainsId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_ThePirateDomainsId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_TheOldKingdomId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_TheOldKingdomId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_TheIslandersId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_TheIslandersId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_TheHuntersId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_TheHuntersId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_TheHorsePeopleId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_TheHorsePeopleId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_TheHigherOnesId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_TheHigherOnesId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_TheForestTribesId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_TheForestTribesId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_TheEmpireId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_TheEmpireId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_TheBigCityId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_TheBigCityId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_StincumId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_StincumId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_SouthernNomadsId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_SouthernNomadsId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_RedimelId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_RedimelId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_OutlawTerritoryId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_OutlawTerritoryId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_NorthernNomadsId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_NorthernNomadsId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_MageTradeRoadId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_MageTradeRoadId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_MageTownTheLibraryId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_MageTownTheLibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_MageTownTheCentralSquareId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_MageTownTheCentralSquareId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_MageTownInnTheOldMagicianId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_MageTownInnTheOldMagicianId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_MageTownId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_MageTownId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_MageTownGuardHillId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_MageTownGuardHillId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_MageSeaId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_MageSeaId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_MagelandId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_MagelandId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_MageHarborId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_MageHarborId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_MageForestId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_MageForestId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_MageFieldsId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_MageFieldsId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_FaegraId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_FaegraId");

            migrationBuilder.RenameIndex(
                name: "IX_WorldInfoVariables_DikaniId",
                table: "WorldInfoVariable",
                newName: "IX_WorldInfoVariable_DikaniId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorldInfoVariable",
                table: "WorldInfoVariable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_Dikanis_DikaniId",
                table: "WorldInfoVariable",
                column: "DikaniId",
                principalTable: "Dikanis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_Faegras_FaegraId",
                table: "WorldInfoVariable",
                column: "FaegraId",
                principalTable: "Faegras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_MageFields_MageFieldsId",
                table: "WorldInfoVariable",
                column: "MageFieldsId",
                principalTable: "MageFields",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_MageForests_MageForestId",
                table: "WorldInfoVariable",
                column: "MageForestId",
                principalTable: "MageForests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_MageHarbors_MageHarborId",
                table: "WorldInfoVariable",
                column: "MageHarborId",
                principalTable: "MageHarbors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_MageSeas_MageSeaId",
                table: "WorldInfoVariable",
                column: "MageSeaId",
                principalTable: "MageSeas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_MageTownGuardHills_MageTownGuardHillId",
                table: "WorldInfoVariable",
                column: "MageTownGuardHillId",
                principalTable: "MageTownGuardHills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_MageTownInnTheOldMagicians_MageTownInnTheOldMagicianId",
                table: "WorldInfoVariable",
                column: "MageTownInnTheOldMagicianId",
                principalTable: "MageTownInnTheOldMagicians",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_MageTownTheCentralSquares_MageTownTheCentralSquareId",
                table: "WorldInfoVariable",
                column: "MageTownTheCentralSquareId",
                principalTable: "MageTownTheCentralSquares",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_MageTownTheLibraries_MageTownTheLibraryId",
                table: "WorldInfoVariable",
                column: "MageTownTheLibraryId",
                principalTable: "MageTownTheLibraries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_MageTowns_MageTownId",
                table: "WorldInfoVariable",
                column: "MageTownId",
                principalTable: "MageTowns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_MageTradeRoads_MageTradeRoadId",
                table: "WorldInfoVariable",
                column: "MageTradeRoadId",
                principalTable: "MageTradeRoads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_Magelands_MagelandId",
                table: "WorldInfoVariable",
                column: "MagelandId",
                principalTable: "Magelands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_NorthernNomads_NorthernNomadsId",
                table: "WorldInfoVariable",
                column: "NorthernNomadsId",
                principalTable: "NorthernNomads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_OutlawTerritories_OutlawTerritoryId",
                table: "WorldInfoVariable",
                column: "OutlawTerritoryId",
                principalTable: "OutlawTerritories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_Redimels_RedimelId",
                table: "WorldInfoVariable",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_SouthernNomads_SouthernNomadsId",
                table: "WorldInfoVariable",
                column: "SouthernNomadsId",
                principalTable: "SouthernNomads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_Stincums_StincumId",
                table: "WorldInfoVariable",
                column: "StincumId",
                principalTable: "Stincums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_TheBigCities_TheBigCityId",
                table: "WorldInfoVariable",
                column: "TheBigCityId",
                principalTable: "TheBigCities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_TheEmpires_TheEmpireId",
                table: "WorldInfoVariable",
                column: "TheEmpireId",
                principalTable: "TheEmpires",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_TheForestTribes_TheForestTribesId",
                table: "WorldInfoVariable",
                column: "TheForestTribesId",
                principalTable: "TheForestTribes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_TheHigherOnes_TheHigherOnesId",
                table: "WorldInfoVariable",
                column: "TheHigherOnesId",
                principalTable: "TheHigherOnes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_TheHorsePeoples_TheHorsePeopleId",
                table: "WorldInfoVariable",
                column: "TheHorsePeopleId",
                principalTable: "TheHorsePeoples",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_TheHunters_TheHuntersId",
                table: "WorldInfoVariable",
                column: "TheHuntersId",
                principalTable: "TheHunters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_TheIslanders_TheIslandersId",
                table: "WorldInfoVariable",
                column: "TheIslandersId",
                principalTable: "TheIslanders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_TheOldKingdoms_TheOldKingdomId",
                table: "WorldInfoVariable",
                column: "TheOldKingdomId",
                principalTable: "TheOldKingdoms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_ThePirateDomains_ThePirateDomainsId",
                table: "WorldInfoVariable",
                column: "ThePirateDomainsId",
                principalTable: "ThePirateDomains",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_TheShadowWorlds_TheShadowWorldId",
                table: "WorldInfoVariable",
                column: "TheShadowWorldId",
                principalTable: "TheShadowWorlds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_TheTradeLeagues_TheTradeLeagueId",
                table: "WorldInfoVariable",
                column: "TheTradeLeagueId",
                principalTable: "TheTradeLeagues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_TheWastelands_TheWastelandId",
                table: "WorldInfoVariable",
                column: "TheWastelandId",
                principalTable: "TheWastelands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorldInfoVariable_Tumpridadams_TumpridadamId",
                table: "WorldInfoVariable",
                column: "TumpridadamId",
                principalTable: "Tumpridadams",
                principalColumn: "Id");
        }
    }
}
