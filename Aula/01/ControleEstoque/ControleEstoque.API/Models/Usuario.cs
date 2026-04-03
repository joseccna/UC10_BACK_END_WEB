using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.API.Models
{
    public enum PerfilUsuario
    {
        Cliente,
        Caixa,
        Gerente,
    }


    public abstract class Usuario // abstract para não permitir instâncias Usuario diretas, apenas herança
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string SenhaHash { get; set; } // aplicar tamanho mínimo 

        [Required]
        public PerfilUsuario Perfil { get; set; }


    }

    public class Cliente : Usuario
    {
        // Propriedades específicas para Cliente, se necessário
        [StringLength(14)]
        public string CPF { get; set; } // Exemplo de propriedade específica para Cliente

    }


    public class Caixa : Usuario
    {
        // Propriedades específicas para Caixa, se necessário
        [StringLength(50)]
        public string Turno { get; set; } // Exemplo de propriedade específica para Caixa
    }


    public class Gerente : Usuario
    {
        // Propriedades específicas para Gerente, se necessário
        [StringLength(50)]
        public string Setor { get; set; } // Exemplo de propriedade específica para Gerente

    }   


}
