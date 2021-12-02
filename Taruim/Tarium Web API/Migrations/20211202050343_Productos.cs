using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Tarium_Web_API.Migrations
{
    public partial class Productos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SKU = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CodigoBarra = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime", nullable: true),
                    Id_Proveedor = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Proveedores",
                        column: x => x.Id_Proveedor,
                        principalTable: "Proveedores",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IND_Productos_CodigoBarra",
                table: "Productos",
                column: "CodigoBarra");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Id_Proveedor",
                table: "Productos",
                column: "Id_Proveedor");

            migrationBuilder.CreateIndex(
                name: "UNQ_Productos_SKU",
                table: "Productos",
                column: "SKU",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
