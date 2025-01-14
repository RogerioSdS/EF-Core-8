using System.Threading.Tasks;
using FuscaFilmes.API.Models;
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.API.EndpointHandlers
{
    /*
    /// Essa classe esta sendo feita para realizar as chamadas ao banco de dados, ela recebe o contexto por meio do construtor, ou seja, nada que esta sendo trabalhado na camada da API faz consultas ao banco de dados
    */
    public static class FilmesHandlers
    {
        public static async Task<IEnumerable<Filme>> GetFilmesAsync(Context context)
        {
            return await context.Filmes
                .Include(filme => filme.Diretores)
                .OrderByDescending(filme => filme.Ano)
                .ThenBy(filme => filme.Titulo)
                .ToListAsync();
        }
        public static async Task<IEnumerable<Filme>> GetFilmeByIdAsync(int id, Context context)
        {
            return await context.Filmes
                .Include(filme => filme.Diretores)
                .Where(filme => filme.Id == id)
                .ToListAsync();
        }

        public static async Task<IEnumerable<Filme>> GetFilmeEFFunctionByTituloAsync(string titulo, Context context)
        {
            return await context.Filmes
                .Include(filme => filme.Diretores)
                .Where(filme => EF.Functions.Like(filme.Titulo, $"%{titulo}%"))
                .ToListAsync();
        }

        public static async Task<IEnumerable<Filme>> GetFilmeContainsByTituloAsync(string titulo, Context context)
        {
            return await context.Filmes
                .Include(filme => filme.Diretores)
                .Where(filme => filme.Titulo.Contains(titulo))
                .ToListAsync();
        }

        public static async Task ExecuteDeleteFilmeAsync(int filmeId, Context context)
        {
            await context.Filmes
            .Where(filme => filme.Id == filmeId)
            .ExecuteDeleteAsync();
        }
        public static async Task<IResult> UpdateFilmeAsync(FilmeUpdate filmeUpdate, Context context)
        {
            var filmeSeleted = await context.Filmes.FindAsync(filmeUpdate.Id);

            if (filmeSeleted == null)
                return Results.NotFound();

            filmeSeleted.Titulo = filmeUpdate.Titulo;
            filmeSeleted.Ano = filmeUpdate.Ano;

            context.Update(filmeSeleted);
            context.SaveChangesAsync();

            return Results.Ok(filmeSeleted);
        }

        public static async Task<IResult> ExecuteUpdateFilmeAsync(FilmeUpdate filmeUpdate, Context context)
        {
            var result = await context.Filmes
            .Where(filme => filme.Id == filmeUpdate.Id)
            .ExecuteUpdateAsync(setter => setter
            .SetProperty(f => f.Titulo, filmeUpdate.Titulo)
            .SetProperty(f => f.Ano, filmeUpdate.Ano)
            );

            if (result > 0)
                return Results.Ok($"Linha(s) afetada(s): {result}");
            else
                return Results.NotFound();
        }
    }
}