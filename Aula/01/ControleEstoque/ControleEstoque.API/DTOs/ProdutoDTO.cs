using ControleEstoque.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoque.API.DTOs
{
    public class ProdutoDTO
    {


        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public FornecedorDTO Fornecedor { get; set; } // Relação com o fornecedor


    }

    public class CriaProdutoDTO
    {

        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int FornecedorId { get; set; } // Relação com o fornecedor


    }


    public class AtualizarProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int FornecedorId { get; set; } // Relação com o fornecedor


    }





}
