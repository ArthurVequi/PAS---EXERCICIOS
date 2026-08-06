using System;

public class ListaEncadeada<T>
{
    public class No
    {
        public T Dado { get; set; }
        public No Proximo { get; set; }

        public No(T dado)
        {
            Dado = dado;
            Proximo = null;
        }
    }

    private No inicio;
    private No fim;
    private int contador;

    public ListaEncadeada()
    {
        inicio = null;
        fim = null;
        contador = 0;
    }

    public void Adicionar(T dado)
    {
        No novoNo = new No(dado);
        if (inicio == null)
        {
            inicio = novoNo;
            fim = novoNo;
        }
        else
        {
            fim.Proximo = novoNo;
            fim = novoNo;
        }
        contador++;
    }

    public void Listar()
    {
        No atual = inicio;
        while (atual != null)
        {
            Console.WriteLine(atual.Dado);
            atual = atual.Proximo;
        }
    }
}
