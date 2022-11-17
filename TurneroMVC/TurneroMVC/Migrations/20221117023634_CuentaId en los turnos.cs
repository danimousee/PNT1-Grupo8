using Microsoft.EntityFrameworkCore.Migrations;

namespace TurneroMVC.Migrations
{
    public partial class CuentaIdenlosturnos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Cuentas_CuentaId",
                table: "Turnos");

            migrationBuilder.AlterColumn<int>(
                name: "CuentaId",
                table: "Turnos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Cuentas_CuentaId",
                table: "Turnos",
                column: "CuentaId",
                principalTable: "Cuentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Cuentas_CuentaId",
                table: "Turnos");

            migrationBuilder.AlterColumn<int>(
                name: "CuentaId",
                table: "Turnos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Cuentas_CuentaId",
                table: "Turnos",
                column: "CuentaId",
                principalTable: "Cuentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
