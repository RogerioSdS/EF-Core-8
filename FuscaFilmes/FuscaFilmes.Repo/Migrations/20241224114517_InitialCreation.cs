using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FuscaFilmes.Repo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
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
                    Ano = table.Column<int>(type: "INTEGER", nullable: true),
                    DiretorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmes_Diretores_DiretorId",
                        column: x => x.DiretorId,
                        principalTable: "Diretores",
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
                columns: new[] { "Id", "Ano", "DiretorId", "Titulo" },
                values: new object[,]
                {
                    { 1, 2014, 1, "Interstellar" },
                    { 2, 1994, 2, "Pulp Fiction" },
                    { 3, 2012, 2, "Django Unchained" },
                    { 4, 1993, 3, "Jurassic Park" },
                    { 5, 1993, 3, "Schindler's List" },
                    { 6, 2013, 4, "The Wolf of Wall Street" },
                    { 7, 1990, 4, "Goodfellas" },
                    { 8, 2009, 5, "Avatar" },
                    { 9, 1997, 5, "Titanic" },
                    { 10, 1972, 6, "The Godfather" },
                    { 11, 1974, 6, "The Godfather Part II" },
                    { 12, 1960, 7, "Psycho" },
                    { 13, 1954, 7, "Rear Window" },
                    { 14, 2000, 8, "Gladiator" },
                    { 15, 1982, 8, "Blade Runner" },
                    { 16, 1968, 9, "2001: A Space Odyssey" },
                    { 17, 1980, 9, "The Shining" },
                    { 18, 2001, 10, "The Lord of the Rings: The Fellowship of the Ring" },
                    { 19, 2012, 10, "The Hobbit: An Unexpected Journey" },
                    { 20, 2021, 11, "Dune" },
                    { 21, 2016, 11, "Arrival" },
                    { 22, 2023, 12, "Barbie" },
                    { 23, 2019, 12, "Little Women" },
                    { 24, 2014, 13, "The Grand Budapest Hotel" },
                    { 25, 2012, 13, "Moonrise Kingdom" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_DiretorId",
                table: "Filmes",
                column: "DiretorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Diretores");
        }
    }
}
