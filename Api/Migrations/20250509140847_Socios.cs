using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class Socios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidad_Provincia_Idprovincia",
                table: "Localidad");

            migrationBuilder.RenameColumn(
                name: "Idprovincia",
                table: "Localidad",
                newName: "IdProvincia");

            migrationBuilder.RenameIndex(
                name: "IX_Localidad_Idprovincia",
                table: "Localidad",
                newName: "IX_Localidad_IdProvincia");

            migrationBuilder.CreateTable(
                name: "Socio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroSocio = table.Column<int>(type: "int", nullable: false),
                    ApeyNom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Depto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fnac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FEgreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vitalicio = table.Column<bool>(type: "bit", nullable: false),
                    PagaAca = table.Column<bool>(type: "bit", nullable: false),
                    IdTipoSocio = table.Column<int>(type: "int", nullable: false),
                    IdEstadoSocio = table.Column<int>(type: "int", nullable: false),
                    IdCategoriaSocio = table.Column<int>(type: "int", nullable: false),
                    IdTipoDocumento = table.Column<int>(type: "int", nullable: false),
                    IdCalle = table.Column<int>(type: "int", nullable: false),
                    IdProfesion = table.Column<int>(type: "int", nullable: false),
                    IdLocalidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Socio_Calle_IdCalle",
                        column: x => x.IdCalle,
                        principalTable: "Calle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Socio_CategoriaSocio_IdCategoriaSocio",
                        column: x => x.IdCategoriaSocio,
                        principalTable: "CategoriaSocio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Socio_EstadoSocio_IdEstadoSocio",
                        column: x => x.IdEstadoSocio,
                        principalTable: "EstadoSocio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Socio_Localidad_IdLocalidad",
                        column: x => x.IdLocalidad,
                        principalTable: "Localidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Socio_Profesion_IdProfesion",
                        column: x => x.IdProfesion,
                        principalTable: "Profesion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Socio_TipoDocumento_IdTipoDocumento",
                        column: x => x.IdTipoDocumento,
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Socio_TipoSocio_IdTipoSocio",
                        column: x => x.IdTipoSocio,
                        principalTable: "TipoSocio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Socio_IdCalle",
                table: "Socio",
                column: "IdCalle");

            migrationBuilder.CreateIndex(
                name: "IX_Socio_IdCategoriaSocio",
                table: "Socio",
                column: "IdCategoriaSocio");

            migrationBuilder.CreateIndex(
                name: "IX_Socio_IdEstadoSocio",
                table: "Socio",
                column: "IdEstadoSocio");

            migrationBuilder.CreateIndex(
                name: "IX_Socio_IdLocalidad",
                table: "Socio",
                column: "IdLocalidad");

            migrationBuilder.CreateIndex(
                name: "IX_Socio_IdProfesion",
                table: "Socio",
                column: "IdProfesion");

            migrationBuilder.CreateIndex(
                name: "IX_Socio_IdTipoDocumento",
                table: "Socio",
                column: "IdTipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_Socio_IdTipoSocio",
                table: "Socio",
                column: "IdTipoSocio");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidad_Provincia_IdProvincia",
                table: "Localidad",
                column: "IdProvincia",
                principalTable: "Provincia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidad_Provincia_IdProvincia",
                table: "Localidad");

            migrationBuilder.DropTable(
                name: "Socio");

            migrationBuilder.RenameColumn(
                name: "IdProvincia",
                table: "Localidad",
                newName: "Idprovincia");

            migrationBuilder.RenameIndex(
                name: "IX_Localidad_IdProvincia",
                table: "Localidad",
                newName: "IX_Localidad_Idprovincia");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidad_Provincia_Idprovincia",
                table: "Localidad",
                column: "Idprovincia",
                principalTable: "Provincia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
