using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace CheapTownTour
{
    class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    class Program
    {
        private static List<Edge>[] _graph;
        private static readonly HashSet<int> _towns = new HashSet<int>();

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var roads = int.Parse(Console.ReadLine());

            _graph = ReadGraph(nodes, roads);
            var totalCost = 0;

            for (int i = 0; i < _graph.Length; i++)
            {
                if (!_towns.Contains(i))
                {
                    totalCost += Prim(i);
                }
            }

            Console.WriteLine($"Total cost: {totalCost}");
        }

        private static int Prim(int node)
        {
            _towns.Add(node);
            var cost = 0;

            var queue = new OrderedBag<Edge>(
                _graph[node],
                Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            while (queue.Count > 0)
            {
                var edge = queue.RemoveFirst();

                var nonTreeNode = GetNonTreeNode(edge);

                if (nonTreeNode == -1)
                {
                    continue;
                }

                cost += edge.Weight;
                _towns.Add(nonTreeNode);
                queue.AddMany(_graph[nonTreeNode]);
            }

            return cost;
        }

        private static int GetNonTreeNode(Edge edge)
        {
            var nonTreeNode = -1;

            if (_towns.Contains(edge.First) && !_towns.Contains(edge.Second))
            {
                nonTreeNode = edge.Second;
            }
            else if (_towns.Contains(edge.Second) && !_towns.Contains(edge.First))
            {
                nonTreeNode = edge.First;
            }

            return nonTreeNode;
        }

        private static List<Edge>[] ReadGraph(int nodes, int roads)
        {
            var graph = new List<Edge>[nodes];

            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < roads; i++)
            {
                var graphData = Console.ReadLine()
                    .Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = graphData[0];
                var secondNode = graphData[1];
                var weight = graphData[2];

                var road = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = weight
                };

                graph[firstNode].Add(road);
                graph[secondNode].Add(road);
            }

            return graph;
        }
    }
}
