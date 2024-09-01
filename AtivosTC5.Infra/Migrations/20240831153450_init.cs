using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AtivosTC5.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATIVOTIPO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "varchar(100)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATIVOTIPO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NOME = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ATIVO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtivoTipo_Id = table.Column<int>(type: "int", nullable: false),
                    SIGLA = table.Column<string>(type: "varchar(10)", nullable: false),
                    NOME = table.Column<string>(type: "varchar(100)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATIVO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ATIVO_ATIVOTIPO_AtivoTipo_Id",
                        column: x => x.AtivoTipo_Id,
                        principalTable: "ATIVOTIPO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PORTFOLIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_Id = table.Column<int>(type: "int", nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(200)", nullable: true),
                    NOME = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PORTFOLIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PORTFOLIO_USUARIO_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PORTFOLIOATIVO",
                columns: table => new
                {
                    Portfolio_Id = table.Column<int>(type: "int", nullable: false),
                    Ativo_Id = table.Column<int>(type: "int", nullable: false),
                    QUANTIDADE = table.Column<decimal>(type: "decimal(20,3)", nullable: false),
                    PRECO = table.Column<decimal>(type: "decimal(10,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PORTFOLIOATIVO", x => new { x.Portfolio_Id, x.Ativo_Id });
                    table.ForeignKey(
                        name: "FK_PORTFOLIOATIVO_ATIVO_Ativo_Id",
                        column: x => x.Ativo_Id,
                        principalTable: "ATIVO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PORTFOLIOATIVO_PORTFOLIO_Portfolio_Id",
                        column: x => x.Portfolio_Id,
                        principalTable: "PORTFOLIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TRANSACAO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Portifolio_Id = table.Column<int>(type: "int", nullable: false),
                    Ativo_Id = table.Column<int>(type: "int", nullable: false),
                    TIPOTRANSACAO = table.Column<string>(type: "varchar(20)", nullable: false),
                    QUANTIDADE = table.Column<decimal>(type: "decimal(20,3)", nullable: false),
                    PRECO = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    DATATRANSACAO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRANSACAO_ATIVO_Ativo_Id",
                        column: x => x.Ativo_Id,
                        principalTable: "ATIVO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TRANSACAO_PORTFOLIO_Portifolio_Id",
                        column: x => x.Portifolio_Id,
                        principalTable: "PORTFOLIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ATIVOTIPO",
                columns: new[] { "Id", "NOME" },
                values: new object[,]
                {
                    { 1, "Ação" },
                    { 2, "Cripto Moeda" },
                    { 3, "Dinheiro" },
                    { 4, "Titulo" }
                });

            migrationBuilder.InsertData(
                table: "USUARIO",
                columns: new[] { "Id", "email", "NOME", "Senha" },
                values: new object[] { 1, "UserTeste@Teste.com", "UserTeste", "e501a9799a067184b96633716287a92626ef9c4c" });

            migrationBuilder.InsertData(
                table: "ATIVO",
                columns: new[] { "Id", "AtivoTipo_Id", "NOME", "SIGLA" },
                values: new object[,]
                {
                    { 1, 3, "Real", "BRL" },
                    { 2, 3, "Dólar Americano", "USD" },
                    { 3, 3, "Dólar Canadense", "CAD" },
                    { 4, 3, "Libra Esterlina", "GBP" },
                    { 5, 3, "Euro", "EUR" },
                    { 6, 3, "Iene Japonês", "JPY" },
                    { 7, 3, "Franco Suíço", "CHF" },
                    { 8, 2, "Bitcoin", "BTC" },
                    { 9, 2, "Ethereum", "ETH" },
                    { 10, 2, "Litecoin", "LTC" },
                    { 11, 2, "Ripple", "XRP" },
                    { 12, 2, "Cardano", "ADA" },
                    { 13, 2, "Binance Coin", "BNB" },
                    { 14, 2, "DogeCoin", "DOGE" },
                    { 15, 2, "Shiba Inu", "SHIB" },
                    { 16, 1, "ALLIANÇA SAÚDE E PARTICIPAÇÕES S.A.", "AALR3" },
                    { 17, 1, "AMBEV S.A.", "ABEV3" },
                    { 18, 1, "CAMIL ALIMENTOS S.A.", "CAML3" },
                    { 19, 1, "ITAUSA S.A.", "ITSA3" },
                    { 20, 1, "PETROLEO BRASILEIRO S.A. PETROBRAS", "PETW3" },
                    { 21, 1, "PETROLEO BRASILEIRO S.A. PETROBRAS", "PETW4" },
                    { 22, 4, "NTN-B - 02/2030 - BRSTNCNTB4J9", "NTN-B" },
                    { 23, 4, "NBCE - 05/2003 - BRBCBRNBC592", "NBCE" },
                    { 24, 4, "LFT-B - 09/2004 - BRSTNCLF1KR7", "LFT-b" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATIVO_AtivoTipo_Id",
                table: "ATIVO",
                column: "AtivoTipo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PORTFOLIO_Usuario_Id",
                table: "PORTFOLIO",
                column: "Usuario_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PORTFOLIOATIVO_Ativo_Id",
                table: "PORTFOLIOATIVO",
                column: "Ativo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACAO_Ativo_Id",
                table: "TRANSACAO",
                column: "Ativo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACAO_Portifolio_Id",
                table: "TRANSACAO",
                column: "Portifolio_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PORTFOLIOATIVO");

            migrationBuilder.DropTable(
                name: "TRANSACAO");

            migrationBuilder.DropTable(
                name: "ATIVO");

            migrationBuilder.DropTable(
                name: "PORTFOLIO");

            migrationBuilder.DropTable(
                name: "ATIVOTIPO");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
