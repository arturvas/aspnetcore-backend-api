namespace CadastroProdutos.Dtos;

public class Produto
{
    public int Id { get; set; }
    public required string Nome { get; set; } = "";
    public decimal Preco { get; set; } = 0;
    public int Estoque { get; set; } = 0;
}