using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tpAgencia_Gpo_2.Migrations
{
    /// <inheritdoc />
    public partial class fix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idVuelo",
                table: "Ciudad");

            migrationBuilder.InsertData(
                table: "Ciudad",
                columns: new[] { "id", "nombre" },
                values: new object[,]
                {
                    { 1, "Salta" },
                    { 2, "Mendoza" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "id", "apellido", "bloqueado", "credito", "dni", "esAdmin", "intentosFallidos", "mail", "name", "password" },
                values: new object[,]
                {
                    { 10, "gno", false, 10000.0, "222", true, 0, "r@gmail.com", "romi", "123" },
                    { 12, "gnoa", false, 10000.0, "222", true, 0, "ro@gmail.com", "romina", "123" }
                });

            migrationBuilder.InsertData(
                table: "Vuelo",
                columns: new[] { "id", "CiudadDestinoId", "CiudadOrigenId", "Ciudadid", "aerolinea", "avion", "capacidad", "costo", "fecha", "vendido" },
                values: new object[] { 1, 2, 1, null, "AA", "Airbus", 30, 50.0, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 12);

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

            migrationBuilder.AddColumn<int>(
                name: "idVuelo",
                table: "Ciudad",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
