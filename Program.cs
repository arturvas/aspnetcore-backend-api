using CadastroProdutos.Infrastructure;
using CadastroProdutos.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<MyDbContext>(options => 
    options.UseSqlite("Data Source = Produtos.db"));

builder.Services.AddScoped<IProdutosService, ProdutosService>();

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();