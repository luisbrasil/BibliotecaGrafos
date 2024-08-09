using System.Globalization;

namespace BibliotecaGrafos.Algoritimos;

class FloydWarshal
{
    private const int Infinite = 9999;
   
    public static void FloydWarshall(Grafo<int> grafo)
    {
        var qtdeNos = grafo.Nos.Count;
        var dist = new double[qtdeNos, qtdeNos];

        for (var i = 0; i < qtdeNos; i++)
        {
            for (var j = 0; j < qtdeNos; j++)
            {
                if (i == j)
                    dist[i, j] = 0;
                else
                    dist[i, j] = Infinite;
            }
        }
        
        foreach (var no in grafo.Nos)
        {
            foreach (var aresta in no.Arestas)
            {
                var u = no.Id;
                var v = aresta.NoFinal.Id;
                dist[u, v] = aresta.Peso;
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
                    }
                }
            }
        }
        
        Print(dist, qtdeNos);
    }
    
    private static void Print(double[,] distance, int verticesCount)
    {
        Console.WriteLine("Menor distancia entre cada par de vertices:");

        for (var i = 0; i < verticesCount; ++i)
        {
            for (var j = 0; j < verticesCount; ++j)
            {
                if (Math.Abs(distance[i, j] - Infinite) < 0.1)
                    Console.Write("Non".PadLeft(7));
                else
                    Console.Write(distance[i, j].ToString(CultureInfo.CurrentCulture).PadLeft(7));
            }

            Console.WriteLine();
        }
    }
}