using BibliotecaGrafos;

var teste = Grafo<int>.GerarGrafoAleatorioInteirosConexo(6);

if (!teste.EhConexo())
{
    teste = Grafo<int>.GerarGrafoAleatorioInteirosConexo(6);
}

teste.ImprimirGrafo();