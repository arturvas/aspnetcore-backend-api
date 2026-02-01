using CadastroProdutos.Dtos;

namespace CadastroProdutos.Services;

public class ProdutosService : IProdutosService
{
    public List<Produto> ObterTodos { get; } =
    [
        new Produto { Id = 1, Nome = "Mouse sem fio", Preco = 99.9m, Estoque = 57 },
        new Produto { Id = 2, Nome = "Teclado sem fio", Preco = 249.9m, Estoque = 30 },
        new Produto { Id = 3, Nome = "Headset sem fio", Preco = 330.9m, Estoque = 16 }
    ];
    
    public Produto? ObterPorId(int id) => ObterTodos.FirstOrDefault(x => x.Id == id);

    public void Adicionar(Produto novoProduto)
    {
        ObterTodos.Add(novoProduto);
    }

    public Produto? Atualizar(int id, Produto produtoAtualizado)
    {
        var produto = ObterTodos.FirstOrDefault(x => x.Id == id);
        if (produto is null)
            return null;
        
        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;
        produto.Estoque = produtoAtualizado.Estoque;

        return produto;
    }

    public Produto? AtualizarParcial(int id, ProdutoPatchDto patch)
    {
        var produto = ObterTodos.FirstOrDefault(x => x.Id == id);
        if (produto is null)
            return null;

        if (patch.Nome is not null)
            produto.Nome = patch.Nome;

        if (patch.Preco.HasValue)
            produto.Preco = patch.Preco.Value;

        if (patch.Estoque.HasValue)
            produto.Estoque = patch.Estoque.Value;

        return produto;
    }

    public bool Remover(int id)
    {
        var produto = ObterTodos.FirstOrDefault(x => x.Id == id);

        if (produto is null)
            return false;

        ObterTodos.Remove(produto);
        return true;
    }
    
}