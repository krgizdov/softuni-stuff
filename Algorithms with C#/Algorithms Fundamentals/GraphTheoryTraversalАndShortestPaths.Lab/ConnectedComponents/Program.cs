using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedComponents
{
    class Program
    {
        private static List<int>[] _graph;
        private static bool[] _visited;

        static void Main()
        {
            ReadGraph();

            FindGraphConnectedComponents();
        }

        private static void FindGraphConnectedComponents()
        {
            _visited = new bool[_graph.Length];

            for (int startNode = 0; startNode < _graph.Count(); startNode++)
            {
                if (!_visited[startNode])
                {
                    Console.Write("Connected component:");
                    DFS(startNode);
                    Console.WriteLine();
                }
            }
        }

        private static void DFS(int vertex)
        {
            if (!_visited[vertex])
            {
                _visited[vertex] = true;
                foreach (var child in _graph[vertex])
                {
                    DFS(child);
                }

                Console.Write($" {vertex}");
            }
        }

        private static void ReadGraph()
        {
            int n = int.Parse(Console.ReadLine());
            _graph = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                _graph[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
            }
        }
    }
}
