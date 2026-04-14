using ControleEstoque.API.Models;

namespace ControleEstoque.API.DTOs
{
    public class FornecedorDTO
    {
        //[Key] não precisa ser adicionado aqui, pois é um DTO e não uma entidade do banco de dados.
        public int Id { get; set; }

        public string NomeFantasia { get; set; }

        public string CNPJ { get; set; }

    }


    public class CriarFornecedorDTO
    {
        public string NomeFantasia { get; set; }

        public string CNPJ { get; set; }

    }


    public class AtualizarFornecedorDTO
    {
        public string NomeFantasia { get; set; }
    }


}
