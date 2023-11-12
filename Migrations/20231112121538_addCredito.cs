using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tpAgencia_Gpo_2.Migrations
{
    /// <inheritdoc />
    public partial class addCredito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 1,
                column: "credito",
                value: 50000.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "id",
                keyValue: 1,
                column: "credito",
                value: 0.0);
        }
    }
}
