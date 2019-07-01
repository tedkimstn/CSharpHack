/*
 * Source: N/A
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Ted Kim
 * Summary: Graph using an adjacency list.
 * Modifications: N/A      
 * Student: Ted Kim
 * Capture Date: June 30, 2019
 */

using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Graph
    {
        // An weighted adjacency list using dictionaries.
        // Dictionary<fromNode, Dictionary<toNode, weight>>.
        Dictionary<string, Dictionary<string, int>> adjacencyList;

        // A constructor.
        public Graph()
        {
            // Initialization.
            adjacencyList = new Dictionary<string, Dictionary<string, int>>();
        }

        // Adds a vertex on a graph.
        public void AddVertex(string newVertex)
        {
            adjacencyList.Add(newVertex, new Dictionary<string, int>());
        }

        // Print vertices on a graph.
        public void PrintVertices()
        {
            foreach(var vertex in adjacencyList.Keys)
            {
                Console.Write(vertex + " ");
            }
            Console.WriteLine();
        }

        // Adds an edge from "from" to "to" with weight "weight".
        public void AddEdge(string from, string to, int weight=1)
        {
            adjacencyList[from].Add(to, weight);
        }

        // Removes an edge from "from" to "to".
        public void RemoveEdge(string from, string to)
        {
            adjacencyList[from].Remove(to);
        }

        // Prints all edges in a graph.
        public void PrintEdges()
        {
            foreach(var vertex in adjacencyList)
            {
                Console.Write(vertex.Key + ": ");
                foreach(var edge in vertex.Value)
                {
                    Console.Write("({0}, {1}) ", edge.Key, edge.Value);
                }

                Console.WriteLine();
            }
        }

        // Removes a vertex from a graph and all edges connected to it.
        public void RemoveVertex(string removingVertex)
        {
            // Removes the vertex.
            adjacencyList.Remove(removingVertex);

            // Removes all edges connected to the vertex.
            foreach(var edge in adjacencyList.Values)
            {
                edge.Remove(removingVertex);
            }
        }

    }
}
