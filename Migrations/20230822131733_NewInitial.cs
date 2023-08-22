using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace redimel_server.Migrations
{
    /// <inheritdoc />
    public partial class NewInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Survival = table.Column<bool>(type: "bit", nullable: false),
                    Diplomacy = table.Column<bool>(type: "bit", nullable: false),
                    Climbing = table.Column<bool>(type: "bit", nullable: false),
                    Acrobatics = table.Column<bool>(type: "bit", nullable: false),
                    Skill = table.Column<bool>(type: "bit", nullable: false),
                    Guile = table.Column<bool>(type: "bit", nullable: false),
                    SecretKnowledge = table.Column<bool>(type: "bit", nullable: false),
                    Sneak = table.Column<bool>(type: "bit", nullable: false),
                    Elusion = table.Column<bool>(type: "bit", nullable: false),
                    WaterCycle = table.Column<bool>(type: "bit", nullable: false),
                    Melee = table.Column<bool>(type: "bit", nullable: false),
                    NatureSkills = table.Column<bool>(type: "bit", nullable: false),
                    BreakingLocks = table.Column<bool>(type: "bit", nullable: false),
                    Transformation = table.Column<bool>(type: "bit", nullable: false),
                    Spells = table.Column<bool>(type: "bit", nullable: false),
                    Rituals = table.Column<bool>(type: "bit", nullable: false),
                    Traps = table.Column<bool>(type: "bit", nullable: false),
                    Archery = table.Column<bool>(type: "bit", nullable: false),
                    ThrowingKnives = table.Column<bool>(type: "bit", nullable: false),
                    PoisonousNeedles = table.Column<bool>(type: "bit", nullable: false),
                    Stimulants = table.Column<bool>(type: "bit", nullable: false),
                    Wrestling = table.Column<bool>(type: "bit", nullable: false),
                    Observation = table.Column<bool>(type: "bit", nullable: false),
                    ShieldBearer = table.Column<bool>(type: "bit", nullable: false),
                    HeroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AditionalPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamGame = table.Column<int>(type: "int", nullable: false),
                    ImportantInformation = table.Column<int>(type: "int", nullable: false),
                    SlainMonsters = table.Column<int>(type: "int", nullable: false),
                    Morals = table.Column<int>(type: "int", nullable: false),
                    Cover = table.Column<int>(type: "int", nullable: false),
                    GroupWestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AditionalPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Armors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArmorType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsExist = table.Column<bool>(type: "bit", nullable: false),
                    Defence = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dikanis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dikanis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faegras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faegras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Indicators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    MentalEnergy = table.Column<int>(type: "int", nullable: false),
                    MentalStrength = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Agility = table.Column<int>(type: "int", nullable: false),
                    Evasion = table.Column<int>(type: "int", nullable: false),
                    Endurance = table.Column<int>(type: "int", nullable: false),
                    HeroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MageFields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MagelandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MageForests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MagelandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageForests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MageHarbors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MagelandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageHarbors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MageSeas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MagelandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageSeas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MageTownGuardHills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MageTownId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageTownGuardHills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MageTownInnTheOldMagicians",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MageTownId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageTownInnTheOldMagicians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MageTownTheCentralSquares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MageTownId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageTownTheCentralSquares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MageTownTheLibraries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MageTownId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageTownTheLibraries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MageTradeRoads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MagelandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageTradeRoads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NorthernNomads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NorthernNomads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutlawTerritories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutlawTerritories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShieldType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsExist = table.Column<bool>(type: "bit", nullable: false),
                    Defence = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SouthernNomads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SouthernNomads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialCombatSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    RequiredMentalEnergy = table.Column<int>(type: "int", nullable: false),
                    SpecialAbilitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialCombatSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stincums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stincums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheBigCities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheBigCities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheEmpires",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheEmpires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheForestTribes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheForestTribes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheHigherOnes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheHigherOnes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheHorsePeoples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheHorsePeoples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheHunters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheHunters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheIslanders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheIslanders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheOldKingdoms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheOldKingdoms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThePirateDomains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThePirateDomains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheShadowWorlds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheShadowWorlds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheTradeLeagues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheTradeLeagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheWastelands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheWastelands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThrowingWeapons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThrowingWeaponType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsExist = table.Column<bool>(type: "bit", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defence = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ThrowingWeaponRange = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThrowingWeapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tumpridadams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tumpridadams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ultimates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    RequiredMentalEnergy = table.Column<int>(type: "int", nullable: false),
                    SpecialAbilitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ultimates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeaponType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsExist = table.Column<bool>(type: "bit", nullable: false),
                    IsItTwoHandWeapon = table.Column<bool>(type: "bit", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defence = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    WeaponRange = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BattleGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountPeople = table.Column<int>(type: "int", nullable: false),
                    AditionalPointsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleGroups_AditionalPoints_AditionalPointsId",
                        column: x => x.AditionalPointsId,
                        principalTable: "AditionalPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupWests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActualMission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AditionalPointsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupWests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupWests_AditionalPoints_AditionalPointsId",
                        column: x => x.AditionalPointsId,
                        principalTable: "AditionalPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Negotiations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AditionalPointsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negotiations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Negotiations_AditionalPoints_AditionalPointsId",
                        column: x => x.AditionalPointsId,
                        principalTable: "AditionalPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MageTowns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MagelandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MageTownTheCentralSquareId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MageTownInnTheOldMagicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MageTownTheLibraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MageTownGuardHillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MageTowns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MageTowns_MageTownGuardHills_MageTownGuardHillId",
                        column: x => x.MageTownGuardHillId,
                        principalTable: "MageTownGuardHills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MageTowns_MageTownInnTheOldMagicians_MageTownInnTheOldMagicianId",
                        column: x => x.MageTownInnTheOldMagicianId,
                        principalTable: "MageTownInnTheOldMagicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MageTowns_MageTownTheCentralSquares_MageTownTheCentralSquareId",
                        column: x => x.MageTownTheCentralSquareId,
                        principalTable: "MageTownTheCentralSquares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MageTowns_MageTownTheLibraries_MageTownTheLibraryId",
                        column: x => x.MageTownTheLibraryId,
                        principalTable: "MageTownTheLibraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextPage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choices_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialAbilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecialCombatSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialAbilities_SpecialCombatSkills_SpecialCombatSkillId",
                        column: x => x.SpecialCombatSkillId,
                        principalTable: "SpecialCombatSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialAbilities_Ultimates_UltimateId",
                        column: x => x.UltimateId,
                        principalTable: "Ultimates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Knife = table.Column<bool>(type: "bit", nullable: false),
                    SmokeBall = table.Column<bool>(type: "bit", nullable: false),
                    Poison = table.Column<bool>(type: "bit", nullable: false),
                    MedicPack = table.Column<bool>(type: "bit", nullable: false),
                    MoneyBag = table.Column<int>(type: "int", nullable: false),
                    HeroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArmorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeaponId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThrowingWeaponId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_Armors_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipments_Shields_ShieldId",
                        column: x => x.ShieldId,
                        principalTable: "Shields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipments_ThrowingWeapons_ThrowingWeaponId",
                        column: x => x.ThrowingWeaponId,
                        principalTable: "ThrowingWeapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipments_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsItDone = table.Column<bool>(type: "bit", nullable: false),
                    GroupWestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missions_GroupWests_GroupWestId",
                        column: x => x.GroupWestId,
                        principalTable: "GroupWests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Magelands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedimelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MageTownId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MageFieldsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MageForestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MageSeaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MageHarborId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MageTradeRoadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magelands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Magelands_MageFields_MageFieldsId",
                        column: x => x.MageFieldsId,
                        principalTable: "MageFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Magelands_MageForests_MageForestId",
                        column: x => x.MageForestId,
                        principalTable: "MageForests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Magelands_MageHarbors_MageHarborId",
                        column: x => x.MageHarborId,
                        principalTable: "MageHarbors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Magelands_MageSeas_MageSeaId",
                        column: x => x.MageSeaId,
                        principalTable: "MageSeas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Magelands_MageTowns_MageTownId",
                        column: x => x.MageTownId,
                        principalTable: "MageTowns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Magelands_MageTradeRoads_MageTradeRoadId",
                        column: x => x.MageTradeRoadId,
                        principalTable: "MageTradeRoads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NatureSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    RequiredMentalEnergy = table.Column<int>(type: "int", nullable: false),
                    SpecialAbilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatureSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NatureSkills_SpecialAbilities_SpecialAbilityId",
                        column: x => x.SpecialAbilityId,
                        principalTable: "SpecialAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rituals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    RequiredMentalEnergy = table.Column<int>(type: "int", nullable: false),
                    SpecialAbilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rituals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rituals_SpecialAbilities_SpecialAbilityId",
                        column: x => x.SpecialAbilityId,
                        principalTable: "SpecialAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    RequiredMentalEnergy = table.Column<int>(type: "int", nullable: false),
                    SpecialAbilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spells_SpecialAbilities_SpecialAbilityId",
                        column: x => x.SpecialAbilityId,
                        principalTable: "SpecialAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeroClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderOfBattle = table.Column<int>(type: "int", nullable: false),
                    BaggageCapacity = table.Column<double>(type: "float", nullable: false),
                    GroupWestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndicatorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AbilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecialAbilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heroes_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Heroes_Equipments_EquipmentsId",
                        column: x => x.EquipmentsId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Heroes_GroupWests_GroupWestId",
                        column: x => x.GroupWestId,
                        principalTable: "GroupWests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Heroes_Indicators_IndicatorsId",
                        column: x => x.IndicatorsId,
                        principalTable: "Indicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Heroes_SpecialAbilities_SpecialAbilityId",
                        column: x => x.SpecialAbilityId,
                        principalTable: "SpecialAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Talismans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TalismanType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BonusIndicator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BonusPoints = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talismans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Talismans_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Redimels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MagelandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TheHorsePeopleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DikaniId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TumpridadamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TheOldKingdomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TheHigherOnesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TheTradeLeagueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FaegraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TheEmpireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TheBigCityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StincumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThePirateDomainsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TheIslandersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TheForestTribesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SouthernNomadsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NorthernNomadsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TheHuntersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutlawTerritoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TheWastelandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TheShadowWorldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MagelandsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redimels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Redimels_Dikanis_DikaniId",
                        column: x => x.DikaniId,
                        principalTable: "Dikanis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_Faegras_FaegraId",
                        column: x => x.FaegraId,
                        principalTable: "Faegras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_Magelands_MagelandsId",
                        column: x => x.MagelandsId,
                        principalTable: "Magelands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_NorthernNomads_NorthernNomadsId",
                        column: x => x.NorthernNomadsId,
                        principalTable: "NorthernNomads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_OutlawTerritories_OutlawTerritoryId",
                        column: x => x.OutlawTerritoryId,
                        principalTable: "OutlawTerritories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_SouthernNomads_SouthernNomadsId",
                        column: x => x.SouthernNomadsId,
                        principalTable: "SouthernNomads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_Stincums_StincumId",
                        column: x => x.StincumId,
                        principalTable: "Stincums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_TheBigCities_TheBigCityId",
                        column: x => x.TheBigCityId,
                        principalTable: "TheBigCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_TheEmpires_TheEmpireId",
                        column: x => x.TheEmpireId,
                        principalTable: "TheEmpires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_TheForestTribes_TheForestTribesId",
                        column: x => x.TheForestTribesId,
                        principalTable: "TheForestTribes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_TheHigherOnes_TheHigherOnesId",
                        column: x => x.TheHigherOnesId,
                        principalTable: "TheHigherOnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_TheHorsePeoples_TheHorsePeopleId",
                        column: x => x.TheHorsePeopleId,
                        principalTable: "TheHorsePeoples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_TheHunters_TheHuntersId",
                        column: x => x.TheHuntersId,
                        principalTable: "TheHunters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_TheIslanders_TheIslandersId",
                        column: x => x.TheIslandersId,
                        principalTable: "TheIslanders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_TheOldKingdoms_TheOldKingdomId",
                        column: x => x.TheOldKingdomId,
                        principalTable: "TheOldKingdoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_ThePirateDomains_ThePirateDomainsId",
                        column: x => x.ThePirateDomainsId,
                        principalTable: "ThePirateDomains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_TheShadowWorlds_TheShadowWorldId",
                        column: x => x.TheShadowWorldId,
                        principalTable: "TheShadowWorlds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_TheTradeLeagues_TheTradeLeagueId",
                        column: x => x.TheTradeLeagueId,
                        principalTable: "TheTradeLeagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_TheWastelands_TheWastelandId",
                        column: x => x.TheWastelandId,
                        principalTable: "TheWastelands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Redimels_Tumpridadams_TumpridadamId",
                        column: x => x.TumpridadamId,
                        principalTable: "Tumpridadams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baggages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false),
                    HeroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baggages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baggages_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsItDone = table.Column<bool>(type: "bit", nullable: false),
                    HeroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promises_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Checkpoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeCounter = table.Column<int>(type: "int", nullable: false),
                    CurrentUserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "WorldInfoVariables",
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
                    table.PrimaryKey("PK_WorldInfoVariables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_Dikanis_DikaniId",
                        column: x => x.DikaniId,
                        principalTable: "Dikanis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_Faegras_FaegraId",
                        column: x => x.FaegraId,
                        principalTable: "Faegras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_MageFields_MageFieldsId",
                        column: x => x.MageFieldsId,
                        principalTable: "MageFields",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_MageForests_MageForestId",
                        column: x => x.MageForestId,
                        principalTable: "MageForests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_MageHarbors_MageHarborId",
                        column: x => x.MageHarborId,
                        principalTable: "MageHarbors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_MageSeas_MageSeaId",
                        column: x => x.MageSeaId,
                        principalTable: "MageSeas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_MageTownGuardHills_MageTownGuardHillId",
                        column: x => x.MageTownGuardHillId,
                        principalTable: "MageTownGuardHills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_MageTownInnTheOldMagicians_MageTownInnTheOldMagicianId",
                        column: x => x.MageTownInnTheOldMagicianId,
                        principalTable: "MageTownInnTheOldMagicians",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_MageTownTheCentralSquares_MageTownTheCentralSquareId",
                        column: x => x.MageTownTheCentralSquareId,
                        principalTable: "MageTownTheCentralSquares",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_MageTownTheLibraries_MageTownTheLibraryId",
                        column: x => x.MageTownTheLibraryId,
                        principalTable: "MageTownTheLibraries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_MageTowns_MageTownId",
                        column: x => x.MageTownId,
                        principalTable: "MageTowns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_MageTradeRoads_MageTradeRoadId",
                        column: x => x.MageTradeRoadId,
                        principalTable: "MageTradeRoads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_Magelands_MagelandId",
                        column: x => x.MagelandId,
                        principalTable: "Magelands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_NorthernNomads_NorthernNomadsId",
                        column: x => x.NorthernNomadsId,
                        principalTable: "NorthernNomads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_OutlawTerritories_OutlawTerritoryId",
                        column: x => x.OutlawTerritoryId,
                        principalTable: "OutlawTerritories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_Redimels_RedimelId",
                        column: x => x.RedimelId,
                        principalTable: "Redimels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_SouthernNomads_SouthernNomadsId",
                        column: x => x.SouthernNomadsId,
                        principalTable: "SouthernNomads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_Stincums_StincumId",
                        column: x => x.StincumId,
                        principalTable: "Stincums",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_TheBigCities_TheBigCityId",
                        column: x => x.TheBigCityId,
                        principalTable: "TheBigCities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_TheEmpires_TheEmpireId",
                        column: x => x.TheEmpireId,
                        principalTable: "TheEmpires",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_TheForestTribes_TheForestTribesId",
                        column: x => x.TheForestTribesId,
                        principalTable: "TheForestTribes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_TheHigherOnes_TheHigherOnesId",
                        column: x => x.TheHigherOnesId,
                        principalTable: "TheHigherOnes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_TheHorsePeoples_TheHorsePeopleId",
                        column: x => x.TheHorsePeopleId,
                        principalTable: "TheHorsePeoples",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_TheHunters_TheHuntersId",
                        column: x => x.TheHuntersId,
                        principalTable: "TheHunters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_TheIslanders_TheIslandersId",
                        column: x => x.TheIslandersId,
                        principalTable: "TheIslanders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_TheOldKingdoms_TheOldKingdomId",
                        column: x => x.TheOldKingdomId,
                        principalTable: "TheOldKingdoms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_ThePirateDomains_ThePirateDomainsId",
                        column: x => x.ThePirateDomainsId,
                        principalTable: "ThePirateDomains",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_TheShadowWorlds_TheShadowWorldId",
                        column: x => x.TheShadowWorldId,
                        principalTable: "TheShadowWorlds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_TheTradeLeagues_TheTradeLeagueId",
                        column: x => x.TheTradeLeagueId,
                        principalTable: "TheTradeLeagues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_TheWastelands_TheWastelandId",
                        column: x => x.TheWastelandId,
                        principalTable: "TheWastelands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_Tumpridadams_TumpridadamId",
                        column: x => x.TumpridadamId,
                        principalTable: "Tumpridadams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baggages_HeroId",
                table: "Baggages",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleGroups_AditionalPointsId",
                table: "BattleGroups",
                column: "AditionalPointsId");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_PageId",
                table: "Choices",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_ArmorId",
                table: "Equipments",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_ShieldId",
                table: "Equipments",
                column: "ShieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_ThrowingWeaponId",
                table: "Equipments",
                column: "ThrowingWeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_WeaponId",
                table: "Equipments",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupWests_AditionalPointsId",
                table: "GroupWests",
                column: "AditionalPointsId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_AbilityId",
                table: "Heroes",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_EquipmentsId",
                table: "Heroes",
                column: "EquipmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_GroupWestId",
                table: "Heroes",
                column: "GroupWestId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_IndicatorsId",
                table: "Heroes",
                column: "IndicatorsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_SpecialAbilityId",
                table: "Heroes",
                column: "SpecialAbilityId");

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
                name: "IX_Missions_GroupWestId",
                table: "Missions",
                column: "GroupWestId");

            migrationBuilder.CreateIndex(
                name: "IX_NatureSkills_SpecialAbilityId",
                table: "NatureSkills",
                column: "SpecialAbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Negotiations_AditionalPointsId",
                table: "Negotiations",
                column: "AditionalPointsId");

            migrationBuilder.CreateIndex(
                name: "IX_Promises_HeroId",
                table: "Promises",
                column: "HeroId");

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
                name: "IX_Rituals_SpecialAbilityId",
                table: "Rituals",
                column: "SpecialAbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialAbilities_SpecialCombatSkillId",
                table: "SpecialAbilities",
                column: "SpecialCombatSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialAbilities_UltimateId",
                table: "SpecialAbilities",
                column: "UltimateId");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_SpecialAbilityId",
                table: "Spells",
                column: "SpecialAbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Talismans_EquipmentId",
                table: "Talismans",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupWestId",
                table: "Users",
                column: "GroupWestId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RedimelId",
                table: "Users",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_DikaniId",
                table: "WorldInfoVariables",
                column: "DikaniId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_FaegraId",
                table: "WorldInfoVariables",
                column: "FaegraId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_MageFieldsId",
                table: "WorldInfoVariables",
                column: "MageFieldsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_MageForestId",
                table: "WorldInfoVariables",
                column: "MageForestId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_MageHarborId",
                table: "WorldInfoVariables",
                column: "MageHarborId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_MagelandId",
                table: "WorldInfoVariables",
                column: "MagelandId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_MageSeaId",
                table: "WorldInfoVariables",
                column: "MageSeaId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_MageTownGuardHillId",
                table: "WorldInfoVariables",
                column: "MageTownGuardHillId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_MageTownId",
                table: "WorldInfoVariables",
                column: "MageTownId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_MageTownInnTheOldMagicianId",
                table: "WorldInfoVariables",
                column: "MageTownInnTheOldMagicianId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_MageTownTheCentralSquareId",
                table: "WorldInfoVariables",
                column: "MageTownTheCentralSquareId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_MageTownTheLibraryId",
                table: "WorldInfoVariables",
                column: "MageTownTheLibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_MageTradeRoadId",
                table: "WorldInfoVariables",
                column: "MageTradeRoadId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_NorthernNomadsId",
                table: "WorldInfoVariables",
                column: "NorthernNomadsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_OutlawTerritoryId",
                table: "WorldInfoVariables",
                column: "OutlawTerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_RedimelId",
                table: "WorldInfoVariables",
                column: "RedimelId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_SouthernNomadsId",
                table: "WorldInfoVariables",
                column: "SouthernNomadsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_StincumId",
                table: "WorldInfoVariables",
                column: "StincumId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_TheBigCityId",
                table: "WorldInfoVariables",
                column: "TheBigCityId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_TheEmpireId",
                table: "WorldInfoVariables",
                column: "TheEmpireId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_TheForestTribesId",
                table: "WorldInfoVariables",
                column: "TheForestTribesId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_TheHigherOnesId",
                table: "WorldInfoVariables",
                column: "TheHigherOnesId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_TheHorsePeopleId",
                table: "WorldInfoVariables",
                column: "TheHorsePeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_TheHuntersId",
                table: "WorldInfoVariables",
                column: "TheHuntersId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_TheIslandersId",
                table: "WorldInfoVariables",
                column: "TheIslandersId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_TheOldKingdomId",
                table: "WorldInfoVariables",
                column: "TheOldKingdomId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_ThePirateDomainsId",
                table: "WorldInfoVariables",
                column: "ThePirateDomainsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_TheShadowWorldId",
                table: "WorldInfoVariables",
                column: "TheShadowWorldId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_TheTradeLeagueId",
                table: "WorldInfoVariables",
                column: "TheTradeLeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_TheWastelandId",
                table: "WorldInfoVariables",
                column: "TheWastelandId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldInfoVariables_TumpridadamId",
                table: "WorldInfoVariables",
                column: "TumpridadamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baggages");

            migrationBuilder.DropTable(
                name: "BattleGroups");

            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "NatureSkills");

            migrationBuilder.DropTable(
                name: "Negotiations");

            migrationBuilder.DropTable(
                name: "Promises");

            migrationBuilder.DropTable(
                name: "Rituals");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Talismans");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WorldInfoVariables");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Redimels");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "GroupWests");

            migrationBuilder.DropTable(
                name: "Indicators");

            migrationBuilder.DropTable(
                name: "SpecialAbilities");

            migrationBuilder.DropTable(
                name: "Dikanis");

            migrationBuilder.DropTable(
                name: "Faegras");

            migrationBuilder.DropTable(
                name: "Magelands");

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
                name: "Armors");

            migrationBuilder.DropTable(
                name: "Shields");

            migrationBuilder.DropTable(
                name: "ThrowingWeapons");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "AditionalPoints");

            migrationBuilder.DropTable(
                name: "SpecialCombatSkills");

            migrationBuilder.DropTable(
                name: "Ultimates");

            migrationBuilder.DropTable(
                name: "MageFields");

            migrationBuilder.DropTable(
                name: "MageForests");

            migrationBuilder.DropTable(
                name: "MageHarbors");

            migrationBuilder.DropTable(
                name: "MageSeas");

            migrationBuilder.DropTable(
                name: "MageTowns");

            migrationBuilder.DropTable(
                name: "MageTradeRoads");

            migrationBuilder.DropTable(
                name: "MageTownGuardHills");

            migrationBuilder.DropTable(
                name: "MageTownInnTheOldMagicians");

            migrationBuilder.DropTable(
                name: "MageTownTheCentralSquares");

            migrationBuilder.DropTable(
                name: "MageTownTheLibraries");
        }
    }
}
