using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FuscaFilmes.Repo.Migrations
{
    /// <inheritdoc />
    public partial class _020DiretorDetalhe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diretores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diretores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Ano = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiretorDetalhe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Biografia = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DiretorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiretorDetalhe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiretorDetalhe_Diretores_DiretorId",
                        column: x => x.DiretorId,
                        principalTable: "Diretores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiretoresFilmes",
                columns: table => new
                {
                    DiretorId = table.Column<int>(type: "INTEGER", nullable: false),
                    FilmeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiretoresFilmes", x => new { x.DiretorId, x.FilmeId });
                    table.ForeignKey(
                        name: "FK_DiretoresFilmes_Diretores_DiretorId",
                        column: x => x.DiretorId,
                        principalTable: "Diretores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiretoresFilmes_Filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Diretores",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Christopher Nolan" },
                    { 2, "Quentin Tarantino" },
                    { 3, "Steven Spielberg" },
                    { 4, "Martin Scorsese" },
                    { 5, "James Cameron" },
                    { 6, "Francis Ford Coppola" },
                    { 7, "Alfred Hitchcock" },
                    { 8, "Ridley Scott" },
                    { 9, "Stanley Kubrick" },
                    { 10, "Peter Jackson" },
                    { 11, "Denis Villeneuve" },
                    { 12, "Greta Gerwig" },
                    { 13, "Wes Anderson" }
                });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "Ano", "Titulo" },
                values: new object[,]
                {
                    { 1, 2014, "Interstellar" },
                    { 2, 1994, "Pulp Fiction" },
                    { 3, 2012, "Django Unchained" },
                    { 4, 1993, "Jurassic Park" },
                    { 5, 1993, "Schindler's List" },
                    { 6, 2013, "The Wolf of Wall Street" },
                    { 7, 1990, "Goodfellas" },
                    { 8, 2009, "Avatar" },
                    { 9, 1997, "Titanic" },
                    { 10, 1972, "The Godfather" },
                    { 11, 1974, "The Godfather Part II" },
                    { 12, 1960, "Psycho" },
                    { 13, 1954, "Rear Window" },
                    { 14, 2000, "Gladiator" },
                    { 15, 1982, "Blade Runner" },
                    { 16, 1968, "2001: A Space Odyssey" },
                    { 17, 1980, "The Shining" },
                    { 18, 2001, "The Lord of the Rings: The Fellowship of the Ring" },
                    { 19, 2012, "The Hobbit: An Unexpected Journey" },
                    { 20, 2021, "Dune" },
                    { 21, 2016, "Arrival" },
                    { 22, 2023, "Barbie" },
                    { 23, 2019, "Little Women" },
                    { 24, 2014, "The Grand Budapest Hotel" },
                    { 25, 2012, "Moonrise Kingdom" }
                });

            migrationBuilder.InsertData(
                table: "DiretorDetalhe",
                columns: new[] { "Id", "Biografia", "DataNascimento", "DiretorId" },
                values: new object[,]
                {
                    { 1, "Biografia do Christopher Nolan", new DateTime(1970, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Biografia do Quentin Tarantino", new DateTime(1963, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "DiretoresFilmes",
                columns: new[] { "DiretorId", "FilmeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 9 },
                    { 4, 10 },
                    { 4, 11 },
                    { 4, 12 },
                    { 5, 13 },
                    { 5, 14 },
                    { 5, 15 },
                    { 6, 16 },
                    { 6, 17 },
                    { 6, 18 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiretorDetalhe_DiretorId",
                table: "DiretorDetalhe",
                column: "DiretorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiretoresFilmes_FilmeId",
                table: "DiretoresFilmes",
                column: "FilmeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiretorDetalhe");

            migrationBuilder.DropTable(
                name: "DiretoresFilmes");

            migrationBuilder.DropTable(
                name: "Diretores");

            migrationBuilder.DropTable(
                name: "Filmes");
        }
    }
}
