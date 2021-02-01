using System;
using System.Collections.Generic;
using System.Linq;

namespace BigTrip
{
    class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }

    class Program
    {
        private static List<Edge>[] _graph;

        static void Main()
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            _graph = ReadGraph(nodes, edges);

            var sortedNodes = TopologicalSorting();

            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            var distances = new double[_graph.Length];
            Array.Fill(distances, double.NegativeInfinity);
            distances[start] = 0;

            //We can use the prev array to track the path from the start node to the end node.
            var prev = new int[_graph.Length];
            Array.Fill(prev, -1);

            FindLongestPath(sortedNodes, distances, prev);

            Console.WriteLine(distances[end]);
            Console.WriteLine(string.Join(" ", GetPath(prev, end)));
        }

        private static void FindLongestPath(Stack<int> sortedNodes, double[] distances, int[] prev)
        {
            while (sortedNodes.Count > 0)
            {
                var node = sortedNodes.Pop();

                foreach (var edge in _graph[node])
                {
                    var newDistance = distances[node] + edge.Weight;
                    if (newDistance > distances[edge.To])
                    {
                        distances[edge.To] = newDistance;
                        prev[edge.To] = node;
                    }
                }
            }
        }

        private static Stack<int> GetPath(int[] prev, int end)
        {
            var path = new Stack<int>();

            while (end != -1)
            {
                path.Push(end);
                end = prev[end];
            }

            return path;
        }

        private static Stack<int> TopologicalSorting()
        {
            var visited = new bool[_graph.Length];
            var sorted = new Stack<int>();

            for (int node = 1; node < _graph.Length; node++)
            {
                DFS(node, visited, sorted);
            }

            return sorted;
        }

        private static void DFS(int node, bool[] visited, Stack<int> sorted)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var edge in _graph[node])
            {
                DFS(edge.To, visited, sorted);
            }

            sorted.Push(node);
        }

        private static List<Edge>[] ReadGraph(int nodes, int e)
        {
            var graph = new List<Edge>[nodes + 1];

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<Edge>();
            }

            for (int i = 0; i < e; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var from = edgeData[0];
                var to = edgeData[1];
                var weight = edgeData[2];

                graph[from].Add(new Edge
                {
                    From = from,
                    To = to,
                    Weight = weight
                });
            }

            return graph;
        }
    }
}
