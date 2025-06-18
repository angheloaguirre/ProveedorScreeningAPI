using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProveedorScreeningAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NombreComercial = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IdentificacionTributaria = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SitioWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FacturacionAnual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FechaUltimaEdicion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnListaRiesgo = table.Column<bool>(type: "bit", nullable: true),
                    FuentesRiesgo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proveedores");
        }
    }
}
