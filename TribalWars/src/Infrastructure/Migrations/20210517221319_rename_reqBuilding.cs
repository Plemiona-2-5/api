using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class rename_reqBuilding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequiredBuildings_Buildings_ReqBuildingId",
                table: "RequiredBuildings");

            migrationBuilder.RenameColumn(
                name: "ReqBuildingId",
                table: "RequiredBuildings",
                newName: "BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_RequiredBuildings_ReqBuildingId",
                table: "RequiredBuildings",
                newName: "IX_RequiredBuildings_BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequiredBuildings_Buildings_BuildingId",
                table: "RequiredBuildings",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequiredBuildings_Buildings_BuildingId",
                table: "RequiredBuildings");

            migrationBuilder.RenameColumn(
                name: "BuildingId",
                table: "RequiredBuildings",
                newName: "ReqBuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_RequiredBuildings_BuildingId",
                table: "RequiredBuildings",
                newName: "IX_RequiredBuildings_ReqBuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequiredBuildings_Buildings_ReqBuildingId",
                table: "RequiredBuildings",
                column: "ReqBuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
