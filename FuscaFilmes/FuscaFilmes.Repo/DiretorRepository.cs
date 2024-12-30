using System;
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contratos;
using FuscaFilmes.Repo.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.Repo;

//Da maneira que foi feita essa classe , ela esta recebe o contexto por meio do construtor, isso permite que agora a classe seja capaz de usar o contexto em todas as suas operações, sem ser preciso passar o contexto explicitamente em cada método. 
public class DiretorRepository(Context _context) : IDiretorRepository
{
    public Context Context { get; } = _context;

    public IEnumerable<Diretor> GetDiretores()
    {
        return Context.Diretores
            .Include(diretor => diretor.Filmes)
            .ToList();
    }

    public Diretor GetDiretorByName(string name)
    {
        return Context.Diretores
            .Where(diretor => EF.Functions.Like(diretor.Name, $"%{name}%"))
            // .Where(diretor => diretor.Name.Contains(name)) //poderia usar esse where, funciona igualmente para essa busca
            .Include(diretor => diretor.Filmes)
            .FirstOrDefault() ?? new Diretor { Id = 9999, Name = "Nenhum Diretor Encontrado" };
    }

    public IEnumerable<Diretor> GetDiretoresById(int id)
    {
        return Context.Diretores
            .Where(diretor => diretor.Id == id)
            .Include(diretor => diretor.Filmes)
            .ToList();
    }

    public void Add(Diretor diretor)
    {
        Context.Diretores.Add(diretor);
    }

    public void Delete(int diretorId)
    {
        //na entidade filme, o delete está sendo feito pelo metodo novo do EF Core o ExecuteDelete
        var diretorDelete = Context.Diretores.Find(diretorId);

        if (diretorDelete != null)
        {
            Context.Diretores.Remove(diretorDelete);
        }
    }

    public void Update(Diretor diretorNovo)
    {
        //na entidade filme, o update está sendo feito pelo metodo novo do EF Core o ExecuteUpdate
        var diretor = Context.Diretores.Find(diretorNovo.Id);

        if (diretor != null)
        {
            diretor.Name = diretorNovo.Name;
            if (diretorNovo.Filmes.Count > 0)
            {
                diretor.Filmes.Clear();

                foreach (var filme in diretorNovo.Filmes)
                {
                    diretor.Filmes.Add(filme);
                }
            }
        }
    }

    public bool SaveChanges()
    {
        return Context.SaveChanges() > 0;
    }
}
