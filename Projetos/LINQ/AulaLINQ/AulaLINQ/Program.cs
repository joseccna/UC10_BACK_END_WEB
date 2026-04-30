
namespace Endereco {

    #region Classes
    public class Endereco
{
    public int Id { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }


}

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Endereco Endereco { get; set; }

}

public class Conta
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public decimal Saldo { get; set; }
        public Cliente Cliente { get; set; }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            
            var contas = new List<Conta>

            {

                new Conta { Id = 1, Numero = "1001", Saldo = 1500.50m, Cliente = new Cliente { Id = 1, Nome = "Ana",
                    Endereco = new Endereco { Id = 1, Cidade = "São Paulo", Estado = "SP" } } },

                new Conta { Id = 2, Numero = "1002", Saldo = 250.00m, Cliente = new Cliente { Id = 2, Nome = "Bruno",
                    Endereco = new Endereco { Id = 2, Cidade = "Campinas", Estado = "SP" } } },

                new Conta { Id = 3, Numero = "1003", Saldo = 8900.00m, Cliente = new Cliente { Id = 3, Nome = "Carlos",
                    Endereco = new Endereco { Id = 3, Cidade = "Curitiba", Estado = "PR" } } }

            };

            // # A. Encontrar um objeto específico

            #region encontrarUmObjeto

            Conta? contaEncontrada = null;

            foreach (var conta in contas)
            {

                //Console.WriteLine($"ID: {conta.Id}, Numero: {conta.Numero}, Nome: {conta.Cliente.Nome}, Cidade: {conta.Cliente.Endereco.Cidade}");
                // Se a conta for do numero == "1002", exiba o nome do cliente.

                if (conta.Numero == "1006")
                {
                    //Console.WriteLine($"Nome do cliente da conta 1002: {conta.Cliente.Nome}");
                    contaEncontrada = conta;
                    break; // Para evitar continuar iterando após encontrar a conta desejada
                }
                

            }

            contaEncontrada = contas.FirstOrDefault(c => c.Numero == "1002");
            #endregion

            // # B. Filtrando e mapeando dados
            #region filtrandoEMapeando
            // Usando um foreach busque apenas os "nome" dos clientes que moram em "SP" e exiba-os.
            List<string> clientesSP = new();

            foreach (var conta in contas)
            {
                if(conta.Cliente.Endereco.Estado == "SP")
                {
                    clientesSP.Add(conta.Cliente.Nome);
                    
                }
            }

            var nomesSP = contas
                .Where(contas => contas.Cliente.Endereco.Estado == "SP")
                .Select(contas => contas.Cliente.Nome)
                .ToList();

            /* No SqL server seria assim:
             select Cliente.Nome from Conta 
	            inner join Cliente on Cliente.Id = ClienteId
	            inner join Endereco on EnderecoId = Endereco.Id
	            where Estado = 'SP';
             */
            #endregion

            // # C. Agregação de dados

            decimal saldoTotal = 0;
            foreach(var conta in contas)
            {
                saldoTotal += conta.Saldo;
            }

            Console.WriteLine($"Saldo total de todas as contas: {saldoTotal}");

            // suando linq:
            saldoTotal = contas.Sum(c => c.Saldo);
            Console.WriteLine($"Saldo total de todas as contas: {saldoTotal}");

            /* em slq server:
             select SUM(Saldo) from Conta;
             */


            // fazer a soma so de SP

        }

    }

}