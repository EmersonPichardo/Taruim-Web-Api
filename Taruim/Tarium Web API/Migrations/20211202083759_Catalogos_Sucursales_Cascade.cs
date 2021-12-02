using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarium_Web_API.Migrations
{
    public partial class Catalogos_Sucursales_Cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogos_Sucursales",
                table: "Catalogos");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogos_Sucursales",
                table: "Catalogos",
                column: "Id_Sucursal",
                principalTable: "Sucursales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogos_Sucursales",
                table: "Catalogos");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogos_Sucursales",
                table: "Catalogos",
                column: "Id_Sucursal",
                principalTable: "Sucursales",
                principalColumn: "Id");
        }
    }
}
