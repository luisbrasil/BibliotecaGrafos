namespace BibliotecaGrafos;

public static class GrafoBuilder
{
    public static Grafo<int> GrafoExemplo1()
    {
        const int qtdeNos = 8;
        
        var grafo = new Grafo<int>(qtdeNos);
        for (var i = 0; i < qtdeNos; i++)
        {
            grafo.AdicionarNo(i);
        }
        
        // A <-> B (15)
        grafo.AdicionarAresta(grafo.Nos[0], new Aresta<int>(15, grafo.Nos[0], grafo.Nos[1]));
        grafo.AdicionarAresta(grafo.Nos[1], new Aresta<int>(15, grafo.Nos[1], grafo.Nos[0])); 
        
        // A <-> C (10)
        grafo.AdicionarAresta(grafo.Nos[0], new Aresta<int>(10, grafo.Nos[0], grafo.Nos[2]));
        grafo.AdicionarAresta(grafo.Nos[2], new Aresta<int>(10, grafo.Nos[2], grafo.Nos[0]));
        
        // A <-> E (2)
        grafo.AdicionarAresta(grafo.Nos[0], new Aresta<int>(2, grafo.Nos[0], grafo.Nos[4]));
        grafo.AdicionarAresta(grafo.Nos[4], new Aresta<int>(2, grafo.Nos[4], grafo.Nos[0]));
        
        // B <-> D (10)
        grafo.AdicionarAresta(grafo.Nos[1], new Aresta<int>(10, grafo.Nos[1], grafo.Nos[3]));
        grafo.AdicionarAresta(grafo.Nos[3], new Aresta<int>(10, grafo.Nos[3], grafo.Nos[1]));
        
        // B <-> F (2)
        grafo.AdicionarAresta(grafo.Nos[1], new Aresta<int>(2, grafo.Nos[1], grafo.Nos[5]));
        grafo.AdicionarAresta(grafo.Nos[5], new Aresta<int>(2, grafo.Nos[5], grafo.Nos[1]));
        
        // C <-> D (15)
        grafo.AdicionarAresta(grafo.Nos[2], new Aresta<int>(15, grafo.Nos[2], grafo.Nos[3]));
        grafo.AdicionarAresta(grafo.Nos[3], new Aresta<int>(15, grafo.Nos[3], grafo.Nos[2]));
        
        // C <-> G (2)
        grafo.AdicionarAresta(grafo.Nos[2], new Aresta<int>(2, grafo.Nos[2], grafo.Nos[6]));
        grafo.AdicionarAresta(grafo.Nos[6], new Aresta<int>(2, grafo.Nos[6], grafo.Nos[2]));
        
        // D <-> H (2)
        grafo.AdicionarAresta(grafo.Nos[3], new Aresta<int>(2, grafo.Nos[3], grafo.Nos[7]));
        grafo.AdicionarAresta(grafo.Nos[7], new Aresta<int>(2, grafo.Nos[7], grafo.Nos[3]));
        
        // E <-> F (3)
        grafo.AdicionarAresta(grafo.Nos[4], new Aresta<int>(3, grafo.Nos[4], grafo.Nos[5]));
        grafo.AdicionarAresta(grafo.Nos[5], new Aresta<int>(3, grafo.Nos[5], grafo.Nos[4]));
        
        // E <-> G (1)
        grafo.AdicionarAresta(grafo.Nos[4], new Aresta<int>(1, grafo.Nos[4], grafo.Nos[6]));
        grafo.AdicionarAresta(grafo.Nos[6], new Aresta<int>(1, grafo.Nos[6], grafo.Nos[4]));
        
        // F <-> H (1)
        grafo.AdicionarAresta(grafo.Nos[5], new Aresta<int>(1, grafo.Nos[5], grafo.Nos[7]));
        grafo.AdicionarAresta(grafo.Nos[7], new Aresta<int>(1, grafo.Nos[7], grafo.Nos[5]));
        
        // G <-> H (3)
        grafo.AdicionarAresta(grafo.Nos[6], new Aresta<int>(3, grafo.Nos[6], grafo.Nos[7]));
        grafo.AdicionarAresta(grafo.Nos[7], new Aresta<int>(3, grafo.Nos[7], grafo.Nos[6]));

        return grafo;
    }
}