using System;
using System.Collections.Generic;

class Grafo
{
    int V;
    List<int>[] adj;

    public Grafo(int[,] matrizAdjacencia)
    {
        V = matrizAdjacencia.GetLength(0);
        adj = new List<int>[V];
        for (int i = 0; i < V; i++)
        {
            adj[i] = new List<int>();
            for (int j = 0; j < V; j++)
            {
                if (matrizAdjacencia[i, j] == 1)
                {
                    adj[i].Add(j);
                    Console.WriteLine($"Adicionando o nó {j + 1} à lista de adjacências do nó {i + 1}");
                }
                
            }
            Thread.Sleep(1000);
            Console.WriteLine("");
        }
    }

    public void OrdenacaoTopologica()
    {
        int[] grauEntrada = new int[V];

        for (int i = 0; i < V; i++)
        {
            List<int> temp = adj[i];
            foreach (int node in temp)
            {
                grauEntrada[node]++;
            }
        }

        Queue<int> q = new Queue<int>();
        for (int i = 0; i < V; i++)
        {
            if (grauEntrada[i] == 0)
            {
                q.Enqueue(i);
            }
        }

        int cont = 0;
        List<int> ordRes = new List<int>();

        while (q.Count != 0)
        {
            int u = q.Dequeue();
            ordRes.Add(u);

            foreach (int node in adj[u])
            {
                if (--grauEntrada[node] == 0)
                {
                    q.Enqueue(node);
                }
            }
            cont++;
        }

        if (cont != V)
        {
            Console.WriteLine("Existe um ciclo no grafo.");
            return;
        }

        Console.WriteLine("Ordenação Topológica:");
        foreach (int i in ordRes)
        {
            Console.Write((i + 1) + " ");
        }
    }
}

class Program
{
    static void Main()
    {
        int[,] matrizAdjacencia = new int[,]
        {
          { 0, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
          { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
          { 0, 0, 0, 1, 1, 1, 1, 1, 0, 0 },
          { 0, 0, 0, 0, 1, 1, 1, 1, 1, 0 },
          { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 },
          { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1 },
          { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1 },
          { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        Grafo g = new Grafo(matrizAdjacencia);
        g.OrdenacaoTopologica();
    }
}
