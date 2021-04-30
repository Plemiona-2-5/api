using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class add_attackVillage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attacks_Villages_AttackerVillageId",
                table: "Attacks");

            migrationBuilder.DropIndex(
                name: "IX_Attacks_AttackerVillageId",
                table: "Attacks");

            migrationBuilder.DropColumn(
                name: "AttackerVillageId",
                table: "Attacks");

            migrationBuilder.DropColumn(
                name: "DefenderVillageId",
                table: "Attacks");

            migrationBuilder.CreateTable(
                name: "AttackVillages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttackId = table.Column<int>(type: "int", nullable: false),
                    VillageId = table.Column<int>(type: "int", nullable: false),
                    BattleSide = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackVillages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttackVillages_Attacks_AttackId",
                        column: x => x.AttackId,
                        principalTable: "Attacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttackVillages_Villages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttackVillages_AttackId",
                table: "AttackVillages",
                column: "AttackId");

            migrationBuilder.CreateIndex(
                name: "IX_AttackVillages_VillageId",
                table: "AttackVillages",
                column: "VillageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttackVillages");

            migrationBuilder.AddColumn<int>(
                name: "AttackerVillageId",
                table: "Attacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DefenderVillageId",
                table: "Attacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_AttackerVillageId",
                table: "Attacks",
                column: "AttackerVillageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attacks_Villages_AttackerVillageId",
                table: "Attacks",
                column: "AttackerVillageId",
                principalTable: "Villages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
