using ControleEstoque.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Caixa> Caixas { get; set; }

        public DbSet<Gerente> Gerentes { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<ItemPedido> IntemPedidos { get; set; }



        //Essa configuração é opcional, pois os decaratores já estão configurados, mas caso queira adicionar mais configurações, pode ser feito aqui
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adiciona configurações extras, alem dos decaratores
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais, se necessário
        }



    }
}
