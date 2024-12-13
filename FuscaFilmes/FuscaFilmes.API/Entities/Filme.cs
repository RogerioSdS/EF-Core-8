using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuscaFilmes.API.Entities
{
    public class Filme
    {
        public int Id { get; set; }
        // Esta propriedade é obrigatória, garantindo que 'Titulo' seja sempre definido.
        public required string Titulo { get; set; }
        public int? Ano { get; set; }
        public Diretor Diretor { get; set; }           
    }
}