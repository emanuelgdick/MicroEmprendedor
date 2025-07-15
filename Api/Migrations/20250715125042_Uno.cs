using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class Uno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MicroEmprendedor_Rubro_RubroId",
                table: "MicroEmprendedor");

            migrationBuilder.DropIndex(
                name: "IX_MicroEmprendedor_RubroId",
                table: "MicroEmprendedor");

            migrationBuilder.DropColumn(
                name: "RubroId",
                table: "MicroEmprendedor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RubroId",
                table: "MicroEmprendedor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MicroEmprendedor_RubroId",
                table: "MicroEmprendedor",
                column: "RubroId");

            migrationBuilder.AddForeignKey(
                name: "FK_MicroEmprendedor_Rubro_RubroId",
                table: "MicroEmprendedor",
                column: "RubroId",
                principalTable: "Rubro",
                principalColumn: "Id");
        }
    }
}
