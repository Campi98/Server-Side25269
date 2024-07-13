using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Viagem> Viagens { get; set; }
        public DbSet<Grupo_de_Viagem> GruposDeViagem { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Alojamento> Alojamentos { get; set; }
        public DbSet<ViagemGrupo> ViagemGrupos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - Perfil (1:1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Perfil)
                .WithOne(p => p.User)
                .HasForeignKey<Perfil>(p => p.ID_do_User);

            // User - Mensagem (1:N)
            modelBuilder.Entity<Mensagem>()
                .HasOne(m => m.Remetente)
                .WithMany(u => u.MensagensEnviadas)
                .HasForeignKey(m => m.ID_do_Remetente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Mensagem>()
                .HasOne(m => m.Destinatario)
                .WithMany(u => u.MensagensRecebidas)
                .HasForeignKey(m => m.ID_do_Destinatario)
                .OnDelete(DeleteBehavior.Restrict);

            // User - Avaliacao (1:N como Avaliador e 1:N como Avaliado)
            modelBuilder.Entity<Avaliacao>()
                .HasOne(a => a.Avaliador)
                .WithMany(u => u.AvaliacoesFeitas)
                .HasForeignKey(a => a.ID_do_Avaliador)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Avaliacao>()
                .HasOne(a => a.Avaliado)
                .WithMany(u => u.AvaliacoesRecebidas)
                .HasForeignKey(a => a.ID_do_Avaliado)
                .OnDelete(DeleteBehavior.Restrict);

            // Viagem - Alojamento (1:N)
            modelBuilder.Entity<Alojamento>()
                .HasOne(a => a.Viagem)
                .WithMany(v => v.Alojamentos)
                .HasForeignKey(a => a.ID_da_Viagem);

            // Grupo_de_Viagem - User (1:N)
            modelBuilder.Entity<Grupo_de_Viagem>()
                .HasMany(g => g.Users)
                .WithOne(u => u.Grupo)
                .HasForeignKey(u => u.ID_do_Grupo);

            // ViagemGrupo (N:N)
            modelBuilder.Entity<ViagemGrupo>()
                .HasKey(vg => new { vg.ViagemId, vg.GrupoDeViagemId });

            modelBuilder.Entity<ViagemGrupo>()
                .HasOne(vg => vg.Viagem)
                .WithMany(v => v.ViagemGrupos)
                .HasForeignKey(vg => vg.ViagemId);

            modelBuilder.Entity<ViagemGrupo>()
                .HasOne(vg => vg.GrupoDeViagem)
                .WithMany(g => g.ViagemGrupos)
                .HasForeignKey(vg => vg.GrupoDeViagemId);
        }
        public DbSet<WebApplication1.Models.Imagem> Imagem { get; set; } = default!;
    }
}
