namespace ControleEstoque.API.DTOs
{
    public class CriarPedidoDTO
    {
        // remover quando tiver o JWT
        public int ClienteId { get; set; }

        public List<CriarItemPedidoDTO> Itens { get; set; } 

    }

    public class CriarItemPedidoDTO
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }


        //Não peidremos o preço. O backend ira buscar no banco.
    }

}
