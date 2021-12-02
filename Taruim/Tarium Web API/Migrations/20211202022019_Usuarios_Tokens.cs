using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarium_Web_API.Migrations
{
    public partial class Usuarios_Tokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Hash = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Hash);
                    table.ForeignKey(
                        name: "FK_Tokens_Usuarios",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_Id_Usuario",
                table: "Tokens",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IND_Usuarios_Nombre",
                table: "Usuarios",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "UNQ_Usuarios_Correo",
                table: "Usuarios",
                column: "Correo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
