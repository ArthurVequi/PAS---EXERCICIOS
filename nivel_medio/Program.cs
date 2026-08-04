using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciciosRevisão.nivel_medio
{
    public class Livro
    {
        private string Titulo { get; set; }
        private string Autor { get; set; }
        private int AnoPublicacao { get; set; }
        private int Paginas { get; set; }
        private bool Emprestado { get; set; }

        public void Emprestimo()
        {
            Emprestado = true;
            Console.WriteLine($"Livro {Titulo} emprestado!!");
        }
        public void Devolucao()
        {
            Emprestado = false;
            Console.WriteLine($"Livro {Titulo} devolvido com sucesso!");
        }
        public bool Status(string livro)
        {
            if (Emprestado)
            {
                Console.WriteLine($"O livro {Titulo} já foi emprestado");
                return true;
            }
            else
            {
                Console.WriteLine($"O livro {Titulo} está disponível");
                return false;
            }
        }
    }
    public class Lampada
    {
        private bool Estado { get; set; }
        private bool Queimada { get; set; }
        public float Potencia { get; set; }
        public float Voltagem { get; set; }
        private static Random random = new Random();

        public Lampada(float potencia, float voltagem)
        {
            Estado = false;
            Queimada = false;
            Potencia = potencia;
            Voltagem = voltagem;
        }

        public bool LigarLampada()
        {
            if (Queimada)
            {
                Console.WriteLine("Lâmpada queimada! Não é possível ligar.");
                return false;
            }

            if (Estado)
            {
                Console.WriteLine("Lâmpada já está ligada!");
                return false;
            }

            // 15% de chance de queimar ao ligar
            if (random.Next(100) < 15)
            {
                Queimada = true;
                Console.WriteLine("A lâmpada queimou ao ser ligada!");
                return false;
            }

            Estado = true;
            Console.WriteLine("Lâmpada ligada!");
            return true;
        }

        public bool DesligarLampada()
        {
            if (!Estado)
            {
                Console.WriteLine("Lâmpada já está desligada!");
                return false;
            }

            Estado = false;
            Console.WriteLine("Lâmpada desligada!");
            return true;
        }

        public void ExibirInfo()
        {
            string statusEstado;
            if (Estado)
            {
                statusEstado = "Ligada";
            }
            else
            {
                statusEstado = "Desligada";
            }

            string statusQueimada;
            if (Queimada)
            {
                statusQueimada = "Queimada";
            }
            else
            {
                statusQueimada = "Ok";
            }

            Console.WriteLine($"Estado: {statusEstado}\nPotência: {Potencia}W\nVoltagem: {Voltagem}V\nSituação: {statusQueimada}");
        }
    }

    public class TesteLampada
    {
        public static void Main(string[] args)
        {
            Lampada lampada = new Lampada(60,110);
            lampada.ExibirInfo(); // estado inicial da lampada
            lampada.LigarLampada();
            lampada.ExibirInfo(); // lampada ligada
            lampada.DesligarLampada();
            lampada.ExibirInfo(); //lampada desligada
        }
    }
}
