using System.ComponentModel.DataAnnotations;
using CadastroProdutos.Domain.Exceptions;

namespace CadastroProdutos.Entities;

public class ProdutoEntity
{
    public int Id { get; init; }
    [StringLength(100)] public string Nome { get; private set; } = string.Empty;
    [Range(0.01, double.MaxValue)] public decimal Preco { get; private set; }
    public int Estoque { get; private set; }

    protected ProdutoEntity() { }

    public ProdutoEntity(string nome, decimal preco, int estoque)
    {
        Renomear(nome);
        AtualizarPreco(preco);
        AtualizarEstoque(estoque);
    }

    public void AtualizarPreco(decimal novoPreco)
    {
        if (novoPreco < 0) throw new DomainException("Preço não pode ser negativo");
        Preco = novoPreco;
    }

    public void Renomear(string novoNome)
    {
        if (string.IsNullOrWhiteSpace(novoNome)) throw new DomainException("Nome vazio");
        Nome = novoNome;
    }

    public void AtualizarEstoque(int novaQuantidade)
    {
        if (novaQuantidade < 0) throw new DomainException("Qtd inválida");
        Estoque = novaQuantidade;
    }
}