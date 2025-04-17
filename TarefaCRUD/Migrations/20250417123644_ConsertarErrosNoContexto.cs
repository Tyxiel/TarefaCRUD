using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TarefaCRUD.Migrations
{
    public partial class ConsertarErrosNoContexto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Tarefa__idPessoa__38996AB5",
                table: "Tarefa");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Tarefa__682C5D37667C7B38",
                table: "Tarefa");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Pessoa__83D303D0AD20D152",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "Prioridade",
                table: "Tarefa",
                newName: "prioridade");

            migrationBuilder.AlterColumn<DateTime>(
                name: "prazo",
                table: "Tarefa",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "Tarefa",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldUnicode: false,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "prioridade",
                table: "Tarefa",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarefa",
                table: "Tarefa",
                column: "idTarefa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa",
                column: "idPessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Pessoa",
                table: "Tarefa",
                column: "idPessoa",
                principalTable: "Pessoa",
                principalColumn: "idPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Pessoa",
                table: "Tarefa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarefa",
                table: "Tarefa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "prioridade",
                table: "Tarefa",
                newName: "Prioridade");

            migrationBuilder.AlterColumn<int>(
                name: "Prioridade",
                table: "Tarefa",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "prazo",
                table: "Tarefa",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "Tarefa",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Tarefa__682C5D37667C7B38",
                table: "Tarefa",
                column: "idTarefa");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Pessoa__83D303D0AD20D152",
                table: "Pessoa",
                column: "idPessoa");

            migrationBuilder.AddForeignKey(
                name: "FK__Tarefa__idPessoa__38996AB5",
                table: "Tarefa",
                column: "idPessoa",
                principalTable: "Pessoa",
                principalColumn: "idPessoa");
        }
    }
}
