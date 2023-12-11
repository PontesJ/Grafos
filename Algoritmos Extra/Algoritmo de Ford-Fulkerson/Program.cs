namespace Algoritmo_de_Ford_Fulkerson;

public class Program
{
    static int Vertices = 10;

    bool bfs(int[,] rGraph, int s, int t, int[] parent)
    {
        bool[] visited = new bool[Vertices];
        for (int i = 0; i < Vertices; ++i)
            visited[i] = false;

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(s);
        visited[s] = true;
        parent[s] = -1;

        while (queue.Count != 0)
        {
            int u = queue.Dequeue();

            for (int v = 0; v < Vertices; v++)
            {
                if (visited[v] == false && rGraph[u, v] > 0)
                {
                    Console.WriteLine("Comparando vértice " + (v + 1) + " com vértice " + (u + 1));
                    Thread.Sleep(1000);
                    Console.WriteLine();
                    queue.Enqueue(v);
                    parent[v] = u;
                    visited[v] = true;
                }
            }
        }

        return (visited[t] == true);
    }

    public int fordFulkerson(int[,] graph, int s, int t)
    {
        int u, v;

        int[,] rGraph = new int[Vertices, Vertices];

        for (u = 0; u < Vertices; u++)
            for (v = 0; v < Vertices; v++)
                rGraph[u, v] = graph[u, v];

        int[] parent = new int[Vertices];

        int max_flow = 0;

        while (bfs(rGraph, s, t, parent))
        {
            int path_flow = int.MaxValue;
            for (v = t; v != s; v = parent[v])
            {
                u = parent[v];
                path_flow = Math.Min(path_flow, rGraph[u, v]);
            }

            Console.WriteLine("Caminho escolhido: ");
            for (v = t; v != s; v = parent[v])
            {
                u = parent[v];
                Console.Write((v + 1) + " <- ");
                rGraph[u, v] -= path_flow;
                rGraph[v, u] += path_flow;
            }
            Console.WriteLine((s + 1));

            max_flow += path_flow;
            Console.WriteLine("Fluxo atual: " + max_flow);

            Thread.Sleep(1000);
            Console.WriteLine();
        }

        return max_flow;
    }

    public static void Main()
    {
        Program program = new Program();

        int[,] graph = new int[,] { {0, 3, 0, 0, 0, 3, 0, 0, 0, 0},
                                    {0, 0, 4, 0, 0, 0, 0, 0, 0, 0},
                                    {0, 0, 0, 8, 0, 0, 0, 3, 0, 0},
                                    {0, 0, 0, 0, 7, 0, 0, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 3, 0},
                                    {0, 0, 2, 0, 0, 0, 6, 0, 0, 0},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 1, 1},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 9, 0},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
                                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
                                  };
        Console.WriteLine("Impossível Continuar\n\nO fluxo máximo possível é " + program.fordFulkerson(graph, 0, 9));
    }
}