using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoCiclo3.App.Persistencia.Migrations
{
    public partial class MigraInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeropuertos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coord_X = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coord_y = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeropuertos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rutas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    origenid = table.Column<int>(type: "int", nullable: true),
                    destinoid = table.Column<int>(type: "int", nullable: true),
                    tiempo_estimado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rutas_Aeropuertos_destinoid",
                        column: x => x.destinoid,
                        principalTable: "Aeropuertos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rutas_Aeropuertos_origenid",
                        column: x => x.origenid,
                        principalTable: "Aeropuertos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rutas_destinoid",
                table: "Rutas",
                column: "destinoid");

            migrationBuilder.CreateIndex(
                name: "IX_Rutas_origenid",
                table: "Rutas",
                column: "origenid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rutas");

            migrationBuilder.DropTable(
                name: "Aeropuertos");
        }
    }
}
