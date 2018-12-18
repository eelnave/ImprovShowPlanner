using Microsoft.EntityFrameworkCore.Migrations;

namespace ImprovShowPlanner.Migrations
{
    public partial class foreignKeyTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Shows",
                newName: "PlayerID");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Shows",
                newName: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_PlayerID",
                table: "Shows",
                column: "PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Players_PlayerID",
                table: "Shows",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Players_PlayerID",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_PlayerID",
                table: "Shows");

            migrationBuilder.RenameColumn(
                name: "PlayerID",
                table: "Shows",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "Shows",
                newName: "GameId");
        }
    }
}
