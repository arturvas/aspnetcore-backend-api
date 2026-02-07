using CadastroProdutos.Dtos;
using CadastroProdutos.Entities;
using CadastroProdutos.Infrastructure;

namespace CadastroProdutos.Services;

public class ProdutosService(MyDbContext myDbContext) : IProdutosService
{
    public List<ProdutoEntity> ObterTodos()
    {
        return myDbContext.Produtos.ToList();
    }

    public void Adicionar(ProdutoEntity novoProduto)
    {
        myDbContext.Produtos.Add(novoProduto);
        myDbContext.SaveChanges();
    }

    public ProdutoEntity? ObterPorId(int id)
    {
        return myDbContext.Produtos.Find(id);
    }

    public ProdutoEntity? Atualizar(int id, ProdutoEntity produtoAtualizado)
    {
        var produto = myDbContext.Produtos.Find(id);
        if (produto is null)
            return null;
        
        produto.Renomear(produtoAtualizado.Nome);
        produto.AtualizarPreco(produtoAtualizado.Preco);
        produto.AtualizarEstoque(produtoAtualizado.Estoque);

        myDbContext.SaveChanges();
        return produto;
    }

    public ProdutoEntity? AtualizarParcial(int id, ProdutoPatchDto patch)
    {
        var produto = myDbContext.Produtos.Find(id);
        if (produto is null)
            return null;

        if (patch.Nome is not null)
            produto.Renomear(patch.Nome);

        if (patch.Preco.HasValue)
            produto.AtualizarPreco(patch.Preco.Value);

        if (patch.Estoque.HasValue)
            produto.AtualizarEstoque(patch.Estoque.Value);

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