using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class editbuildingentityv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Buildings");

            migrationBuilder.RenameColumn(
                name: "buildingType",
                table: "Buildings",
                newName: "BuildingType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BuildingType",
                table: "Buildings",
                newName: "buildingType");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
