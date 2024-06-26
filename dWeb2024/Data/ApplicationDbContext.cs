using dWeb2024.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dWeb2024.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Grupo_de_Viagem> GruposDeViagem { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Viagem> Viagens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Users
            modelBuilder.Entity<Users>().HasData(
                new Users { Id_do_User = 1, Nome = "Admin", Email = "admin@example.com", Senha = "admin123", Tipo = "Admin" },
                new Users { Id_do_User = 2, Nome = "User1", Email = "user1@example.com", Senha = "user123", Tipo = "User" }
            );

            // Seed data for Viagens
            modelBuilder.Entity<Viagem>().HasData(
                new Viagem
                {
                    Id_da_Viagem = 1,
                    Id_do_Grupo_de_Viagem = 1,
                    Fotografia_relacionada_com_a_viagem = "paris.jpg",
                    Destino = "Paris",
                    Data_de_Inicio = new DateTime(2023, 12, 25),
                    Data_de_Fim = new DateTime(2024, 1, 5),
                    Descricao = "Visita a Paris durante o Natal",
                    Itenerario = "Dia 1: Chegada; Dia 2: Torre Eiffel; ...",
                    Dicas_e_Recomendacoes = "Levar roupas quentes",
                    Rating_de_Viagem = 4.5f
                },
                new Viagem
                {
                    Id_da_Viagem = 2,
                    Id_do_Grupo_de_Viagem = 2,
                    Fotografia_relacionada_com_a_viagem = "lisboa.jpg",
                    Destino = "Lisboa",
                    Data_de_Inicio = new DateTime(2023, 12, 31),
                    Data_de_Fim = new DateTime(2024, 1, 2),
                    Descricao = "Ano Novo em Lisboa",
                    Itenerario = "Dia 1: Chegada; Dia 2: Baixa de Lisboa; ...",
                    Dicas_e_Recomendacoes = "Ver os fogos na Torre de Belém",
                    Rating_de_Viagem = 4.8f
                }
            );

            // Adiciona aqui outros seed data conforme necessário
        }




    }



}
