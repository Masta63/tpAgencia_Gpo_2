using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tpAgencia_Gpo_2.Migrations
{
    /// <inheritdoc />
    public partial class fix5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vuelo_Ciudad_Ciudadid",
                table: "Vuelo");

            migrationBuilder.DropIndex(
                name: "IX_Vuelo_Ciudadid",
                table: "Vuelo");

            migrationBuilder.DropColumn(
                name: "Ciudadid",
                table: "Vuelo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ciudadid",
                table: "Vuelo",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Vuelo",
                keyColumn: "id",
                keyValue: 1,
                column: "Ciudadid",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Vuelo_Ciudadid",
                table: "Vuelo",
                column: "Ciudadid");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelo_Ciudad_Ciudadid",
                table: "Vuelo",
                column: "Ciudadid",
                principalTable: "Ciudad",
                principalColumn: "id");
        }
    }
}
