using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fisioterapia.Api.Migrations
{
    /// <inheritdoc />
    public partial class AgregarServicios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Servicios",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Servicios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Servicios");
        }
    }
}
