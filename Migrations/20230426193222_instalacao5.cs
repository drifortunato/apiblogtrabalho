using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiblognoticia.Migrations
{
    /// <inheritdoc />
    public partial class instalacao5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Noticias");

            migrationBuilder.AddColumn<string>(
                name: "Subtitulo",
                table: "Noticias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtitulo",
                table: "Noticias");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Noticias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
