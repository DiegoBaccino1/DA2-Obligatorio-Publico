using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class MyMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "puntoTuristicos");

            migrationBuilder.AddColumn<int>(
                name: "ImagenId",
                table: "puntoTuristicos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "hospedajes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreHospedaje = table.Column<string>(nullable: true),
                    PuntoTuristicoId = table.Column<int>(nullable: true),
                    CantidadEstrellas = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    PrecioPorNoche = table.Column<int>(nullable: false),
                    PrecioTotalPeriodo = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Ocupado = table.Column<bool>(nullable: false),
                    Capacidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospedajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hospedajes_puntoTuristicos_PuntoTuristicoId",
                        column: x => x.PuntoTuristicoId,
                        principalTable: "puntoTuristicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "imagenes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ruta = table.Column<string>(nullable: true),
                    HospedajeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imagenes_hospedajes_HospedajeId",
                        column: x => x.HospedajeId,
                        principalTable: "hospedajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_puntoTuristicos_ImagenId",
                table: "puntoTuristicos",
                column: "ImagenId");

            migrationBuilder.CreateIndex(
                name: "IX_hospedajes_PuntoTuristicoId",
                table: "hospedajes",
                column: "PuntoTuristicoId");

            migrationBuilder.CreateIndex(
                name: "IX_imagenes_HospedajeId",
                table: "imagenes",
                column: "HospedajeId");

            migrationBuilder.AddForeignKey(
                name: "FK_puntoTuristicos_imagenes_ImagenId",
                table: "puntoTuristicos",
                column: "ImagenId",
                principalTable: "imagenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_puntoTuristicos_imagenes_ImagenId",
                table: "puntoTuristicos");

            migrationBuilder.DropTable(
                name: "imagenes");

            migrationBuilder.DropTable(
                name: "hospedajes");

            migrationBuilder.DropIndex(
                name: "IX_puntoTuristicos_ImagenId",
                table: "puntoTuristicos");

            migrationBuilder.DropColumn(
                name: "ImagenId",
                table: "puntoTuristicos");

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "puntoTuristicos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
