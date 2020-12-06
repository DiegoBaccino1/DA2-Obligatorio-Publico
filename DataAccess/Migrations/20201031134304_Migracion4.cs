using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Migracion4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Puntaje",
                table: "hospedajes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "DatosUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "huespedes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantAdultos = table.Column<int>(nullable: false),
                    CantNinios = table.Column<int>(nullable: false),
                    CantBebes = table.Column<int>(nullable: false),
                    CantJubilados = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_huespedes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resenia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Puntaje = table.Column<int>(nullable: false),
                    Texto = table.Column<string>(nullable: true),
                    DatosId = table.Column<int>(nullable: true),
                    HospedajeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resenia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resenia_DatosUsuario_DatosId",
                        column: x => x.DatosId,
                        principalTable: "DatosUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resenia_hospedajes_HospedajeId",
                        column: x => x.HospedajeId,
                        principalTable: "hospedajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatosId = table.Column<int>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    Contrasenia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuarios_DatosUsuario_DatosId",
                        column: x => x.DatosId,
                        principalTable: "DatosUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resenia_DatosId",
                table: "Resenia",
                column: "DatosId");

            migrationBuilder.CreateIndex(
                name: "IX_Resenia_HospedajeId",
                table: "Resenia",
                column: "HospedajeId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_DatosId",
                table: "usuarios",
                column: "DatosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "huespedes");

            migrationBuilder.DropTable(
                name: "Resenia");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "DatosUsuario");

            migrationBuilder.DropColumn(
                name: "Puntaje",
                table: "hospedajes");
        }
    }
}
