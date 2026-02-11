using CadastroProdutos.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutos.Infrastructure;

public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{
    public DbSet<ProdutoEntity> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ProdutoEntity>().HasData(
            new { Id = 1, Nome = "Notebook Dell Inspiron", Preco = 3499.99m, Estoque = 15 },
            new { Id = 2, Nome = "Mouse Logitech MX Master", Preco = 349.90m, Estoque = 50 },
            new { Id = 3, Nome = "Teclado Mecânico Keychron", Preco = 599.00m, Estoque = 30 },
            new { Id = 4, Nome = "Monitor LG 27 UltraWide", Preco = 1899.00m, Estoque = 12 },
            new { Id = 5, Nome = "Headset HyperX Cloud II", Preco = 459.99m, Estoque = 25 },
            new { Id = 6, Nome = "SSD Samsung 1TB", Preco = 499.00m, Estoque = 40 },
            new { Id = 7, Nome = "Webcam Logitech C920", Preco = 389.90m, Estoque = 18 },
            new { Id = 8, Nome = "Cadeira Gamer DT3 Sports", Preco = 1299.00m, Estoque = 8 },
            new { Id = 9, Nome = "Mesa Digitalizadora Wacom", Preco = 899.00m, Estoque = 10 },
            new { Id = 10, Nome = "Hub USB-C 7 em 1", Preco = 199.90m, Estoque = 35 }
        );
    }
}