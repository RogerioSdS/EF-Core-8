using System.Threading.Tasks;
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contratos;

namespace FuscaFilmes.API.EndpointHandlers
{
    public static class DiretoresHandlers
    {
        //Todas as chamadas do context/repositorio estão sendo feitas por meio de um IDiretorRepository, que é uma interface IDiretorRepository que está sendo implementada na classe DiretorRepository, que recebe o contexto por meio do construtor, ou seja, nada que esta sendo trabalhado na camada da API faz consultas ao banco de dados.
        public static async Task<IEnumerable<Diretor>> GetDiretoresAsync(IDiretorRepository diretorRepository)
        {
            return await diretorRepository.GetDiretoresAsync();
        }

        public static async Task<Diretor> GetDiretorByNameAsync(string name, IDiretorRepository diretorRepository)
        {
            return await diretorRepository.GetDiretorByNameAsync(name);
        }

        public static async Task<IEnumerable<Diretor>> GetDiretoresByIdAsync(int id, IDiretorRepository diretorRepository)
        {
            return await diretorRepository.GetDiretoresByIdAsync(id);
        }

        public static async Task<IResult> AddDiretoresAsync(IDiretorRepository diretorRepository, Diretor diretor)
        {
            await diretorRepository.AddAsync(diretor);
            if (await diretorRepository.SaveChangesAsync())
            {
                return Results.Ok(diretor);
            }
            
            return Results.Problem("Erro ao salvar o diretor");
            
        }

        public static async Task<IResult> UpdateDiretorAsync(IDiretorRepository diretorRepository, Diretor diretorNovo)
        {
            //na entidade filme, o update está sendo feito pelo metodo novo do EF Core o ExecuteUpdate
            await diretorRepository.UpdateAsync(diretorNovo);
          
            if (await diretorRepository.SaveChangesAsync())
            {
                return Results.Ok(diretorNovo);
            }
            else
            {
                return Results.Problem("Erro ao salvar o diretor");
            }
        }

        public static async Task<IResult> DeleteDiretorAsync(IDiretorRepository diretorRepository, int diretorId)
        {
            //na entidade filme, o delete está sendo feito pelo metodo novo do EF Core o ExecuteDelete
            await diretorRepository.DeleteAsync(diretorId);

            if (await diretorRepository.SaveChangesAsync())
            {               
            return Results.Ok();
            }
            
            return Results.Problem("Erro ao salvar o diretor");
        }

    }
}