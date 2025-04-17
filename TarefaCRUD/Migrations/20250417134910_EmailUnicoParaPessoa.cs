using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefaCRUD.Migrations
{
    public partial class EmailUnicoParaPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_email",
                table: "Pessoa",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pessoa_email",
                table: "Pessoa");
        }
    }
}
