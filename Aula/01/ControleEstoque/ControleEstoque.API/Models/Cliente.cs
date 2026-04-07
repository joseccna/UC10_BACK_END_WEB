using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.API.Models
{
    public class Cliente : Usuario
    {
        // Propriedades específicas para Cliente, se necessário
        [StringLength(14)]
        public string CPF { get; set; } // Exemplo de propriedade específica para Cliente

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>(); // Exemplo de relação com pedidos

    }


}
