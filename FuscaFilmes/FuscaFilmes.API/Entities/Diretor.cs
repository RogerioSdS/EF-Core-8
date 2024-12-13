using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuscaFilmes.API.Entities
{
    public class Diretor
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // O ICollection<Filme> é uma colecao de objetos do tipo Filme.
        // Ele serve para representar uma lista de Filmes que um Diretor realizou.
        // O tipo ICollection permite que seja possivel adicionar, remover e contar
        // quantos Filmes um Diretor tem.
        public ICollection<Filme> Filmes { get; set; } = new List<Filme>();    
    }
}