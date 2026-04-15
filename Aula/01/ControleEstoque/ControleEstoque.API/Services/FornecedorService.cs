using ControleEstoque.API.Data;
using ControleEstoque.API.DTOs;
using ControleEstoque.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class FornecedorService : IFornecedorService

    {
        private readonly AppDbContext _context;

        public FornecedorService(AppDbContext context)
        {
            _context = context;
        }




        //Implementação do serviço de fornecedor, onde serão implementados os métodos definidos na interface IFornecedorService
        //assinar contrato da interface e implementar os métodos, por enquanto estão lançando NotImplementedException, mas futuramente serão implementados com a lógica de negócio para manipular os dados dos fornecedores

        async Task IFornecedorService.AtualizarAsync(AtualizarFornecedorDTO dto)
        {
           var fornecedor = await _context.Fornecedores.FindAsync(dto.Id);
            if (fornecedor != null)
            {
                fornecedor.NomeFantasia = dto.NomeFantasia;
                _context.Fornecedores.Update(fornecedor);
                await _context.SaveChangesAsync();
            }
        }



        async Task<FornecedorDTO> IFornecedorService.CriarAsync(CriarFornecedorDTO dto)
        {
            // instanciar um forncedorModel com os dados do dto, adicionar ao contexto e salvar as mudanças, retornando um FornecedorDTO com os dados do fornecedor criado

            var fornecedor = new Fornecedor()
            {
               CNPJ = dto.CNPJ,
               NomeFantasia = dto.NomeFantasia
            };

            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();

            return new FornecedorDTO()
            {
                Id = fornecedor.Id,
                CNPJ = fornecedor.CNPJ,
                NomeFantasia = fornecedor.NomeFantasia
            };
        }

        async Task<FornecedorDTO?> IFornecedorService.ObterPorIdAsync(int id)
        {
            var fornecedorModel = await _context.Fornecedores.FirstOrDefaultAsync(f => f.Id == id);
            if (fornecedorModel == null)
            {
                return null;
            }


            return new FornecedorDTO {
                Id = fornecedorModel.Id,
                NomeFantasia = fornecedorModel.NomeFantasia,
                CNPJ = fornecedorModel.CNPJ
            };
            
        }


        async Task<IEnumerable<FornecedorDTO>> IFornecedorService.ObterTodosAsync()
        {
            return await _context.Fornecedores
                .Select(f => new FornecedorDTO
            {
                Id = f.Id,
                NomeFantasia = f.NomeFantasia,
                CNPJ = f.CNPJ
            }).ToListAsync();

        }

        async Task IFornecedorService.RemoverAsync(int id)
        {
            var fornecedor= await _context.Fornecedores
                .FirstOrDefaultAsync(f => f.Id == id);

            if (fornecedor != null)
            { 
                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
                
            }
        }
    }
}
