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

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _produtoService.ObterTodosAsync());


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
            => Ok(await _produtoService.ObterPorIdAsync(id));



    }
}