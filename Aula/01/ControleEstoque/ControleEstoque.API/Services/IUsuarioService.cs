using ControleEstoque.API.DTOs;

namespace ControleEstoque.API.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> ListarTodosUsuariosAsync();
        Task<UsuarioDTO?> BuscarUsuarioPorId(int id);
        Task<UsuarioDTO?> BuscarUsuarioPorEmail(string email);

        Task<UsuarioDTO> RegistrarCliente(CriarClienteDTO DTO);
        Task<UsuarioDTO> RegistrarCaixa(CriarCaixaDTO DTO);
        Task<UsuarioDTO> RegistrarGerente(CriarGerenteDTO DTO);

    }
}
