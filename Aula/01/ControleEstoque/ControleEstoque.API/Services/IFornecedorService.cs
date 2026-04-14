using ControleEstoque.API.DTOs;

namespace ControleEstoque.API.Services
{
    public interface IFornecedorService
    {
        //Contrato para o serviço de fornecedor, com os métodos necessários para as operações CRUD
        Task <IEnumerable<FornecedorDTO>> ObterTodosAsync(); //restorna uma lista de fornecedores

        Task<FornecedorDTO?> ObterPorIdAsync(int id);

        Task<FornecedorDTO> CriarAsync(CriarFornecedorDTO dto);

        Task AtualizarAsync(int id, AtualizarFornecedorDTO dto);

        Task RemoverAsync(int id);

    }

}
