using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class MutualenPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMutual",
                table: "Paciente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdMutual",
                table: "Paciente",
                column: "IdMutual");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Mutual_IdMutual",
                table: "Paciente",
                column: "IdMutual",
                principalTable: "Mutual",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Mutual_IdMutual",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_IdMutual",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "IdMutual",
                table: "Paciente");
        }
    }
}
