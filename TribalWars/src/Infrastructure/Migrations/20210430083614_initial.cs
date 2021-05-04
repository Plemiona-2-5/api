using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConstructionTime = table.Column<int>(type: "int", nullable: false),
                    MaxLevel = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tribes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tribes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArmyUnitTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttackStrength = table.Column<int>(type: "int", nullable: false),
                    DefenceValue = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    RecruitmentTime = table.Column<int>(type: "int", nullable: false),
                    RequiredBuildingId = table.Column<int>(type: "int", nullable: false),
                    RequiredBuildingILevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmyUnitTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArmyUnitTypes_Buildings_RequiredBuildingId",
                        column: x => x.RequiredBuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingRequiredBuildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    RequiredBuildingId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingRequiredBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingRequiredBuildings_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingRequiredMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingRequiredMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingRequiredMaterials_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingRequiredMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TribePlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TribeId = table.Column<int>(type: "int", nullable: false),
                    TribeRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TribePlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TribePlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TribePlayers_Tribes_TribeId",
                        column: x => x.TribeId,
                        principalTable: "Tribes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Villages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoordinateX = table.Column<int>(type: "int", nullable: false),
                    CoordinateY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Villages_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArmyUnitRequiredMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmyUnitTypeId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmyUnitRequiredMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArmyUnitRequiredMaterials_ArmyUnitTypes_ArmyUnitTypeId",
                        column: x => x.ArmyUnitTypeId,
                        principalTable: "ArmyUnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmyUnitRequiredMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefenderVillageId = table.Column<int>(type: "int", nullable: false),
                    AttackerVillageId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attacks_Villages_AttackerVillageId",
                        column: x => x.AttackerVillageId,
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingQueues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillageId = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingQueues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingQueues_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingQueues_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecruitmentQueues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillageId = table.Column<int>(type: "int", nullable: false),
                    ArmyUnitTypeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StartData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitmentQueues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecruitmentQueues_ArmyUnitTypes_ArmyUnitTypeId",
                        column: x => x.ArmyUnitTypeId,
                        principalTable: "ArmyUnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecruitmentQueues_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VillageBuildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillageId = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    CurrentLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillageBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VillageBuildings_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VillageBuildings_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VillageMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillageId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PerMinute = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillageMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VillageMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VillageMaterials_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VillageStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialsCapacity = table.Column<int>(type: "int", nullable: false),
                    PeopleCapacity = table.Column<int>(type: "int", nullable: false),
                    WallDefence = table.Column<int>(type: "int", nullable: false),
                    VillageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillageStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VillageStatistics_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VillageUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmyUnitTypeId = table.Column<int>(type: "int", nullable: false),
                    VillageId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillageUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VillageUnits_ArmyUnitTypes_ArmyUnitTypeId",
                        column: x => x.ArmyUnitTypeId,
                        principalTable: "ArmyUnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VillageUnits_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttackReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttackId = table.Column<int>(type: "int", nullable: false),
                    AttackDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttackReports_Attacks_AttackId",
                        column: x => x.AttackId,
                        principalTable: "Attacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BattleUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttackId = table.Column<int>(type: "int", nullable: false),
                    ArmyUnitTypeId = table.Column<int>(type: "int", nullable: false),
                    BeforQuantity = table.Column<int>(type: "int", nullable: false),
                    AfterQuantity = table.Column<int>(type: "int", nullable: false),
                    Side = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleUnits_ArmyUnitTypes_ArmyUnitTypeId",
                        column: x => x.ArmyUnitTypeId,
                        principalTable: "ArmyUnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleUnits_Attacks_AttackId",
                        column: x => x.AttackId,
                        principalTable: "Attacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StolenMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    AttackId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StolenMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StolenMaterials_Attacks_AttackId",
                        column: x => x.AttackId,
                        principalTable: "Attacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StolenMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmyUnitRequiredMaterials_ArmyUnitTypeId",
                table: "ArmyUnitRequiredMaterials",
                column: "ArmyUnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmyUnitRequiredMaterials_MaterialId",
                table: "ArmyUnitRequiredMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmyUnitTypes_RequiredBuildingId",
                table: "ArmyUnitTypes",
                column: "RequiredBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AttackReports_AttackId",
                table: "AttackReports",
                column: "AttackId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_AttackerVillageId",
                table: "Attacks",
                column: "AttackerVillageId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleUnits_ArmyUnitTypeId",
                table: "BattleUnits",
                column: "ArmyUnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleUnits_AttackId",
                table: "BattleUnits",
                column: "AttackId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingQueues_BuildingId",
                table: "BuildingQueues",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingQueues_VillageId",
                table: "BuildingQueues",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingRequiredBuildings_BuildingId",
                table: "BuildingRequiredBuildings",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingRequiredMaterials_BuildingId",
                table: "BuildingRequiredMaterials",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingRequiredMaterials_MaterialId",
                table: "BuildingRequiredMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentQueues_ArmyUnitTypeId",
                table: "RecruitmentQueues",
                column: "ArmyUnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentQueues_VillageId",
                table: "RecruitmentQueues",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_StolenMaterials_AttackId",
                table: "StolenMaterials",
                column: "AttackId");

            migrationBuilder.CreateIndex(
                name: "IX_StolenMaterials_MaterialId",
                table: "StolenMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_TribePlayers_PlayerId",
                table: "TribePlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TribePlayers_TribeId",
                table: "TribePlayers",
                column: "TribeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VillageBuildings_BuildingId",
                table: "VillageBuildings",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_VillageBuildings_VillageId",
                table: "VillageBuildings",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_VillageMaterials_MaterialId",
                table: "VillageMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_VillageMaterials_VillageId",
                table: "VillageMaterials",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_Villages_PlayerId",
                table: "Villages",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VillageStatistics_VillageId",
                table: "VillageStatistics",
                column: "VillageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VillageUnits_ArmyUnitTypeId",
                table: "VillageUnits",
                column: "ArmyUnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VillageUnits_VillageId",
                table: "VillageUnits",
                column: "VillageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmyUnitRequiredMaterials");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AttackReports");

            migrationBuilder.DropTable(
                name: "BattleUnits");

            migrationBuilder.DropTable(
                name: "BuildingQueues");

            migrationBuilder.DropTable(
                name: "BuildingRequiredBuildings");

            migrationBuilder.DropTable(
                name: "BuildingRequiredMaterials");

            migrationBuilder.DropTable(
                name: "RecruitmentQueues");

            migrationBuilder.DropTable(
                name: "StolenMaterials");

            migrationBuilder.DropTable(
                name: "TribePlayers");

            migrationBuilder.DropTable(
                name: "VillageBuildings");

            migrationBuilder.DropTable(
                name: "VillageMaterials");

            migrationBuilder.DropTable(
                name: "VillageStatistics");

            migrationBuilder.DropTable(
                name: "VillageUnits");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Attacks");

            migrationBuilder.DropTable(
                name: "Tribes");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "ArmyUnitTypes");

            migrationBuilder.DropTable(
                name: "Villages");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
