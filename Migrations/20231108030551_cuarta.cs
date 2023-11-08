using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tpAgencia_Gpo_2.Migrations
{
    /// <inheritdoc />
    public partial class cuarta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vuelo_Ciudad_CiudadDestinoId",
                table: "Vuelo");

            migrationBuilder.DropForeignKey(
                name: "FK_Vuelo_Ciudad_Ciudadid",
                table: "Vuelo");

            migrationBuilder.DropIndex(
                name: "IX_Vuelo_Ciudadid",
                table: "Vuelo");

            migrationBuilder.DropColumn(
                name: "Ciudadid",
                table: "Vuelo");

            migrationBuilder.DropColumn(
                name: "idVuelo",
                table: "Ciudad");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelo_Ciudad_CiudadDestinoId",
                table: "Vuelo",
                column: "CiudadDestinoId",
                principalTable: "Ciudad",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vuelo_Ciudad_CiudadDestinoId",
                table: "Vuelo");

            migrationBuilder.AddColumn<int>(
                name: "Ciudadid",
                table: "Vuelo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idVuelo",
                table: "Ciudad",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vuelo_Ciudadid",
                table: "Vuelo",
                column: "Ciudadid");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelo_Ciudad_CiudadDestinoId",
                table: "Vuelo",
                column: "CiudadDestinoId",
                principalTable: "Ciudad",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelo_Ciudad_Ciudadid",
                table: "Vuelo",
                column: "Ciudadid",
                principalTable: "Ciudad",
                principalColumn: "id");
        }
    }
}
