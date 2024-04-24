using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dWeb2024.Data.Migrations
{
    /// <inheritdoc />
    public partial class antons02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GruposDeViagem",
                columns: table => new
                {
                    Id_do_Grupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminUser = table.Column<int>(type: "int", nullable: false),
                    Nome_do_Grupo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_de_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_de_Fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposDeViagem", x => x.Id_do_Grupo);
                });

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    Id_da_Mensagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_do_Remetente = table.Column<int>(type: "int", nullable: false),
                    Id_do_Destinatario = table.Column<int>(type: "int", nullable: false),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_e_Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fotografia_do_User = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.Id_da_Mensagem);
                });

            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    Id_do_Perfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_do_User = table.Column<int>(type: "int", nullable: false),
                    Fotografia_do_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interesses_de_Viagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destinos_Favoritos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nivel_de_Experiencia_em_Viagens = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.Id_do_Perfil);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_do_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id_do_User);
                });

            migrationBuilder.CreateTable(
                name: "Viagens",
                columns: table => new
                {
                    Id_da_Viagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_do_Grupo_de_Viagem = table.Column<int>(type: "int", nullable: false),
                    Fotografia_relacionada_com_a_viagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_de_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_de_Fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Itenerario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dicas_e_Recomendacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating_de_Viagem = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viagens", x => x.Id_da_Viagem);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    Id_da_Avaliacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_do_Avaliador = table.Column<int>(type: "int", nullable: false),
                    Id_do_Avaliado = table.Column<int>(type: "int", nullable: false),
                    Classificacao = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsersId_do_User = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.Id_da_Avaliacao);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Users_UsersId_do_User",
                        column: x => x.UsersId_do_User,
                        principalTable: "Users",
                        principalColumn: "Id_do_User");
                });

            migrationBuilder.CreateTable(
                name: "MensagemUsers",
                columns: table => new
                {
                    ListaMensagensId_da_Mensagem = table.Column<int>(type: "int", nullable: false),
                    ListaUsersId_do_User = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensagemUsers", x => new { x.ListaMensagensId_da_Mensagem, x.ListaUsersId_do_User });
                    table.ForeignKey(
                        name: "FK_MensagemUsers_Mensagens_ListaMensagensId_da_Mensagem",
                        column: x => x.ListaMensagensId_da_Mensagem,
                        principalTable: "Mensagens",
                        principalColumn: "Id_da_Mensagem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MensagemUsers_Users_ListaUsersId_do_User",
                        column: x => x.ListaUsersId_do_User,
                        principalTable: "Users",
                        principalColumn: "Id_do_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_UsersId_do_User",
                table: "Avaliacoes",
                column: "UsersId_do_User");

            migrationBuilder.CreateIndex(
                name: "IX_MensagemUsers_ListaUsersId_do_User",
                table: "MensagemUsers",
                column: "ListaUsersId_do_User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "GruposDeViagem");

            migrationBuilder.DropTable(
                name: "MensagemUsers");

            migrationBuilder.DropTable(
                name: "Perfis");

            migrationBuilder.DropTable(
                name: "Viagens");

            migrationBuilder.DropTable(
                name: "Mensagens");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
