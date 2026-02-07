using System.ComponentModel.DataAnnotations;

namespace CadastroProdutos.Dtos;

public class ProdutoPatchDto(string? nome, decimal? preco, int? estoque)
{
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string? Nome { get; } = nome;
    
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
    public decimal? Preco { get; } = preco;
    
    [Range(0, int.MaxValue, ErrorMessage = "O estoque não pode ser negativo.")]
    public int? Estoque { get; } = estoque;
}