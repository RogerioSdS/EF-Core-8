using FuscaFilmes.API.EndpointHandlers;

namespace FuscaFilmes.API.EndpointExtensions
{
    public static class EndpointDiretores
    {
        // Este método de extensão "DiretoresEndpoints" adiciona endpoints relacionados à funcionalidade de "Diretores" ao pipeline de roteamento do aplicativo.
        // O parâmetro "app" é do tipo "IEndpointRouteBuilder", que é uma interface fornecida pelo ASP.NET Core para construir e configurar rotas.
        // Este método é usado para organizar e modularizar a definição de endpoints em uma aplicação ASP.NET Core, permitindo que seja chamada na configuração principal (classe Program).

        public static void DiretoresEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/diretores", DiretoresHandlers.GetDiretoresAsync).WithOpenApi();

            app.MapGet("/diretores/firstOrDefault/{name}", DiretoresHandlers.GetDiretorByNameAsync).WithOpenApi();

            app.MapGet("/diretores/where/{id}", DiretoresHandlers.GetDiretoresByIdAsync).WithOpenApi();

            app.MapPost("/diretores/", DiretoresHandlers.AddDiretoresAsync).WithOpenApi();

            app.MapPut("/diretores/", DiretoresHandlers.UpdateDiretorAsync).WithOpenApi();

            app.MapDelete("/diretores/{diretorId}", DiretoresHandlers.DeleteDiretorAsync).WithOpenApi();

        }
    }
}

/* 
Este método de extensão utiliza o contexto (Context) para passá-lo como argumento às classes de handlers. 
Isso é possível porque o contexto foi configurado e registrado no contêiner de injeção de dependências (DI) na classe Program, por meio do seguinte código:

builder.Services.AddDbContext<Context>(
    options => options.UseSqlite(builder.Configuration["ConnectionStrings:FuscaFilmesStr"])
                      .LogTo(Console.WriteLine, LogLevel.Information)
);

No trecho acima:
- O contexto (`Context`) é configurado para usar o banco de dados com a string de conexão definida na configuração.
- O log das operações no banco é configurado, permitindo visualizar as queries e outras informações no console.

O parâmetro `(this IEndpointRouteBuilder app)` no método de extensão refere-se ao `app`, que é o resultado de `builder.Build()` na classe Program:

var app = builder.Build();

O `app` encapsula toda a configuração do pipeline, incluindo middlewares, serviços e endpoints. Como o contexto (`Context`) foi registrado no contêiner de serviços durante a configuração (via `builder.Services`), ele pode ser resolvido em qualquer lugar onde a injeção de dependências seja suportada, como nas classes de handlers.

Dessa forma, ao usar o método de extensão para configurar endpoints, o contexto está disponível para ser utilizado em todas as classes de handlers ou diretamente nos endpoints, garantindo consistência e integração com o pipeline configurado. */

