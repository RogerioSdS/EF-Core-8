using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuscaFilmes.API.Models
{
    public record FilmeUpdate(int Id, string Titulo, int Ano);
}