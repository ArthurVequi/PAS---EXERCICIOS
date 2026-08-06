using System;

class Program
{
    static void Main(string[] args)
    {
        // Teste Conta Normal
        Console.WriteLine("\nConta Normal");
        ContaNormal contaNormal = new ContaNormal(1111, "Arthur Normal", 500.00m); // Criação de uma conta normal, saldo 500
        
        Console.WriteLine($"Cliente: {contaNormal.NomeTitular} | Saldo Inicial: R$ {contaNormal.Saldo}");
        
        contaNormal.Depositar(200.00m); // deposito de 200
        contaNormal.Saque(600.00m); // saque de 600 (sucesso)
        contaNormal.Saque(200.00m); // saque de 200 (erro por falta de saldo)
        
        Console.WriteLine("\n--- Extrato Conta Normal ---");
        contaNormal.ExtratoBancario.Listar();
        Console.WriteLine($"Saldo Final: R$ {contaNormal.Saldo}\n");

        // Teste Conta Especial
        Console.WriteLine("Conta Especial");
        ContaEspecial contaEspecial = new ContaEspecial(2222, "Arthur Especial", 100.00m, 300.00m); // Criação de uma conta especial, saldo 100 e limite 300
        
        Console.WriteLine($"Cliente: {contaEspecial.NomeTitular} | Saldo: R$ {contaEspecial.Saldo} |Limite: R$ 300,00");

        contaEspecial.Saque(350.00m); // saque de 350
        contaEspecial.Saque(100.00m); // saque de 100 (erro por falta de saldo)
        
        Console.WriteLine("\n--- Extrato Conta Especial ---");
        contaEspecial.ExtratoBancario.Listar();
        Console.WriteLine($"Saldo Final: R$ {contaEspecial.Saldo}\n");
    }
}
