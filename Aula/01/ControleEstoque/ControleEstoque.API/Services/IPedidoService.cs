using ControleEstoque.API.Models;

namespace ControleEstoque.API.Services
{
    public interface IPedidoService
    {
        Task<Pedido?> ObterPedidoComDetalhesAsync(int pedidoId); // Método para obter um pedido com seus detalhes (itens)
        Task<IEnumerable<Pedido>> ListarPedidosDoClienteAsync(int clienteId); // Método para listar todos os pedidos de um cliente específico
        Task<Pedido> CriarPedidoAsync(int clienteId, List<ItemPedido> itens); // Método para criar um novo pedido para um cliente, incluindo os itens do pedido

    }
}
