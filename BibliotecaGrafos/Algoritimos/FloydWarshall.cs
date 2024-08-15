using System.Globalization;

namespace BibliotecaGrafos.Algoritimos;

class FloydWarshal
{
    private const int Infinite = 9999;
   
    public static void FloydWarshall(Grafo<int> grafo, No<int> origem, No<int> destino)
    {
        var qtdeNos = grafo.Nos.Count;
        var dist = new double[qtdeNos, qtdeNos];
        var next = new int?[qtdeNos, qtdeNos];  // Matriz para rastrear os caminhos

        for (var i = 0; i < qtdeNos; i++)
        {
            for (var j = 0; j < qtdeNos; j++)
            {
                if (i == j)
                    dist[i, j] = 0;
                else
                    dist[i, j] = Infinite;

                next[i, j] = null;
            }
        }

        foreach (var no in grafo.Nos)
        {
            foreach (var aresta in no.Arestas)
            {
                var u = no.Id;
                var v = aresta.NoFinal.Id;
                dist[u, v] = aresta.Peso;
                next[u, v] = v;  // Armazenando o próximo nó no caminho
            }
        }

        for (var k = 0; k < qtdeNos; k++)
        {
            for (var i = 0; i < qtdeNos; i++)
            {
                for (var j = 0; j < qtdeNos; j++)
                {
                    if (dist[i, j] > dist[i, k] + dist[k, j])
                    {
                        dist[i, j] = dist[i, k] + dist[k, j];
                        next[i, j] = next[i, k];  // Atualizando o caminho
                    }
                }
            }
        }

        if (Math.Abs(dist[origem.Id, destino.Id] - Infinite) < 0.1)
        {
            Console.WriteLine($"Não existe caminho entre origem e destino");
        }
        else
        {
            Console.WriteLine($"Distância mínima de origem para destino: {dist[origem.Id, destino.Id]}");
            Console.Write("Caminho: ");
            PrintPath(next, origem.Id, destino.Id);
        }
    }

    private static void PrintPath(int?[,] next, int origem, int destino)
    {
        if (next[origem, destino] == null)
        {
            Console.WriteLine("Não há caminho disponível.");
            return;
        }

        var path = new List<int> { origem };
        while (origem != destino)
        {
            origem = next[origem, destino].Value;
            path.Add(origem);
        }

        Console.WriteLine(string.Join(" -> ", path));
    }
}