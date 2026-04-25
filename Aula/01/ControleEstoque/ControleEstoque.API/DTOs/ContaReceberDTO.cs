namespace ControleEstoque.API.DTOs
{
    public class ContaReceberDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateOnly DataVencimento { get; set; }
        public DateOnly? DataPagamento { get; set; }
        public string Status { get; set; }
        public int ClienteId { get; set; }
        // adicionar informações do cliente, ClienteDTO ou apenas o nome do cliente
        // no futuro.


    }

    public class CriarContaReceberDTO
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateOnly DataVencimento { get; set; }
        public DateOnly? DataPagamento { get; set; }
        public string Status { get; set; }
        public int ClienteId { get; set; }

    }

    public class AtualizarContaReceberDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateOnly DataVencimento { get; set; }
        public DateOnly? DataPagamento { get; set; }
        public string Status { get; set; }  
        public int ClienteId { get; set; }

    }

}
