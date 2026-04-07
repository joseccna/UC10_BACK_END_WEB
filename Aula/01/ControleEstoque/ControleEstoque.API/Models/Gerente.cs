using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.API.Models
{
    public class Gerente : Usuario
    {
        // Propriedades específicas para Gerente, se necessário
        [StringLength(50)]
        public string Setor { get; set; } // Exemplo de propriedade específica para Gerente

    }   


}
