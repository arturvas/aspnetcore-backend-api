using CadastroProdutos.Dtos;

namespace CadastroProdutos.Services;

public interface IProdutosService
{
    List<Produto> ObterTodos { get; }
    Produto? ObterPorId(int id);
    void Adicionar(Produto novoProduto);
    Produto? Atualizar(int id, Produto produtoAtualizado);
    Produto? AtualizarParcial(int id, ProdutoPatchDto patch);
    bool Remover(int id);
}