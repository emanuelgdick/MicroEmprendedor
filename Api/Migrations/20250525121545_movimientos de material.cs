using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class movimientosdematerial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoMovimiento = table.Column<int>(type: "int", nullable: false),
                    IdSector = table.Column<int>(type: "int", nullable: false),
                    IdSocio = table.Column<int>(type: "int", nullable: false),
                    IdTipoMaterial = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialMovimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialMovimiento_Sector_IdSector",
                        column: x => x.IdSector,
                        principalTable: "Sector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialMovimiento_Socio_IdSocio",
                        column: x => x.IdSocio,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialMovimiento_TipoMaterial_IdTipoMaterial",
                        column: x => x.IdTipoMaterial,
                        principalTable: "TipoMaterial",
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialMovimiento_IdSector",
                table: "MaterialMovimiento",
                column: "IdSector");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialMovimiento_IdSocio",
                table: "MaterialMovimiento",
                column: "IdSocio");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialMovimiento_IdTipoMaterial",
                table: "MaterialMovimiento",
                column: "IdTipoMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialMovimiento_IdTipoMovimiento",
                table: "MaterialMovimiento",
                column: "IdTipoMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialMovimiento_IdUsuario",
                table: "MaterialMovimiento",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialMovimiento");
        }
    }
}
