using System;
using System.Linq;

public class WelshPowell
{
    public int[] WelshPowellAlgorithm(int[,] adjacencyMatrix)
    {
        int size = adjacencyMatrix.GetLength(0);
        int[] colors = new int[size];
        int[] degrees = new int[size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (adjacencyMatrix[i, j] == 1)
                {
                    degrees[i]++;
                }
            }
        }

        var sortedIndices = Enumerable.Range(0, degrees.Length).ToArray();
        Array.Sort(degrees, sortedIndices, Comparer<int>.Create((x, y) => y.CompareTo(x)));

        int color = 0;
        while (sortedIndices.Any(index => colors[index] == 0))
        {
            color++;
            for (int i = 0; i < size; i++)
            {
                int node = sortedIndices[i];
                if (colors[node] != 0)
                {
                    continue;
                }

                bool canColor = true;
                for (int j = 0; j < size; j++)
                {
                    if (adjacencyMatrix[node, j] == 1 && colors[j] == color)
                    {
                        canColor = false;
                        break;
                    }
                }

                if (canColor)
                {
                    colors[node] = color;
                    Console.WriteLine($"Nó {node} colorido com cor {color}");
                    Console.ReadLine();
                }
            }
        }

        return colors;
    }
}
