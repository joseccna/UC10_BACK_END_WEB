using ControleEstoque.API.DTOs;

namespace ControleEstoque.API.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> ObterTodosAsync();

        Task<ProdutoDTO?> ObterPorIdAsync(int id);
    }
}
