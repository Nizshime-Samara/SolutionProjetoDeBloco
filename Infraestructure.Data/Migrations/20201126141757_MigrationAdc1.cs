using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Data.Migrations
{
    public partial class MigrationAdc1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Jogadores_jogadorId",
                table: "Jogos");

            migrationBuilder.RenameColumn(
                name: "jogadorId",
                table: "Jogos",
                newName: "JogadorId");

            migrationBuilder.RenameIndex(
                name: "IX_Jogos_jogadorId",
                table: "Jogos",
                newName: "IX_Jogos_JogadorId");

            migrationBuilder.AlterColumn<int>(
                name: "JogadorId",
                table: "Jogos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Jogadores_JogadorId",
                table: "Jogos",
                column: "JogadorId",
                principalTable: "Jogadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Jogadores_JogadorId",
                table: "Jogos");

            migrationBuilder.RenameColumn(
                name: "JogadorId",
                table: "Jogos",
                newName: "jogadorId");

            migrationBuilder.RenameIndex(
                name: "IX_Jogos_JogadorId",
                table: "Jogos",
                newName: "IX_Jogos_jogadorId");

            migrationBuilder.AlterColumn<int>(
                name: "jogadorId",
                table: "Jogos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Jogadores_jogadorId",
                table: "Jogos",
                column: "jogadorId",
                principalTable: "Jogadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
