namespace BibliotecaGrafos;

public class Aresta<T>
{
    public double Peso { get; private set; }
    public No<T> NoInicial { get; private set; }
    public No<T> NoFinal { get; private set; }

    public Aresta(double peso, No<T> noInicial, No<T> noFinal)
    {
        Peso = peso;
        NoInicial = noInicial;
        NoFinal = noFinal;
    }
}