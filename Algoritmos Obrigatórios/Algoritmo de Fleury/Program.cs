
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
        g1.addAresta(1, 2);
        g1.addAresta(1, 3);
        g1.addAresta(1, 4);
        g1.addAresta(2, 3);
        g1.addAresta(2, 5);
        g1.addAresta(3, 4);
        g1.addAresta(3, 5);
        g1.addAresta(4, 5);
        g1.printTourEuleriano();
 
    }
}