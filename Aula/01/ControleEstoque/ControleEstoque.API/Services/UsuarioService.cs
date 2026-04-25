using ControleEstoque.API.Data;
using ControleEstoque.API.DTOs;
using ControleEstoque.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        #region Busca de Usuarios
        public async Task<UsuarioDTO?> BuscarUsuarioPorEmail(string email)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null) return null;

            return MapearParaDTO(usuario);
        }

        public async Task<UsuarioDTO?> BuscarUsuarioPorId(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null) return null;

            return MapearParaDTO(usuario);



        }

        public async Task<IEnumerable<UsuarioDTO>> ListarTodosUsuariosAsync()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return usuarios.Select(MapearParaDTO);

        }

        private UsuarioDTO MapearParaDTO(Usuario usuario)
        {
            var dto = new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Perfil = usuario.Perfil,


            };

            if (usuario is Cliente cliente) { dto.CPF = cliente.CPF; }
            if (usuario is Caixa caixa) { dto.Turno = caixa.Turno; }
            if (usuario is Gerente gerente) { dto.Setor = gerente.Setor; }



            return dto;

        }
        #endregion


        #region Cadastro de Usuarios
        public async Task<UsuarioDTO> RegistrarCaixa(CriarCaixaDTO DTO)
        {
            // instanciar um novo usuario
            var caixa = new Caixa()
            {
                Email = DTO.Email,
                Nome = DTO.Nome,
                SenhaHash = DTO.Senha,
                Turno = DTO.Turno,
                Perfil = PerfilUsuario.Caixa // definir o perfil do usuario como caixa
            };
            // passarr os dados da DTO para o objeto  usuario

            _context.Add(caixa);
            await _context.SaveChangesAsync();

            // salvar ele no banco de dados
            return MapearParaDTO(caixa);

        }

        public async Task<UsuarioDTO> RegistrarCliente(CriarClienteDTO DTO)
        {
            var cliente = new Cliente()
            {
                Email = DTO.Email,
                Nome = DTO.Nome,
                SenhaHash = DTO.Senha,
                CPF = DTO.CPF,
                Perfil = PerfilUsuario.Cliente
            };

            _context.Add(cliente);
            await _context.SaveChangesAsync();

            return MapearParaDTO(cliente);
        }

        public async Task<UsuarioDTO> RegistrarGerente(CriarGerenteDTO DTO)
        {
            var gerente = new Gerente()
            {
                Email = DTO.Email,
                Nome = DTO.Nome,
                SenhaHash = DTO.Senha,
                Setor = DTO.Setor,
                Perfil = PerfilUsuario.Gerente
            };
            _context.Add(gerente);
            await _context.SaveChangesAsync();

            return MapearParaDTO(gerente);
        }
        #endregion
    }
}
