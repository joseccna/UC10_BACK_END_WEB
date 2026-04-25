using ControleEstoque.API.Models;
using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.API.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public PerfilUsuario Perfil { get; set; }

        public string? Turno { get; set; }

        public string? CPF { get; set; }

        public string? Setor { get; set; }
    }

    public class CriarClienteDTO
    {
        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        public string CPF { get; set; } = string.Empty;

    }


    public class CriarCaixaDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Turno { get; set; } = string.Empty;
    }

    public class CriarGerenteDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Setor { get; set; } = string.Empty;

    }

}
