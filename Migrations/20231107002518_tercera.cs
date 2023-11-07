using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tpAgencia_Gpo_2.Migrations
{
    /// <inheritdoc />
    public partial class tercera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "id", "apellido", "bloqueado", "credito", "dni", "esAdmin", "intentosFallidos", "mail", "name", "password" },
                values: new object[,]
                {
                    { 1, "admin", false, 0.0, "10111222", true, 0, "admin@admin.com", "admin", "12345" },
                    { 2, "perez", false, 0.0, "11222333", false, 0, "juan@juan.com", "juan", "12345" },
                    { 3, "perez", false, 0.0, "33222111", false, 0, "luciana@luciana.com", "luciana", "12345" },
                    { 4, "gomez", false, 0.0, "22333444", false, 0, "perdo@pedro.com", "pedro ", "12345" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
