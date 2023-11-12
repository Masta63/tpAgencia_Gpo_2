using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tpAgencia_Gpo_2.Migrations
{
    /// <inheritdoc />
    public partial class addVueloUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VueloUsuario_Usuario_idUsuario",
                table: "VueloUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_VueloUsuario_Vuelo_idVuelo",
                table: "VueloUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VueloUsuario",
                table: "VueloUsuario");

            migrationBuilder.RenameTable(
                name: "VueloUsuario",
                newName: "vueloUsuarios");

            migrationBuilder.RenameIndex(
                name: "IX_VueloUsuario_idUsuario",
                table: "vueloUsuarios",
                newName: "IX_vueloUsuarios_idUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vueloUsuarios",
                table: "vueloUsuarios",
                columns: new[] { "idVuelo", "idUsuario" });

            migrationBuilder.AddForeignKey(
                name: "FK_vueloUsuarios_Usuario_idUsuario",
                table: "vueloUsuarios",
                column: "idUsuario",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vueloUsuarios_Vuelo_idVuelo",
                table: "vueloUsuarios",
                column: "idVuelo",
                principalTable: "Vuelo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vueloUsuarios_Usuario_idUsuario",
                table: "vueloUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_vueloUsuarios_Vuelo_idVuelo",
                table: "vueloUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vueloUsuarios",
                table: "vueloUsuarios");

            migrationBuilder.RenameTable(
                name: "vueloUsuarios",
                newName: "VueloUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_vueloUsuarios_idUsuario",
                table: "VueloUsuario",
                newName: "IX_VueloUsuario_idUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VueloUsuario",
                table: "VueloUsuario",
                columns: new[] { "idVuelo", "idUsuario" });

            migrationBuilder.AddForeignKey(
                name: "FK_VueloUsuario_Usuario_idUsuario",
                table: "VueloUsuario",
                column: "idUsuario",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VueloUsuario_Vuelo_idVuelo",
                table: "VueloUsuario",
                column: "idVuelo",
                principalTable: "Vuelo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
