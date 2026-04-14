using ControleEstoque.API.DTOs;

namespace ControleEstoque.API.Services
{
    public class FornecedorService : IFornecedorService
    {
        //Implementação do serviço de fornecedor, onde serão implementados os métodos definidos na interface IFornecedorService
        //assinar contrato da interface e implementar os métodos, por enquanto estão lançando NotImplementedException, mas futuramente serão implementados com a lógica de negócio para manipular os dados dos fornecedores

        Task IFornecedorService.AtualizarAsync(AtualizarFornecedorDTO dto)
        {
            throw new NotImplementedException();
        }

        Task<FornecedorDTO> IFornecedorService.CriarAsync(CriarFornecedorDTO dto)
        {
            throw new NotImplementedException();
        }

        Task<FornecedorDTO?> IFornecedorService.ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<FornecedorDTO>> IFornecedorService.ObterTodosAsync()
        {
            throw new NotImplementedException();
        }

        Task IFornecedorService.RemoverAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
