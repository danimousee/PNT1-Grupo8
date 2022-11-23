using Microsoft.EntityFrameworkCore.Migrations;

namespace TurneroMVC.Migrations
{
    public partial class QuitaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NroComprobante",
                table: "Turnos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NroComprobante",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
