using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeSeguros.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolizaSeguros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePoliza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TarifaPoliza = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolizaSeguros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolizaVehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Linea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehiculoActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolizaVehiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimineto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Celular = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPolizas",
                columns: table => new
                {
                    UsuarioPolizaId = table.Column<int>(type: "int", nullable: false),
                    PolizaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    PolizaSegurosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPolizas", x => new { x.UsuarioPolizaId, x.PolizaId });
                    table.ForeignKey(
                        name: "FK_UsuarioPolizas_PolizaSeguros_PolizaSegurosId",
                        column: x => x.PolizaSegurosId,
                        principalTable: "PolizaSeguros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsuarioPolizas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioVehiculos",
                columns: table => new
                {
                    UsuarioVehiculoId = table.Column<int>(type: "int", nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    PolizaVehiculoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioVehiculos", x => new { x.UsuarioVehiculoId, x.VehiculoId });
                    table.ForeignKey(
                        name: "FK_UsuarioVehiculos_PolizaVehiculos_PolizaVehiculoId",
                        column: x => x.PolizaVehiculoId,
                        principalTable: "PolizaVehiculos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsuarioVehiculos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPolizas_PolizaSegurosId",
                table: "UsuarioPolizas",
                column: "PolizaSegurosId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPolizas_UsuarioId",
                table: "UsuarioPolizas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioVehiculos_PolizaVehiculoId",
                table: "UsuarioVehiculos",
                column: "PolizaVehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioVehiculos_UsuarioId",
                table: "UsuarioVehiculos",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioPolizas");

            migrationBuilder.DropTable(
                name: "UsuarioVehiculos");

            migrationBuilder.DropTable(
                name: "PolizaSeguros");

            migrationBuilder.DropTable(
                name: "PolizaVehiculos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
