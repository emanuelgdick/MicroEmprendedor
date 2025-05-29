using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class sinnroinventario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anexo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anexo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApeyNom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaSocio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantMaterial = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaSocio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cobrador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApeyNom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobrador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coleccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coleccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApeyNom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApeyNom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editorial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Encuadernacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encuadernacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoSocio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoSocio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guionista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApeyNom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guionista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Idioma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idioma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ilustrador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApeyNom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilustrador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interprete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApeyNom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interprete", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lugar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lugar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procedencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApeyNom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productor", x => x.Id);
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
                name: "Prologuista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApeyNom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prologuista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sector",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie", x => x.Id);
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
                name: "TipoMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMaterial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantDias = table.Column<int>(type: "int", nullable: false),
                    NroMov = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoSocio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSocio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoSoporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSoporte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoSuspension",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSuspension", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Traductor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApeyNom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traductor", x => x.Id);
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
                name: "Provincia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provincia_Pais_IdPais",
                        column: x => x.IdPais,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdIdioma = table.Column<int>(type: "int", nullable: true),
                    IdProcedencia = table.Column<int>(type: "int", nullable: true),
                    IdSerie = table.Column<int>(type: "int", nullable: true),
                    IdEditorial = table.Column<int>(type: "int", nullable: true),
                    IdSector = table.Column<int>(type: "int", nullable: true),
                    IdTipoMaterial = table.Column<int>(type: "int", nullable: true),
                    IdEncuadernacion = table.Column<int>(type: "int", nullable: true),
                    IdColeccion = table.Column<int>(type: "int", nullable: true),
                    IdTraductor = table.Column<int>(type: "int", nullable: true),
                    IdProloguista = table.Column<int>(type: "int", nullable: true),
                    IdEditor = table.Column<int>(type: "int", nullable: true),
                    IdIlustrador = table.Column<int>(type: "int", nullable: true),
                    IdLugar = table.Column<int>(type: "int", nullable: true),
                    NroInventario = table.Column<int>(type: "int", nullable: false),
                    NroTomo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CantPaginas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCompra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EanIsbn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Volumen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NroColeccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NroEdicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnoEdicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Libristica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieneIlustracion = table.Column<bool>(type: "bit", nullable: true),
                    NroEjemplar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_Coleccion_IdColeccion",
                        column: x => x.IdColeccion,
                        principalTable: "Coleccion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Material_Editor_IdEditor",
                        column: x => x.IdEditor,
                        principalTable: "Editor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Material_Editorial_IdEditorial",
                        column: x => x.IdEditorial,
                        principalTable: "Editorial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Material_Encuadernacion_IdEncuadernacion",
                        column: x => x.IdEncuadernacion,
                        principalTable: "Encuadernacion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Material_Idioma_IdIdioma",
                        column: x => x.IdIdioma,
                        principalTable: "Idioma",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Material_Ilustrador_IdIlustrador",
                        column: x => x.IdIlustrador,
                        principalTable: "Ilustrador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Material_Lugar_IdLugar",
                        column: x => x.IdLugar,
                        principalTable: "Lugar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Material_Procedencia_IdProcedencia",
                        column: x => x.IdProcedencia,
                        principalTable: "Procedencia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Material_Prologuista_IdProloguista",
                        column: x => x.IdProloguista,
                        principalTable: "Prologuista",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Material_Sector_IdSector",
                        column: x => x.IdSector,
                        principalTable: "Sector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Material_Serie_IdSerie",
                        column: x => x.IdSerie,
                        principalTable: "Serie",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Material_TipoMaterial_IdTipoMaterial",
                        column: x => x.IdTipoMaterial,
                        principalTable: "TipoMaterial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Material_Traductor_IdTraductor",
                        column: x => x.IdTraductor,
                        principalTable: "Traductor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Localidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProvincia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localidad_Provincia_IdProvincia",
                        column: x => x.IdProvincia,
                        principalTable: "Provincia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Socio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoSocio = table.Column<int>(type: "int", nullable: false),
                    IdEstadoSocio = table.Column<int>(type: "int", nullable: false),
                    IdCategoriaSocio = table.Column<int>(type: "int", nullable: false),
                    IdTipoDocumento = table.Column<int>(type: "int", nullable: false),
                    IdCalle = table.Column<int>(type: "int", nullable: false),
                    IdProfesion = table.Column<int>(type: "int", nullable: true),
                    IdLocalidad = table.Column<int>(type: "int", nullable: false),
                    NroSocio = table.Column<int>(type: "int", nullable: false),
                    ApeyNom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Piso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Depto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelFijo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelCelular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fnac = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FIngreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FEgreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vitalicio = table.Column<bool>(type: "bit", nullable: false),
                    PagaAca = table.Column<bool>(type: "bit", nullable: false),
                    Sexo = table.Column<bool>(type: "bit", nullable: true)
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
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "MaterialMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoMovimiento = table.Column<int>(type: "int", nullable: false),
                    IdSector = table.Column<int>(type: "int", nullable: true),
                    IdSocio = table.Column<int>(type: "int", nullable: false),
                    IdMaterial = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NroMovimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialMovimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialMovimiento_Material_IdMaterial",
                        column: x => x.IdMaterial,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialMovimiento_Sector_IdSector",
                        column: x => x.IdSector,
                        principalTable: "Sector",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaterialMovimiento_Socio_IdSocio",
                        column: x => x.IdSocio,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialMovimiento_TipoMovimiento_IdTipoMovimiento",
                        column: x => x.IdTipoMovimiento,
                        principalTable: "TipoMovimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialMovimiento_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Localidad_IdProvincia",
                table: "Localidad",
                column: "IdProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_Material_IdColeccion",
                table: "Material",
                column: "IdColeccion");

            migrationBuilder.CreateIndex(
                name: "IX_Material_IdEditor",
                table: "Material",
                column: "IdEditor");

            migrationBuilder.CreateIndex(
                name: "IX_Material_IdEditorial",
                table: "Material",
                column: "IdEditorial");

            migrationBuilder.CreateIndex(
                name: "IX_Material_IdEncuadernacion",
                table: "Material",
                column: "IdEncuadernacion");

            migrationBuilder.CreateIndex(
                name: "IX_Material_IdIdioma",
                table: "Material",
                column: "IdIdioma");

            migrationBuilder.CreateIndex(
                name: "IX_Material_IdIlustrador",
                table: "Material",
                column: "IdIlustrador");

            migrationBuilder.CreateIndex(
                name: "IX_Material_IdLugar",
                table: "Material",
                column: "IdLugar");

            migrationBuilder.CreateIndex(
                name: "IX_Material_IdProcedencia",
                table: "Material",
                column: "IdProcedencia");

            migrationBuilder.CreateIndex(
                name: "IX_Material_IdProloguista",
                table: "Material",
                column: "IdProloguista");

            migrationBuilder.CreateIndex(
                name: "IX_Material_IdSector",
                table: "Material",
                column: "IdSector");

            migrationBuilder.CreateIndex(
                name: "IX_Material_IdSerie",
                table: "Material",
                column: "IdSerie");

            migrationBuilder.CreateIndex(
                name: "IX_Material_IdTipoMaterial",
                table: "Material",
                column: "IdTipoMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_Material_IdTraductor",
                table: "Material",
                column: "IdTraductor");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialMovimiento_IdMaterial",
                table: "MaterialMovimiento",
                column: "IdMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialMovimiento_IdSector",
                table: "MaterialMovimiento",
                column: "IdSector");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialMovimiento_IdSocio",
                table: "MaterialMovimiento",
                column: "IdSocio");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialMovimiento_IdTipoMovimiento",
                table: "MaterialMovimiento",
                column: "IdTipoMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialMovimiento_IdUsuario",
                table: "MaterialMovimiento",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Provincia_IdPais",
                table: "Provincia",
                column: "IdPais");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anexo");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Cobrador");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Guionista");

            migrationBuilder.DropTable(
                name: "Interprete");

            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.DropTable(
                name: "MaterialMovimiento");

            migrationBuilder.DropTable(
                name: "Productor");

            migrationBuilder.DropTable(
                name: "TipoSoporte");

            migrationBuilder.DropTable(
                name: "TipoSuspension");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Socio");

            migrationBuilder.DropTable(
                name: "TipoMovimiento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Coleccion");

            migrationBuilder.DropTable(
                name: "Editor");

            migrationBuilder.DropTable(
                name: "Editorial");

            migrationBuilder.DropTable(
                name: "Encuadernacion");

            migrationBuilder.DropTable(
                name: "Idioma");

            migrationBuilder.DropTable(
                name: "Ilustrador");

            migrationBuilder.DropTable(
                name: "Lugar");

            migrationBuilder.DropTable(
                name: "Procedencia");

            migrationBuilder.DropTable(
                name: "Prologuista");

            migrationBuilder.DropTable(
                name: "Sector");

            migrationBuilder.DropTable(
                name: "Serie");

            migrationBuilder.DropTable(
                name: "TipoMaterial");

            migrationBuilder.DropTable(
                name: "Traductor");

            migrationBuilder.DropTable(
                name: "Calle");

            migrationBuilder.DropTable(
                name: "CategoriaSocio");

            migrationBuilder.DropTable(
                name: "EstadoSocio");

            migrationBuilder.DropTable(
                name: "Localidad");

            migrationBuilder.DropTable(
                name: "Profesion");

            migrationBuilder.DropTable(
                name: "TipoDocumento");

            migrationBuilder.DropTable(
                name: "TipoSocio");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
