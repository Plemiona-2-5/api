using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class add_map_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MapId",
                table: "Villages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SideSize = table.Column<int>(type: "int", nullable: false, defaultValue: 1000),
                    Capacity = table.Column<int>(type: "int", nullable: false, defaultValue: 500000)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Villages_MapId",
                table: "Villages",
                column: "MapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Villages_Maps_MapId",
                table: "Villages",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Villages_Maps_MapId",
                table: "Villages");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropIndex(
                name: "IX_Villages_MapId",
                table: "Villages");

            migrationBuilder.DropColumn(
                name: "MapId",
                table: "Villages");
        }
    }
}
