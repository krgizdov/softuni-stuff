using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace ChainLightning
{
    class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Distance { get; set; }
    }

    class Program
    {
        private static List<Edge>[] _graph;
        private static Dictionary<int, Dictionary<int, int>> _treeByNode;
        private static Dictionary<int, int> _damageByNode;

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());
            var lightnings = int.Parse(Console.ReadLine());

            _graph = ReadGraph(nodes, edges);

            _treeByNode = new Dictionary<int, Dictionary<int, int>>();
            _damageByNode = new Dictionary<int, int>();

            FindMaxDamagedNode(lightnings);

            var maxDamagedNode = _damageByNode.Max(kvp => kvp.Value);

            Console.WriteLine(maxDamagedNode);
        }

        private static void FindMaxDamagedNode(int lightnings)
        {
            for (int i = 0; i < lightnings; i++)
            {
                var lightningData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var node = lightningData[0];
                var damage = lightningData[1];

                if (!_treeByNode.ContainsKey(node))
                {
                    _treeByNode[node] = Prim(node);
                }

                var tree = _treeByNode[node];

                foreach (var kvp in tree)
                {
                    var currentDamage = CalculateDamage(damage, kvp.Value);

                    if (!_damageByNode.ContainsKey(kvp.Key))
                    {
                        _damageByNode[kvp.Key] = 0;
                    }

                    _damageByNode[kvp.Key] += currentDamage;
                }
            }
        }

        private static int CalculateDamage(int damage, int depth)
        {
            for (int i = 0; i < depth - 1; i++)
            {
                damage /= 2;
            }

            return damage;
        }

        private static Dictionary<int, int> Prim(int startNode)
        {
            var tree = new Dictionary<int, int> { { startNode, 1 } };

            var queue = new OrderedBag<Edge>(
                Comparer<Edge>.Create((f, s) => f.Distance - s.Distance));

            queue.AddMany(_graph[startNode]);

            while (queue.Count > 0)
            {
                var edge = queue.RemoveFirst();

                var nonTreeNode = GetNonTreeNode(tree, edge);

                if (nonTreeNode == -1)
                {
                    continue;
                }

                var treeNode = GetTreeNode(tree, edge);

                tree.Add(nonTreeNode, tree[treeNode] + 1);
                queue.AddMany(_graph[nonTreeNode]);
            }

            return tree;
        }

        private static int GetTreeNode(Dictionary<int, int> tree, Edge edge)
        {
            if (tree.ContainsKey(edge.First))
            {
                return edge.First;
            }

            return edge.Second;
        }

        private static int GetNonTreeNode(Dictionary<int, int> tree, Edge edge)
        {
            if (tree.ContainsKey(edge.First) &&
                !tree.ContainsKey(edge.Second))
            {
                return edge.Second;
            }

            if (tree.ContainsKey(edge.Second) &&
                !tree.ContainsKey(edge.First))
            {
                return edge.First;
            }

            return -1;
        }

        private static List<Edge>[] ReadGraph(int nodes, int edges)
        {
            var graph = new List<Edge>[nodes];

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var first = edgeData[0];
                var second = edgeData[1];
                var distance = edgeData[2];

                var edge = new Edge
                {
                    First = first,
                    Second = second,
                    Distance = distance
                };

                graph[first].Add(edge);
                graph[second].Add(edge);
            }

            return graph;
        }
    }
}
