using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class diagnosticos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsultaId",
                table: "Diagnostico",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_ConsultaId",
                table: "Diagnostico",
                column: "ConsultaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnostico_Consulta_ConsultaId",
                table: "Diagnostico",
                column: "ConsultaId",
                principalTable: "Consulta",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnostico_Consulta_ConsultaId",
                table: "Diagnostico");

            migrationBuilder.DropIndex(
                name: "IX_Diagnostico_ConsultaId",
                table: "Diagnostico");

            migrationBuilder.DropColumn(
                name: "ConsultaId",
                table: "Diagnostico");
        }
    }
}
