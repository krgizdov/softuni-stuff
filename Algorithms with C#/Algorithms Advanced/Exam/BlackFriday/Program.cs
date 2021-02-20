using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackFriday
{
    class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var shops = int.Parse(Console.ReadLine());
            var streets = int.Parse(Console.ReadLine());

            var edges = ReadGraph(streets);

            var sortedEdges = edges.OrderBy(e => e.Weight).ToList();

            var root = new int[shops];
            for (int node = 0; node < root.Length; node++)
            {
                root[node] = node;
            }

            var totalCost = FindMinimumPath(sortedEdges, root);

            Console.WriteLine(totalCost);
        }

        private static int FindMinimumPath(List<Edge> sortedEdges, int[] root)
        {
            var totalCost = 0;

            foreach (var edge in sortedEdges)
            {
                var firstRoot = GetRoot(edge.First, root);
                var secondRoot = GetRoot(edge.Second, root);

                if (firstRoot != secondRoot)
                {
                    totalCost += edge.Weight;
                    root[firstRoot] = secondRoot;
                }
            }

            return totalCost;
        }

        private static int GetRoot(int node, int[] root)
        {
            while (node != root[node])
            {
                node = root[node];
            }

            return node;
        }

        private static List<Edge> ReadGraph(int streets)
        {
            var graph = new List<Edge>();

            for (int i = 0; i < streets; i++)
            {
                var graphData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = graphData[0];
                var secondNode = graphData[1];
                var weight = graphData[2];

                graph.Add(new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = weight
                });
            }

            return graph;
        }
    }
}
