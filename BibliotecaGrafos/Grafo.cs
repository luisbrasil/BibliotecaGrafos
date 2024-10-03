using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaGrafos;

public class Grafo<T>
{
    public List<No<T>> Nos { get; private set; }

    public Grafo(int qtdeNos)
    {
        Nos = new List<No<T>>(qtdeNos);
    }

    public No<T> AdicionarNo(T value)
    {
        if (Nos.Count == Nos.Capacity)
        {
            throw new InvalidOperationException("Alocação maior do que reservada");
        }
        
        var no = new No<T>(Nos.Count, value);
        Nos.Add(no);
        
        return no;
    }
    
    public void AdicionarAresta(No<T> no, Aresta<T> aresta)
    {
        no.Arestas.Add(aresta);
    }
    
    public void RemoverNo(No<T> no)
    {
        Nos.Remove(no);
    }
    
    public No<T>? ObterNo(Func<No<T>, bool> predicate)
    {
        return Nos.FirstOrDefault(predicate);
    }
    
    public bool GrafoCompleto()
    {
        var qtdeNos = Nos.Count;
        var matrizAdj = new bool[qtdeNos, qtdeNos];

        foreach (var no in Nos)
        {
            foreach (var aresta in no.Arestas)
            {
                matrizAdj[no.Id, aresta.NoFinal.Id] = true;
            }
        }

        for (var i = 0; i < qtdeNos; i++)
        {
            for (var j = 0; j < qtdeNos; j++)
            {
                if (i != j && !matrizAdj[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }
    
    public static Grafo<int> GerarGrafoAleatorioInteiros(int qtdeNos)
    {
        var random = new Random();
        const int lowerBound = 0;
        const int upperBound = 100;

        var grafo = new Grafo<int>(qtdeNos);
        
        for (var i = 0; i < qtdeNos; i++)
        {
            grafo.AdicionarNo(i);
        }

        for (var i = 0; i < qtdeNos; i++)
        {
            for (var j = 0; j < qtdeNos; j++)
            {
                if(i == j)
                    continue;

                var sorteado = random.NextSingle();
                if (sorteado < 0.65) continue;
                var doubleAleatorio = random.Next(lowerBound,upperBound);

                grafo.AdicionarAresta(grafo.Nos[i], new Aresta<int>(doubleAleatorio, grafo.Nos[i], grafo.Nos[j]));
            }
        }

        return grafo;
    }
    
    public void ImprimirMatrizAdjacencia()
    {
        var n = Nos.Count;
        var matriz = new double[n, n];

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                matriz[i, j] = 0;
            }
        }

        foreach (var no in Nos)
        {
            foreach (var aresta in no.Arestas)
            {
                var origem = no.Id;
                var destino = aresta.NoFinal.Id;
                matriz[origem, destino] = aresta.Peso;
            }
        }

        Console.WriteLine("Matriz de Adjacência:");
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                Console.Write(matriz[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
    
    public bool EhConexo()
    {
        if (Nos.Count == 0)
            return true;

        var visitados = new HashSet<No<T>>();
        DepthFirstSearch(Nos[0], visitados);

        return visitados.Count == Nos.Count;
    }

    private static void DepthFirstSearch(No<T> no, HashSet<No<T>> visitados)
    {
        visitados.Add(no);
        foreach (var aresta in no.Arestas)
        {
            var noAdjacente = aresta.NoInicial.Equals(no) ? aresta.NoFinal : aresta.NoInicial;
            if (!visitados.Contains(noAdjacente))
            {
                DepthFirstSearch(noAdjacente, visitados);
            }
        }
    }
    
    public static Grafo<int> GerarGrafoAleatorioInteiroConexo(int qtdeNos)
    {
        var grafo = Grafo<int>.GerarGrafoAleatorioInteiros(qtdeNos);

        while (!grafo.EhConexo())
        {
            grafo = Grafo<int>.GerarGrafoAleatorioInteiros(qtdeNos);
        }

        return grafo;
    }
}