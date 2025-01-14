using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuscaFilmes.Repo.Migrations
{
    /// <inheritdoc />
    public partial class DataAnnotation_FluentAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Filmes",
                newName: "id_diretor");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Diretores",
                newName: "id_diretor");

            migrationBuilder.AddColumn<decimal>(
                name: "Orcamento",
                table: "Filmes",
                type: "TEXT",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "DiretorDetalhe",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DiretorDetalhe",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "DiretorDetalhe",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 1,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 2,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 3,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 4,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 5,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 6,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 7,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 8,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 9,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 10,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 11,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 12,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 13,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 14,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 15,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 16,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 17,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 18,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 19,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 20,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 21,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 22,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 23,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 24,
                column: "Orcamento",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "id_diretor",
                keyValue: 25,
                column: "Orcamento",
                value: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Orcamento",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "DiretorDetalhe");

            migrationBuilder.RenameColumn(
                name: "id_diretor",
                table: "Filmes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id_diretor",
                table: "Diretores",
                newName: "Id");
        }
    }
}
