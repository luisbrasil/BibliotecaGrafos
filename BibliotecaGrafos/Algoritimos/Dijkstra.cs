using BibliotecaGrafos;

namespace BibliotecaGrafos.Algoritimos;

class Dijkstra
{
    public static void RunDijkstra<T>(Grafo<T> grafo, No<T> origem, No<T> destino)
    {
        var dist = new Dictionary<No<T>, double>(); // Armazena a menor distância conhecida até cada nó
        var antecessor = new Dictionary<No<T>, No<T>>(); // Armazena o antecessor de cada nó no caminho mais curto
        var filaPrioridade = new SortedSet<(double, No<T>)>(
            Comparer<(double, No<T>)>.Create((x, y) =>
            {
                if (Math.Abs(x.Item1 - y.Item1) < 0.1) // Se as distâncias forem iguais
                {
                    return x.Item2.Id.CompareTo(y.Item2.Id); // Compara IDs
                }

                return x.Item1.CompareTo(y.Item1); // Compara distâncias
            })
        );

        var visitado = new HashSet<No<T>>(); // Armazena os nós que já foram visitados
        foreach (var no in grafo.Nos)
        {
            dist[no] = double.MaxValue; // Inicializa todas as distâncias como infinitas
        }

        dist[origem] = 0; // Distância da origem para ela mesma é 0
        filaPrioridade.Add((0, origem)); // Adiciona a origem à fila de prioridade

        while (filaPrioridade.Count > 0)
        {
            var (distAtual, noAtual) = filaPrioridade.Min; // Obtém o nó com a menor distância
            filaPrioridade.Remove(filaPrioridade.Min); // Remove esse nó da fila

            if (!visitado.Add(noAtual)) // Se o nó já foi visitado, pula para o próximo
            {
                continue;
            }

            if (noAtual.Equals(destino)) // Se chegamos ao destino, podemos parar
            {
                break;
            }

            foreach (var aresta in noAtual.Arestas)
            {
                var vizinho = aresta.NoFinal;
                var peso = aresta.Peso;
                var distancia = distAtual + peso;

                if (distancia < dist[vizinho]) // Se encontramos um caminho mais curto até o vizinho
                {
                    dist[vizinho] = distancia; // Atualiza a distância mínima conhecida
                    antecessor[vizinho] = noAtual; // Registra o nó atual como antecessor do vizinho
                    filaPrioridade.Add((distancia, vizinho)); // Adiciona o vizinho à fila de prioridade
                }
            }
        }

        // Reconstrução e impressão do caminho
        if (Math.Abs(dist[destino] - double.MaxValue) < 0.1)
        {
            // Console.WriteLine("Não existe caminho entre origem e destino");
        }
        else
        {
            // Console.WriteLine($"Distância mínima de origem para destino: {dist[destino]}");
            // Console.Write("Caminho: ");
            var caminho = new Stack<No<T>>();
            var atual = destino;
            while (!atual.Equals(origem))
            {
                caminho.Push(atual);
                atual = antecessor[atual];
            }

            caminho.Push(origem);

            // Console.WriteLine(string.Join(" -> ", caminho.Select(n => (char)(65+n.Id))));
        }
    }
}