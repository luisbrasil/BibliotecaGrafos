using BibliotecaGrafos.Algoritimos;

namespace BibliotecaGrafos;

static class Program{
    public static void Main()
    {
        var teste = Grafo<int>.GerarGrafoAleatorioInteirosConexo(6);

        if (!teste.EhConexo())
        {
            teste = Grafo<int>.GerarGrafoAleatorioInteirosConexo(6);
        }

        Console.WriteLine("FloydWarshal:");
        FloydWarshal.FloydWarshall(teste, teste.Nos.First(),teste.Nos.Last());
        Console.WriteLine("\nDijkstra:");
        Dijkstra.RunDijkstra(teste, teste.Nos.First(), teste.Nos.Last());
    }
}