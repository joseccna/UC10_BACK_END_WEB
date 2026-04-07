using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoque.API.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; }


        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Required]
        public int QuantidadeEstoque { get; set; }

        [ForeignKey("Fornecedor")]
        public int FornecedorId { get; set; } // Chave estrangeira para o fornecedor
        public Fornecedor Fornecedor { get; set; } // Relação com o fornecedor

        public ICollection<IntemPedido> ItensPedido { get; set; } = new List<IntemPedido>(); // Relação com itens de pedido

    }
}
