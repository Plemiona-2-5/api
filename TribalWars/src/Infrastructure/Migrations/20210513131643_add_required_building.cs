using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class add_required_building : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "BuildingRequiredBuildings");

            migrationBuilder.CreateTable(
                name: "RequiredBuildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequiredBuildings_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingRequiredBuildings_RequiredBuildingId",
                table: "BuildingRequiredBuildings",
                column: "RequiredBuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_RequiredBuildings_BuildingId",
                table: "RequiredBuildings",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingRequiredBuildings_RequiredBuildings_RequiredBuildingId",
                table: "BuildingRequiredBuildings",
                column: "RequiredBuildingId",
                principalTable: "RequiredBuildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingRequiredBuildings_RequiredBuildings_RequiredBuildingId",
                table: "BuildingRequiredBuildings");

            migrationBuilder.DropTable(
                name: "RequiredBuildings");

            migrationBuilder.DropIndex(
                name: "IX_BuildingRequiredBuildings_RequiredBuildingId",
                table: "BuildingRequiredBuildings");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "BuildingRequiredBuildings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
