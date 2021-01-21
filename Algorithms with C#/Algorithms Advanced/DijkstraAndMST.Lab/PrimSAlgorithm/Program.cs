using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace PrimSAlgorithm
{
    class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    class Program
    {
        private static Dictionary<int, List<Edge>> _edgesByNode;
        private static readonly HashSet<int> _forest = new HashSet<int>();

        static void Main()
        {
            var e = int.Parse(Console.ReadLine());

            _edgesByNode = ReadEdges(e);

            foreach (var node in _edgesByNode.Keys)
            {
                if (!_forest.Contains(node))
                {
                    Prim(node);
                }
            }
        }

        private static void Prim(int node)
        {
            _forest.Add(node);

            var queue = new OrderedBag<Edge>(
                _edgesByNode[node],
                Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            while (queue.Count > 0)
            {
                var edge = queue.RemoveFirst();

                var nonTreeNode = GetNonTreeNode(edge);

                if (nonTreeNode == -1)
                {
                    continue;
                }

                Console.WriteLine($"{edge.First} - {edge.Second}");

                _forest.Add(nonTreeNode);
                queue.AddMany(_edgesByNode[nonTreeNode]);
            }
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

        private static Dictionary<int, List<Edge>> ReadEdges(int e)
        {
            var edges = new Dictionary<int, List<Edge>>();

            for (int i = 0; i < e; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeData[0];
                var secondNode = edgeData[1];
                var weight = edgeData[2];

                if (!edges.ContainsKey(firstNode))
                {
                    edges[firstNode] = new List<Edge>();
                }

                if (!edges.ContainsKey(secondNode))
                {
                    edges[secondNode] = new List<Edge>();
                }

                var edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = weight
                };

                edges[firstNode].Add(edge);
                edges[secondNode].Add(edge);
            }

            return edges;
        }
    }
}
