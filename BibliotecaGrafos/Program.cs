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

        Console.WriteLine("FloydWarshal:");
        FloydWarshal.FloydWarshall(teste);
        
        
        Console.WriteLine("\nDijkstra:");
        Dijkstra.RunDijkstra(teste, teste.Nos.First(), teste.Nos.Last());
    }
}