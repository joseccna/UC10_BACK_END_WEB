using ControleEstoque.API.DTOs;

namespace ControleEstoque.API.Services
{
    public interface IContaReceber
    {
        Task<IEnumerable<ContaReceberDTO>> ObterTodosAsync(); //restorna uma lista de contas a receber
        Task<ContaReceberDTO?> ObterPorIdAsync(int id);

        Task<ContaReceberDTO> CriarAsync(CriarContaReceberDTO dto);

            Task RemoverAsync(int id);
            Task AtualizarAsync(AtualizarContaReceberDTO dto);

    }

}

