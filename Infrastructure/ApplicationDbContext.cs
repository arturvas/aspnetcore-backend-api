using CadastroProdutos.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutos.Infrastructure;

public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{
    public DbSet<Produto> Produtos { get; set; }
}