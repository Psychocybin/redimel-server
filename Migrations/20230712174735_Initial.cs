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

            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "Id", "Acrobatics", "Archery", "BreakingLocks", "Climbing", "Diplomacy", "Elusion", "Guile", "HeroId", "Melee", "NatureSkills", "Observation", "PoisonousNeedles", "Rituals", "SecretKnowledge", "ShieldBearer", "Skill", "Sneak", "Spells", "Stimulants", "Survival", "ThrowingKnives", "Transformation", "Traps", "WaterCycle", "Wrestling" },
                values: new object[] { new Guid("cd5a3e48-5eb4-49fa-a24d-3c3e861f22b3"), false, false, false, false, false, false, false, new Guid("a9542e10-30a3-45a8-b2ea-cacef3df468a"), false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true });

            migrationBuilder.InsertData(
                table: "AditionalPoints",
                columns: new[] { "Id", "Cover", "GroupWestId", "ImportantInformation", "Morals", "SlainMonsters", "TeamGame" },
                values: new object[] { new Guid("8db8e341-9d6e-42e8-8504-45b5f56eac5f"), 2, new Guid("44a06217-58ec-4dce-bb7d-5a951e2bef9e"), 0, 2, 0, 0 });

            migrationBuilder.InsertData(
                table: "Armors",
                columns: new[] { "Id", "ArmorType", "Defence", "EquipmentId", "IsExist" },
                values: new object[] { new Guid("05bee6ad-3556-4d28-b537-ab3fed69ea26"), "FullPlate", 11, new Guid("6f58f2e9-7788-43f8-abe1-06a6d96a537b"), true });

            migrationBuilder.InsertData(
                table: "Indicators",
                columns: new[] { "Id", "Agility", "Dexterity", "Endurance", "Evasion", "Health", "HeroId", "MentalEnergy", "MentalStrength", "Strength" },
                values: new object[] { new Guid("1aa43831-d5b0-4299-9585-a98c527ef9f8"), 3, 8, 6, 5, 70, new Guid("a9542e10-30a3-45a8-b2ea-cacef3df468a"), 20, 6, 12 });

            migrationBuilder.InsertData(
                table: "Shields",
                columns: new[] { "Id", "Defence", "EquipmentId", "IsExist", "ShieldType" },
                values: new object[] { new Guid("e87042bf-50c0-4b73-adc5-1da34dfdcd5f"), 0, new Guid("6f58f2e9-7788-43f8-abe1-06a6d96a537b"), false, "" });

            migrationBuilder.InsertData(
                table: "SpecialCombatSkills",
                columns: new[] { "Id", "Name", "RequiredMentalEnergy", "SkillLevel", "SpecialAbilitiesId" },
                values: new object[] { new Guid("d1d752d4-216b-4e3e-b663-6e2f5e849477"), "SoldierSCS", 4, 1, new Guid("bf99b385-56ee-49f9-b7fe-36cc88f829d0") });

            migrationBuilder.InsertData(
                table: "ThrowingWeapons",
                columns: new[] { "Id", "Attack", "Damage", "Defence", "EquipmentId", "IsExist", "Quantity", "ThrowingWeaponRange", "ThrowingWeaponType" },
                values: new object[] { new Guid("bcb17f68-b01e-484f-b757-7962129f95f6"), 0, 0, 0, new Guid("6f58f2e9-7788-43f8-abe1-06a6d96a537b"), false, 0, 0, "" });

            migrationBuilder.InsertData(
                table: "Ultimates",
                columns: new[] { "Id", "Name", "RequiredMentalEnergy", "SkillLevel", "SpecialAbilitiesId" },
                values: new object[] { new Guid("0d71b738-b538-4e19-aebe-05806ab7d2fd"), "SoldierUltimate", 5, 1, new Guid("bf99b385-56ee-49f9-b7fe-36cc88f829d0") });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "Id", "Attack", "Damage", "Defence", "EquipmentId", "IsExist", "IsItTwoHandWeapon", "WeaponRange", "WeaponType" },
                values: new object[] { new Guid("57006109-51e5-43e3-a8e0-8f3ece262649"), 12, 15, 3, new Guid("6f58f2e9-7788-43f8-abe1-06a6d96a537b"), true, true, 3, "TwoHand" });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "ArmorId", "HeroId", "Knife", "MedicPack", "MoneyBag", "Poison", "ShieldId", "SmokeBall", "ThrowingWeaponId", "WeaponId" },
                values: new object[] { new Guid("6f58f2e9-7788-43f8-abe1-06a6d96a537b"), new Guid("05bee6ad-3556-4d28-b537-ab3fed69ea26"), new Guid("a9542e10-30a3-45a8-b2ea-cacef3df468a"), true, true, 100, false, new Guid("e87042bf-50c0-4b73-adc5-1da34dfdcd5f"), true, new Guid("bcb17f68-b01e-484f-b757-7962129f95f6"), new Guid("57006109-51e5-43e3-a8e0-8f3ece262649") });

            migrationBuilder.InsertData(
                table: "GroupWests",
                columns: new[] { "Id", "ActualMission", "AditionalPointsId" },
                values: new object[] { new Guid("44a06217-58ec-4dce-bb7d-5a951e2bef9e"), "", new Guid("8db8e341-9d6e-42e8-8504-45b5f56eac5f") });

            migrationBuilder.InsertData(
                table: "SpecialAbilities",
                columns: new[] { "Id", "HeroId", "SpecialCombatSkillId", "UltimateId" },
                values: new object[] { new Guid("bf99b385-56ee-49f9-b7fe-36cc88f829d0"), new Guid("a9542e10-30a3-45a8-b2ea-cacef3df468a"), new Guid("d1d752d4-216b-4e3e-b663-6e2f5e849477"), new Guid("0d71b738-b538-4e19-aebe-05806ab7d2fd") });

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "AbilityId", "BaggageCapacity", "EquipmentsId", "GroupWestId", "HeroClass", "IndicatorsId", "Name", "SpecialAbilityId" },
                values: new object[] { new Guid("a9542e10-30a3-45a8-b2ea-cacef3df468a"), new Guid("cd5a3e48-5eb4-49fa-a24d-3c3e861f22b3"), 60.0, new Guid("6f58f2e9-7788-43f8-abe1-06a6d96a537b"), new Guid("44a06217-58ec-4dce-bb7d-5a951e2bef9e"), "Barbarian", new Guid("1aa43831-d5b0-4299-9585-a98c527ef9f8"), "Vranko", new Guid("bf99b385-56ee-49f9-b7fe-36cc88f829d0") });

            migrationBuilder.CreateIndex(
                name: "IX_Baggages_HeroId",
                table: "Baggages",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleGroups_AditionalPointsId",
                table: "BattleGroups",
                column: "AditionalPointsId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baggages");

            migrationBuilder.DropTable(
                name: "BattleGroups");

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
                name: "Heroes");

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
        }
    }
}
