using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessScheduler.Bot.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PodiumChannel = table.Column<ulong>(type: "INTEGER", nullable: false),
                    ChampionRole = table.Column<ulong>(type: "INTEGER", nullable: false),
                    LichessTeam = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
