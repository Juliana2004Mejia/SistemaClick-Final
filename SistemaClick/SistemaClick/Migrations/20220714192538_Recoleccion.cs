using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaClick.Migrations
{
    public partial class Recoleccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Hora_llegada",
                table: "Recolecciones",
                type: "datetime2",
                maxLength: 30,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LocalidadId",
                table: "Recolecciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recolecciones_LocalidadId",
                table: "Recolecciones",
                column: "LocalidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recolecciones_Localidades_LocalidadId",
                table: "Recolecciones",
                column: "LocalidadId",
                principalTable: "Localidades",
                principalColumn: "LocalidadId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recolecciones_Localidades_LocalidadId",
                table: "Recolecciones");

            migrationBuilder.DropIndex(
                name: "IX_Recolecciones_LocalidadId",
                table: "Recolecciones");

            migrationBuilder.DropColumn(
                name: "Hora_llegada",
                table: "Recolecciones");

            migrationBuilder.DropColumn(
                name: "LocalidadId",
                table: "Recolecciones");
        }
    }
}
