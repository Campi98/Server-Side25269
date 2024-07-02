﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240702161245_try05")]
    partial class try05
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ViagemGrupo", b =>
                {
                    b.Property<int>("ID_da_Viagem")
                        .HasColumnType("int");

                    b.Property<int>("ID_do_Grupo")
                        .HasColumnType("int");

                    b.HasKey("ID_da_Viagem", "ID_do_Grupo");

                    b.HasIndex("ID_do_Grupo");

                    b.ToTable("ViagemGrupo");
                });

            modelBuilder.Entity("WebApplication1.Models.Alojamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDisponivel")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID_da_Viagem")
                        .HasColumnType("int");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrecoPorNoite")
                        .HasColumnType("int");

                    b.Property<string>("Proprietario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefoneProprietario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ID_da_Viagem");

                    b.ToTable("Alojamentos");
                });

            modelBuilder.Entity("WebApplication1.Models.Avaliacao", b =>
                {
                    b.Property<int>("ID_da_Avaliacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_da_Avaliacao"));

                    b.Property<int>("Classificacao")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_do_Avaliado")
                        .HasColumnType("int");

                    b.Property<int>("ID_do_Avaliador")
                        .HasColumnType("int");

                    b.HasKey("ID_da_Avaliacao");

                    b.HasIndex("ID_do_Avaliado");

                    b.HasIndex("ID_do_Avaliador");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("WebApplication1.Models.Grupo_de_Viagem", b =>
                {
                    b.Property<int>("ID_do_Grupo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_do_Grupo"));

                    b.Property<DateTime>("Data_de_Fim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_de_Inicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome_do_Grupo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_do_Grupo");

                    b.ToTable("GruposDeViagem");
                });

            modelBuilder.Entity("WebApplication1.Models.Imagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Base64String")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Imagem");
                });

            modelBuilder.Entity("WebApplication1.Models.Mensagem", b =>
                {
                    b.Property<int>("ID_da_Mensagem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_da_Mensagem"));

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data_e_Hora")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_do_Destinatario")
                        .HasColumnType("int");

                    b.Property<int>("ID_do_Remetente")
                        .HasColumnType("int");

                    b.HasKey("ID_da_Mensagem");

                    b.HasIndex("ID_do_Destinatario");

                    b.HasIndex("ID_do_Remetente");

                    b.ToTable("Mensagens");
                });

            modelBuilder.Entity("WebApplication1.Models.Perfil", b =>
                {
                    b.Property<int>("ID_do_Perfil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_do_Perfil"));

                    b.Property<string>("Destinos_Favoritos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fotografia_do_User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID_do_User")
                        .HasColumnType("int");

                    b.Property<string>("Interesses_de_Viagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nivel_de_Experiencia_em_Viagens")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_do_Perfil");

                    b.HasIndex("ID_do_User")
                        .IsUnique();

                    b.ToTable("Perfis");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Property<int>("ID_do_User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_do_User"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ID_do_Grupo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_do_User");

                    b.HasIndex("ID_do_Grupo");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication1.Models.Viagem", b =>
                {
                    b.Property<int>("ID_da_Viagem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_da_Viagem"));

                    b.Property<DateTime>("Data_de_Fim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_de_Inicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dicas_e_Recomendacoes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fotografia_relacionada_com_a_viagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Itinerario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating_da_Viagem")
                        .HasColumnType("real");

                    b.HasKey("ID_da_Viagem");

                    b.ToTable("Viagens");
                });

            modelBuilder.Entity("ViagemGrupo", b =>
                {
                    b.HasOne("WebApplication1.Models.Viagem", null)
                        .WithMany()
                        .HasForeignKey("ID_da_Viagem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Grupo_de_Viagem", null)
                        .WithMany()
                        .HasForeignKey("ID_do_Grupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.Alojamento", b =>
                {
                    b.HasOne("WebApplication1.Models.Viagem", "Viagem")
                        .WithMany("Alojamentos")
                        .HasForeignKey("ID_da_Viagem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Viagem");
                });

            modelBuilder.Entity("WebApplication1.Models.Avaliacao", b =>
                {
                    b.HasOne("WebApplication1.Models.User", "Avaliado")
                        .WithMany("AvaliacoesRecebidas")
                        .HasForeignKey("ID_do_Avaliado")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.User", "Avaliador")
                        .WithMany("AvaliacoesFeitas")
                        .HasForeignKey("ID_do_Avaliador")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Avaliado");

                    b.Navigation("Avaliador");
                });

            modelBuilder.Entity("WebApplication1.Models.Mensagem", b =>
                {
                    b.HasOne("WebApplication1.Models.User", "Destinatario")
                        .WithMany("MensagensRecebidas")
                        .HasForeignKey("ID_do_Destinatario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.User", "Remetente")
                        .WithMany("MensagensEnviadas")
                        .HasForeignKey("ID_do_Remetente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Destinatario");

                    b.Navigation("Remetente");
                });

            modelBuilder.Entity("WebApplication1.Models.Perfil", b =>
                {
                    b.HasOne("WebApplication1.Models.User", "User")
                        .WithOne("Perfil")
                        .HasForeignKey("WebApplication1.Models.Perfil", "ID_do_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.HasOne("WebApplication1.Models.Grupo_de_Viagem", "Grupo")
                        .WithMany("Users")
                        .HasForeignKey("ID_do_Grupo");

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("WebApplication1.Models.Grupo_de_Viagem", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Navigation("AvaliacoesFeitas");

                    b.Navigation("AvaliacoesRecebidas");

                    b.Navigation("MensagensEnviadas");

                    b.Navigation("MensagensRecebidas");

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("WebApplication1.Models.Viagem", b =>
                {
                    b.Navigation("Alojamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
