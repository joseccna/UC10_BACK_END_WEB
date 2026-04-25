using ControleEstoque.API.DTOs;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioService.ListarTodosUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id:int}")]//rota tipada para garantir que o id seja um inteiro
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _usuarioService.BuscarUsuarioPorId(id);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado para o ID informado");
            }

            return Ok(usuario);
        }


        [HttpGet("email/{email}")]//rota com endereço email para buscar email do usuário
        public async Task<IActionResult> GetByEmail(string email)
        {
            var usuario = await _usuarioService.BuscarUsuarioPorEmail(email);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado para o email informado");
            }
            return Ok(usuario);

        }

        [HttpPost("registrar-cliente")]
        public async Task<IActionResult> RegistrarCliente([FromBody] CriarClienteDTO DTO)
        {
            var usuario = await _usuarioService.RegistrarCliente(DTO);
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        [HttpPost("registrar-caixa")]
        public async Task<IActionResult> RegistrarCaixa([FromBody] CriarCaixaDTO DTO)
        {
            var usuario = await _usuarioService.RegistrarCaixa(DTO);
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        [HttpPost("registrar-gerente")]
        public async Task<IActionResult> RegistrarGerente([FromBody] CriarGerenteDTO DTO)
        {
            var usuario = await _usuarioService.RegistrarGerente(DTO);
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);

        }

    }

}
