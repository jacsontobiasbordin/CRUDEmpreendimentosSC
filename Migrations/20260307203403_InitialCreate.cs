using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDEmpreendimentosSC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpreendimentosSC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeEmpreendimento = table.Column<string>(type: "TEXT", nullable: false),
                    NomeEmpreendedor = table.Column<string>(type: "TEXT", nullable: false),
                    Municipio = table.Column<string>(type: "TEXT", nullable: false),
                    Segmento = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Observacao = table.Column<string>(type: "TEXT", nullable: false),
                    PorteEmpresa = table.Column<string>(type: "TEXT", nullable: false),
                    Website = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpreendimentosSC", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpreendimentosSC");
        }
    }
}
