using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace redimel_server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    ShieldBearer = table.Column<bool>(type: "bit", nullable: false)
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
                    BattleGroupsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NegotiationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AditionalPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArmorsAndShields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsExist = table.Column<bool>(type: "bit", nullable: false),
                    Defence = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorsAndShields", x => x.Id);
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
                    Endurance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shield",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsExist = table.Column<bool>(type: "bit", nullable: false),
                    Defence = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shield", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialAbilityPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    RequiredMentalEnergy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialAbilityPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThrowingWeapons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsExist = table.Column<bool>(type: "bit", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defence = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThrowingWeapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ultimate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    RequiredMentalEnergy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ultimate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defence = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BattleGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AditionalPointsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleGroup_AditionalPoints_AditionalPointsId",
                        column: x => x.AditionalPointsId,
                        principalTable: "AditionalPoints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GroupWest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActualMission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeroesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AditionalPointsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MissionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupWest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupWest_AditionalPoints_AditionalPointsId",
                        column: x => x.AditionalPointsId,
                        principalTable: "AditionalPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Negotiation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AditionalPointsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negotiation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Negotiation_AditionalPoints_AditionalPointsId",
                        column: x => x.AditionalPointsId,
                        principalTable: "AditionalPoints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SpecialAbilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecialCombatSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpellsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RitualsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NatureSkillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialAbilities_SpecialAbilityPoints_SpecialCombatSkillId",
                        column: x => x.SpecialCombatSkillId,
                        principalTable: "SpecialAbilityPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialAbilities_Ultimate_UltimateId",
                        column: x => x.UltimateId,
                        principalTable: "Ultimate",
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
                    ArmorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeaponId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThrowingWeaponId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TalismansId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_ArmorsAndShields_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "ArmorsAndShields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipments_Shield_ShieldId",
                        column: x => x.ShieldId,
                        principalTable: "Shield",
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
                name: "Mission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsItDone = table.Column<bool>(type: "bit", nullable: false),
                    GroupWestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mission_GroupWest_GroupWestId",
                        column: x => x.GroupWestId,
                        principalTable: "GroupWest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NatureSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    RequiredMentalEnergy = table.Column<int>(type: "int", nullable: false),
                    SpecialAbilitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatureSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NatureSkill_SpecialAbilities_SpecialAbilitiesId",
                        column: x => x.SpecialAbilitiesId,
                        principalTable: "SpecialAbilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ritual",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    RequiredMentalEnergy = table.Column<int>(type: "int", nullable: false),
                    SpecialAbilitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ritual", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ritual_SpecialAbilities_SpecialAbilitiesId",
                        column: x => x.SpecialAbilitiesId,
                        principalTable: "SpecialAbilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Spell",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillLevel = table.Column<int>(type: "int", nullable: false),
                    RequiredMentalEnergy = table.Column<int>(type: "int", nullable: false),
                    SpecialAbilitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spell_SpecialAbilities_SpecialAbilitiesId",
                        column: x => x.SpecialAbilitiesId,
                        principalTable: "SpecialAbilities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeroClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaggageCapacity = table.Column<double>(type: "float", nullable: false),
                    PromisesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaggagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndicatorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AbilitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecialAbilitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupWestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heroes_Abilities_AbilitiesId",
                        column: x => x.AbilitiesId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Heroes_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Heroes_GroupWest_GroupWestId",
                        column: x => x.GroupWestId,
                        principalTable: "GroupWest",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Heroes_Indicators_IndicatorsId",
                        column: x => x.IndicatorsId,
                        principalTable: "Indicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Heroes_SpecialAbilities_SpecialAbilitiesId",
                        column: x => x.SpecialAbilitiesId,
                        principalTable: "SpecialAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Talismans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BonusIndicator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BonusPoints = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talismans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Talismans_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Baggage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false),
                    HeroId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baggage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baggage_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Promises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsItDone = table.Column<bool>(type: "bit", nullable: false),
                    HeroId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promises_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baggage_HeroId",
                table: "Baggage",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleGroup_AditionalPointsId",
                table: "BattleGroup",
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
                name: "IX_GroupWest_AditionalPointsId",
                table: "GroupWest",
                column: "AditionalPointsId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_AbilitiesId",
                table: "Heroes",
                column: "AbilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_EquipmentId",
                table: "Heroes",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_GroupWestId",
                table: "Heroes",
                column: "GroupWestId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_IndicatorsId",
                table: "Heroes",
                column: "IndicatorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_SpecialAbilitiesId",
                table: "Heroes",
                column: "SpecialAbilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Mission_GroupWestId",
                table: "Mission",
                column: "GroupWestId");

            migrationBuilder.CreateIndex(
                name: "IX_NatureSkill_SpecialAbilitiesId",
                table: "NatureSkill",
                column: "SpecialAbilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Negotiation_AditionalPointsId",
                table: "Negotiation",
                column: "AditionalPointsId");

            migrationBuilder.CreateIndex(
                name: "IX_Promises_HeroId",
                table: "Promises",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ritual_SpecialAbilitiesId",
                table: "Ritual",
                column: "SpecialAbilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialAbilities_SpecialCombatSkillId",
                table: "SpecialAbilities",
                column: "SpecialCombatSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialAbilities_UltimateId",
                table: "SpecialAbilities",
                column: "UltimateId");

            migrationBuilder.CreateIndex(
                name: "IX_Spell_SpecialAbilitiesId",
                table: "Spell",
                column: "SpecialAbilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Talismans_EquipmentId",
                table: "Talismans",
                column: "EquipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baggage");

            migrationBuilder.DropTable(
                name: "BattleGroup");

            migrationBuilder.DropTable(
                name: "Mission");

            migrationBuilder.DropTable(
                name: "NatureSkill");

            migrationBuilder.DropTable(
                name: "Negotiation");

            migrationBuilder.DropTable(
                name: "Promises");

            migrationBuilder.DropTable(
                name: "Ritual");

            migrationBuilder.DropTable(
                name: "Spell");

            migrationBuilder.DropTable(
                name: "Talismans");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "GroupWest");

            migrationBuilder.DropTable(
                name: "Indicators");

            migrationBuilder.DropTable(
                name: "SpecialAbilities");

            migrationBuilder.DropTable(
                name: "ArmorsAndShields");

            migrationBuilder.DropTable(
                name: "Shield");

            migrationBuilder.DropTable(
                name: "ThrowingWeapons");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "AditionalPoints");

            migrationBuilder.DropTable(
                name: "SpecialAbilityPoints");

            migrationBuilder.DropTable(
                name: "Ultimate");
        }
    }
}
