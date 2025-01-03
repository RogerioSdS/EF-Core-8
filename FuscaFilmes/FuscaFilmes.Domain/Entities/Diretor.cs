namespace FuscaFilmes.Domain.Entities
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
        public ICollection<DiretorFilme> DiretoresFilmes { get; set; } = null!; 
        public DiretorDetalhe? DiretorDetalhe { get; set; }

    }
}