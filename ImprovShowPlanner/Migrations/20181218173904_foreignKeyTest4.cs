using Microsoft.EntityFrameworkCore.Migrations;

namespace ImprovShowPlanner.Migrations
{
    public partial class ForeignKeyTest4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Players_PlayerID",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "PlayerID",
                table: "Shows",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "Shows",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Shows_PlayerID",
                table: "Shows",
                newName: "IX_Shows_PlayerId");

            migrationBuilder.RenameColumn(
                name: "PlayerID",
                table: "Players",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "Games",
                newName: "GameId");

            migrationBuilder.AddColumn<int>(
                name: "IndivShowId",
                table: "Shows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GameTypeId",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Players_PlayerId",
                table: "Shows",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Players_PlayerId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "IndivShowId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "GameTypeId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Shows",
                newName: "PlayerID");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Shows",
                newName: "GameID");

            migrationBuilder.RenameIndex(
                name: "IX_Shows_PlayerId",
                table: "Shows",
                newName: "IX_Shows_PlayerID");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Players",
                newName: "PlayerID");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Games",
                newName: "GameID");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Games",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Players_PlayerID",
                table: "Shows",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
