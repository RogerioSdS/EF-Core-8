using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuscaFilmes.Domain.Entities
{
    public class Filme
    {
        [Key]

        [Column("id_diretor")]
        public int Id { get; set; }
        // Esta propriedade é obrigatória, garantindo que 'Titulo' seja sempre definido.
        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; } = string.Empty;
        //Range(1900, 2099) significa que o valor deve estar entre 1900 e 2099, inclusive.
        [Range(1900, 2099)]
        public int? Ano { get; set; }
        // A exclamação (!)   chamada de "null-forgiving operator" e   usada para indicar que o valor não é nulo, mesmo que o compilador não consiga determinar isso. Nesse caso, está garantindo que o valor de Diretor não é nulo, mesmo que o compilador não consiga determinar isso.
        public decimal Orcamento { get; set; }
        public ICollection<Diretor> Diretores { get; set; } = null!; 
        public ICollection<DiretorFilme> DiretoresFilmes { get; set; } = null!; 

    }
}