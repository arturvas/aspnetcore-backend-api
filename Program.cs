using CadastroProdutos.Dtos;
using CadastroProdutos.Infrastructure;
using CadastroProdutos.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlite("Data Source = Produtos.db"));

builder.Services.AddScoped<IProdutosService, ProdutosRepositoryService>();

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseHttpsRedirection();

var produtos = new List<Produto>
{
    new Produto { Id = 1, Nome = "Mouse sem fio", Preco = 99.9m, Estoque = 57 },
    new Produto { Id = 2, Nome = "Teclado sem fio", Preco = 249.9m, Estoque = 30 },
    new Produto { Id = 3, Nome = "Headset sem fio", Preco = 330.9m, Estoque = 16 }
};

app.MapGet("/produtos", () => produtos);

app.MapGet("/produtos/{id:int}", (int id) =>
{
    var produto = produtos.FirstOrDefault(p => p.Id == id);
    
    return produto is not null 
        ? Results.Ok(produto) 
        : Results.NotFound($"Produto com ID {id} não encontrado.");
});

app.MapPost("/produtos", (Produto novoProduto) =>
{
    produtos.Add(novoProduto);

    return Results.Created();
});

app.MapPut("/produtos/{id:int}", (int id, Produto produtoAtualizado) =>
{
    var produto = produtos.FirstOrDefault(x => x.Id == id);
    if (produto is null)
        return Results.NotFound($"Produto com ID {id} não encontrado.");
    
    produto.Nome = produtoAtualizado.Nome;
    produto.Preco = produtoAtualizado.Preco;
    produto.Estoque = produtoAtualizado.Estoque;

    return Results.NoContent();
});

app.MapDelete("/produtos/{id:int}", (int id) => 
{
   var produto = produtos.FirstOrDefault(p => p.Id == id);

    if (produto is null)
        return Results.NotFound($"Produto com ID {id} não encontrado.");

    produtos.Remove(produto);

    return Results.NoContent();
});

app.Run();