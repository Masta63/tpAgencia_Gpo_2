using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace tpAgencia_Gpo_2.Migrations
{
    /// <inheritdoc />
    public partial class primera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    apellido = table.Column<string>(type: "varchar(50)", nullable: false),
                    dni = table.Column<string>(type: "varchar(10)", nullable: false),
                    mail = table.Column<string>(type: "varchar(256)", nullable: false),
                    password = table.Column<string>(type: "varchar(50)", nullable: false),
                    intentosFallidos = table.Column<int>(type: "int", nullable: false),
                    bloqueado = table.Column<bool>(type: "bit", nullable: false),
                    credito = table.Column<double>(type: "float", nullable: false),
                    esAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    capacidad = table.Column<int>(type: "int", nullable: false),
                    disponibilidad = table.Column<int>(type: "int", nullable: false),
                    costo = table.Column<double>(type: "float", nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    idCiudad = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hotel_Ciudad_idCiudad",
                        column: x => x.idCiudad,
                        principalTable: "Ciudad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vuelo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CiudadOrigenId = table.Column<int>(type: "int", nullable: false),
                    CiudadDestinoId = table.Column<int>(type: "int", nullable: false),
                    capacidad = table.Column<int>(type: "int", nullable: false),
                    vendido = table.Column<int>(type: "int", nullable: false),
                    costo = table.Column<double>(type: "float", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    aerolinea = table.Column<string>(type: "varchar(50)", nullable: false),
                    avion = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vuelo_Ciudad_CiudadDestinoId",
                        column: x => x.CiudadDestinoId,
                        principalTable: "Ciudad",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Vuelo_Ciudad_CiudadOrigenId",
                        column: x => x.CiudadOrigenId,
                        principalTable: "Ciudad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelUsuario",
                columns: table => new
                {
                    idHotel = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelUsuario", x => new { x.idHotel, x.idUsuario });
                    table.ForeignKey(
                        name: "FK_HotelUsuario_Hotel_idHotel",
                        column: x => x.idHotel,
                        principalTable: "Hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelUsuario_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservaHotel",
                columns: table => new
                {
                    idReservaHotel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idHotel = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    fechaDesde = table.Column<DateTime>(type: "datetime", nullable: false),
                    fechaHasta = table.Column<DateTime>(type: "datetime", nullable: false),
                    pagado = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaHotel", x => x.idReservaHotel);
                    table.ForeignKey(
                        name: "FK_ReservaHotel_Hotel_idHotel",
                        column: x => x.idHotel,
                        principalTable: "Hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaHotel_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservaVuelo",
                columns: table => new
                {
                    idReservaVuelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idVuelo = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    pagado = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaVuelo", x => x.idReservaVuelo);
                    table.ForeignKey(
                        name: "FK_ReservaVuelo_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaVuelo_Vuelo_idVuelo",
                        column: x => x.idVuelo,
                        principalTable: "Vuelo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VueloUsuario",
                columns: table => new
                {
                    idVuelo = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VueloUsuario", x => new { x.idVuelo, x.idUsuario });
                    table.ForeignKey(
                        name: "FK_VueloUsuario_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VueloUsuario_Vuelo_idVuelo",
                        column: x => x.idVuelo,
                        principalTable: "Vuelo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_idCiudad",
                table: "Hotel",
                column: "idCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_HotelUsuario_idUsuario",
                table: "HotelUsuario",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHotel_idHotel",
                table: "ReservaHotel",
                column: "idHotel");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHotel_idUsuario",
                table: "ReservaHotel",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaVuelo_idUsuario",
                table: "ReservaVuelo",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaVuelo_idVuelo",
                table: "ReservaVuelo",
                column: "idVuelo");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelo_CiudadDestinoId",
                table: "Vuelo",
                column: "CiudadDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelo_CiudadOrigenId",
                table: "Vuelo",
                column: "CiudadOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_VueloUsuario_idUsuario",
                table: "VueloUsuario",
                column: "idUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelUsuario");

            migrationBuilder.DropTable(
                name: "ReservaHotel");

            migrationBuilder.DropTable(
                name: "ReservaVuelo");

            migrationBuilder.DropTable(
                name: "VueloUsuario");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Vuelo");

            migrationBuilder.DropTable(
                name: "Ciudad");
        }
    }
}
