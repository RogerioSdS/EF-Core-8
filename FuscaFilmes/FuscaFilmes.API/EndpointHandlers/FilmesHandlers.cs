using FuscaFilmes.API.Models;
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.API.EndpointHandlers
{
    public static class FilmesHandlers
    {
        public static IEnumerable<Filme> GetFilmes(Context context)
        {
            return context.Filmes
                .Include(filme => filme.Diretor)
                .OrderByDescending(filme => filme.Ano)
                .ThenBy(filme => filme.Titulo)
                .ToList();
        }
        public static IEnumerable<Filme> GetFilmeById(int id, Context context)
        {
            return context.Filmes
                .Where(filme => filme.Id == id)
                .Include(filme => filme.Diretor)
                .ToList();
        }

        public static IEnumerable<Filme> GetFilmeEFFunctionByTitulo(string titulo, Context context)
        {
            return context.Filmes
                .Where(filme => EF.Functions.Like(filme.Titulo, $"%{titulo}%"))
                .Include(filme => filme.Diretor)
                .ToList();
        }

        public static IEnumerable<Filme> GetFilmeContainsByTitulo(string titulo, Context context)
        {
            return context.Filmes
                .Where(filme => filme.Titulo.Contains(titulo))
                .Include(filme => filme.Diretor)
                .ToList();
        }

        public static void ExecuteDeleteFilme(int filmeId, Context context)
        {
            context.Filmes
            .Where(filme => filme.Id == filmeId)
            .ExecuteDelete();
        }
        public static IResult UpdateFilme(FilmeUpdate filmeUpdate, Context context)
        {
            var filmeSeleted = context.Filmes.Find(filmeUpdate.Id);

            if (filmeSeleted == null)
                return Results.NotFound();

            filmeSeleted.Titulo = filmeUpdate.Titulo;
            filmeSeleted.Ano = filmeUpdate.Ano;

            context.Update(filmeSeleted);
            context.SaveChanges();

            return Results.Ok(filmeSeleted);
        }

        public static IResult ExecuteUpdateFilme(FilmeUpdate filmeUpdate, Context context)
        {
            var result = context.Filmes
            .Where(filme => filme.Id == filmeUpdate.Id)
            .ExecuteUpdate(setter => setter
            .SetProperty(f => f.Titulo, filmeUpdate.Titulo)
            .SetProperty(f => f.Ano, filmeUpdate.Ano)
            );

            if (result > 0)
                return Results.Ok($"Linha(s) afetada(s) {result}");
            else
                return Results.NotFound();
        }
    }
}