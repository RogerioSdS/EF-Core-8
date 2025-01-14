using System;
using System.Threading.Tasks;
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contratos;
using FuscaFilmes.Repo.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.Repo;

//Da maneira que foi feita essa classe , ela esta recebe o contexto por meio do construtor, isso permite que agora a classe seja capaz de usar o contexto em todas as suas operações, sem ser preciso passar o contexto explicitamente em cada método. 
public class DiretorRepository(Context _context) : IDiretorRepository
{
    public Context Context { get; } = _context;

    public async Task<IEnumerable<Diretor>> GetDiretoresAsync()
    {
        return await Context.Diretores
            .Include(diretor => diretor.Filmes)
            .ToListAsync();
    }

    public async Task<Diretor> GetDiretorByNameAsync(string name)
    {
        return await Context.Diretores
            .Where(diretor => EF.Functions.Like(diretor.Name, $"%{name}%"))
            // .Where(diretor => diretor.Name.Contains(name)) //poderia usar esse where, funciona igualmente para essa busca
            .Include(diretor => diretor.Filmes)
            .FirstOrDefaultAsync() ?? new Diretor { Id = 9999, Name = "Nenhum Diretor Encontrado" };
    }

    public async Task<IEnumerable<Diretor>> GetDiretoresByIdAsync(int id)
    {
        return await Context.Diretores
            .Where(diretor => diretor.Id == id)
            .Include(diretor => diretor.Filmes)
            .ToListAsync();
    }

    public async Task AddAsync(Diretor diretor)
    {
        await Context.Diretores.AddAsync(diretor);
    }

    public async Task DeleteAsync(int diretorId)
    {
        //na entidade filme, o delete está sendo feito pelo metodo novo do EF Core o ExecuteDelete
        var diretorDelete = await Context.Diretores.FindAsync(diretorId);

        if (diretorDelete != null)
        {
            Context.Diretores.Remove(diretorDelete);
        }
    }

    public async Task UpdateAsync(Diretor diretorNovo)
    {
        //na entidade filme, o update está sendo feito pelo metodo novo do EF Core o ExecuteUpdate
        var diretor = await Context.Diretores.FindAsync(diretorNovo.Id);

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

    public async Task<bool> SaveChangesAsync()
    {
        return (await Context.SaveChangesAsync()) > 0;
    }
}
