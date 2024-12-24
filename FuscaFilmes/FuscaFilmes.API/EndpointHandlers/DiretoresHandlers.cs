using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contratos;

namespace FuscaFilmes.API.EndpointHandlers
{
    public static class DiretoresHandlers
    {
        //Todas as chamadas do context/repositorio estão sendo feitas por meio de um IDiretorRepository, que é uma interface IDiretorRepository que está sendo implementada na classe DiretorRepository, que recebe o contexto por meio do construtor, ou seja, nada que esta sendo trabalhado na camada da API faz consultas ao banco de dados.
        public static IEnumerable<Diretor> GetDiretores(IDiretorRepository diretorRepository)
        {
            return diretorRepository.GetDiretores();
        }

        public static Diretor GetDiretorByName(string name, IDiretorRepository diretorRepository)
        {
            return diretorRepository.GetDiretorByName(name);
        }

        public static IEnumerable<Diretor> GetDiretoresById(int id, IDiretorRepository diretorRepository)
        {
            return diretorRepository.GetDiretoresById(id);
        }

        public static IResult AddDiretores(IDiretorRepository diretorRepository, Diretor diretor)
        {
            diretorRepository.Add(diretor);
            if (diretorRepository.SaveChanges())
            {
                return Results.Ok(diretor);
            }
            else
            {
                return Results.Problem("Erro ao salvar o diretor");
            }
        }

        public static IResult UpdateDiretor(IDiretorRepository diretorRepository, Diretor diretorNovo)
        {
            //na entidade filme, o update está sendo feito pelo metodo novo do EF Core o ExecuteUpdate
            diretorRepository.Update(diretorNovo);
          
            if (diretorRepository.SaveChanges())
            {
                return Results.Ok(diretorNovo);
            }
            else
            {
                return Results.Problem("Erro ao salvar o diretor");
            }
        }

        public static IResult DeleteDiretor(IDiretorRepository diretorRepository, int diretorId)
        {
            //na entidade filme, o delete está sendo feito pelo metodo novo do EF Core o ExecuteDelete
            diretorRepository.Delete(diretorId);

            if (!diretorRepository.SaveChanges())
            {               
                return Results.Problem("Erro ao salvar o diretor");
            }

            return Results.Ok();
        }

    }
}