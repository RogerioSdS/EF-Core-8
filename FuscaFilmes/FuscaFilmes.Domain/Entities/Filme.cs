namespace FuscaFilmes.Domain.Entities
{
    public class Filme
    {
        public int Id { get; set; }
        // Esta propriedade é obrigatória, garantindo que 'Titulo' seja sempre definido.
        public required string Titulo { get; set; }
        public int? Ano { get; set; }
        public int DiretorId { get; set; }
        // A exclamação (!)   chamada de "null-forgiving operator" e   usada para indicar que o valor não é nulo, mesmo que o compilador não consiga determinar isso. Nesse caso, está garantindo que o valor de Diretor não é nulo, mesmo que o compilador não consiga determinar isso.
        public Diretor Diretor { get; set; } = null!; 
    }
}