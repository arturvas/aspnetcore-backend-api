using CadastroProdutos.Dtos;
using CadastroProdutos.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutos.Infrastructure;

public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
{
    public DbSet<ProdutoEntity> Produtos { get; set; }
}