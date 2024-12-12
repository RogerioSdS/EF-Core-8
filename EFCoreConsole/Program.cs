// See https://aka.ms/new-console-template for more information
using System.Data.Common;
using EFCoreConsole.DbContexts;
using EFCoreConsole.Entities;

using (var context = new Context())
{
    // A função EnsureCreated verifica se o banco de dados existe, e se não existir, cria o esquema do banco de dados.
    context.Database.EnsureCreated();
}
using var db = new Context();

db.Add(new Filme() { Titulo = "Star Wars", Ano = 2007 });
db.Add(new Filme() { Titulo = "DeadPool", Ano = 2019 });
db.SaveChanges();

var filme = db.Filmes.Find(1);

if (filme != null)
{
    filme.Titulo = "Star Wars - Remake";
    filme.Diretor = new Diretor() { Name = "Al Pacino" };
}

db.SaveChanges();

var filmes = db.Filmes.ToList();

foreach (var Item in filmes)
{
    Console.WriteLine($"{Item.Titulo}  {Item.Id}");
}

var filmeRemovido = db.Filmes.Find(1);

if (filmeRemovido != null)
{
    db.Remove(filmeRemovido);
    db.SaveChanges();
}

filmes = db.Filmes.ToList();
Console.Write("Lista Atualizada\n");

foreach (var Item in filmes)
{
    Console.WriteLine($"{Item.Titulo}  {Item.Id}");
}