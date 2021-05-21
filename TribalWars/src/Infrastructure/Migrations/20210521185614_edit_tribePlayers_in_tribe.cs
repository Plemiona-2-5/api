using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class edit_tribePlayers_in_tribe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TribePlayers_TribeId",
                table: "TribePlayers");

            migrationBuilder.CreateIndex(
                name: "IX_TribePlayers_TribeId",
                table: "TribePlayers",
                column: "TribeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TribePlayers_TribeId",
                table: "TribePlayers");

            migrationBuilder.CreateIndex(
                name: "IX_TribePlayers_TribeId",
                table: "TribePlayers",
                column: "TribeId",
                unique: true);
        }
    }
}
