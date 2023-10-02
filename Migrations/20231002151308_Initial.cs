using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace redimel_server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Leadership = table.Column<bool>(type: "bit", nullable: false),
                    KickFight = table.Column<bool>(type: "bit", nullable: false),
                    DoubleStrike = table.Column<bool>(type: "bit", nullable: false),
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
                    TemporaryPoints = table.Column<int>(type: "int", nullable: false),
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
                    ArmorType = table.Column<int>(type: "int", nullable: false),
                    IsExist = table.Column<bool>(type: "bit", nullable: false),
                    Defence = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Changes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    HeroClass = table.Column<int>(type: "int", nullable: false),
                    HeroType = table.Column<int>(type: "int", nullable: false),
                    OrderOfBattle = table.Column<int>(type: "int", nullable: false),
                    PageId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrueOrFalse = table.Column<bool>(type: "bit", nullable: false),
                    ActiveOrNot = table.Column<bool>(type: "bit", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defence = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Range = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Changes", x => x.Id);
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
                name: "RedimelInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedimelInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShieldType = table.Column<int>(type: "int", nullable: false),
                    IsExist = table.Column<bool>(type: "bit", nullable: false),
                    Defence = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialCombatSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<int>(type: "int", nullable: false),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    RequiredMentalEnergy = table.Column<int>(type: "int", nullable: false),
                    SpecialAbilitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialCombatSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThrowingWeapons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThrowingWeaponType = table.Column<int>(type: "int", nullable: false),
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
                name: "Ultimates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<int>(type: "int", nullable: false),
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
                    WeaponType = table.Column<int>(type: "int", nullable: false),
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
                name: "Choices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdditionalCheck = table.Column<bool>(type: "bit", nullable: false),
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
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id");
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Checkpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeCounter = table.Column<int>(type: "int", nullable: false),
                    CurrentUserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    HeroClass = table.Column<int>(type: "int", nullable: false),
                    HeroType = table.Column<int>(type: "int", nullable: false),
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
                    TalismanType = table.Column<int>(type: "int", nullable: false),
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
                name: "WorldInfoVariables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RedimelLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ActiveOrNot = table.Column<bool>(type: "bit", nullable: false),
                    TrueOrFalse = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldInfoVariables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorldInfoVariables_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                column: "IndicatorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_SpecialAbilityId",
                table: "Heroes",
                column: "SpecialAbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PageId",
                table: "Images",
                column: "PageId");

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
                name: "IX_WorldInfoVariables_UserId",
                table: "WorldInfoVariables",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baggages");

            migrationBuilder.DropTable(
                name: "BattleGroups");

            migrationBuilder.DropTable(
                name: "Changes");

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
                name: "RedimelInfos");

            migrationBuilder.DropTable(
                name: "Rituals");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Talismans");

            migrationBuilder.DropTable(
                name: "WorldInfoVariables");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Indicators");

            migrationBuilder.DropTable(
                name: "SpecialAbilities");

            migrationBuilder.DropTable(
                name: "GroupWests");

            migrationBuilder.DropTable(
                name: "Armors");

            migrationBuilder.DropTable(
                name: "Shields");

            migrationBuilder.DropTable(
                name: "ThrowingWeapons");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "SpecialCombatSkills");

            migrationBuilder.DropTable(
                name: "Ultimates");

            migrationBuilder.DropTable(
                name: "AditionalPoints");
        }
    }
}
