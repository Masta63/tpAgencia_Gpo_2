using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tpAgencia_Gpo_2.Migrations
{
    /// <inheritdoc />
    public partial class datosvuelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ciudad",
                columns: new[] { "id", "nombre" },
                values: new object[,]
                {
                    { 1, "Salta" },
                    { 2, "Buenos Aires" },
                    { 3, "Mendoza" }
                });

            migrationBuilder.InsertData(
                table: "Vuelo",
                columns: new[] { "id", "CiudadDestinoId", "CiudadOrigenId", "aerolinea", "avion", "capacidad", "costo", "fecha", "vendido" },
                values: new object[] { 1, 2, 1, "AA", "Airbus", 30, 1000.0, new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ciudad",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vuelo",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ciudad",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ciudad",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
