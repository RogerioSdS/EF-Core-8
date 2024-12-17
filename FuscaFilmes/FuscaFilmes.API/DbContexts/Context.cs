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
        }
    }
}