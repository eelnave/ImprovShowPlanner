using Microsoft.EntityFrameworkCore.Migrations;

namespace ImprovShowPlanner.Migrations
{
    public partial class foreignKeyTest7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "IndivShows",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "IndivShows",
                newName: "date");
        }
    }
}
