using CadastroProdutos.Dtos;
using CadastroProdutos.Infrastructure;

namespace CadastroProdutos.Services;

public class ProdutosRepositoryService(MyDbContext myDbContext) : IProdutosService
{
    public List<Produto> ObterTodos()
    {
        return myDbContext.Produtos.ToList();
    }

    public void Adicionar(Produto novoProduto)
    {
        myDbContext.Produtos.Add(novoProduto);
        myDbContext.SaveChanges();
    }

    public Produto? ObterPorId(int id)
    {
        return myDbContext.Produtos.Find(id);
    }

    public Produto? Atualizar(int id, Produto produtoAtualizado)
    {
        var produto = myDbContext.Produtos.Find(id);
        if (produto is null)
            return null;

        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;
        produto.Estoque = produtoAtualizado.Estoque;

        myDbContext.SaveChanges();

        return produto;
    }

    public Produto? AtualizarParcial(int id, ProdutoPatchDto patch)
    {
        var produto = myDbContext.Produtos.Find(id);
        if (produto is null)
            return null;

        if (patch.Nome is not null)
            produto.Nome = patch.Nome;

        if (patch.Preco.HasValue)
            produto.Preco = patch.Preco.Value;

        if (patch.Estoque.HasValue)
            produto.Estoque = patch.Estoque.Value;

        myDbContext.SaveChanges();

        return produto;
    }

    public bool Remover(int id)
    {
        var produto = myDbContext.Produtos.Find(id);

        if (produto is null)
            return false;

        myDbContext.Produtos.Remove(produto);
        myDbContext.SaveChanges();
        return true;
    }
}