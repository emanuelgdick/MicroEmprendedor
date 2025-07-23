using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class qwerty2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MicroEmprendedorRubro_MicroEmprendedor_IdMicroEmprendedor",
                table: "MicroEmprendedorRubro");

            migrationBuilder.DropForeignKey(
                name: "FK_MicroEmprendedorRubro_Rubro_IdRubro",
                table: "MicroEmprendedorRubro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MicroEmprendedorRubro",
                table: "MicroEmprendedorRubro");

            migrationBuilder.DropIndex(
                name: "IX_MicroEmprendedorRubro_IdMicroEmprendedor",
                table: "MicroEmprendedorRubro");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MicroEmprendedorRubro");

            migrationBuilder.RenameColumn(
                name: "IdRubro",
                table: "MicroEmprendedorRubro",
                newName: "RubrosId");

            migrationBuilder.RenameColumn(
                name: "IdMicroEmprendedor",
                table: "MicroEmprendedorRubro",
                newName: "MicroEmprendedoresId");

            migrationBuilder.RenameIndex(
                name: "IX_MicroEmprendedorRubro_IdRubro",
                table: "MicroEmprendedorRubro",
                newName: "IX_MicroEmprendedorRubro_RubrosId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MicroEmprendedorRubro",
                table: "MicroEmprendedorRubro",
                columns: new[] { "MicroEmprendedoresId", "RubrosId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MicroEmprendedorRubro_MicroEmprendedor_MicroEmprendedoresId",
                table: "MicroEmprendedorRubro",
                column: "MicroEmprendedoresId",
                principalTable: "MicroEmprendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MicroEmprendedorRubro_Rubro_RubrosId",
                table: "MicroEmprendedorRubro",
                column: "RubrosId",
                principalTable: "Rubro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MicroEmprendedorRubro_MicroEmprendedor_MicroEmprendedoresId",
                table: "MicroEmprendedorRubro");

            migrationBuilder.DropForeignKey(
                name: "FK_MicroEmprendedorRubro_Rubro_RubrosId",
                table: "MicroEmprendedorRubro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MicroEmprendedorRubro",
                table: "MicroEmprendedorRubro");

            migrationBuilder.RenameColumn(
                name: "RubrosId",
                table: "MicroEmprendedorRubro",
                newName: "IdRubro");

            migrationBuilder.RenameColumn(
                name: "MicroEmprendedoresId",
                table: "MicroEmprendedorRubro",
                newName: "IdMicroEmprendedor");

            migrationBuilder.RenameIndex(
                name: "IX_MicroEmprendedorRubro_RubrosId",
                table: "MicroEmprendedorRubro",
                newName: "IX_MicroEmprendedorRubro_IdRubro");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MicroEmprendedorRubro",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MicroEmprendedorRubro",
                table: "MicroEmprendedorRubro",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MicroEmprendedorRubro_IdMicroEmprendedor",
                table: "MicroEmprendedorRubro",
                column: "IdMicroEmprendedor");

            migrationBuilder.AddForeignKey(
                name: "FK_MicroEmprendedorRubro_MicroEmprendedor_IdMicroEmprendedor",
                table: "MicroEmprendedorRubro",
                column: "IdMicroEmprendedor",
                principalTable: "MicroEmprendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MicroEmprendedorRubro_Rubro_IdRubro",
                table: "MicroEmprendedorRubro",
                column: "IdRubro",
                principalTable: "Rubro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
