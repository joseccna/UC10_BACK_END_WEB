using ControleEstoque.API.Data;
using ControleEstoque.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    
    
        public class PedidoService : IPedidoService
        {
            private readonly AppDbContext _context;

            public PedidoService(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Pedido> CriarPedidoAsync(int clienteId, List<ItemPedido> itens)
            {
                var pedido = new Pedido
                {
                    ClienteId = clienteId,
                    DataPedido = DateTime.UtcNow,
                    Status = "Aberto",
                    ItensPedido = itens
                };

                _context.Pedidos.Add(pedido);
                await _context.SaveChangesAsync();
                return pedido;
            }

            public Task<IEnumerable<Pedido>> ListarPedidosDoClienteAsync(int clienteId)
            {
                throw new NotImplementedException();
            }

            public Task<Pedido?> ObterPedidoComDetalhesAsync(int pedidoId)
            {

            //incluir a busca dos dados do cliente também
            return _context.Pedidos.Include(p => p.ItensPedido).ThenInclude(i => i.Produto).Include(p =>p.Cliente).FirstOrDefaultAsync(p => p.Id == pedidoId);
                
        }
        }
    
}