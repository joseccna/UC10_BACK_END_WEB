using ControleEstoque.API.DTOs;
using ControleEstoque.API.Models;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedoresController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var fornecedores = await _fornecedorService.ObterTodosAsync();
            return Ok(fornecedores);
        }
        [HttpGet("{id}")]//rota para obter um fornecedor por id
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _fornecedorService.ObterPorIdAsync(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CriarFornecedorDTO dto)
        {
           FornecedorDTO result = await _fornecedorService.CriarAsync(dto);
           return Created(nameof(Create), result);

        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AtualizarFornecedorDTO dto)
        {
            var exist = await _fornecedorService.ObterPorIdAsync(id);
            if (exist == null) return NotFound();

            await _fornecedorService.AtualizarAsync(id, dto);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id )
        {
            await _fornecedorService.RemoverAsync(id);
            return NoContent();
        }

    }

}
