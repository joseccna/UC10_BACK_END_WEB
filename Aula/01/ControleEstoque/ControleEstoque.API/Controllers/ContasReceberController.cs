using ControleEstoque.API.DTOs;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasReceberController : ControllerBase
    {
        public readonly IContaReceber _contaReceberService;

        public ContasReceberController(IContaReceber contaReceberService)
        {
            _contaReceberService = contaReceberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contasReceber = await _contaReceberService.ObterTodosAsync();
            return Ok(contasReceber);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _contaReceberService.ObterPorIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CriarContaReceberDTO dto)
        {
            var result = await _contaReceberService.CriarAsync(dto);
            return Created(nameof(Create), result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AtualizarContaReceberDTO dto)
        {
            if (id != dto.Id) return BadRequest();
            var exist = await _contaReceberService.ObterPorIdAsync(id);
            if (exist == null) return NotFound();
            await _contaReceberService.AtualizarAsync(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exist = await _contaReceberService.ObterPorIdAsync(id);
            if (exist == null) return NotFound();
            await _contaReceberService.RemoverAsync(id);
            return NoContent();


        }

    }

}
