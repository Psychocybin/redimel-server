using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace redimel_server.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTableAndUserRepository : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Suspects",
                table: "TheHorsePeoples");

            migrationBuilder.DropColumn(
                name: "Earthquake",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "IsTheWarStarting",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "AnAlly",
                table: "MageTownTheLibraries");

            migrationBuilder.DropColumn(
                name: "BooksRead",
                table: "MageTownTheLibraries");

            migrationBuilder.DropColumn(
                name: "IsTheGuardAlive",
                table: "MageTownTheLibraries");

            migrationBuilder.DropColumn(
                name: "SeekerOfTheLight",
                table: "MageTownTheLibraries");

            migrationBuilder.DropColumn(
                name: "ShadowHunter",
                table: "MageTownTheLibraries");

            migrationBuilder.DropColumn(
                name: "IsPeopleHate",
                table: "MageTowns");

            migrationBuilder.DropColumn(
                name: "SecretKey",
                table: "MageTowns");

            migrationBuilder.DropColumn(
                name: "ShadowCounter",
                table: "MageTowns");

            migrationBuilder.DropColumn(
                name: "NumberOfDoubters",
                table: "Magelands");

            migrationBuilder.DropColumn(
                name: "NumberOfRobberGangs",
                table: "Magelands");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Redimels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "GroupWests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Checkpoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeCounter = table.Column<int>(type: "int", nullable: false),
                    CurrentUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupWestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_GroupWests_GroupWestId",
                        column: x => x.GroupWestId,
                        principalTable: "GroupWests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorldInfoVariable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    TrueOrFalse = table.Column<bool>(type: "bit", nullable: false),
                    DikaniId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FaegraId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MageFieldsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MageForestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MageHarborId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MageSeaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MageTownGuardHillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MageTownId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MageTownInnTheOldMagicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MageTownTheCentralSquareId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MageTownTheLibraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MageTradeRoadId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MagelandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NorthernNomadsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OutlawTerritoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SouthernNomadsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StincumId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TheBigCityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TheEmpireId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TheForestTribesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TheHigherOnesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TheHorsePeopleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TheHuntersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TheIslandersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TheOldKingdomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThePirateDomainsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TheShadowWorldId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TheTradeLeagueId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TheWastelandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TumpridadamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldInfoVariable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_Dikanis_DikaniId",
                        column: x => x.DikaniId,
                        principalTable: "Dikanis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_Faegras_FaegraId",
                        column: x => x.FaegraId,
                        principalTable: "Faegras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_MageFields_MageFieldsId",
                        column: x => x.MageFieldsId,
                        principalTable: "MageFields",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_MageForests_MageForestId",
                        column: x => x.MageForestId,
                        principalTable: "MageForests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_MageHarbors_MageHarborId",
                        column: x => x.MageHarborId,
                        principalTable: "MageHarbors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_MageSeas_MageSeaId",
                        column: x => x.MageSeaId,
                        principalTable: "MageSeas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_MageTownGuardHills_MageTownGuardHillId",
                        column: x => x.MageTownGuardHillId,
                        principalTable: "MageTownGuardHills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_MageTownInnTheOldMagicians_MageTownInnTheOldMagicianId",
                        column: x => x.MageTownInnTheOldMagicianId,
                        principalTable: "MageTownInnTheOldMagicians",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_MageTownTheCentralSquares_MageTownTheCentralSquareId",
                        column: x => x.MageTownTheCentralSquareId,
                        principalTable: "MageTownTheCentralSquares",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_MageTownTheLibraries_MageTownTheLibraryId",
                        column: x => x.MageTownTheLibraryId,
                        principalTable: "MageTownTheLibraries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_MageTowns_MageTownId",
                        column: x => x.MageTownId,
                        principalTable: "MageTowns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_MageTradeRoads_MageTradeRoadId",
                        column: x => x.MageTradeRoadId,
                        principalTable: "MageTradeRoads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_Magelands_MagelandId",
                        column: x => x.MagelandId,
                        principalTable: "Magelands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_NorthernNomads_NorthernNomadsId",
                        column: x => x.NorthernNomadsId,
                        principalTable: "NorthernNomads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_OutlawTerritories_OutlawTerritoryId",
                        column: x => x.OutlawTerritoryId,
                        principalTable: "OutlawTerritories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_SouthernNomads_SouthernNomadsId",
                        column: x => x.SouthernNomadsId,
                        principalTable: "SouthernNomads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_Stincums_StincumId",
                        column: x => x.StincumId,
                        principalTable: "Stincums",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_TheBigCities_TheBigCityId",
                        column: x => x.TheBigCityId,
                        principalTable: "TheBigCities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_TheEmpires_TheEmpireId",
                        column: x => x.TheEmpireId,
                        principalTable: "TheEmpires",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_TheForestTribes_TheForestTribesId",
                        column: x => x.TheForestTribesId,
                        principalTable: "TheForestTribes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_TheHigherOnes_TheHigherOnesId",
                        column: x => x.TheHigherOnesId,
                        principalTable: "TheHigherOnes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_TheHorsePeoples_TheHorsePeopleId",
                        column: x => x.TheHorsePeopleId,
                        principalTable: "TheHorsePeoples",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_TheHunters_TheHuntersId",
                        column: x => x.TheHuntersId,
                        principalTable: "TheHunters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_TheIslanders_TheIslandersId",
                        column: x => x.TheIslandersId,
                        principalTable: "TheIslanders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_TheOldKingdoms_TheOldKingdomId",
                        column: x => x.TheOldKingdomId,
                        principalTable: "TheOldKingdoms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_ThePirateDomains_ThePirateDomainsId",
                        column: x => x.ThePirateDomainsId,
                        principalTable: "ThePirateDomains",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_TheShadowWorlds_TheShadowWorldId",
                        column: x => x.TheShadowWorldId,
                        principalTable: "TheShadowWorlds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_TheTradeLeagues_TheTradeLeagueId",
                        column: x => x.TheTradeLeagueId,
                        principalTable: "TheTradeLeagues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_TheWastelands_TheWastelandId",
                        column: x => x.TheWastelandId,
                        principalTable: "TheWastelands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariable_Tumpridadams_TumpridadamId",
                        column: x => x.TumpridadamId,
                        principalTable: "Tumpridadams",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "GroupWests",
                keyColumn: "Id",
                keyValue: new Guid("44a06217-58ec-4dce-bb7d-5a951e2bef9e"),
                column: "UserId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupWestId",
                table: "Users",
                column: "GroupWestId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RedimelId",
                table: "Users",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_DikaniId",
                table: "WorldInfoVariable",
                column: "DikaniId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_FaegraId",
                table: "WorldInfoVariable",
                column: "FaegraId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_MageFieldsId",
                table: "WorldInfoVariable",
                column: "MageFieldsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_MageForestId",
                table: "WorldInfoVariable",
                column: "MageForestId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_MageHarborId",
                table: "WorldInfoVariable",
                column: "MageHarborId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_MagelandId",
                table: "WorldInfoVariable",
                column: "MagelandId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_MageSeaId",
                table: "WorldInfoVariable",
                column: "MageSeaId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_MageTownGuardHillId",
                table: "WorldInfoVariable",
                column: "MageTownGuardHillId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_MageTownId",
                table: "WorldInfoVariable",
                column: "MageTownId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_MageTownInnTheOldMagicianId",
                table: "WorldInfoVariable",
                column: "MageTownInnTheOldMagicianId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_MageTownTheCentralSquareId",
                table: "WorldInfoVariable",
                column: "MageTownTheCentralSquareId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_MageTownTheLibraryId",
                table: "WorldInfoVariable",
                column: "MageTownTheLibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_MageTradeRoadId",
                table: "WorldInfoVariable",
                column: "MageTradeRoadId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_NorthernNomadsId",
                table: "WorldInfoVariable",
                column: "NorthernNomadsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_OutlawTerritoryId",
                table: "WorldInfoVariable",
                column: "OutlawTerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_RedimelId",
                table: "WorldInfoVariable",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_SouthernNomadsId",
                table: "WorldInfoVariable",
                column: "SouthernNomadsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_StincumId",
                table: "WorldInfoVariable",
                column: "StincumId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_TheBigCityId",
                table: "WorldInfoVariable",
                column: "TheBigCityId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_TheEmpireId",
                table: "WorldInfoVariable",
                column: "TheEmpireId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_TheForestTribesId",
                table: "WorldInfoVariable",
                column: "TheForestTribesId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_TheHigherOnesId",
                table: "WorldInfoVariable",
                column: "TheHigherOnesId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_TheHorsePeopleId",
                table: "WorldInfoVariable",
                column: "TheHorsePeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_TheHuntersId",
                table: "WorldInfoVariable",
                column: "TheHuntersId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_TheIslandersId",
                table: "WorldInfoVariable",
                column: "TheIslandersId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_TheOldKingdomId",
                table: "WorldInfoVariable",
                column: "TheOldKingdomId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_ThePirateDomainsId",
                table: "WorldInfoVariable",
                column: "ThePirateDomainsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_TheShadowWorldId",
                table: "WorldInfoVariable",
                column: "TheShadowWorldId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_TheTradeLeagueId",
                table: "WorldInfoVariable",
                column: "TheTradeLeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_TheWastelandId",
                table: "WorldInfoVariable",
                column: "TheWastelandId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariable_TumpridadamId",
                table: "WorldInfoVariable",
                column: "TumpridadamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WorldInfoVariable");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Redimels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GroupWests");

            migrationBuilder.AddColumn<bool>(
                name: "Suspects",
                table: "TheHorsePeoples",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Earthquake",
                table: "Redimels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTheWarStarting",
                table: "Redimels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AnAlly",
                table: "MageTownTheLibraries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BooksRead",
                table: "MageTownTheLibraries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsTheGuardAlive",
                table: "MageTownTheLibraries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SeekerOfTheLight",
                table: "MageTownTheLibraries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShadowHunter",
                table: "MageTownTheLibraries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPeopleHate",
                table: "MageTowns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecretKey",
                table: "MageTowns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShadowCounter",
                table: "MageTowns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDoubters",
                table: "Magelands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRobberGangs",
                table: "Magelands",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
