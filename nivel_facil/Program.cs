using System;

public class Circulo
{
    private double Raio { get; set; }

    public double CalcularArea()
    {
        return Math.PI * Math.Pow(Raio, 2);
    }
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * Raio;
    }
    public void ExibirInfo()
    {
        Console.WriteLine($"O raio corresponde a {Raio}, a área a {CalcularArea} e o perímetro a {CalcularPerimetro}");
    }
}

public class ContaBancaria
{
    private int NumConta { get; set; }
    private string Titular { get; set; }
    private decimal Saldo { get; set; }

    public decimal Deposito(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("Digite um valor válido!");
            return Saldo;
        }

        Saldo += valor;
        return Saldo;
    }
    public decimal Saque(decimal valor)
    {
        if (valor > Saldo)
        {
            Console.WriteLine("Valor indisponivel para saque!");
            return Saldo;
        }
        else
        {
            Saldo -= valor;
            return Saldo;
        }
    }
    public void ExibirDados()
    {
        Console.WriteLine($"Titular: {Titular}\n Conta:{NumConta}\n Saldo atual: {Saldo} ");
    }
}

public class Pessoa
{
    private string Nome { get; set; }
    private int Idade { get; set; }
    private string Genero { get; set; }

    public void ExibirInfo()
    {
        Console.WriteLine($"Nome: {Nome}\nIdade: {Idade}\nGenero: {Genero}");
    }
    public bool EhMaior()
    {
        return Idade >= 18;
    }
}

public class Retangulo
{
    private double Largura { get; set; }
    private double Altura { get; set; }

    public Retangulo(double largura, double altura)
    {
        Largura = largura;
        Altura = altura;
    }

    public double CalcularArea()
    {
        return Largura * Altura;
    }

    public double CalcularPerimetro()
    {
        return 2 * (Largura + Altura);
    }
    public void Exibir()
    {
        Console.WriteLine($"Largura: {Largura}\nAltura: {Altura}");
    }
}
