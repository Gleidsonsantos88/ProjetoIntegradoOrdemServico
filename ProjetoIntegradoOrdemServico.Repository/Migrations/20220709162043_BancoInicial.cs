using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoIntegradoOrdemServico.Repository.Migrations
{
    public partial class BancoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdemServicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TecnicoId = table.Column<Guid>(nullable: false),
                    UsuarioCriacaoId = table.Column<Guid>(nullable: false),
                    DataInicioServico = table.Column<DateTime>(nullable: false),
                    NomeTecnico = table.Column<string>(nullable: false),
                    NomeCliente = table.Column<string>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 500, nullable: true),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataVigencia = table.Column<DateTime>(nullable: true),
                    ValorTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    OrdemServicoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_OrdemServicos_OrdemServicoId",
                        column: x => x.OrdemServicoId,
                        principalTable: "OrdemServicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemOrdemServicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ServicoId = table.Column<Guid>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    OrdemServicoId = table.Column<Guid>(nullable: false),
                    DescricaoServico = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOrdemServicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemOrdemServicos_OrdemServicos_OrdemServicoId",
                        column: x => x.OrdemServicoId,
                        principalTable: "OrdemServicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdemServicoSituacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioCriacaoId = table.Column<Guid>(nullable: false),
                    OrdemServicoId = table.Column<Guid>(nullable: false),
                    OrdemServicoStatus = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServicoSituacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemServicoSituacoes_OrdemServicos_OrdemServicoId",
                        column: x => x.OrdemServicoId,
                        principalTable: "OrdemServicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_OrdemServicoId",
                table: "Endereco",
                column: "OrdemServicoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemOrdemServicos_OrdemServicoId",
                table: "ItemOrdemServicos",
                column: "OrdemServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServicoSituacoes_OrdemServicoId",
                table: "OrdemServicoSituacoes",
                column: "OrdemServicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "ItemOrdemServicos");

            migrationBuilder.DropTable(
                name: "OrdemServicoSituacoes");

            migrationBuilder.DropTable(
                name: "OrdemServicos");
        }
    }
}
