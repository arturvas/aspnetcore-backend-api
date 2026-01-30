using CadastroProdutos.Dtos;
using CadastroProdutos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private ProdutosService _produtosService = new ProdutosService();
        
        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            return Ok(ProdutosService.ObterTodos);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Produto> GetById(int id)
        {
            var produto = ProdutosService.ObterPorId(id);

            if (produto is null)
                return NotFound($"Produto com o ID [{id}] não encontrado.");

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(Produto novoProduto)
        {
            ProdutosService.Adicionar(novoProduto);

            return Created();
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produtoAtualizado)
        {
            var produto = ProdutosService.ObterPorId(id);

            if (produto is null)
                return NotFound($"Produto com Id [{id}] não encontrado.");
            
            ProdutosService.Atualizar(id, produtoAtualizado);
            
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public ActionResult Patch(int id, ProdutoPatchDto patch)
        {
            var produto = ProdutosService.ObterPorId(id);
            
            ProdutosService.AtualizarParcial(id, patch);
            
            if (produto is null)
                return NotFound($"Produto com ID {id} não encontrado.");

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = ProdutosService.ObterPorId(id);

            if (produto is null)
                return NotFound($"Produto com ID [{id}] não encontrado.");

            ProdutosService.Remover(id);

            return NoContent();
        }

    }
}

