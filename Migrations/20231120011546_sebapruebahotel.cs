using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tpAgencia_Gpo_2.Migrations
{
    /// <inheritdoc />
    public partial class sebapruebahotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "id", "capacidad", "costo", "disponibilidad", "idCiudad", "nombre" },
                values: new object[] { 1, 10, 123.44999694824219, 10, 1, "Faena" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
