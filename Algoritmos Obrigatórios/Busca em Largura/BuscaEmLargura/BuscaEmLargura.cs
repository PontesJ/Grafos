public class BuscaEmLargura{
    // matriz de adjacência de um grafo esparso
    public int[,] grafo_esparso = new int[10,10]{
        {0,1,1,1,1,0,0,0,0,0},
        {1,0,0,0,1,1,0,0,0,0},
        {1,0,0,1,0,1,0,0,0,0},
        {1,0,1,0,0,1,0,0,1,0},
        {1,1,0,0,0,1,1,1,0,0},
        {0,1,1,1,1,0,1,0,1,0},
        {0,0,0,0,1,1,0,1,1,1},
        {0,0,0,0,1,0,1,0,0,1},
        {0,0,0,1,0,1,1,0,0,1},
        {0,0,0,0,0,0,1,1,1,0}
    };
    // fila que armazena os nós a serem visitados
    public Queue<int> fila_execucao = new Queue<int>();
    public int [] nos_visitados = new int[10];
    public int inicio = 0;
    public int final = 8;
}