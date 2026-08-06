using System;

public class ContaNormal : ContaBancaria {
    public ContaNormal(int numConta, string nomeTitular, decimal saldo) : base(numConta, nomeTitular, saldo) {
    }

    public override void Saque(decimal valor) {
        if (valor > 0 && Saldo >= valor) {
            base.Saque(valor);
        } 
        else {
            Console.WriteLine("Saldo insuficiente para realizar o saque");
        }
    }
}
