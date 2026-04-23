using ControleEstoque.API.DTOs;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CriaProdutoDTO dto)
        {
            var produtoCriado = await _produtoService.CriarProdutoAsync(dto);
            return Ok(produtoCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AtualizarProdutoDTO dto)
        {
            if(id !=dto.Id) return BadRequest("Id da rota  difere do is do produto.");

            await _produtoService.AtualizarProdutoDtoAsync(dto);
            return NoContent(); // é um tipo de ok, mas sem conteúdo, pois a atualização não retorna um objeto atualizado, apenas indica que a operação foi bem-sucedida.
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        { 
           return  Ok(await _produtoService.ObterTodosAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok(await _produtoService.ObterPorIdAsync(id));


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _produtoService.RemoverAsync(id);
            return NoContent();
        }



    }
}