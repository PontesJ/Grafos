
using System;
using System.Collections.Generic;
 
class Grafo
{
    private int vertices; //numero de vertices
    private List<int>[] adj; // lista de adjacencia
 
    public Grafo(int numDeVertices)
    {
        this.vertices = numDeVertices;
 
        iniciaGrafo();
    }
     private void iniciaGrafo()
    {
        adj = new List<int>[vertices];
        for (int i = 0; i < vertices; i++)
        {
            adj[i] = new List<int>();
        }
    }
 
    private void addAresta(int u, int v)
    {
        adj[u].Add(v);
        adj[v].Add(u);
    }
 
    private void removeAresta(int u, int v)
    {
        adj[u].Remove(v);
        adj[v].Remove(u);
    }
 
    
    private void printTourEuleriano()
    {
        int u = 0;
        for (int i = 0; i < vertices; i++)
        {
            if (adj[i].Count % 2 == 1)
            {
                u = i;
                break;
            }
        }
         

        printEulerDo(u);
        Console.WriteLine();
    }
 
    private void printEulerDo(int u)
    {
       
        for (int i = 0; i < adj[u].Count; i++)
        {
            int v = adj[u][i];

            if (proxArestaEValida(u, v))
            {
                Console.Write(u + "-" + v + " ");
                 
                
                removeAresta(u, v);
                printEulerDo(v);
            }
        }
    }
 
   
    private bool proxArestaEValida(int u, int v)
    {
        
        if (adj[u].Count == 1)
        {
            return true;
        }
 
        
        bool[] foiVisitado = new bool[this.vertices];
        int count1 = dfsCount(u, foiVisitado);
 
        
        removeAresta(u, v);
        foiVisitado = new bool[this.vertices];
        int count2 = dfsCount(u, foiVisitado);
 
        
        addAresta(u, v);
        return (count1 > count2) ? false : true;
    }
 

    private int dfsCount(int v, bool[] foiVisitado)
    {

        foiVisitado[v] = true;
        int count = 1;

        foreach(int i in adj[v])
        {
            if (!foiVisitado[i])
            {
                count = count + dfsCount(i, foiVisitado);
            }
        }
        return count;
    }
 
    // Driver Code
    public static void Main(String []a)
    {
        
        Grafo g1 = new Grafo(10);
        g1.addAresta(0, 1);
        g1.addAresta(0, 2);
        g1.addAresta(0, 3);
        g1.addAresta(0, 4);
        g1.addAresta(0, 6);
        g1.addAresta(0, 7);
        g1.addAresta(1, 6);
        g1.addAresta(2, 3);
        g1.addAresta(2, 4);
        g1.addAresta(2, 5);
        g1.addAresta(3, 5);
        g1.addAresta(3, 6);
        g1.addAresta(3, 7);
        g1.addAresta(3, 8);
        g1.addAresta(4, 7);
        g1.addAresta(4, 9);
        g1.addAresta(6, 8);
        g1.addAresta(7, 8);
        g1.addAresta(8, 9);
        
        Console.WriteLine("Algoritmo de Fleury no Grafo Esparso: ");
        g1.printTourEuleriano();



        Grafo g2 = new Grafo(10);
        g2.addAresta(0, 1);
        g2.addAresta(0, 2);
        g2.addAresta(0, 3);
        g2.addAresta(0, 4);
        g2.addAresta(0, 6);
        g2.addAresta(0, 7);
        g2.addAresta(1, 6);
        g2.addAresta(2, 3);
        g2.addAresta(2, 4);
        g2.addAresta(2, 5);
        g2.addAresta(3, 5);
        g2.addAresta(3, 6);
        g2.addAresta(3, 7);
        g2.addAresta(3, 8);
        g2.addAresta(4, 7);
        g2.addAresta(4, 9);
        g2.addAresta(6, 8);
        g2.addAresta(7, 8);
        g2.addAresta(8, 9);
        g2.addAresta(1, 2);
        g2.addAresta(1, 3);
        g2.addAresta(1, 4);
        g2.addAresta(1, 5);
        g2.addAresta(1, 7);
        g2.addAresta(2, 6);
        g2.addAresta(2, 7);
        g2.addAresta(2, 8);
        g2.addAresta(2, 9);
        g2.addAresta(3, 4);
        g2.addAresta(3, 9);
        g2.addAresta(4, 5);
        g2.addAresta(4, 6);
        g2.addAresta(4, 8);
        g2.addAresta(5, 6);
        g2.addAresta(5, 7);
        g2.addAresta(5, 8);
        g2.addAresta(6, 9);
        g2.addAresta(7, 9);
        g2.addAresta(8, 9);


        Console.WriteLine("Algoritmo de Fleury no Grafo Denso: ");
        g2.printTourEuleriano();
 
    }
}