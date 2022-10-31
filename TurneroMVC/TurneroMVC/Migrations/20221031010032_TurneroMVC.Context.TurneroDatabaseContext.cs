using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TurneroMVC.Migrations
{
    public partial class TurneroMVCContextTurneroDatabaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroComprobante = table.Column<string>(nullable: true),
                    DiaHora = table.Column<DateTime>(nullable: false),
                    Actividad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turnos");
        }
    }
}
