namespace Algoritmo_de_Welsh_Powell;

class Program
{
    static void Main(string[] args)
    {
        int[,] grafo = {
                { 0, 1, 0, 0, 0, 0, 1, 0, 0 },
                { 1, 0, 1, 0, 0, 0, 0, 1, 0 },
                { 0, 1, 0, 1, 0, 0, 0, 0, 1 },
                { 0, 0, 1, 0, 1, 0, 0, 0, 1 },
                { 0, 0, 0, 1, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 1, 0, 1 },
                { 1, 0, 0, 0, 0, 1, 0, 1, 0 },
                { 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 0, 0, 1, 1, 0, 1, 0, 1, 0 }
            };
        WelshPowell wp = new WelshPowell();
        int[] colors = wp.WelshPowellAlgorithm(grafo);

        for (int i = 0; i < colors.Length; i++)
        {
            Console.WriteLine($"Nó {i} tem cor {colors[i]}");
        }
    }
}
