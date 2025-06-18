using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class consulta2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Paciente_IdPaciente",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_IdPaciente",
                table: "Consulta");

            migrationBuilder.RenameColumn(
                name: "observaciones",
                table: "Consulta",
                newName: "Texto");

            migrationBuilder.RenameColumn(
                name: "Desde",
                table: "Consulta",
                newName: "start");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "start",
                table: "Consulta",
                newName: "Desde");

            migrationBuilder.RenameColumn(
                name: "Texto",
                table: "Consulta",
                newName: "observaciones");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdPaciente",
                table: "Consulta",
                column: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Paciente_IdPaciente",
                table: "Consulta",
                column: "IdPaciente",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
