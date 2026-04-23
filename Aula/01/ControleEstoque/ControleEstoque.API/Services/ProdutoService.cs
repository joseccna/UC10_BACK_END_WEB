using ControleEstoque.API.Data;
using ControleEstoque.API.DTOs;
using ControleEstoque.API.Models;
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

        public async Task AtualizarProdutoDtoAsync(AtualizarProdutoDTO dto)
        {
            //buscar essa entidade no banco
            //se ela existir,
            //verificar se o fornecedor informado existe
            //Atualizar os dados da entidade com os dados do DTO


            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == dto.Id);

            if (produto !=null)
              {
                var fornecedorExistente = await _context.Fornecedores.FirstOrDefaultAsync(f => f.Id == dto.FornecedorId);

                if (fornecedorExistente == null)
                {
                        throw new ArgumentException("O fornecedor informado não existe.");
                  }

                produto.Nome = dto.Nome;
                produto.Preco = dto.Preco;
                produto.QuantidadeEstoque = dto.QuantidadeEstoque;
                produto.FornecedorId = dto.FornecedorId;

                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();
            };

        }









        public async Task<ProdutoDTO> CriarProdutoAsync(CriaProdutoDTO dto)
        {
            // 1 - Verficar a existencia desse fornecedor no banco de dados

            var fornecedorExistente = await _context.Fornecedores.FirstOrDefaultAsync(f => f.Id == dto.FornecedorId);

            // 2 - Se não existir, interrompa o fluxo de forma amigável, informando o cliente da API sobre o erro
            if (fornecedorExistente == null)
            {
                throw new ArgumentException("O fornecedor informado não existe.");
            }


            var produto = new Produto()
            {
                Nome = dto.Nome,
                Preco = dto.Preco,
                QuantidadeEstoque = dto.QuantidadeEstoque,
                FornecedorId = dto.FornecedorId,

            };

            // E SE O FORNECDOR NÃO EXISTIR? NO BANDO DE DADOS
             _context.Produtos.Add(produto);
             _context.SaveChanges();

            return await ObterPorIdAsync(produto.Id);


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

        public async Task<IEnumerable<ProdutoDTO>> ObterTodosAsync()
        {
            return await _context.Produtos
                .Select(p => new ProdutoDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco,
                    QuantidadeEstoque = p.QuantidadeEstoque,
                    Fornecedor = new FornecedorDTO
                    {
                        Id = p.Fornecedor.Id,
                        CNPJ = p.Fornecedor.CNPJ,
                        NomeFantasia = p.Fornecedor.NomeFantasia
                    }

                })
                .ToListAsync();

        }

        public async Task RemoverAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }
    }

}
