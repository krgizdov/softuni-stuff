using System;
using System.Collections.Generic;
using System.Linq;

namespace Undefined
{
    class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    class Program
    {
        private static List<Edge> _edges;

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

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
                Console.WriteLine("Undefined");
            }
        }

        private static bool FindShortestPath(double[] distances, int[] prev, int nodes)
        {
            for (int i = 0; i < nodes - 1; i++)
            {
                var updated = false;
                foreach (var edge in _edges)
                {
                    if (double.IsPositiveInfinity(distances[edge.First]))
                    {
                        continue;
                    }

                    var newDistance = distances[edge.First] + edge.Weight;
                    if (newDistance < distances[edge.Second])
                    {
                        distances[edge.Second] = newDistance;
                        prev[edge.Second] = edge.First;

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
                if (double.IsPositiveInfinity(edge.First))
                {
                    continue;
                }

                var newDistance = distances[edge.First] + edge.Weight;
                if (newDistance < distances[edge.Second])
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

                var firstNode = edgeData[0];
                var secondNode = edgeData[1];
                var weight = edgeData[2];

                edges.Add(new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = weight
                });
            }

            return edges;
        }
    }
}
