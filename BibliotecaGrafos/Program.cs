namespace BibliotecaGrafos;

static class Program{
    public static void Main()
    {
        var teste = Grafo<int>.GerarGrafoAleatorioInteirosConexo(6);

        if (!teste.EhConexo())
        {
            teste = Grafo<int>.GerarGrafoAleatorioInteirosConexo(6);
        }

        teste.ImprimirGrafo();
    }
}