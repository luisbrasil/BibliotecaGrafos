using System.Collections.Generic;

namespace BibliotecaGrafos;

public class No<T>
{
    public int Id { get; private set; }
    public T Valor { get; set; }
    public List<Aresta<T>> Arestas { get; private set; }

    public No(int id, T valor)
    {
        Id = id;
        Valor = valor;
        Arestas = new List<Aresta<T>>();
    }

    public void AdicionarAresta(Aresta<T> aresta)
    {
        Arestas.Add(aresta);
    }

    public void RemoverAresta(Aresta<T> aresta)
    {
        Arestas.Remove(aresta);
    }
}