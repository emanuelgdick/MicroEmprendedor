using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class Primer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Localidad_LocalidadId",
                table: "Paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Profesion_ProfesionId",
                table: "Paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_TipoDocumento_TipoDocumentoId",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_LocalidadId",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_ProfesionId",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_TipoDocumentoId",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "LocalidadId",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "ProfesionId",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "TipoDocumentoId",
                table: "Paciente");

            migrationBuilder.AlterColumn<int>(
                name: "IdTipoDocumento",
                table: "Paciente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdProfesion",
                table: "Paciente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdLocalidad",
                table: "Paciente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdLocalidad",
                table: "Paciente",
                column: "IdLocalidad");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdProfesion",
                table: "Paciente",
                column: "IdProfesion");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdTipoDocumento",
                table: "Paciente",
                column: "IdTipoDocumento");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Localidad_IdLocalidad",
                table: "Paciente",
                column: "IdLocalidad",
                principalTable: "Localidad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Profesion_IdProfesion",
                table: "Paciente",
                column: "IdProfesion",
                principalTable: "Profesion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_TipoDocumento_IdTipoDocumento",
                table: "Paciente",
                column: "IdTipoDocumento",
                principalTable: "TipoDocumento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Localidad_IdLocalidad",
                table: "Paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_Profesion_IdProfesion",
                table: "Paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_TipoDocumento_IdTipoDocumento",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_IdLocalidad",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_IdProfesion",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_IdTipoDocumento",
                table: "Paciente");

            migrationBuilder.AlterColumn<int>(
                name: "IdTipoDocumento",
                table: "Paciente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdProfesion",
                table: "Paciente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdLocalidad",
                table: "Paciente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalidadId",
                table: "Paciente",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfesionId",
                table: "Paciente",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDocumentoId",
                table: "Paciente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_LocalidadId",
                table: "Paciente",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_ProfesionId",
                table: "Paciente",
                column: "ProfesionId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_TipoDocumentoId",
                table: "Paciente",
                column: "TipoDocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Localidad_LocalidadId",
                table: "Paciente",
                column: "LocalidadId",
                principalTable: "Localidad",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_Profesion_ProfesionId",
                table: "Paciente",
                column: "ProfesionId",
                principalTable: "Profesion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_TipoDocumento_TipoDocumentoId",
                table: "Paciente",
                column: "TipoDocumentoId",
                principalTable: "TipoDocumento",
                principalColumn: "Id");
        }
    }
}
