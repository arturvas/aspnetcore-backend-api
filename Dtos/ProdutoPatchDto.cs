namespace CadastroProdutos.Dtos;

public class ProdutoPatchDto
{
    public string? Nome { get; set; }
    public decimal? Preco { get; set; }
    public int? Estoque { get; set; }
}