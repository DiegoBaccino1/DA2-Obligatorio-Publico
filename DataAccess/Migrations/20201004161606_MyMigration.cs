using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "regiones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "puntoTuristicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Imagen = table.Column<string>(nullable: true),
                    RegionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_puntoTuristicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_puntoTuristicos_regiones_RegionId",
                        column: x => x.RegionId,
                        principalTable: "regiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "puntoTuristicoCategoria",
                columns: table => new
                {
                    PuntoTuristicoId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_puntoTuristicoCategoria", x => new { x.PuntoTuristicoId, x.CategoriaId });
                    table.ForeignKey(
                        name: "FK_puntoTuristicoCategoria_categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_puntoTuristicoCategoria_puntoTuristicos_PuntoTuristicoId",
                        column: x => x.PuntoTuristicoId,
                        principalTable: "puntoTuristicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_puntoTuristicoCategoria_CategoriaId",
                table: "puntoTuristicoCategoria",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_puntoTuristicos_RegionId",
                table: "puntoTuristicos",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "puntoTuristicoCategoria");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "puntoTuristicos");

            migrationBuilder.DropTable(
                name: "regiones");
        }
    }
}
