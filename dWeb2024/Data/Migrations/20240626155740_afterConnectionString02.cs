using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dWeb2024.Data.Migrations
{
    /// <inheritdoc />
    public partial class afterConnectionString02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_do_User", "Email", "Nome", "Senha", "Tipo" },
                values: new object[,]
                {
                    { 1, "admin@example.com", "Admin", "admin123", "Admin" },
                    { 2, "user1@example.com", "User1", "user123", "User" }
                });

            migrationBuilder.InsertData(
                table: "Viagens",
                columns: new[] { "Id_da_Viagem", "Data_de_Fim", "Data_de_Inicio", "Descricao", "Destino", "Dicas_e_Recomendacoes", "Fotografia_relacionada_com_a_viagem", "Id_do_Grupo_de_Viagem", "Itenerario", "Rating_de_Viagem" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visita a Paris durante o Natal", "Paris", "Levar roupas quentes", "paris.jpg", 1, "Dia 1: Chegada; Dia 2: Torre Eiffel; ...", 4.5f },
                    { 2, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ano Novo em Lisboa", "Lisboa", "Ver os fogos na Torre de Belém", "lisboa.jpg", 2, "Dia 1: Chegada; Dia 2: Baixa de Lisboa; ...", 4.8f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_do_User",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_do_User",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Viagens",
                keyColumn: "Id_da_Viagem",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Viagens",
                keyColumn: "Id_da_Viagem",
                keyValue: 2);
        }
    }
}
