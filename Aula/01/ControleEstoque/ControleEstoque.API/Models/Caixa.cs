using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.API.Models
{
    public class Caixa : Usuario
    {
        // Propriedades específicas para Caixa, se necessário
        [StringLength(50)]
        public string Turno { get; set; } // Exemplo de propriedade específica para Caixa

        public ICollection<Pedido> PedidosFechados { get; set; } = new List<Pedido>(); // Exemplo de relação com pedidos fechados

    }


}
