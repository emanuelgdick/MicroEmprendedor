using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class end : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Texto",
                table: "Consulta",
                newName: "texto");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "Consulta",
                newName: "end");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Consulta",
                newName: "color");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "texto",
                table: "Consulta",
                newName: "Texto");

            migrationBuilder.RenameColumn(
                name: "end",
                table: "Consulta",
                newName: "End");

            migrationBuilder.RenameColumn(
                name: "color",
                table: "Consulta",
                newName: "Color");
        }
    }
}
