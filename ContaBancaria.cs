using System;

public class ContaBancaria {
    public int NumConta { get; protected set; }
    public string NomeTitular { get; protected set; }
    public decimal Saldo { get; protected set; }
    public ListaEncadeada<string> ExtratoBancario { get; protected set; }

    public ContaBancaria(int numConta, string nomeTitular, decimal saldo) {
        NumConta = numConta;
        NomeTitular = nomeTitular;
        Saldo = saldo;
        ExtratoBancario = new ListaEncadeada<string>();
    }

    public void Depositar(decimal valor) {
        if (valor > 0) {
            Saldo += valor;
            ExtratoBancario.Adicionar($"Depósito: R$ {valor}");
        }
    }

    public virtual void Saque(decimal valor) {
        if (valor > 0) {
            Saldo -= valor;
            ExtratoBancario.Adicionar($"Saque: R$ {valor}");
        }
    }
}
