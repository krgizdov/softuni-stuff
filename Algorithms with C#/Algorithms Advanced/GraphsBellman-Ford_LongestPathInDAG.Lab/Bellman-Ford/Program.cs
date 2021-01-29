using System;
using System.Collections.Generic;
using System.Linq;

namespace Bellman_Ford
{
    class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }

    class Program
    {
        private static List<Edge> _edges;

        static void Main()
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());
            
            _edges = ReadGraph(edges);

            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            var distances = new double[nodes + 1];
            Array.Fill(distances, double.PositiveInfinity);
            distances[start] = 0;

            var prev = new int[nodes + 1];
            Array.Fill(prev, -1);

            var shortestPathFound = FindShortestPath(distances, prev, nodes);

            if (shortestPathFound)
            {
                var path = ReconstructPath(prev, end);

                Console.WriteLine(string.Join(" ", path));
                Console.WriteLine(distances[end]);
            }
            else
            {
                Console.WriteLine("Negative Cycle Detected");
            }
        }

        private static bool FindShortestPath(double[] distances, int[] prev, int nodes)
        {
            for (int i = 0; i < nodes - 1; i++)
            {
                var updated = false;
                foreach (var edge in _edges)
                {
                    if (double.IsPositiveInfinity(edge.From))
                    {
                        continue;
                    }

                    var newDistance = distances[edge.From] + edge.Weight;
                    if (newDistance < distances[edge.To])
                    {
                        distances[edge.To] = newDistance;
                        prev[edge.To] = edge.From;

                        updated = true;
                    }
                }

                if (!updated)
                {
                    break;
                }
            }

            foreach (var edge in _edges)
            {
                if (double.IsPositiveInfinity(edge.From))
                {
                    continue;
                }

                var newDistance = distances[edge.From] + edge.Weight;
                if (newDistance < distances[edge.To])
                {
                    return false;
                }
            }

            return true;
        }

        private static Stack<int> ReconstructPath(int[] prev, int node)
        {
            var path = new Stack<int>();

            while (node != -1)
            {
                path.Push(node);
                node = prev[node];
            }

            return path;
        }

        private static List<Edge> ReadGraph(int e)
        {
            var edges = new List<Edge>();

            for (int i = 0; i < e; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var from = edgeData[0];
                var to = edgeData[1];
                var weight = edgeData[2];

                edges.Add(new Edge
                {
                    From = from,
                    To = to,
                    Weight = weight
                });
            }

            return edges;
        }
    }
}
