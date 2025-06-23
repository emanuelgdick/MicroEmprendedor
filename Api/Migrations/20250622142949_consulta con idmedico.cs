using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class consultaconidmedico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMedico",
                table: "Consulta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdMedico",
                table: "Consulta",
                column: "IdMedico");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Medico_IdMedico",
                table: "Consulta",
                column: "IdMedico",
                principalTable: "Medico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Medico_IdMedico",
                table: "Consulta");

            migrationBuilder.DropIndex(
                name: "IX_Consulta_IdMedico",
                table: "Consulta");

            migrationBuilder.DropColumn(
                name: "IdMedico",
                table: "Consulta");
        }
    }
}
