using ControleEstoque.API.Data;
using ControleEstoque.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProdutoDTO?> ObterPorIdAsync(int id)
        {
            var produto = await _context.Produtos
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);

            return new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                QuantidadeEstoque = produto.QuantidadeEstoque,
                Fornecedor = new FornecedorDTO
                {
                    Id= produto.Fornecedor.Id,
                    CNPJ = produto.Fornecedor.CNPJ,
                    NomeFantasia = produto.Fornecedor.NomeFantasia
                }
            };
        }

        public Task<IEnumerable<ProdutoDTO>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }


    }

}
