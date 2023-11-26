using System;
using System.Collections.Generic;

class Grafo
{
    int V;
    List<int>[] adj;

    public Grafo(int V)
    {
        this.V = V;
        adj = new List<int>[V];
        for (int i = 0; i < V; i++)
            adj[i] = new List<int>();
    }

    public void AddAresta(int u, int v)
    {
        adj[u].Add(v);
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
                q.Enqueue(i);
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
                    q.Enqueue(node);
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
            Console.Write(i + " ");
        }
    }
}

class Program
{
    static void Main()
    {
        Grafo g = new Grafo(6);
        g.AddAresta(0, 1);
        g.AddAresta(0, 2);
        g.AddAresta(1, 3);
        g.AddAresta(2, 3);
        g.AddAresta(2, 5);
        g.AddAresta(3, 4);
        g.AddAresta(3, 5);

        
        g.OrdenacaoTopologica();
    }
}
