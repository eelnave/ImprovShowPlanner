using Microsoft.EntityFrameworkCore.Migrations;

namespace ImprovShowPlanner.Migrations
{
    public partial class foreignKeyTest6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Games_GameTypeId",
                table: "Games",
                column: "GameTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameTypes_GameTypeId",
                table: "Games",
                column: "GameTypeId",
                principalTable: "GameTypes",
                principalColumn: "GameTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameTypes_GameTypeId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_GameTypeId",
                table: "Games");
        }
    }
}
