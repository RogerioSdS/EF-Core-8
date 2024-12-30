using System;

namespace FuscaFilmes.Domain.Entities;
//Essa classe/entidade foi para criada pois resolvi realizar a gestão do relacionamento entre filmes e diretores por conta propria, senão, poderia ter deixado nas classes relacionadas o Icollection<Entidade> por exemplo na classe Filme colocaria um Icollection<Diretor>,da classe relacionado e o mesmo seria o suficiente, apenas por questão de praticar,fiz assim 
public class DiretorFilme
{
    public int DiretorId { get; set; }
    public Diretor Diretor { get; set; }
    public int FilmeId { get; set; }
    public Filme Filme { get; set; }
}
