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
        {
            if (distancia[i] == int.MaxValue)
                Console.WriteLine(i + "\t\t" + "infinito");
            else
                Console.WriteLine(i + "\t\t" + distancia[i]);
        }
    }

    public static void Main(String[] args)
    {
        int V = 10; // numero de vertices do grafo
        int E = 20; // numero de arestas do grafo

        //toda aresta tem 3 valores: 1: indo do vertice X
        //2: chegando no vertice Y
        //3: peso da aresta de X até Y
        int[,] grafoEsparso = {
            { 0, 1, 10 }, { 0, 3, 20 }, { 0, 4, 20 }, { 0, 5, 5 }, { 0, 6, 15 },
            { 1, 2, -5 }, { 1, 3, 10 }, 
            { 2, 1, 15 }, { 2, 3, 5 },
            { 3, 4, -10 },
            {4, 5, 5},
            {6, 5, 10},
            {7, 0, 5}, {7, 1, 20}, {7, 6, 5},
            {8, 1, 15}, {8, 7, 20}, {8, 9, 10},
            {9, 1, 5}, {9, 2, 15}
            
        };

        int VDesno = 10; // numero de vertices do grafo
        int EDesno = 20; // numero de arestas do grafo

        int[,] grafoDenso = {
            { 0, 1, 5 }, { 0, 2, 10 }, { 0, 3, 15 }, { 0, 4, 20 },
            { 1, 2, 5 }, { 1, 3, 10 }, { 1, 4, 15 },
            { 2, 3, 5 }, { 2, 4, 10 },
            { 3, 4, 5 },
            { 5, 6, 8 }, { 5, 7, 12 }, { 5, 8, 16 }, { 5, 9, 20 },
            { 6, 7, 4 }, { 6, 8, 8 }, { 6, 9, 12 },
            { 7, 8, 4 }, { 7, 9, 8 },
            { 8, 9, 4 },
            { 1, 0, 2 }, { 2, 0, 5 }, { 2, 1, 3 }, { 3, 0, 1 }, { 3, 1, 6 },
            { 3, 2, 4 }, { 4, 0, 7 }, { 4, 1, 9 }, { 4, 2, 11 }, { 4, 3, 13 },
            { 6, 5, 15 }, { 7, 5, 18 }, { 8, 5, 21 }, { 9, 5, 24 },
            { 7, 6, 14 }, { 8, 6, 17 }, { 9, 6, 20 },
            { 8, 7, 11 }, { 9, 7, 14 },
            { 9, 8, 7 }
        };
        

        Console.WriteLine("Algoritmo de Bellman-Ford no Grafo Esparso: ");
        BellmanFord(grafoEsparso, V, E, 0);

        Console.WriteLine("\n");
        
        Console.WriteLine("Algoritmo de Bellman-Ford no Grafo Denso: ");
        BellmanFord(grafoDenso, VDesno, EDesno, 0);
    }
}
