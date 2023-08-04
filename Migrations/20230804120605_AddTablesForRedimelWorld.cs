using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace redimel_server.Migrations
{
    /// <inheritdoc />
    public partial class AddTablesForRedimelWorld : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Redimels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsTheWarStarting = table.Column<bool>(type: "bit", nullable: false),
                    Earthquake = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redimels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dikanis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dikanis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dikanis_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Faegras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faegras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faegras_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Magelands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfRobberGangs = table.Column<int>(type: "int", nullable: false),
                    NumberOfDoubters = table.Column<int>(type: "int", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magelands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Magelands_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NorthernNomads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NorthernNomads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NorthernNomads_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OutlawTerritories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutlawTerritories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutlawTerritories_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SouthernNomads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SouthernNomads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SouthernNomads_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stincums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stincums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stincums_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TheBigCities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheBigCities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheBigCities_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TheEmpires",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheEmpires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheEmpires_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TheForestTribes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheForestTribes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheForestTribes_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TheHigherOnes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheHigherOnes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheHigherOnes_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TheHorsePeoples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Suspects = table.Column<bool>(type: "bit", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheHorsePeoples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheHorsePeoples_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TheHunters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheHunters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheHunters_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TheIslanders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheIslanders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheIslanders_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TheOldKingdoms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheOldKingdoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheOldKingdoms_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ThePirateDomains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThePirateDomains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThePirateDomains_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TheShadowWorlds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheShadowWorlds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheShadowWorlds_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TheTradeLeagues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheTradeLeagues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheTradeLeagues_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TheWastelands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheWastelands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheWastelands_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tumpridadams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tumpridadams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tumpridadams_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MageFields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MagelandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MageFields_Magelands_MagelandId",
                        column: x => x.MagelandId,
                        principalTable: "Magelands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MageForests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MagelandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageForests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MageForests_Magelands_MagelandId",
                        column: x => x.MagelandId,
                        principalTable: "Magelands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MageHarbors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MagelandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageHarbors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MageHarbors_Magelands_MagelandId",
                        column: x => x.MagelandId,
                        principalTable: "Magelands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MageSeas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MagelandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageSeas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MageSeas_Magelands_MagelandId",
                        column: x => x.MagelandId,
                        principalTable: "Magelands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MageTowns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShadowCounter = table.Column<int>(type: "int", nullable: false),
                    SecretKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPeopleHate = table.Column<bool>(type: "bit", nullable: false),
                    MagelandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageTowns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MageTowns_Magelands_MagelandId",
                        column: x => x.MagelandId,
                        principalTable: "Magelands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MageTradeRoads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MagelandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageTradeRoads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MageTradeRoads_Magelands_MagelandId",
                        column: x => x.MagelandId,
                        principalTable: "Magelands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MageTownGuardHills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MageTownId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageTownGuardHills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MageTownGuardHills_MageTowns_MageTownId",
                        column: x => x.MageTownId,
                        principalTable: "MageTowns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MageTownInnTheOldMagicians",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MageTownId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageTownInnTheOldMagicians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MageTownInnTheOldMagicians_MageTowns_MageTownId",
                        column: x => x.MageTownId,
                        principalTable: "MageTowns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MageTownTheCentralSquares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MageTownId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageTownTheCentralSquares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MageTownTheCentralSquares_MageTowns_MageTownId",
                        column: x => x.MageTownId,
                        principalTable: "MageTowns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MageTownTheLibraries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BooksRead = table.Column<int>(type: "int", nullable: false),
                    AnAlly = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShadowHunter = table.Column<bool>(type: "bit", nullable: false),
                    SeekerOfTheLight = table.Column<bool>(type: "bit", nullable: false),
                    MageTownId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageTownTheLibraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MageTownTheLibraries_MageTowns_MageTownId",
                        column: x => x.MageTownId,
                        principalTable: "MageTowns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dikanis_RedimelId",
                table: "Dikanis",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_Faegras_RedimelId",
                table: "Faegras",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_MageFields_MagelandId",
                table: "MageFields",
                column: "MagelandId");

            migrationBuilder.CreateIndex(
                name: "IX_MageForests_MagelandId",
                table: "MageForests",
                column: "MagelandId");

            migrationBuilder.CreateIndex(
                name: "IX_MageHarbors_MagelandId",
                table: "MageHarbors",
                column: "MagelandId");

            migrationBuilder.CreateIndex(
                name: "IX_Magelands_RedimelId",
                table: "Magelands",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_MageSeas_MagelandId",
                table: "MageSeas",
                column: "MagelandId");

            migrationBuilder.CreateIndex(
                name: "IX_MageTownGuardHills_MageTownId",
                table: "MageTownGuardHills",
                column: "MageTownId");

            migrationBuilder.CreateIndex(
                name: "IX_MageTownInnTheOldMagicians_MageTownId",
                table: "MageTownInnTheOldMagicians",
                column: "MageTownId");

            migrationBuilder.CreateIndex(
                name: "IX_MageTowns_MagelandId",
                table: "MageTowns",
                column: "MagelandId");

            migrationBuilder.CreateIndex(
                name: "IX_MageTownTheCentralSquares_MageTownId",
                table: "MageTownTheCentralSquares",
                column: "MageTownId");

            migrationBuilder.CreateIndex(
                name: "IX_MageTownTheLibraries_MageTownId",
                table: "MageTownTheLibraries",
                column: "MageTownId");

            migrationBuilder.CreateIndex(
                name: "IX_MageTradeRoads_MagelandId",
                table: "MageTradeRoads",
                column: "MagelandId");

            migrationBuilder.CreateIndex(
                name: "IX_NorthernNomads_RedimelId",
                table: "NorthernNomads",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_OutlawTerritories_RedimelId",
                table: "OutlawTerritories",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_SouthernNomads_RedimelId",
                table: "SouthernNomads",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_Stincums_RedimelId",
                table: "Stincums",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheBigCities_RedimelId",
                table: "TheBigCities",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheEmpires_RedimelId",
                table: "TheEmpires",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheForestTribes_RedimelId",
                table: "TheForestTribes",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheHigherOnes_RedimelId",
                table: "TheHigherOnes",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheHorsePeoples_RedimelId",
                table: "TheHorsePeoples",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheHunters_RedimelId",
                table: "TheHunters",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheIslanders_RedimelId",
                table: "TheIslanders",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheOldKingdoms_RedimelId",
                table: "TheOldKingdoms",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_ThePirateDomains_RedimelId",
                table: "ThePirateDomains",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheShadowWorlds_RedimelId",
                table: "TheShadowWorlds",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheTradeLeagues_RedimelId",
                table: "TheTradeLeagues",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_TheWastelands_RedimelId",
                table: "TheWastelands",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tumpridadams_RedimelId",
                table: "Tumpridadams",
                column: "RedimelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dikanis");

            migrationBuilder.DropTable(
                name: "Faegras");

            migrationBuilder.DropTable(
                name: "MageFields");

            migrationBuilder.DropTable(
                name: "MageForests");

            migrationBuilder.DropTable(
                name: "MageHarbors");

            migrationBuilder.DropTable(
                name: "MageSeas");

            migrationBuilder.DropTable(
                name: "MageTownGuardHills");

            migrationBuilder.DropTable(
                name: "MageTownInnTheOldMagicians");

            migrationBuilder.DropTable(
                name: "MageTownTheCentralSquares");

            migrationBuilder.DropTable(
                name: "MageTownTheLibraries");

            migrationBuilder.DropTable(
                name: "MageTradeRoads");

            migrationBuilder.DropTable(
                name: "NorthernNomads");

            migrationBuilder.DropTable(
                name: "OutlawTerritories");

            migrationBuilder.DropTable(
                name: "SouthernNomads");

            migrationBuilder.DropTable(
                name: "Stincums");

            migrationBuilder.DropTable(
                name: "TheBigCities");

            migrationBuilder.DropTable(
                name: "TheEmpires");

            migrationBuilder.DropTable(
                name: "TheForestTribes");

            migrationBuilder.DropTable(
                name: "TheHigherOnes");

            migrationBuilder.DropTable(
                name: "TheHorsePeoples");

            migrationBuilder.DropTable(
                name: "TheHunters");

            migrationBuilder.DropTable(
                name: "TheIslanders");

            migrationBuilder.DropTable(
                name: "TheOldKingdoms");

            migrationBuilder.DropTable(
                name: "ThePirateDomains");

            migrationBuilder.DropTable(
                name: "TheShadowWorlds");

            migrationBuilder.DropTable(
                name: "TheTradeLeagues");

            migrationBuilder.DropTable(
                name: "TheWastelands");

            migrationBuilder.DropTable(
                name: "Tumpridadams");

            migrationBuilder.DropTable(
                name: "MageTowns");

            migrationBuilder.DropTable(
                name: "Magelands");

            migrationBuilder.DropTable(
                name: "Redimels");
        }
    }
}
