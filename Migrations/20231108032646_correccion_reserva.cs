using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tpAgencia_Gpo_2.Migrations
{
    /// <inheritdoc />
    public partial class correccion_reserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservaVuelo",
                table: "ReservaVuelo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservaHotel",
                table: "ReservaHotel");

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

            migrationBuilder.AlterColumn<int>(
                name: "idReservaVuelo",
                table: "ReservaVuelo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "idReservaHotel",
                table: "ReservaHotel",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservaVuelo",
                table: "ReservaVuelo",
                column: "idReservaVuelo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservaHotel",
                table: "ReservaHotel",
                column: "idReservaHotel");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaVuelo_idVuelo",
                table: "ReservaVuelo",
                column: "idVuelo");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHotel_idHotel",
                table: "ReservaHotel",
                column: "idHotel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservaVuelo",
                table: "ReservaVuelo");

            migrationBuilder.DropIndex(
                name: "IX_ReservaVuelo_idVuelo",
                table: "ReservaVuelo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservaHotel",
                table: "ReservaHotel");

            migrationBuilder.DropIndex(
                name: "IX_ReservaHotel_idHotel",
                table: "ReservaHotel");

            migrationBuilder.AlterColumn<int>(
                name: "idReservaVuelo",
                table: "ReservaVuelo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "idReservaHotel",
                table: "ReservaHotel",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservaVuelo",
                table: "ReservaVuelo",
                columns: new[] { "idVuelo", "idUsuario" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservaHotel",
                table: "ReservaHotel",
                columns: new[] { "idHotel", "idUsuario" });

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
    }
}
