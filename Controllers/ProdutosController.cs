using CadastroProdutos.Dtos;
using CadastroProdutos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController(IProdutosService produtosService) : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            return Ok(produtosService.ObterTodos);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Produto> GetById(int id)
        {
            var produto = produtosService.ObterPorId(id);

            if (produto is null)
                return NotFound($"Produto com o ID [{id}] não encontrado.");

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(Produto novoProduto)
        {
            produtosService.Adicionar(novoProduto);

            return Created();
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produtoAtualizado)
        {
            var produto = produtosService.ObterPorId(id);

            if (produto is null)
                return NotFound($"Produto com Id [{id}] não encontrado.");
            
            produtosService.Atualizar(id, produtoAtualizado);
            
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public ActionResult Patch(int id, ProdutoPatchDto patch)
        {
            var produto = produtosService.ObterPorId(id);
            
            produtosService.AtualizarParcial(id, patch);
            
            if (produto is null)
                return NotFound($"Produto com ID {id} não encontrado.");

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = produtosService.ObterPorId(id);

            if (produto is null)
                return NotFound($"Produto com ID [{id}] não encontrado.");

            produtosService.Remover(id);

            return NoContent();
        }

    }
}

