using System.Diagnostics;
using BibliotecaGrafos.Algoritimos;

namespace BibliotecaGrafos;

static class Program{
    public static void Main()
    {
        var teste = Grafo<int>.GerarGrafoAleatorioInteirosConexo(6);

        while (!teste.EhConexo())
        {
            teste = Grafo<int>.GerarGrafoAleatorioInteirosConexo(6);
        }
        
        teste.ImprimirMatrizAdjacencia();
        
        Console.WriteLine("\n");

        Console.WriteLine("FloydWarshall:");
        var stopwatch = Stopwatch.StartNew();
        FloydWarshal.FloydWarshall(teste);
        stopwatch.Stop();

        var tempoFloydWarshall = stopwatch.Elapsed;
        
        Console.WriteLine("\n");

        Console.WriteLine("Dijkstra:");
        stopwatch.Restart();
        Dijkstra.RunDijkstra(teste, teste.Nos.First(), teste.Nos.Last());
        stopwatch.Stop();
        
        var tempoDijkstra = stopwatch.Elapsed;
        
        Console.WriteLine($"Tempo de execução (FloydWarshall): {tempoFloydWarshall}");
        Console.WriteLine($"Tempo de execução (Dijkstra): {tempoDijkstra}");
    }
}