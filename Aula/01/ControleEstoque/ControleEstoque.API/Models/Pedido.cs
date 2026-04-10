using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ControleEstoque.API.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataPedido { get; set; } = DateTime.Now;

        [Required, StringLength(20) ]
        public string Status { get; set; } // Ex: "Aberto", "Fechado", "Suspenso..."


        [ForeignKey("Cliente")]
        public int ClienteId { get; set; } // Cliente que fez o pedido
        public Cliente Cliente { get; set; } // Relação com o cliente que fez o pedido

        [ForeignKey("Caixa")]
        public int? CaixaId { get; set; } // Caixa que fecha o pedido
        public Caixa Caixa { get; set; } // Relação com o caixa que fecha o pedido

        public ICollection<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>(); // Relação com itens de pedido



    }

}




