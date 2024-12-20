using FuscaFilmes.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.API.DbContexts
{
    public class Context(DbContextOptions<Context> options) : DbContext(options)
    {
        public DbSet<Filme>? Filmes { get; set; }
        public DbSet<Diretor>? Diretores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diretor>()
            // Define que a entidade "Diretor" tem uma relação de "um para muitos" com a entidade "Filmes".
            .HasMany(e => e.Filmes)
            // sendo  que a entidade "Filmes" possui uma relação de "muitos para um" com a entidade "Diretor".
            .WithOne(e => e.Diretor)
            // sendo a propriedade "DiretorId" como chave estrangeira na entidade "Filmes".
            .HasForeignKey(e => e.DiretorId)
            // Especifica que a propriedade "DiretorId" é obrigatória (não pode ser nula).
            .IsRequired();

            modelBuilder.Entity<Diretor>().HasData(
                // Aqui é feita a predefinição de dados para a entidade "Diretor".
                // Isso é útil em caso que queira que o banco venha com dados pré-definidos.
                // Neste exemplo, estão sendo predefinidos 13 diretores. 
                new Diretor { Id = 1, Name = "Christopher Nolan" },
                new Diretor { Id = 2, Name = "Quentin Tarantino" },
                new Diretor { Id = 3, Name = "Steven Spielberg" },
                new Diretor { Id = 4, Name = "Martin Scorsese" },
                new Diretor { Id = 5, Name = "James Cameron" },
                new Diretor { Id = 6, Name = "Francis Ford Coppola" },
                new Diretor { Id = 7, Name = "Alfred Hitchcock" },
                new Diretor { Id = 8, Name = "Ridley Scott" },
                new Diretor { Id = 9, Name = "Stanley Kubrick" },
                new Diretor { Id = 10, Name = "Peter Jackson" },
                new Diretor { Id = 11, Name = "Denis Villeneuve" },
                new Diretor { Id = 12, Name = "Greta Gerwig" },
                new Diretor { Id = 13, Name = "Wes Anderson" }
            );

            modelBuilder.Entity<Filme>().HasData( 
                new Filme { Id = 1, Titulo = "Interstellar", Ano = 2014, DiretorId = 1 },
                new Filme { Id = 2, Titulo = "Pulp Fiction", Ano = 1994, DiretorId = 2 },
                new Filme { Id = 3, Titulo = "Django Unchained", Ano = 2012, DiretorId = 2 },
                new Filme { Id = 4, Titulo = "Jurassic Park", Ano = 1993, DiretorId = 3 },
                new Filme { Id = 5, Titulo = "Schindler's List", Ano = 1993, DiretorId = 3 },
                new Filme { Id = 6, Titulo = "The Wolf of Wall Street", Ano = 2013, DiretorId = 4 },
                new Filme { Id = 7, Titulo = "Goodfellas", Ano = 1990, DiretorId = 4 },
                new Filme { Id = 8, Titulo = "Avatar", Ano = 2009, DiretorId = 5 },
                new Filme { Id = 9, Titulo = "Titanic", Ano = 1997, DiretorId = 5 },
                new Filme { Id = 10, Titulo = "The Godfather", Ano = 1972, DiretorId = 6 },
                new Filme { Id = 11, Titulo = "The Godfather Part II", Ano = 1974, DiretorId = 6 },
                new Filme { Id = 12, Titulo = "Psycho", Ano = 1960, DiretorId = 7 },
                new Filme { Id = 13, Titulo = "Rear Window", Ano = 1954, DiretorId = 7 },
                new Filme { Id = 14, Titulo = "Gladiator", Ano = 2000, DiretorId = 8 },
                new Filme { Id = 15, Titulo = "Blade Runner", Ano = 1982, DiretorId = 8 },
                new Filme { Id = 16, Titulo = "2001: A Space Odyssey", Ano = 1968, DiretorId = 9 },
                new Filme { Id = 17, Titulo = "The Shining", Ano = 1980, DiretorId = 9 },
                new Filme { Id = 18, Titulo = "The Lord of the Rings: The Fellowship of the Ring", Ano = 2001, DiretorId = 10 },
                new Filme { Id = 19, Titulo = "The Hobbit: An Unexpected Journey", Ano = 2012, DiretorId = 10 },
                new Filme { Id = 20, Titulo = "Dune", Ano = 2021, DiretorId = 11 },
                new Filme { Id = 21, Titulo = "Arrival", Ano = 2016, DiretorId = 11 },
                new Filme { Id = 22, Titulo = "Barbie", Ano = 2023, DiretorId = 12 },
                new Filme { Id = 23, Titulo = "Little Women", Ano = 2019, DiretorId = 12 },
                new Filme { Id = 24, Titulo = "The Grand Budapest Hotel", Ano = 2014, DiretorId = 13 },
                new Filme { Id = 25, Titulo = "Moonrise Kingdom", Ano = 2012, DiretorId = 13 }
            );

        }
    }
}