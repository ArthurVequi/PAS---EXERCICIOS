using System;

namespace ExerciciosRevisão.nivel_dificil
{
    public class Extrato
    {
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }

        public Extrato(decimal valor)
        {
            Data = DateTime.Now;
            Valor = valor;
        }
    }

    public class Conta
    {
        protected string Nome { get; set; }
        protected int NumConta { get; set; }
        protected decimal Saldo { get; set; }
        protected Extrato[] Extratos { get; set; }
        protected int IndiceExtrato { get; set; }

        public Conta(string nome, int numConta)
        {
            Nome = nome;
            NumConta = numConta;
            Saldo = 0;
            Extratos = new Extrato[1000];
            IndiceExtrato = 0;
        }

        public virtual void Depositar(decimal valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
                if (IndiceExtrato < 1000)
                {
                    Extratos[IndiceExtrato] = new Extrato(valor);
                    IndiceExtrato++;
                }
                Console.WriteLine($"Depósitado {valor}!");
            }
        }

        public virtual void Sacar(decimal valor)
        {
            if (valor > 0 && valor <= Saldo)
            {
                Saldo -= valor;
                if (IndiceExtrato < 1000)
                {
                    Extratos[IndiceExtrato] = new Extrato(-valor);
                    IndiceExtrato++;
                }
                Console.WriteLine($"Saque de {valor} realizado!");
            }
            else
            {
                Console.WriteLine("Saque inválido!");
            }
        }

        public virtual void ExibirInfo()
        {
            Console.WriteLine($"Conta: {NumConta}\nTitular: {Nome}\nSaldo: R${Saldo}");
        }

        public void ExibirExtrato()
        {
            Console.WriteLine($"Saldo: {Saldo}");

            if (IndiceExtrato == 0)
            {
                Console.WriteLine("Sem movimentações.");
                return;
            }
        }
    }

    public class ContaBancaria : Conta
    {
        private string CartaoNumero { get; set; }
        private string CartaoValidade { get; set; }

        public ContaBancaria(string nome, int numConta) : base(nome, numConta)
        {
            CartaoNumero = null;
            CartaoValidade = null;
        }
        public void AdicionarCartao(string numero, string validade)
        {
            CartaoNumero = numero;
            CartaoValidade = validade;
            Console.WriteLine($"Cartão {numero} adicionado!");
        }

        public void SacarComCartao(string numero, string validade, decimal valor)
        {
            if (CartaoNumero == numero && CartaoValidade == validade)
            {
                Sacar(valor);
            }
            else
            {
                Console.WriteLine("Cartão inválido!");
            }
        }

        public override void ExibirInfo()
        {
            base.ExibirInfo();
            if (CartaoNumero != null)
            {
                Console.WriteLine($"  Cartão: {CartaoNumero}\nValidade: {CartaoValidade}");
            }
        }
    }

    public class Teste
    {
        public static void Main()
        {
            ContaBancaria conta1 = new ContaBancaria("João Silva", 1001);
            ContaBancaria conta2 = new ContaBancaria("Maria Santos", 1002);
            ContaBancaria conta3 = new ContaBancaria("Pedro Costa", 1003);

            // Operações básicas
            conta1.Depositar(1000);
            conta1.Sacar(200);
            conta1.Depositar(500);

            conta2.Depositar(2000);
            conta2.Sacar(300);
            conta2.Depositar(100);

            conta3.Depositar(1500);
            conta3.Sacar(100);
            conta3.Sacar(50);

            // Relatório 1: Apenas saldo
            conta1.ExibirInfo();
            conta2.ExibirInfo();
            conta3.ExibirInfo();

            // Relatório 2: Com extratos
            conta1.ExibirExtrato();
            conta2.ExibirExtrato();
            conta3.ExibirExtrato();

            // Adicionar cartões
            conta1.AdicionarCartao("1234-5678-9012-3456", "12/25");
            conta2.AdicionarCartao("9876-5432-1098-7654", "08/24");
            conta3.AdicionarCartao("5555-4444-3333-2222", "10/26");

            // Saques com cartão
            conta1.SacarComCartao("1234-5678-9012-3456", "12/25", 150);
            conta2.SacarComCartao("9876-5432-1098-7654", "08/24", 250);
            conta3.SacarComCartao("5555-4444-3333-2222", "10/26", 75);

            // Teste com cartão inválido
            conta1.SacarComCartao("1111-1111-1111-1111", "12/25", 100);

            // Relatório 3: Final com cartão e extrato
            conta1.ExibirInfo();
            conta2.ExibirInfo();
            conta3.ExibirInfo();

            conta1.ExibirExtrato();
            conta2.ExibirExtrato();
            conta3.ExibirExtrato();
        }
    }
}
