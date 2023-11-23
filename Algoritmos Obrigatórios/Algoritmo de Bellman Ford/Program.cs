using System;

class GFG
{
    static void BellmanFord(int[,] grafo, int V, int E, int raiz)
    {
        //inicializa com todas as distancias sendo infinitas
        int[] distancia = new int[V];
        for (int i = 0; i < V; i++)
            distancia[i] = int.MaxValue;

        // inicializa a distancia da raiz como sendo 0
        distancia[raiz] = 0;

        
        for (int i = 0; i < V - 1; i++)
        {
            for (int j = 0; j < E; j++)
            {
                if (distancia[grafo[j, 0]] != int.MaxValue && distancia[grafo[j, 0]] + grafo[j, 2] < distancia[grafo[j, 1]])
                    distancia[grafo[j, 1]] = distancia[grafo[j, 0]] + grafo[j, 2];
            }
        }

        // procura por ciclo negativo
        for (int i = 0; i < E; i++)
        {
            int x = grafo[i, 0];
            int y = grafo[i, 1];
            int peso = grafo[i, 2];
            if (distancia[x] != int.MaxValue && distancia[x] + peso < distancia[y])
                Console.WriteLine("grafo contains a negative peso cycle");
        }

        Console.WriteLine("Distância do vértice da raiz");
        for (int i = 0; i < V; i++)
            Console.WriteLine(i + "\t\t" + distancia[i]);
    }

    public static void Main(String[] args)
    {
        int V = 7; // numero de vertices do grafo
        int E = 10; // numero de arestas do grafo

        //toda aresta tem 3 valores: 1: indo do vertice X
        //2: chegando no vertice Y
        //3: peso da aresta de X até Y
        int[,] grafo = {
            { 0, 1, 6 }, { 0, 2, 5 }, { 0, 3, 5 },
            { 1, 4, -1 }, 
            { 2, 1, -2 }, { 2, 4, 1 },
            { 3, 2, -2 }, { 3, 5, -1 },
            {4, 6, 3},
            {5, 6, 3}
        };


        BellmanFord(grafo, V, E, 0);
    }
}
