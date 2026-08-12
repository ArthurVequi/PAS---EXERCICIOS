using System;

public class ContaEspecial : ContaBancaria {
    private decimal Limite { get; set; }

    public ContaEspecial(int numConta, string nomeTitular, decimal saldo, decimal limite) : base(numConta, nomeTitular, saldo) {
        Limite = limite;
    }
    public override void Saque(decimal valor) {
        if (valor <= 0) {
            Console.WriteLine("Valor inválido para saque.");
            return;
        }
        if ((Saldo + Limite) >= valor) {
            base.Saque(valor);
        }
        else {
            Console.WriteLine("Saldo insuficiente para realizar o saque");
        }
    }
}
