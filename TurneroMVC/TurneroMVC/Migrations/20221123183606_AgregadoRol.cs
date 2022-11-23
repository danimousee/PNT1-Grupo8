using Microsoft.EntityFrameworkCore.Migrations;

namespace TurneroMVC.Migrations
{
    public partial class AgregadoRol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rol",
                table: "Cuentas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Cuentas");
        }
    }
}
