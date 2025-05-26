using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class TiposdeMovimientosyCamposdeSocios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Socio",
                newName: "Telfijo");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Socio",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Piso",
                table: "Socio",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Sexo",
                table: "Socio",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TelCelular",
                table: "Socio",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoMovimiento");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Socio");

            migrationBuilder.DropColumn(
                name: "Piso",
                table: "Socio");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Socio");

            migrationBuilder.DropColumn(
                name: "TelCelular",
                table: "Socio");

            migrationBuilder.RenameColumn(
                name: "Telfijo",
                table: "Socio",
                newName: "Telefono");
        }
    }
}
