using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace CableNetwork
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
        private static readonly HashSet<int> _forest = new HashSet<int>();

        static void Main()
        {
            var budget = int.Parse(Console.ReadLine());
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            _graph = ReadGraph(nodes, edges);

            var totalCost = Prim(budget);

            Console.WriteLine($"Budget used: {totalCost}");
        }

        private static int Prim(int budget)
        {
            var totalCost = 0;

            var queue = new OrderedBag<Edge>(
                Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            foreach (var node in _forest)
            {
                queue.AddMany(_graph[node]);
            }

            while (queue.Count > 0)
            {
                var edge = queue.RemoveFirst();

                var nonTreeNode = GetNonTreeNode(edge);

                if (nonTreeNode == -1)
                {
                    continue;
                }

                if (edge.Weight > budget)
                {
                    break;
                }

                totalCost += edge.Weight;
                budget -= edge.Weight;
                _forest.Add(nonTreeNode);
                queue.AddMany(_graph[nonTreeNode]);
            }

            return totalCost;
        }

        private static int GetNonTreeNode(Edge edge)
        {
            var nonTreeNode = -1;

            if (_forest.Contains(edge.First) && !_forest.Contains(edge.Second))
            {
                nonTreeNode = edge.Second;
            }
            else if (_forest.Contains(edge.Second) && !_forest.Contains(edge.First))
            {
                nonTreeNode = edge.First;
            }

            return nonTreeNode;
        }

        private static List<Edge>[] ReadGraph(int nodes, int edges)
        {
            var graph = new List<Edge>[nodes];

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<Edge>();
            }

            for (int e = 0; e < edges; e++)
            {
                var edgeData = Console.ReadLine().Split();

                var firstNode = int.Parse(edgeData[0]);
                var secondNode = int.Parse(edgeData[1]);
                var weight = int.Parse(edgeData[2]);

                var edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = weight
                };

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);

                if (edgeData.Length == 4)
                {
                    _forest.Add(firstNode);
                    _forest.Add(secondNode);
                }
            }

            return graph;
        }
    }
}
