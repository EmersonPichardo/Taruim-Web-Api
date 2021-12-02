using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarium_Web_API.Migrations
{
    public partial class Catalogos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Sucursal = table.Column<int>(type: "int", nullable: false),
                    Id_Producto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogos_Productos",
                        column: x => x.Id_Producto,
                        principalTable: "Productos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Catalogos_Sucursales",
                        column: x => x.Id_Sucursal,
                        principalTable: "Sucursales",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogos_Id_Producto",
                table: "Catalogos",
                column: "Id_Producto");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogos_Id_Sucursal",
                table: "Catalogos",
                column: "Id_Sucursal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalogos");
        }
    }
}
