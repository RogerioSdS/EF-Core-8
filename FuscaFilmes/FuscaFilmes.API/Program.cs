using System.Text.Json.Serialization;
using FuscaFilmes.API.DbContexts;
using FuscaFilmes.API.Entities;
using FuscaFilmes.API.Models;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(
    options => options.UseSqlite(builder.Configuration["ConnectionStrings:FuscaFilmesStr"])
                      .LogTo(Console.WriteLine, LogLevel.Information)//Inserindo log na tela que esta executando o codigo
);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura o JsonOptions para que o serializador JSON ignore os loops de referencia
// e permita virgulas no final dos arrays e objetos.
// Isso   necessario para que o serializador JSON possa lidar com as referências cíclicas ( no caso, Diretor busca filmes, filmes busca diretor..... e assim por diante, fazendo um loop de referência)
// entre os objetos e evite que o sistema lance uma exceção de estouro de pilha.
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.SerializerOptions.AllowTrailingCommas = true;
});

var app = builder.Build();

/*
using (var context = new Context())
{
    // The EnsureCreated method is used to ensure that the database for the context exists.
    // If it exists, no action is taken. If it does not exist then the database and all its schema are created.
    // Note: This method should not be used in production environments as it does not use migrations to create the database.
    context.Database.EnsureCreated();
}
*/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/diretores", (Context context) =>
{
    return context.Diretores
    .Include(diretor => diretor.Filmes)
    .ToList();
})
.WithOpenApi(); 

app.MapGet("/diretores/firstOrDefault/{name}", (string name, Context context) =>
{
    // return context.Diretores
    //     .Include(diretor => diretor.Filmes)    
    //     .Select(diretor => diretor.Name)
    //     .FirstOrDefault() ?? "Nenhum Diretor Encontrado";

    return context.Diretores
        .Include(diretor => diretor.Filmes)    
        //.Select(diretor => diretor.Name)
        .FirstOrDefault(diretor => diretor.Name == name) ?? new Diretor{Id = 9999, Name = "Nenhum Diretor Encontrado"};
})
.WithOpenApi(); 

app.MapGet("/diretores/where/{id}", (int id, Context context) =>
{
    return context.Diretores
    .Where(diretor => diretor.Id == id)
    .Include(diretor => diretor.Filmes)
    .ToList();
})
.WithOpenApi(); 

app.MapPost("/diretores/", (Diretor diretor,Context context) =>
{
    context.Diretores.Add(diretor);
    context.SaveChanges();
})
.WithOpenApi();

app.MapPut("/diretores/{diretorId}", (int diretorId, Diretor diretorNovo, Context context) =>
{
    //na entidade filme, o update está sendo feito pelo metodo novo do EF Core o ExecuteUpdate
    var diretor = context.Diretores.Find(diretorId);

    if (diretor != null)
    {
        diretor.Name = diretorNovo.Name;
        if (diretorNovo.Filmes.Count > 0)
        {
            diretor.Filmes.Clear();

            foreach (var filme in diretorNovo.Filmes)
            {
                diretor.Filmes.Add(filme);
            }
        }
    }
    context.SaveChanges();
})
.WithOpenApi();

app.MapDelete("/diretores/{diretorId}", (int diretorId, Context context) =>
{
    //na entidade filme, o delete está sendo feito pelo metodo novo do EF Core o ExecuteDelete
    var diretorDelete = context.Diretores.Find(diretorId);

    if (diretorDelete != null)
    {
        context.Diretores.Remove(diretorDelete);
    }
    context.SaveChanges();
})
.WithOpenApi();

app.MapGet("/filmes", ( Context context) =>
{
    return context.Filmes        
        .Include(filme => filme.Diretor)
        .OrderByDescending(filme => filme.Ano)
        .ThenBy(filme => filme.Titulo)
        .ToList();
})
.WithOpenApi(); 

app.MapGet("/filmes/{id}", (int id, Context context) =>
{
    return context.Filmes
        .Where(filme => filme.Id == id)
        .Include(filme => filme.Diretor)
        .ToList();
})
.WithOpenApi(); 

app.MapGet("/filmes/byNameLikeEFFunctions/{titulo}", (string titulo, Context context) =>
{
    // return context.Filmes
    //     .Where(filme => filme.Titulo.Contains(titulo))
    //     .Include(filme => filme.Diretor)
    //     .ToList();

    return context.Filmes
        .Where(filme => EF.Functions.Like(filme.Titulo, $"%{titulo}%"))
        .Include(filme => filme.Diretor)
        .ToList();
})
.WithOpenApi(); 

app.MapGet("/filmes/byNameContainsLinQ/{titulo}", (string titulo, Context context) =>
{
    // return context.Filmes
    //     .Where(filme => filme.Titulo.Contains(titulo))
    //     .Include(filme => filme.Diretor)
    //     .ToList();

    return context.Filmes
        .Where(filme => EF.Functions.Like(filme.Titulo, $"%{titulo}%"))
        .Include(filme => filme.Diretor)
        .ToList();
})
.WithOpenApi(); 

app.MapPatch("/filmes/update", (FilmeUpdate filmeUpdate, Context context) =>
{
   var filmeSeleted = context.Filmes.Find(filmeUpdate.Id);

    if (filmeSeleted == null) 
        return Results.NotFound();

    filmeSeleted.Titulo = filmeUpdate.Titulo;
    filmeSeleted.Ano = filmeUpdate.Ano;

    context.Update(filmeSeleted);
    context.SaveChanges();

    return Results.Ok(filmeSeleted);       
})
.WithOpenApi();

app.MapPatch("/filmes/executeUpdate", (FilmeUpdate filmeUpdate, Context context) =>
{
    var result = context.Filmes
    .Where(filme => filme.Id == filmeUpdate.Id)
    .ExecuteUpdate(setter => setter
    .SetProperty(f => f.Titulo, filmeUpdate.Titulo)
    .SetProperty(f => f.Ano, filmeUpdate.Ano)
    );

    if (result > 0) 
       return Results.Ok($"Linha(s) afetada(s) {result}");       
    else
        return Results.NotFound();
})
.WithOpenApi();

app.MapDelete("/filmes/{filmeId}", (int filmeId, Context context) =>
{
    context.Filmes
    .Where(filme => filme.Id == filmeId)
    .ExecuteDelete();
})
.WithOpenApi();

app.UseHttpsRedirection();

app.Run();
