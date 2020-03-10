﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senatur.Context;

namespace Senatur.Migrations
{
    [DbContext(typeof(SenaturContext))]
    [Migration("20200310181343_SenaturMigration")]
    partial class SenaturMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Senatur.Domains.Pacotes", b =>
                {
                    b.Property<int>("IdPacote")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("BIT");

                    b.Property<DateTime>("DataIda")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("DataVolta")
                        .HasColumnType("DATE");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR (500)");

                    b.Property<string>("NomeCidade")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("NomePacote")
                        .IsRequired()
                        .HasColumnType("VARCHAR (255)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("DECIMAL (18,2)");

                    b.HasKey("IdPacote");

                    b.ToTable("Pacotes");

                    b.HasData(
                        new { IdPacote = 1, Ativo = true, DataIda = new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), DataVolta = new DateTime(2020, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), Descricao = " O que não falta em Salvador são atrações. Prova disso são as praias, os museus e as construções seculares que dão um charme mais que especial à região. A cidade, sinônimo de alegria, também é conhecida pela efervescência cultural que a credenciou como um dos destinos mais procurados por turistas brasileiros e estrangeiros. O Pelourinho e o Elevador são alguns dos principais pontos de visitação. ", NomeCidade = "Salvador", NomePacote = "SALVADOR - 5 DIAS / 4 DIÁRIAS", Preco = 854.00m },
                        new { IdPacote = 2, Ativo = true, DataIda = new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), DataVolta = new DateTime(2020, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), Descricao = " O Litoral Norte da Bahia conta com inúmeras praias emolduradas por coqueiros, além de piscinas naturais de águas mornas que são protegidas por recifes e habitadas por peixes coloridos. Banhos de mar em águas calmas ou agitadas, mergulho com snorkel, caminhada pela orla e calçadões, passeios de bicicleta, pontos turísticos históricos, interação com animais e até baladas estão entre as atrações da região. Destacam-se as praias de Guarajuba, Imbassaí, Praia do Forte e Costa do Sauipe.  ", NomeCidade = "Salvador", NomePacote = "RESORTS NA BAHIA - LITORAL NORTE - 5 DIAS / 4 DIÁRIAS", Preco = 1826.00m },
                        new { IdPacote = 3, Ativo = true, DataIda = new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), DataVolta = new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Descricao = " Localizado no estado de Mato Grosso do Sul e ao sul do Pantanal, Bonito possui centenas de cachoeiras, rios e lagos de águas cristalinas, além de cavernas inundadas, paredões rochosos e uma infinidade de peixes. Os aventureiros costumam render-se facilmente a esse destino regado por trilhas ecológicas, passeios de bote e descidas de rapel pelas inúmeras quedas d'água da região.", NomeCidade = "Bonito", NomePacote = "BONITO VIA CAMPO GRANDE - 1 PASSEIO - 5 DIAS / 4 DIÁRIAS", Preco = 1004.00m }
                    );
                });

            modelBuilder.Entity("Senatur.Domains.TiposUsuarios", b =>
                {
                    b.Property<int>("IdTipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("IdTipoUsuario");

                    b.HasIndex("Titulo")
                        .IsUnique();

                    b.ToTable("TiposUsuarios");

                    b.HasData(
                        new { IdTipoUsuario = 1, Titulo = "Administrador" },
                        new { IdTipoUsuario = 2, Titulo = "Cliente" }
                    );
                });

            modelBuilder.Entity("Senatur.Domains.Usuarios", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<int>("IdTipoUsuario");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdTipoUsuario");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new { IdUsuario = 1, Email = "Administrador@adm.com", IdTipoUsuario = 1, Senha = "adm1" },
                        new { IdUsuario = 2, Email = "Cliente@cliente.com", IdTipoUsuario = 2, Senha = "cliente1" }
                    );
                });

            modelBuilder.Entity("Senatur.Domains.Usuarios", b =>
                {
                    b.HasOne("Senatur.Domains.TiposUsuarios", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("IdTipoUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
