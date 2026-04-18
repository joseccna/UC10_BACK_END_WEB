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