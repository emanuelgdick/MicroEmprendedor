using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class qwerty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApeyNom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TieneAgenda = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mutual",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mutual", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescC = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApeyNom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoDocumento = table.Column<int>(type: "int", nullable: true),
                    IdProfesion = table.Column<int>(type: "int", nullable: true),
                    IdLocalidad = table.Column<int>(type: "int", nullable: true),
                    IdMedico = table.Column<int>(type: "int", nullable: true),
                    IdMutual = table.Column<int>(type: "int", nullable: true),
                    ApeyNom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Piso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Depto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelFijo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelCelular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fnac = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NroHC = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codAflp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Historia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paciente_Localidad_IdLocalidad",
                        column: x => x.IdLocalidad,
                        principalTable: "Localidad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Paciente_Medico_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medico",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Paciente_Mutual_IdMutual",
                        column: x => x.IdMutual,
                        principalTable: "Mutual",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Paciente_Profesion_IdProfesion",
                        column: x => x.IdProfesion,
                        principalTable: "Profesion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Paciente_TipoDocumento_IdTipoDocumento",
                        column: x => x.IdTipoDocumento,
                        principalTable: "TipoDocumento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    start = table.Column<DateTime>(type: "datetime2", nullable: true),
                    end = table.Column<DateTime>(type: "datetime2", nullable: true),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consulta_Medico_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnostico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnostico_Consulta_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consulta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConsultaDiagnostico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdConsulta = table.Column<int>(type: "int", nullable: true),
                    IdDiagnostico = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaDiagnostico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultaDiagnostico_Consulta_IdConsulta",
                        column: x => x.IdConsulta,
                        principalTable: "Consulta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConsultaDiagnostico_Diagnostico_IdDiagnostico",
                        column: x => x.IdDiagnostico,
                        principalTable: "Diagnostico",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdMedico",
                table: "Consulta",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdPaciente",
                table: "Consulta",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaDiagnostico_IdConsulta",
                table: "ConsultaDiagnostico",
                column: "IdConsulta");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaDiagnostico_IdDiagnostico",
                table: "ConsultaDiagnostico",
                column: "IdDiagnostico");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_ConsultaId",
                table: "Diagnostico",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdLocalidad",
                table: "Paciente",
                column: "IdLocalidad");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdMedico",
                table: "Paciente",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdMutual",
                table: "Paciente",
                column: "IdMutual");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdProfesion",
                table: "Paciente",
                column: "IdProfesion");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdTipoDocumento",
                table: "Paciente",
                column: "IdTipoDocumento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultaDiagnostico");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Diagnostico");

            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Localidad");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Mutual");

            migrationBuilder.DropTable(
                name: "Profesion");

            migrationBuilder.DropTable(
                name: "TipoDocumento");
        }
    }
}
