using CadastroProdutos.Entities;
using CadastroProdutos.Infrastructure;
using CadastroProdutos.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutos.Tests;

public class ProdutosServiceTests
{
    private MyDbContext CriarContextoEmMemoria()
    {
        var options = new DbContextOptionsBuilder<MyDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new MyDbContext(options);
    }

    [Fact]
    public void Adicionar_DevePersistirProdutoNoBanco()
    {
        var context = CriarContextoEmMemoria();
        var service = new ProdutosService(context);
        var produto = new ProdutoEntity("Teclado", 150.0m, 5);
        
        service.Adicionar(produto);

        context.Produtos.Count().Should().Be(1);
        context.Produtos.First().Nome.Should().Be("Teclado");
    }

    [Fact]
    public void ObterPorId_ProdutoExistente_DeveRetornarProduto()
    {
        var context = CriarContextoEmMemoria();
        var produto = new ProdutoEntity("Headset", 200, 2);
        context.Produtos.Add(produto);
        context.SaveChanges();

        var service = new ProdutosService(context);

        var sucesso = service.Remover(produto.Id);

        sucesso.Should().BeTrue();
        context.Produtos.Should().BeEmpty();
    }
}