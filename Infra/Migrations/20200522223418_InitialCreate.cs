using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "tb_filme",
                columns: table => new
                {
                    Idfilme = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_filme", x => x.Idfilme);
                });

            migrationBuilder.CreateTable(
                name: "tb_locacao",
                columns: table => new
                {
                    IdLocacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: false),
                    IdFilme = table.Column<int>(nullable: false),
                    DataLocacao = table.Column<DateTime>(nullable: false),
                    DataDevolucao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_locacao", x => x.IdLocacao);
                    table.ForeignKey(
                        name: "FK_tb_locacao_tb_cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "tb_cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_locacao_tb_filme_IdFilme",
                        column: x => x.IdFilme,
                        principalTable: "tb_filme",
                        principalColumn: "Idfilme",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tb_cliente",
                columns: new[] { "IdCliente", "Email", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, "cecilialuziadrumond@oticascarol.com.br", "Cecília Luzia Drumond", "(95)98476-3855" },
                    { 2, "gabriellygabrielalima_@mirafactoring.com.br", "Gabrielly Gabriela Lima", "(95)98697-4886" },
                    { 3, "kaiquemarcos@oticascarol.com.br", "Kaique Marcos Gonçalves", "(95)98242-7258" },
                    { 4, "louisecatarina@oticascarol.com.br", "Louise Catarina", "(95)99757-0501" },
                    { 5, "hugotiagosilva_@oticascarol.com.br", "Hugo Tiago Silva", "(95)98214-0378" }
                });

            migrationBuilder.InsertData(
                table: "tb_filme",
                columns: new[] { "Idfilme", "Nome" },
                values: new object[,]
                {
                    { 1, "A Casa Monstro" },
                    { 2, "Dois Caras Legais" },
                    { 3, "Entrando Numa Fria" },
                    { 4, "O Lobo de Wall Street" },
                    { 5, "O Poderoso Chefão" },
                    { 6, "De Volta Para o Futuro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_locacao_IdCliente",
                table: "tb_locacao",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_tb_locacao_IdFilme",
                table: "tb_locacao",
                column: "IdFilme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_locacao");

            migrationBuilder.DropTable(
                name: "tb_cliente");

            migrationBuilder.DropTable(
                name: "tb_filme");
        }
    }
}
