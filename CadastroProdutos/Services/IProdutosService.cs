using CadastroProdutos.Dtos;
using CadastroProdutos.Entities;

namespace CadastroProdutos.Services;

public interface IProdutosService
{
    List<ProdutoEntity> ObterTodos();
    ProdutoEntity? ObterPorId(int id);
    void Adicionar(ProdutoEntity novoProduto);
    ProdutoEntity? Atualizar(int id, ProdutoEntity produtoAtualizado);
    ProdutoEntity? AtualizarParcial(int id, ProdutoPatchDto patch);
    bool Remover(int id);
}