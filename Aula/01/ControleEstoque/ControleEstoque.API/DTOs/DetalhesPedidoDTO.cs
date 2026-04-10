namespace ControleEstoque.API.DTOs
{
    public class DetalhesPedidoDTO
    {
        public int Id { get; set; }

        public DateTime DataPedido { get; set; }

        public string Status { get; set; } = string.Empty;

        public int? ClienteId { get; set; }
        // preciso adicionar a propriedade string nomeCliente
        public string NomeCliente { get; set; } = string.Empty;

        public decimal Total => Itens.Sum(i => i.Quantidade * i.PrecoUnitario);

        public List<DetalhesItemPedidoDTO> Itens { get; set; }

    }

    public class DetalhesItemPedidoDTO
    {
        public int Id { get; set; }

        public int Quantidade { get; set; }

        public decimal PrecoUnitario { get; set; }

        public int? ProdutoId { get; set; }

        public string ProdutoNome { get; set; } = string.Empty;

    }


}
