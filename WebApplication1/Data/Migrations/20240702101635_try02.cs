using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class try02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrupoUser_GruposDeViagem_GruposID_do_Grupo",
                table: "GrupoUser");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoUser_Users_UsersID_do_User",
                table: "GrupoUser");

            migrationBuilder.RenameColumn(
                name: "UsersID_do_User",
                table: "GrupoUser",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "GruposID_do_Grupo",
                table: "GrupoUser",
                newName: "GrupoId");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoUser_UsersID_do_User",
                table: "GrupoUser",
                newName: "IX_GrupoUser_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoUser_GruposDeViagem_GrupoId",
                table: "GrupoUser",
                column: "GrupoId",
                principalTable: "GruposDeViagem",
                principalColumn: "ID_do_Grupo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoUser_Users_UserId",
                table: "GrupoUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID_do_User",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrupoUser_GruposDeViagem_GrupoId",
                table: "GrupoUser");

            migrationBuilder.DropForeignKey(
                name: "FK_GrupoUser_Users_UserId",
                table: "GrupoUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "GrupoUser",
                newName: "UsersID_do_User");

            migrationBuilder.RenameColumn(
                name: "GrupoId",
                table: "GrupoUser",
                newName: "GruposID_do_Grupo");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoUser_UserId",
                table: "GrupoUser",
                newName: "IX_GrupoUser_UsersID_do_User");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoUser_GruposDeViagem_GruposID_do_Grupo",
                table: "GrupoUser",
                column: "GruposID_do_Grupo",
                principalTable: "GruposDeViagem",
                principalColumn: "ID_do_Grupo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoUser_Users_UsersID_do_User",
                table: "GrupoUser",
                column: "UsersID_do_User",
                principalTable: "Users",
                principalColumn: "ID_do_User",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
