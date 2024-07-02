using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class try04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viagens_GruposDeViagem_ID_do_Grupo_de_Viagem",
                table: "Viagens");

            migrationBuilder.DropTable(
                name: "GrupoUser");

            migrationBuilder.DropIndex(
                name: "IX_Viagens_ID_do_Grupo_de_Viagem",
                table: "Viagens");

            migrationBuilder.DropColumn(
                name: "ID_do_Grupo_de_Viagem",
                table: "Viagens");

            migrationBuilder.AddColumn<int>(
                name: "ID_do_Grupo",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ViagemGrupo",
                columns: table => new
                {
                    ID_da_Viagem = table.Column<int>(type: "int", nullable: false),
                    ID_do_Grupo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViagemGrupo", x => new { x.ID_da_Viagem, x.ID_do_Grupo });
                    table.ForeignKey(
                        name: "FK_ViagemGrupo_GruposDeViagem_ID_do_Grupo",
                        column: x => x.ID_do_Grupo,
                        principalTable: "GruposDeViagem",
                        principalColumn: "ID_do_Grupo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViagemGrupo_Viagens_ID_da_Viagem",
                        column: x => x.ID_da_Viagem,
                        principalTable: "Viagens",
                        principalColumn: "ID_da_Viagem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ID_do_Grupo",
                table: "Users",
                column: "ID_do_Grupo");

            migrationBuilder.CreateIndex(
                name: "IX_ViagemGrupo_ID_do_Grupo",
                table: "ViagemGrupo",
                column: "ID_do_Grupo");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GruposDeViagem_ID_do_Grupo",
                table: "Users",
                column: "ID_do_Grupo",
                principalTable: "GruposDeViagem",
                principalColumn: "ID_do_Grupo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_GruposDeViagem_ID_do_Grupo",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ViagemGrupo");

            migrationBuilder.DropIndex(
                name: "IX_Users_ID_do_Grupo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ID_do_Grupo",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "ID_do_Grupo_de_Viagem",
                table: "Viagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GrupoUser",
                columns: table => new
                {
                    GrupoId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoUser", x => new { x.GrupoId, x.UserId });
                    table.ForeignKey(
                        name: "FK_GrupoUser_GruposDeViagem_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "GruposDeViagem",
                        principalColumn: "ID_do_Grupo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrupoUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID_do_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Viagens_ID_do_Grupo_de_Viagem",
                table: "Viagens",
                column: "ID_do_Grupo_de_Viagem");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoUser_UserId",
                table: "GrupoUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Viagens_GruposDeViagem_ID_do_Grupo_de_Viagem",
                table: "Viagens",
                column: "ID_do_Grupo_de_Viagem",
                principalTable: "GruposDeViagem",
                principalColumn: "ID_do_Grupo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
