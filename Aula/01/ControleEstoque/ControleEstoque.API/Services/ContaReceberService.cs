using ControleEstoque.API.Data;
using ControleEstoque.API.DTOs;
using ControleEstoque.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class ContaReceberService : IContaReceber
    {
        private readonly AppDbContext _context;

        public ContaReceberService(AppDbContext context)
        {
            _context = context;
        }

        async Task IContaReceber.AtualizarAsync(AtualizarContaReceberDTO dto)
        {
            var entity = await _context.ContaRecebers.FindAsync(dto.Id);
            if (entity != null)
            {
                entity.Valor = dto.Valor;
                entity.DataVencimento = dto.DataVencimento;

                _context.ContaRecebers.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
        

        async Task<ContaReceberDTO> IContaReceber.CriarAsync(CriarContaReceberDTO dto)
        {
            var contaReceber = new ContaReceber()
            {
                Descricao = dto.Descricao,
                Valor = dto.Valor,
                DataVencimento = dto.DataVencimento,
                DataPagamento = dto.DataPagamento,
                Status = dto.Status
            };

            _context.ContaRecebers.Add(contaReceber);
            await _context.SaveChangesAsync();

            return new ContaReceberDTO()
            {
                Id = contaReceber.Id,
                Descricao = contaReceber.Descricao,
                Valor = contaReceber.Valor,
                DataVencimento = contaReceber.DataVencimento,
                DataPagamento = contaReceber.DataPagamento,
                Status = contaReceber.Status
            };

        }

        async Task<ContaReceberDTO?> IContaReceber.ObterPorIdAsync(int id)
        {
            var contaReceber = await _context.ContaRecebers.FirstOrDefaultAsync(r => r.Id == id);

            if (contaReceber == null) return null;

            return new ContaReceberDTO
            {
                Id = contaReceber.Id,
                Descricao = contaReceber.Descricao,
                Valor = contaReceber.Valor,
                DataVencimento = contaReceber.DataVencimento,
                DataPagamento = contaReceber.DataPagamento,
                Status = contaReceber.Status

            };

        }
        async Task<IEnumerable<ContaReceberDTO>> IContaReceber.ObterTodosAsync()
        {
            return await _context.ContaRecebers.Select(r => new ContaReceberDTO
            {
                Id = r.Id,
                Descricao = r.Descricao,
                Valor = r.Valor,
                DataVencimento = r.DataVencimento,
                DataPagamento = r.DataPagamento,
                Status = r.Status

            }).ToListAsync();
        }

        async Task IContaReceber.RemoverAsync(int id)
        {
            var contaReceber = await _context.ContaRecebers.FirstOrDefaultAsync(r => r.Id == id);
            if (contaReceber != null)
            {
                _context.ContaRecebers.Remove(contaReceber);
                await _context.SaveChangesAsync();
            }
        }
    }
}
