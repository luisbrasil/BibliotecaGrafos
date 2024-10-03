using System.Diagnostics;
using BibliotecaGrafos.Algoritimos;

namespace BibliotecaGrafos;

static class Program{
    public static void Main()
    {
        //var grafo = Grafo<int>.GerarGrafoAleatorioInteiroConexo(6);
        var grafo = GrafoBuilder.GrafoExemplo1();  
        
        grafo.ImprimirMatrizAdjacencia();
        
        Console.WriteLine("\n");

        Console.WriteLine("FloydWarshall:");
        var stopwatch = Stopwatch.StartNew();
        FloydWarshal.FloydWarshall(grafo);
        stopwatch.Stop();

        var tempoFloydWarshall = stopwatch.Elapsed;
        
        Console.WriteLine("\n");

        Console.WriteLine("Dijkstra:");
        stopwatch.Restart();
        Dijkstra.RunDijkstra(grafo, grafo.Nos.First(), grafo.Nos.Last());
        stopwatch.Stop();
        
        var tempoDijkstra = stopwatch.Elapsed;
        
        Console.WriteLine($"Tempo de execução (FloydWarshall): {tempoFloydWarshall}");
        Console.WriteLine($"Tempo de execução (Dijkstra): {tempoDijkstra}");
    }
}