using System;
using System.Collections.Generic;

class Dijkstra
{
    class Node
    {
        public int destino { get; set; }
        public int Peso { get; set; }
    }

    class AdjLista
    {
        public List<Node> Nodes { get; set; } = new List<Node>();
    }

    class Grafo
    {
        public int V { get; set; }
        public List<AdjLista> Array { get; set; } = new List<AdjLista>();
    }

    static Node NewAdjListaNode(int destino, int peso)
    {
        return new Node { destino = destino, Peso = peso };
    }

    static Grafo CriaGrafo(int V)
    {
        var grafo = new Grafo { V = V };

        for (int i = 0; i < V; ++i)
            grafo.Array.Add(new AdjLista());

        return grafo;
    }

    static void AddAresta(Grafo grafo, int raiz, int destino, int peso)
    {
        grafo.Array[raiz].Nodes.Add(NewAdjListaNode(destino, peso));
        // Certifique-se de que não há arestas adicionadas para os vértices 8 e 9
        if (raiz != 8 && raiz != 9)
        {
            grafo.Array[destino].Nodes.Add(NewAdjListaNode(raiz, peso));
        }
    }

    static void PrintArray(int[] dist, int n)
    {
        Console.WriteLine("Distância do vértice da raiz");
        for (int i = 0; i < n; ++i)
        {
            if (dist[i] == int.MaxValue)
            {
                Console.WriteLine($"{i}\t\tCaminho inexistente");
            }
            else
            {
                Console.WriteLine($"{i}\t\t{dist[i]}");
            }
        }
    }

    static void AlgoritmoDijkstra(Grafo grafo, int raiz)
    {
        int V = grafo.V;
        int[] dist = new int[V];
        var minHeap = new SortedSet<(int, int)>(Comparer<(int, int)>.Create((a, b) => a.Item1.CompareTo(b.Item1)));

        for (int v = 0; v < V; ++v)
        {
            dist[v] = (v == raiz) ? 0 : int.MaxValue;
            minHeap.Add((dist[v], v));
        }

        while (minHeap.Count != 0)
        {
            var (dist_u, u) = minHeap.Min;
            minHeap.Remove((dist_u, u));

            foreach (var node in grafo.Array[u].Nodes)
            {
                int v = node.destino;
                int peso = node.Peso;

                if (dist[u] != int.MaxValue && dist[u] + peso < dist[v])
                {
                    minHeap.Remove((dist[v], v));
                    dist[v] = dist[u] + peso;
                    minHeap.Add((dist[v], v));
                }
            }
        }

        // Printa na tela o vértice e sua distância 
        // da raiz definida
        PrintArray(dist, V);
    }

    public static void Main(string[] args)
    {
        int V = 10;
        Grafo grafoEsparso = CriaGrafo(V);

        // Cria as arestas com as 3 informações
        // 1: Vértice que está saindo X
        // 2: Vértice que está chegando Y
        // 3: Peso da aresta entre os vértices X e Y
        AddAresta(grafoEsparso, 0, 1, 10);
        AddAresta(grafoEsparso, 0, 3, 20);
        AddAresta(grafoEsparso, 0, 4, 20);
        AddAresta(grafoEsparso, 0, 5, 5);
        AddAresta(grafoEsparso, 0, 6, 15);
        AddAresta(grafoEsparso, 1, 2, 5);
        AddAresta(grafoEsparso, 2, 1, 15);
        AddAresta(grafoEsparso, 2, 3, 5);
        AddAresta(grafoEsparso, 3, 4, 10);
        AddAresta(grafoEsparso, 4, 5, 5);
        AddAresta(grafoEsparso, 6, 5, 10);
        AddAresta(grafoEsparso, 7, 0, 5);
        AddAresta(grafoEsparso, 7, 1, 20);
        AddAresta(grafoEsparso, 7, 6, 5);
        AddAresta(grafoEsparso, 8, 1, 15);
        AddAresta(grafoEsparso, 8, 7, 20);
        AddAresta(grafoEsparso, 8, 9, 10);
        AddAresta(grafoEsparso, 9, 1, 5);
        AddAresta(grafoEsparso, 9, 2, 15);

        // Começa do vértice 0
        Console.WriteLine("Grafo Esparso saindo do vértice 0: ");
        AlgoritmoDijkstra(grafoEsparso, 0);
    }
}
