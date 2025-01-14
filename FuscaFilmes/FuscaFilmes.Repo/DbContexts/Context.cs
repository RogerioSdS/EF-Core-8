
using System.Data.Common;
using FuscaFilmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.Repo.DbContexts
{
    public class Context(DbContextOptions<Context> options) : DbContext(options)
    {
        public DbSet<Filme>? Filmes { get; set; }
        public DbSet<Diretor>? Diretores { get; set; }
        public DbSet<DiretorFilme>? DiretoresFilmes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diretor>(
               d =>
               {
                    d.HasMany(d => d.Filmes)
                    .WithMany(f => f.Diretores)
                    .UsingEntity<DiretorFilme>(
                        // // Define que a entidade "Diretor" tem uma relação de "um para muitos" com a entidade "Filmes".
                        // .HasMany(e => e.Filmes)
                        // // sendo  que a entidade "Filmes" possui uma relação de "muitos para um" com a entidade "Diretor".
                        // .WithOne(e => e.Diretor)
                        // // sendo a propriedade "DiretorId" como chave estrangeira na entidade "Filmes".
                        // .HasForeignKey(e => e.DiretorId)
                        // // Especifica que a propriedade "DiretorId" é obrigatória (não pode ser nula).
                        // .IsRequired();
                        df => df.HasOne<Filme>(e => e.Filme)
                                .WithMany(e => e.DiretoresFilmes)
                                .HasForeignKey(e => e.FilmeId),//Comando apenas para confirmar que estejam relacionados. Mas o entity framework faz isso por padrão.

                        df => df.HasOne<Diretor>(e => e.Diretor)
                                .WithMany(e => e.DiretoresFilmes)
                                .HasForeignKey(e => e.DiretorId),//Comando apenas para confirmar que estejam relacionados. Mas o entity framework faz isso por padrão.

                        //comando para garantir que a chave primária seja composta, porque o entity framework não faz isso por padrão, mas não é preciso fazer isso. Fazendo apenas para garantir que estej funcionando        
                        df => 
                        {
                            df.HasKey(e => new { e.DiretorId, e.FilmeId });
                            df.ToTable("DiretoresFilmes");
                        });
                    //determinando foreignKey
                    d.HasOne(d => d.DiretorDetalhe)
                    .WithOne(d => d.Diretor)
                    .HasForeignKey<DiretorDetalhe>(d => d.DiretorId);

                    //Já esta sendo aplicado essa data annotation para alterar o nome da coluna chave na classe Filmes, apenas fiz aqui para saber que a mesma pode ser feita aqui no Fluent API
                    d.Property(diretor => diretor.Id)
                    .HasColumnName("id_diretor");
               }
            );

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

            modelBuilder.Entity<Filme>()
                .Property(filme => filme.Orcamento)
                .HasPrecision(18, 2);
            
            modelBuilder.Entity<Filme>().HasData(
                new Filme { Id = 1, Titulo = "Interstellar", Ano = 2014 },
                new Filme { Id = 2, Titulo = "Pulp Fiction", Ano = 1994 },
                new Filme { Id = 3, Titulo = "Django Unchained", Ano = 2012 },
                new Filme { Id = 4, Titulo = "Jurassic Park", Ano = 1993 },
                new Filme { Id = 5, Titulo = "Schindler's List", Ano = 1993 },
                new Filme { Id = 6, Titulo = "The Wolf of Wall Street", Ano = 2013 },
                new Filme { Id = 7, Titulo = "Goodfellas", Ano = 1990 },
                new Filme { Id = 8, Titulo = "Avatar", Ano = 2009 },
                new Filme { Id = 9, Titulo = "Titanic", Ano = 1997 },
                new Filme { Id = 10, Titulo = "The Godfather", Ano = 1972 },
                new Filme { Id = 11, Titulo = "The Godfather Part II", Ano = 1974 },
                new Filme { Id = 12, Titulo = "Psycho", Ano = 1960 },
                new Filme { Id = 13, Titulo = "Rear Window", Ano = 1954 },
                new Filme { Id = 14, Titulo = "Gladiator", Ano = 2000 },
                new Filme { Id = 15, Titulo = "Blade Runner", Ano = 1982 },
                new Filme { Id = 16, Titulo = "2001: A Space Odyssey", Ano = 1968 },
                new Filme { Id = 17, Titulo = "The Shining", Ano = 1980 },
                new Filme { Id = 18, Titulo = "The Lord of the Rings: The Fellowship of the Ring", Ano = 2001 },
                new Filme { Id = 19, Titulo = "The Hobbit: An Unexpected Journey", Ano = 2012 },
                new Filme { Id = 20, Titulo = "Dune", Ano = 2021 },
                new Filme { Id = 21, Titulo = "Arrival", Ano = 2016 },
                new Filme { Id = 22, Titulo = "Barbie", Ano = 2023 },
                new Filme { Id = 23, Titulo = "Little Women", Ano = 2019 },
                new Filme { Id = 24, Titulo = "The Grand Budapest Hotel", Ano = 2014 },
                new Filme { Id = 25, Titulo = "Moonrise Kingdom", Ano = 2012 }
            );     

            modelBuilder.Entity<DiretorFilme>().HasData(
                new { DiretorId = 1, FilmeId = 1 },
                new { DiretorId = 1, FilmeId = 2 },
                new { DiretorId = 1, FilmeId = 3 },
                new { DiretorId = 2, FilmeId = 4 },
                new { DiretorId = 2, FilmeId = 5 },
                new { DiretorId = 2, FilmeId = 6 },
                new { DiretorId = 3, FilmeId = 7 },
                new { DiretorId = 3, FilmeId = 8 },
                new { DiretorId = 3, FilmeId = 9 },
                new { DiretorId = 4, FilmeId = 10 },
                new { DiretorId = 4, FilmeId = 11 },
                new { DiretorId = 4, FilmeId = 12 },
                new { DiretorId = 5, FilmeId = 13 },
                new { DiretorId = 5, FilmeId = 14 },
                new { DiretorId = 5, FilmeId = 15 },
                new { DiretorId = 6, FilmeId = 16 },
                new { DiretorId = 6, FilmeId = 17 },
                new { DiretorId = 6, FilmeId = 18 }
            );

           /* modelBuilder.Entity<DiretorDetalhe>()
           .Property(dd => dd.DataCriacao)
           .HasDefaultValueSql("GETDATE()");*/

            modelBuilder.Entity<DiretorDetalhe>().HasData(
               new DiretorDetalhe { Id = 1, DiretorId = 1, Biografia = "Biografia do Christopher Nolan", DataNascimento = new DateTime(1970, 10, 30) },
               new DiretorDetalhe { Id = 2, DiretorId = 2, Biografia = "Biografia do Quentin Tarantino", DataNascimento = new DateTime(1963, 3, 27) }
           );
        }
    }
}