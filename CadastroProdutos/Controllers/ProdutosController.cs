using CadastroProdutos.Dtos;
using CadastroProdutos.Entities;
using CadastroProdutos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController(IProdutosService produtosService) : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProdutoEntity>> Get()
        {
            return Ok(produtosService.ObterTodos());
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{id:int}")]
        public ActionResult<ProdutoEntity> GetById(int id)
        {
            var produto = produtosService.ObterPorId(id);

            if (produto is null)
                return NotFound($"Produto com o ID [{id}] não encontrado.");

            return Ok(produto);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Post(ProdutoEntity novoProduto)
        {
            produtosService.Adicionar(novoProduto);

            return CreatedAtAction(nameof(GetById), new { id = novoProduto.Id }, novoProduto);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, ProdutoEntity produtoAtualizado)
        {
            var produto = produtosService.Atualizar(id, produtoAtualizado);

            if (produto is null)
                return NotFound($"Produto com Id [{id}] não encontrado.");
            
            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpPatch("{id:int}")]
        public ActionResult Patch(int id, ProdutoPatchDto patch)
        {
            var produto = produtosService.AtualizarParcial(id, patch);
            
            if (produto is null)
                return NotFound($"Produto com ID {id} não encontrado.");

            return Ok(produto);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var sucesso = produtosService.Remover(id);

            if (!sucesso)
                return NotFound($"Produto com ID [{id}] não encontrado.");
            
            return NoContent();
        }

    }
}

