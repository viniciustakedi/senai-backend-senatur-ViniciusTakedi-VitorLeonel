using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Senatur.Migrations
{
    public partial class SenaturMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacotes",
                columns: table => new
                {
                    IdPacote = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomePacote = table.Column<string>(type: "VARCHAR (255)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR (500)", nullable: false),
                    DataIda = table.Column<DateTime>(type: "DATE", nullable: false),
                    DataVolta = table.Column<DateTime>(type: "DATE", nullable: false),
                    Preco = table.Column<decimal>(type: "DECIMAL (18,2)", nullable: false),
                    Ativo = table.Column<bool>(type: "BIT", nullable: false),
                    NomeCidade = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacotes", x => x.IdPacote);
                });

            migrationBuilder.CreateTable(
                name: "TiposUsuarios",
                columns: table => new
                {
                    IdTipoUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuarios", x => x.IdTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    IdTipoUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_TiposUsuarios_IdTipoUsuario",
                        column: x => x.IdTipoUsuario,
                        principalTable: "TiposUsuarios",
                        principalColumn: "IdTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pacotes",
                columns: new[] { "IdPacote", "Ativo", "DataIda", "DataVolta", "Descricao", "NomeCidade", "NomePacote", "Preco" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), " O que não falta em Salvador são atrações. Prova disso são as praias, os museus e as construções seculares que dão um charme mais que especial à região. A cidade, sinônimo de alegria, também é conhecida pela efervescência cultural que a credenciou como um dos destinos mais procurados por turistas brasileiros e estrangeiros. O Pelourinho e o Elevador são alguns dos principais pontos de visitação. ", "Salvador", "SALVADOR - 5 DIAS / 4 DIÁRIAS", 854.00m },
                    { 2, true, new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), " O Litoral Norte da Bahia conta com inúmeras praias emolduradas por coqueiros, além de piscinas naturais de águas mornas que são protegidas por recifes e habitadas por peixes coloridos. Banhos de mar em águas calmas ou agitadas, mergulho com snorkel, caminhada pela orla e calçadões, passeios de bicicleta, pontos turísticos históricos, interação com animais e até baladas estão entre as atrações da região. Destacam-se as praias de Guarajuba, Imbassaí, Praia do Forte e Costa do Sauipe.  ", "Salvador", "RESORTS NA BAHIA - LITORAL NORTE - 5 DIAS / 4 DIÁRIAS", 1826.00m },
                    { 3, true, new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " Localizado no estado de Mato Grosso do Sul e ao sul do Pantanal, Bonito possui centenas de cachoeiras, rios e lagos de águas cristalinas, além de cavernas inundadas, paredões rochosos e uma infinidade de peixes. Os aventureiros costumam render-se facilmente a esse destino regado por trilhas ecológicas, passeios de bote e descidas de rapel pelas inúmeras quedas d'água da região.", "Bonito", "BONITO VIA CAMPO GRANDE - 1 PASSEIO - 5 DIAS / 4 DIÁRIAS", 1004.00m }
                });

            migrationBuilder.InsertData(
                table: "TiposUsuarios",
                columns: new[] { "IdTipoUsuario", "Titulo" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Email", "IdTipoUsuario", "Senha" },
                values: new object[] { 1, "Administrador@adm.com", 1, "adm1" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Email", "IdTipoUsuario", "Senha" },
                values: new object[] { 2, "Cliente@cliente.com", 2, "cliente1" });

            migrationBuilder.CreateIndex(
                name: "IX_TiposUsuarios_Titulo",
                table: "TiposUsuarios",
                column: "Titulo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdTipoUsuario",
                table: "Usuarios",
                column: "IdTipoUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacotes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TiposUsuarios");
        }
    }
}
