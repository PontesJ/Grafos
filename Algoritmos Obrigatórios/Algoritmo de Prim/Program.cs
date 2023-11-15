using System;

namespace Algoritmo_de_Prim
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exemplo de uma matriz de adjacência ponderada (representando um grafo não direcionado)
            int[,] grafo = {
                { 0, 1, 0, 0, 0, 0, 8, 0, 0 },
                { 1, 0, 5, 0, 0, 0, 0, 7, 0 },
                { 0, 5, 0, 9, 0, 0, 0, 0, 8 },
                { 0, 0, 9, 0, 7, 0, 0, 0, 6 },
                { 0, 0, 0, 7, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 5, 0, 2 },
                { 8, 0, 0, 0, 0, 5, 0, 4, 0 },
                { 0, 7, 0, 0, 0, 0, 4, 0, 1 },
                { 0, 0, 8, 6, 0, 2, 0, 1, 0 }
            };

            AlgoritmoPrim(grafo);
        }

        static void AlgoritmoPrim(int[,] grafo)
        {
            int numVertices = grafo.GetLength(0);

            // Vetor para armazenar os pais dos vértices na AGM
            int[] pais = new int[numVertices];

            // Vetor para armazenar os custos mínimos de cada vértice à AGM
            int[] custoMinimo = new int[numVertices];

            // Array para rastrear se um vértice está incluído na AGM
            bool[] incluido = new bool[numVertices];

            // Inicializando custos mínimos como infinito e incluído como falso
            for (int i = 0; i < numVertices; i++)
            {
                custoMinimo[i] = int.MaxValue;
                incluido[i] = false;
            }

            // O custo mínimo da raiz para ela mesma é sempre 0
            custoMinimo[0] = 0;

            // O primeiro vértice sempre será a raiz da AGM
            pais[0] = -1;

            // Construindo a AGM
            for (int count = 0; count < numVertices - 1; count++)
            {
                // Encontrar o vértice com o custo mínimo que ainda não foi incluído
                int u = EncontrarCustoMinimo(custoMinimo, incluido);

                // Incluindo o vértice na AGM
                incluido[u] = true;

                // Atualizando os custos mínimos e pais dos vértices adjacentes
                for (int v = 0; v < numVertices; v++)
                {
                    if (grafo[u, v] != 0 && incluido[v] == false && grafo[u, v] < custoMinimo[v])
                    {
                        Console.WriteLine($"Comparação: Custo de {u} para {v} ({grafo[u, v]}) é menor que o custo mínimo conhecido para {v} ({custoMinimo[v]})");
                        pais[v] = u;
                        custoMinimo[v] = grafo[u, v];
                    }
                }
            }

            // Exibindo a AGM
            ExibirAGM(pais, grafo, numVertices);
        }

        static int EncontrarCustoMinimo(int[] custoMinimo, bool[] incluido)
        {
            int minimo = int.MaxValue;
            int minimoIndex = -1;

            for (int i = 0; i < custoMinimo.Length; i++)
            {
                if (incluido[i] == false && custoMinimo[i] < minimo)
                {
                    minimo = custoMinimo[i];
                    minimoIndex = i;
                }
            }

            Console.WriteLine($"Escolhido vértice {minimoIndex} com custo mínimo de {minimo}");
            Console.ReadLine();
            return minimoIndex;
        }

        static void ExibirAGM(int[] pais, int[,] grafo, int numVertices)
        {
            Console.WriteLine("Aresta   Peso");
            for (int i = 1; i < numVertices; i++)
            {
                Console.WriteLine($"{pais[i]} - {i}    {grafo[i, pais[i]]}");
            }
        }
    }
}
