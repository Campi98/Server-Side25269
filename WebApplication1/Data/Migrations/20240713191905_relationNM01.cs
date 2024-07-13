using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class relationNM01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ViagemGrupo");

            migrationBuilder.CreateTable(
                name: "Grupo_de_ViagemViagem",
                columns: table => new
                {
                    GruposID_do_Grupo = table.Column<int>(type: "int", nullable: false),
                    ViagensID_da_Viagem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo_de_ViagemViagem", x => new { x.GruposID_do_Grupo, x.ViagensID_da_Viagem });
                    table.ForeignKey(
                        name: "FK_Grupo_de_ViagemViagem_GruposDeViagem_GruposID_do_Grupo",
                        column: x => x.GruposID_do_Grupo,
                        principalTable: "GruposDeViagem",
                        principalColumn: "ID_do_Grupo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grupo_de_ViagemViagem_Viagens_ViagensID_da_Viagem",
                        column: x => x.ViagensID_da_Viagem,
                        principalTable: "Viagens",
                        principalColumn: "ID_da_Viagem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViagemGrupos",
                columns: table => new
                {
                    ViagemId = table.Column<int>(type: "int", nullable: false),
                    GrupoDeViagemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViagemGrupos", x => new { x.ViagemId, x.GrupoDeViagemId });
                    table.ForeignKey(
                        name: "FK_ViagemGrupos_GruposDeViagem_GrupoDeViagemId",
                        column: x => x.GrupoDeViagemId,
                        principalTable: "GruposDeViagem",
                        principalColumn: "ID_do_Grupo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViagemGrupos_Viagens_ViagemId",
                        column: x => x.ViagemId,
                        principalTable: "Viagens",
                        principalColumn: "ID_da_Viagem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_de_ViagemViagem_ViagensID_da_Viagem",
                table: "Grupo_de_ViagemViagem",
                column: "ViagensID_da_Viagem");

            migrationBuilder.CreateIndex(
                name: "IX_ViagemGrupos_GrupoDeViagemId",
                table: "ViagemGrupos",
                column: "GrupoDeViagemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grupo_de_ViagemViagem");

            migrationBuilder.DropTable(
                name: "ViagemGrupos");

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
                name: "IX_ViagemGrupo_ID_do_Grupo",
                table: "ViagemGrupo",
                column: "ID_do_Grupo");
        }
    }
}
