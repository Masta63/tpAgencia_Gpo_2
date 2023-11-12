using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tpAgencia_Gpo_2.Migrations
{
    /// <inheritdoc />
    public partial class addCredito2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 2,
                column: "credito",
                value: 50000.0);

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 3,
                column: "credito",
                value: 10000.0);

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 4,
                column: "credito",
                value: 20000.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 2,
                column: "credito",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 3,
                column: "credito",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 4,
                column: "credito",
                value: 0.0);
        }
    }
}
