using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDEmpreendimentosSC.Migrations
{
    /// <inheritdoc />
    public partial class AddSegmentoEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Segmento",
                table: "EmpreendimentosSC",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Segmento",
                table: "EmpreendimentosSC",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
