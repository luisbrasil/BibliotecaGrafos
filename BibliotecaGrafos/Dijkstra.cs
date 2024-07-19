using System;
using System.Collections.Generic;
using BibliotecaGrafos;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var graph = Grafo<int, double>.GerarGrafoAleatorioInteiros(6); // Definindo o grafo utilizando a biblioteca
        var startNode = graph.Nos[0];
        var distances = Dijkstra(graph, startNode); // Passando informações do grafo para o algoritmo Dijkstra

        Console.WriteLine("Distâncias do nó " + startNode.Valor + " para todos os outros nós:");
        foreach (var kvp in distances)
        {
            Console.WriteLine("Nó " + kvp.Key.Valor + ": " + kvp.Value);
        }
    }

    static Dictionary<No<T>, double> Dijkstra<T>(Grafo<T, double> graph, No<T> startNode)
    {
        var distances = new Dictionary<No<T>, double>();
        var priorityQueue = new SortedSet<(double, No<T>)>(
            Comparer<(double, No<T>)>.Create((x, y) => 
            {
                if (x.Item1 == y.Item1)
                {
                    return x.Item2.Id.CompareTo(y.Item2.Id);
                }
                else
                {
                    return x.Item1.CompareTo(y.Item1);
                }
            })
        );

        var visited = new HashSet<No<T>>();

        foreach (var node in graph.Nos)
        {
            distances[node] = double.MaxValue;
        }
        distances[startNode] = 0;

        priorityQueue.Add((0, startNode));

        while (priorityQueue.Count > 0)
        {
            var (currentDistance, currentNode) = priorityQueue.Min;
            priorityQueue.Remove(priorityQueue.Min);

            if (visited.Contains(currentNode))
            {
                continue;
            }
            visited.Add(currentNode);

            foreach (var edge in currentNode.Arestas)
            {
                var neighbor = edge.NoFinal;
                var weight = edge.Peso;
                double distance = currentDistance + weight;

                if (distance < distances[neighbor])
                {
                    distances[neighbor] = distance;
                    priorityQueue.Add((distance, neighbor));
                }
            }
        }

        return distances;
    }
}
