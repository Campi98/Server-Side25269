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
    }
}
