using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tpAgencia_Gpo_2.Migrations
{
    /// <inheritdoc />
    public partial class add_campoNuevoReservaHotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "disponibilidad",
                table: "Hotel");

            migrationBuilder.AddColumn<int>(
                name: "cantidadPersonas",
                table: "ReservaHotel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cantidadPersonas",
                table: "ReservaHotel");

            migrationBuilder.AddColumn<int>(
                name: "disponibilidad",
                table: "Hotel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
