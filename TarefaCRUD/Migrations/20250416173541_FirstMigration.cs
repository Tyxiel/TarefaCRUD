using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefaCRUD.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    idPessoa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomePessoa = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pessoa__83D303D0AD20D152", x => x.idPessoa);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    idTarefa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    dataInicio = table.Column<DateTime>(type: "date", nullable: true),
                    prazo = table.Column<DateTime>(type: "datetime", nullable: true),
                    idPessoa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tarefa__682C5D37667C7B38", x => x.idTarefa);
                    table.ForeignKey(
                        name: "FK__Tarefa__idPessoa__38996AB5",
                        column: x => x.idPessoa,
                        principalTable: "Pessoa",
                        principalColumn: "idPessoa");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_idPessoa",
                table: "Tarefa",
                column: "idPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
