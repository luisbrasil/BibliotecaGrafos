class Program
{
    static Dictionary<No<T>, double> Dijkstra<T>(Grafo<T, double> graph, No<T> startNode) // Recebe o grafo e o nó inicial
        {
            var distances = new Dictionary<No<T>, double>(); // Cria um objeto chave/valor com o nó e a distancia
            var priorityQueue = new SortedSet<(double, No<T>)>( 
                Comparer<(double, No<T>)>.Create((x, y) => 
                {
                    if (x.Item1 == y.Item1) //compara se as distancias entre o nó atual e o prox nó são iguais
                    {
                        return x.Item2.Id.CompareTo(y.Item2.Id); //se forem iguais ele coloca o menor ID na frente
                    }
                    else //caso as distâncias sejam diferentes 
                    {
                        return x.Item1.CompareTo(y.Item1); //coloca o nó com menor distancia na frente
                    }
                })
            ); // essa sortedSet é criada de maneira a ordenar os nós da maior para a menor distância



            var visited = new HashSet<No<T>>(); //Cria uma lista vazia de hashs para armazenar os visitados
            foreach (var node in graph.Nos) // percorre todos os nós do grafo
            {
                distances[node] = double.MaxValue; // seta o valor das arestas como infinito. Inicio do Dijkstra
            }
            distances[startNode] = 0; // Seta o primeiro nó com a distancia 0, já que ele é o primeiro. Chave [startNode], valor 0
            priorityQueue.Add((0, startNode)); //adiciona na lista de prioridade o nó inicial com distancia 0 



            while (priorityQueue.Count > 0) // Enquanto a lista de prioridade for maior q 0 roda o laço (inicialmente só tera o startNode)
            {
                var (currentDistance, currentNode) = priorityQueue.Min; //Seta a distancia e o nó como o primeiro valor da lista
                priorityQueue.Remove(priorityQueue.Min); //Deleta o primeiro valor da lista

                if (visited.Contains(currentNode)) //Se o nó atual estiver na lista de visitados ele skipa o while pro proximo item
                {
                    continue;
                }
                visited.Add(currentNode); //se o nó atual não estiver entre os visitados, adiciona ele na lista de visitados



                foreach (var aresta in currentNode.Arestas)// Percorre todas as arestas 
                {
                    var neighbor = aresta.NoFinal; // Cria o "vizinho" com o valor do nó final na ponta da aresta
                    var weight = aresta.Peso; // Cria o peso (distancia) da aresta
                    double distance = currentDistance + weight; // Cria a variavel distancia como sendo a distancia atual + a distancia da aresta atual

                    if (distance < distances[neighbor]) // se a distancia atual (do nó atual) for menor que a distancia da aresta que conecta no nó final (vizinho/neighbor)
                    {
                        distances[neighbor] = distance; // a distancia da aresta que conecta ao nó vizinho é igual a distancia do nó atual
                        // (no começo todos os nós serao infinitos, e a distancia entre eles são setadas a partir dessa linha)
                        priorityQueue.Add((distance, neighbor)); // Adiciona a distancia e o nó vizinho na lista de prioridade
                    }
                }


            }

            return distances;// ao fim do While retorna as distancias dos nós
        }
}