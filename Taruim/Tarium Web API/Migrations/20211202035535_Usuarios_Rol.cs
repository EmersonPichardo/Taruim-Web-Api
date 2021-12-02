using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarium_Web_API.Migrations
{
    public partial class Usuarios_Rol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rol",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Usuarios");
        }
    }
}
