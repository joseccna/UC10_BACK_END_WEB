using ControleEstoque.API.DTOs;

namespace ControleEstoque.API.Services
{
    public interface IProdutoService
    {
        Task<ProdutoDTO> CriarProdutoAsync(CriaProdutoDTO dto);

        Task AtualizarProdutoDtoAsync(AtualizarProdutoDTO dto);

        Task<IEnumerable<ProdutoDTO>> ObterTodosAsync();

        Task<ProdutoDTO?> ObterPorIdAsync(int id);

        Task RemoverAsync(int id);


    }
}
