using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TurneroMVC.Migrations
{
    public partial class TurneroMVCContextTurneroDatabaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Contrasenia = table.Column<string>(nullable: true),
                    CodVerif = table.Column<string>(nullable: true),
                    NombreCompleto = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Dni = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroComprobante = table.Column<int>(nullable: false),
                    DiaHora = table.Column<DateTime>(nullable: false),
                    Actividad = table.Column<int>(nullable: false),
                    CuentaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turnos_Cuentas_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "Cuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_CuentaId",
                table: "Turnos",
                column: "CuentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Cuentas");
        }
    }
}
