// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class Edge : IComparable<Edge>
{
    public int Source { get; set; }
    public int Destination { get; set; }
    public int Weight { get; set; }

    public Edge(int source, int destination, int weight)
    {
        Source = source;
        Destination = destination;
        Weight = weight;
    }

    public int CompareTo(Edge other)
    {
        return Weight.CompareTo(other.Weight);
    }
}

class KruskalAlgorithm
{
    // Find function with path compression
    static int Find(int[] parent, int vertex)
    {
        if (parent[vertex] != vertex)
        {
            parent[vertex] = Find(parent, parent[vertex]);
        }
        return parent[vertex];
    }

    // Union function with union by rank
    static void Union(int[] parent, int[] rank, int root1, int root2)
    {
        if (rank[root1] > rank[root2])
        {
            parent[root2] = root1;
        }
        else if (rank[root1] < rank[root2])
        {
            parent[root1] = root2;
        }
        else
        {
            parent[root2] = root1;
            rank[root1]++;
        }
    }

    // Kruskal's Algorithm to find MST
    public static List<Edge> Kruskal(List<Edge> edges, int vertices)
    {
        // Step 1: Sort edges by weight
        edges.Sort();

        // Step 2: Initialize parent and rank arrays
        int[] parent = new int[vertices];
        int[] rank = new int[vertices];
        for (int i = 0; i < vertices; i++)
        {
            parent[i] = i;
            rank[i] = 0;
        }

        // Step 3: Process edges to construct the MST
        List<Edge> mst = new List<Edge>();
        foreach (var edge in edges)
        {
            int root1 = Find(parent, edge.Source);
            int root2 = Find(parent, edge.Destination);

            // If including this edge does not create a cycle
            if (root1 != root2)
            {
                mst.Add(edge);
                Union(parent, rank, root1, root2);
            }
        }

        return mst;
    }

    static void Main(string[] args)
    {
        // Input: Number of vertices and edges
        int vertices = 5;
        List<Edge> edges = new List<Edge>
        {
            new Edge(0, 1, 10),
            new Edge(0, 2, 6),
            new Edge(0, 3, 5),
            new Edge(1, 3, 15),
            new Edge(2, 3, 4)
        };

        // Find MST using Kruskal's Algorithm
        List<Edge> mst = Kruskal(edges, vertices);

        // Output the edges in the MST
        Console.WriteLine("Edges in the MST:");
        foreach (var edge in mst)
        {
            Console.WriteLine($"{edge.Source} -- {edge.Destination} == {edge.Weight}");
        }
    }
}