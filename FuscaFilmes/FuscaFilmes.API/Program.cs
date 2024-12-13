using System.Text.Json.Serialization;
using FuscaFilmes.API.DbContexts;
using FuscaFilmes.API.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(
    options => options.UseSqlite(builder.Configuration["ConnectionStrings:FuscaFilmesStr"])
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

app.UseHttpsRedirection();

app.MapGet("/diretores", (Context context) =>
{
    return context.Diretores
    .Include(diretor => diretor.Filmes)
    .ToList();
})
.WithOpenApi(); app.UseHttpsRedirection();

app.MapPost("/diretores/", (Diretor diretor,Context context) =>
{
    context.Diretores.Add(diretor);
    context.SaveChanges();
})
.WithOpenApi(); app.UseHttpsRedirection();

app.MapPut("/diretores/{diretorId}", (int diretorId, Diretor diretorNovo, Context context) =>
{
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
app.UseHttpsRedirection();

app.MapDelete("/diretores/{diretorId}", (int diretorId, Context context) =>
{
    var diretorDelete = context.Diretores.Find(diretorId);

    if (diretorDelete != null)
    {
        context.Diretores.Remove(diretorDelete);
    }
    context.SaveChanges();
})
.WithOpenApi();
app.Run();
