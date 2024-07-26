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
    
    public static Grafo<int> GerarGrafoAleatorioInteirosConexo(int qtdeNos)
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
                var doubleAleatorio = lowerBound + (upperBound - lowerBound) * random.NextDouble();

                grafo.Nos[i].AdicionarAresta(new Aresta<int>(doubleAleatorio, grafo.Nos[i], grafo.Nos[j]));
            }
        }

        return grafo;
    }
    
    private void ImprimirGrafoRecursivo(No<T> noAtual, List<bool> nosVisitados, ref double custoAcumulado, ref No<T>? ultimoNo)
    {
        //if (noAtual.Arestas.Count != 2) return;
        
        foreach (var aresta in noAtual.Arestas)
        {
            var noDestino = aresta.NoFinal;
            if (nosVisitados[noDestino.Id]) continue;
            nosVisitados[noDestino.Id] = true;
            Console.Write(" " + noDestino.Valor);
            ultimoNo = noDestino;
            custoAcumulado += aresta.Peso;
            ImprimirGrafoRecursivo(noDestino, nosVisitados, ref custoAcumulado, ref ultimoNo);
        }
    }

    public void ImprimirGrafo()
    {
        var nosVisitados = new List<bool>(new bool[Nos.Count]);
        var noInicial = Nos[0];
        No<T>? ultimoNo = null;
        double custoAcumulado = 0;

        nosVisitados[noInicial.Id] = true;
        Console.Write(" " + noInicial.Valor);
        ImprimirGrafoRecursivo(noInicial, nosVisitados, ref custoAcumulado, ref ultimoNo);

        Console.WriteLine("[" + ultimoNo.Valor + "]");
        if (ultimoNo.Arestas.Count == 2)
        {
            foreach (var aresta in ultimoNo.Arestas.Where(aresta => aresta.NoFinal == noInicial))
            {
                custoAcumulado += aresta.Peso;
                break;
            }
        }

        Console.WriteLine("    Custo acumulado: " + custoAcumulado);
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
}