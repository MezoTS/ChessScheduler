using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessScheduler.Bot.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LichessTeam",
                table: "Servers",
                newName: "TeamName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeamName",
                table: "Servers",
                newName: "LichessTeam");
        }
    }
}
