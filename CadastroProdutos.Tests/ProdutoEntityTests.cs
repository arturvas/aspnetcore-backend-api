using CadastroProdutos.Domain.Exceptions;
using CadastroProdutos.Entities;
using FluentAssertions;

namespace CadastroProdutos.Tests;

public class ProdutoEntityTests
{
    [Fact]
    public void CriarProduto_ComDadosValidos_DeveInstanciarCorretamente()
    {
        var produto = new ProdutoEntity("Mouse", 50.0m, 10);

        produto.Nome.Should().Be("Mouse");
        produto.Preco.Should().Be(50.0m);
        produto.Estoque.Should().Be(10);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Renomear_ComNomeInvalido_DeveLancarDomainException(string nomeInvalido)
    {
        var produto = new ProdutoEntity("Valido", 10, 10);

        var acao = () => produto.Renomear(nomeInvalido);

        acao.Should().Throw<DomainException>().WithMessage("Nome vazio");
    }

    [Fact]
    public void Renomear_ComNomeNull_DeveLancarDomainException()
    {
        var produto = new ProdutoEntity("Valido", 10, 10);

        var acao = () => produto.Renomear(null!);

        acao.Should().Throw<DomainException>().WithMessage("Nome vazio");
    }

    [Fact]
    public void AtualizarPreco_ComPrecoNegativo_DeveLancarDomainException()
    {
        var produto = new ProdutoEntity("Valido", 10, 10);

        var acao = () => produto.AtualizarPreco(-1);

        acao.Should().Throw<DomainException>().WithMessage("Preço não pode ser negativo");
    }

    [Fact]
    public void AtualizarEstoque_ComQuantidadeNegativa_DeveLancarDomainException()
    {
        var produto = new ProdutoEntity("Valido", 10, 10);

        var acao = () => produto.AtualizarEstoque(-5);

        acao.Should().Throw<DomainException>().WithMessage("Qtd inválida");
    }
}