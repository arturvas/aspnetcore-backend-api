using CadastroProdutos.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProdutosService, ProdutosService>();

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var produtos = new List<Produto>
{
    new Produto { Id = 1, Nome = "Mouse sem fio", Preco = 99.9m, Estoque = 57 },
    new Produto { Id = 2, Nome = "Teclado sem fio", Preco = 249.9m, Estoque = 30 },
    new Produto { Id = 3, Nome = "Headset sem fio", Preco = 330.9m, Estoque = 16 }
};

app.MapGet("/produtos", () => produtos);

app.MapGet("/produtos/{id}", (int id) =>
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

app.MapPut("/produtos/{id}", (int id, Produto produtoAtualizado) =>
{
    var produto = produtos.FirstOrDefault(x => x.Id == id);
    if (produto is null)
        return Results.NotFound($"Produto com ID {id} não encontrado.");
    
    produto.Nome = produtoAtualizado.Nome;
    produto.Preco = produtoAtualizado.Preco;
    produto.Estoque = produtoAtualizado.Estoque;

    return Results.NoContent();
});

// app.MapPatch("/produtos/{id}", (int id, ProdutoPatchDto patch) =>
// {
//     var produto = produtos.FirstOrDefault(p => p.Id == id);
//     if (produto is null)
//         return Results.NotFound($"Produto com ID {id} não encontrado.");
    
//     if (patch.Nome is not null)
//         produto.Nome = patch.Nome;
    
//     if (patch.Preco.HasValue)
//         produto.Preco = patch.Preco.Value;
    
//     if (patch.Estoque.HasValue)
//         produto.Estoque = patch.Estoque.Value;

//     return Results.NoContent();
// });

app.MapDelete("/produtos/{id}", (int id) => 
{
   var produto = produtos.FirstOrDefault(p => p.Id == id);

    if (produto is null)
        return Results.NotFound($"Produto com ID {id} não encontrado.");

    produtos.Remove(produto);

    return Results.NoContent();
});

app.Run();

public class Produto
{
    public int Id { get; set; }
    public required string Nome { get; set; } = "";
    public decimal Preco { get; set; } = 0;
    public int Estoque { get; set; } = 0;
}

// class ProdutoPatchDto
// {
//     public string? Nome { get; set; }
//     public decimal? Preco { get; set; }
//     public int? Estoque { get; set; }
// }