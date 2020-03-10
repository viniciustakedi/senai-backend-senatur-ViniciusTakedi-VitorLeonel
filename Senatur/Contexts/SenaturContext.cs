using System;
using Microsoft.EntityFrameworkCore;
using Senatur.Domains;

namespace Senatur.Context
{
    public class SenaturContext : DbContext
    {
        public DbSet<Pacotes> Pacotes { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<TiposUsuarios> TiposUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Server=DEV1001\\SQLEXPRESS; Database=Senaitur.Tarde; Integrated Security=True;");
            optionsBuilder.UseSqlServer("Server=DEV14\\SQLEXPRESS; Database=Senatur_Tarde; user Id=sa; pwd=sa@132;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposUsuarios>(entity =>
            {
                entity
                .HasIndex(tu => tu.Titulo)
                .IsUnique();

                entity.HasData(
                new TiposUsuarios
                {
                    IdTipoUsuario = 1,
                    Titulo = "Administrador"
                },
                new TiposUsuarios
                {
                    IdTipoUsuario = 2,
                    Titulo = "Cliente"
                });
            });

            modelBuilder.Entity<Usuarios>().HasData(
            new Usuarios
            {
                IdUsuario = 1,
                Email = "Administrador@adm.com",
                Senha = "adm1",
                IdTipoUsuario = 1
            },
            new Usuarios
            {
                IdUsuario = 2,
                Email = "Cliente@cliente.com",
                Senha = "cliente1",
                IdTipoUsuario = 2

            });

            modelBuilder.Entity<Pacotes>().HasData(
                new Pacotes
                {
                    IdPacote = 1,
                    NomePacote = "SALVADOR - 5 DIAS / 4 DIÁRIAS",
                    Descricao = " O que não falta em Salvador são atrações. Prova disso são as praias, os museus e as construções seculares que dão um charme mais que especial à região. A cidade, sinônimo de alegria, também é conhecida pela efervescência cultural que a credenciou como um dos destinos mais procurados por turistas brasileiros e estrangeiros. O Pelourinho e o Elevador são alguns dos principais pontos de visitação. ",
                    DataIda = Convert.ToDateTime("06/08/2020"),
                    DataVolta = Convert.ToDateTime("10/08/2020"),
                    Preco = Convert.ToDecimal("854,00"),
                    Ativo = Convert.ToBoolean(1),
                    NomeCidade = "Salvador"
                },
                new Pacotes
                {
                    IdPacote = 2,
                    NomePacote = "RESORTS NA BAHIA - LITORAL NORTE - 5 DIAS / 4 DIÁRIAS",
                    Descricao = " O Litoral Norte da Bahia conta com inúmeras praias emolduradas por coqueiros, além de piscinas naturais de águas mornas que são protegidas por recifes e habitadas por peixes coloridos. Banhos de mar em águas calmas ou agitadas, mergulho com snorkel, caminhada pela orla e calçadões, passeios de bicicleta, pontos turísticos históricos, interação com animais e até baladas estão entre as atrações da região. Destacam-se as praias de Guarajuba, Imbassaí, Praia do Forte e Costa do Sauipe.  ",
                    DataIda = Convert.ToDateTime("14/05/2020"),
                    DataVolta = Convert.ToDateTime("18/05/2020"),
                    Preco = Convert.ToDecimal("1826,00"),
                    Ativo = Convert.ToBoolean(1),
                    NomeCidade = "Salvador"
                },
                new Pacotes
                {
                    IdPacote = 3,
                    NomePacote = "BONITO VIA CAMPO GRANDE - 1 PASSEIO - 5 DIAS / 4 DIÁRIAS",
                    Descricao = " Localizado no estado de Mato Grosso do Sul e ao sul do Pantanal, Bonito possui centenas de cachoeiras, rios e lagos de águas cristalinas, além de cavernas inundadas, paredões rochosos e uma infinidade de peixes. Os aventureiros costumam render-se facilmente a esse destino regado por trilhas ecológicas, passeios de bote e descidas de rapel pelas inúmeras quedas d'água da região.",
                    DataIda = Convert.ToDateTime("28/03/2020"),
                    DataVolta = Convert.ToDateTime("01/04/2020"),
                    Preco = Convert.ToDecimal("1004,00"),
                    Ativo = Convert.ToBoolean(1),
                    NomeCidade = "Bonito"
                });
        }
    }
}