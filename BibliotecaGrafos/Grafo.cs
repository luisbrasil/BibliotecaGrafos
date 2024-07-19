namespace BibliotecaGrafos;

public class Grafo<T, TK>
{
    public List<No<T>> Nos { get; private set; }

    public Grafo(int qtdeNos)
    {
        Nos = new List<No<T>>(qtdeNos);
    }

    public No<T> AdicionarNo(T value)
    {
        if (Nos.Count == Nos.Capacity)
        {
            throw new InvalidOperationException("Alocação maior do que reservada");
        }
        
        var no = new No<T>(Nos.Count, value);
        Nos.Add(no);
        
        return no;
    }
    
    public void RemoverNo(No<T> no)
    {
        Nos.Remove(no);
    }
    
    public No<T>? ObterNo(Func<No<T>, bool> predicate)
    {
        return Nos.FirstOrDefault(predicate);
    }
    
    public void AdicionarAresta(double peso, No<T> noInicial, No<T> noFinal)
    {
        var aresta = new Aresta<T>(peso, noInicial, noFinal);
        noInicial.AdicionarAresta(aresta);
        
        var reverseEdge = new Aresta<T>(peso, noFinal, noInicial);
        noFinal.AdicionarAresta(reverseEdge);
    }
    
    public void RemoverAresta(Aresta<T> aresta)
    {
        aresta.NoInicial.RemoverAresta(aresta);
        aresta.NoFinal.RemoverAresta(aresta);
    }
    
    public bool GrafoCompleto()
    {
        var qtdeNos = Nos.Count;
        var matrizAdj = new bool[qtdeNos, qtdeNos];

        foreach (var no in Nos)
        {
            foreach (var aresta in no.Arestas)
            {
                matrizAdj[no.Id, aresta.NoFinal.Id] = true;
            }
        }

        for (var i = 0; i < qtdeNos; i++)
        {
            for (var j = 0; j < qtdeNos; j++)
            {
                if (i != j && !matrizAdj[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }
    
    public static Grafo<int, double> GerarGrafoAleatorioInteiros(int qtdeNos)
    {
        var random = new Random();
        const int lowerBound = 0;
        const int upperBound = 100;

        var grafo = new Grafo<int, double>(qtdeNos);
        No<int>? noAnterior = null;

        for (var i = 0; i < qtdeNos; i++)
        {
            grafo.AdicionarNo(i);
        }

        var noVisitado = new bool[grafo.Nos.Count];
        for (var i = 0; i < qtdeNos - 1; i++)
        {
            var noInicial = grafo.Nos[i];

            for (var j = 1; j < qtdeNos; j++)
            {
                var doubleAleatorio = lowerBound + (upperBound - lowerBound) * random.NextDouble();
                var noFinal = grafo.Nos[j];

                if (!noVisitado[noFinal.Id] && noFinal != noAnterior && noFinal != noInicial)
                {
                    grafo.AdicionarAresta(doubleAleatorio, noInicial, noFinal);
                }
            }
            noVisitado[noInicial.Id] = true;
            noAnterior = noInicial;
        }

        return grafo;
    }
    
    private void ImprimirGrafoRecursivo(No<T> noAtual, List<bool> nosVisitados, ref double custoAcumulado, ref No<T>? ultimoNo)
    {
        //if (noAtual.Arestas.Count != 2) return;
        
        foreach (var aresta in noAtual.Arestas)
        {
            var noDestino = aresta.NoFinal;
            if (nosVisitados[noDestino.Id]) continue;
            nosVisitados[noDestino.Id] = true;
            Console.Write(" " + noDestino.Valor);
            ultimoNo = noDestino;
            custoAcumulado += aresta.Peso;
            ImprimirGrafoRecursivo(noDestino, nosVisitados, ref custoAcumulado, ref ultimoNo);
        }
    }

    public void ImprimirGrafo()
    {
        var nosVisitados = new List<bool>(new bool[Nos.Count]);
        var noInicial = Nos[0];
        No<T>? ultimoNo = null;
        double custoAcumulado = 0;

        nosVisitados[noInicial.Id] = true;
        Console.Write(" " + noInicial.Valor);
        ImprimirGrafoRecursivo(noInicial, nosVisitados, ref custoAcumulado, ref ultimoNo);

        Console.WriteLine("[" + ultimoNo.Valor + "]");
        if (ultimoNo.Arestas.Count == 2)
        {
            foreach (var aresta in ultimoNo.Arestas.Where(aresta => aresta.NoFinal == noInicial))
            {
                custoAcumulado += aresta.Peso;
                break;
            }
        }

        Console.WriteLine("    Custo acumulado: " + custoAcumulado);
    }
}