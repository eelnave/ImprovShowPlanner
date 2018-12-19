using Microsoft.EntityFrameworkCore.Migrations;

namespace ImprovShowPlanner.Migrations
{
    public partial class ForeignKeyTest5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Shows_GameId",
                table: "Shows",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_IndivShowId",
                table: "Shows",
                column: "IndivShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Games_GameId",
                table: "Shows",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_IndivShows_IndivShowId",
                table: "Shows",
                column: "IndivShowId",
                principalTable: "IndivShows",
                principalColumn: "IndivShowId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Games_GameId",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_IndivShows_IndivShowId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_GameId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_IndivShowId",
                table: "Shows");
        }
    }
}
