using System;
using System.Collections.Generic;
using BibliotecaGrafos;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var graph = Grafo<int>.GerarGrafoAleatorioInteiros(6); // Definindo o grafo utilizando a biblioteca
        var startNode = graph.Nos[0]; // Seta o primeiro nó como nó inicial
        var distances = Dijkstra(graph, startNode); // Passando informações do grafo para o algoritmo Dijkstra

        Console.WriteLine("Distâncias do nó " + startNode.Valor + " para todos os outros nós:");
        foreach (var kvp in distances) //key value pair
        {
            Console.WriteLine("Nó " + kvp.Key.Valor + ": " + kvp.Value); //valor do nó (indice) + (distancia da aresta)
        }
    }

    
}
