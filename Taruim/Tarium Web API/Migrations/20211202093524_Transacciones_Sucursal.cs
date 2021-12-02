using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarium_Web_API.Migrations
{
    public partial class Transacciones_Sucursal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Sucursal",
                table: "Transacciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_Id_Sucursal",
                table: "Transacciones",
                column: "Id_Sucursal");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Sucursal",
                table: "Transacciones",
                column: "Id_Sucursal",
                principalTable: "Sucursales",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Sucursal",
                table: "Transacciones");

            migrationBuilder.DropIndex(
                name: "IX_Transacciones_Id_Sucursal",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "Id_Sucursal",
                table: "Transacciones");
        }
    }
}
