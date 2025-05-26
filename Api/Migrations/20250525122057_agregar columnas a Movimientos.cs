using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class agregarcolumnasaMovimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "MaterialMovimiento",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDevolucion",
                table: "MaterialMovimiento",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NroInventario",
                table: "MaterialMovimiento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NroMovimiento",
                table: "MaterialMovimiento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "MaterialMovimiento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "MaterialMovimiento");

            migrationBuilder.DropColumn(
                name: "FechaDevolucion",
                table: "MaterialMovimiento");

            migrationBuilder.DropColumn(
                name: "NroInventario",
                table: "MaterialMovimiento");

            migrationBuilder.DropColumn(
                name: "NroMovimiento",
                table: "MaterialMovimiento");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "MaterialMovimiento");
        }
    }
}
