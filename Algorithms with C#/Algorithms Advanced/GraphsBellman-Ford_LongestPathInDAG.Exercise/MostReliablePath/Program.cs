using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace MostReliablePath
{
    class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    class Program
    {
        private static List<Edge>[] _edgesByNode;
        private static double[] _distances;
        private static int[] _prev;

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            _edgesByNode = ReadEdges(nodes, edges);

            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            _distances = new double[nodes];
            _prev = new int[nodes];

            InitializeDistancesAndPrev();
            _distances[start] = 100.0;

            GetShortestPath(start, end);

            PrintResult(end);
        }

        private static void PrintResult(int end)
        {
            var path = new Stack<int>();
            var node = end;

            while (node != -1)
            {
                path.Push(node);
                node = _prev[node];
            }

            Console.WriteLine($"Most reliable path reliability: {_distances[end]:f2}%");
            Console.WriteLine(string.Join(" -> ", path));
        }

        private static void InitializeDistancesAndPrev()
        {
            for (int i = 0; i < _distances.Length; i++)
            {
                _distances[i] = double.NegativeInfinity;
                _prev[i] = -1;
            }
        }

        private static void GetShortestPath(int start, int end)
        {
            var queue = new OrderedBag<int>(
                Comparer<int>.Create((f, s) => _distances[s].CompareTo(_distances[f])));

            queue.Add(start);

            while (queue.Count > 0)
            {
                var maxNode = queue.RemoveFirst();

                if (maxNode == end)
                {
                    break;
                }

                var children = _edgesByNode[maxNode];

                //This could be extracted in another method.
                foreach (var child in children)
                {
                    var childNode = child.First == maxNode ? child.Second : child.First;

                    if (double.IsNegativeInfinity(_distances[childNode]))
                    {
                        queue.Add(childNode);
                    }

                    var newDistance = child.Weight * _distances[maxNode] / 100.0;

                    if (newDistance > _distances[childNode])
                    {
                        _distances[childNode] = newDistance;
                        _prev[childNode] = maxNode;

                        queue = new OrderedBag<int>(
                            queue,
                            Comparer<int>.Create((f, s) => _distances[s].CompareTo(_distances[f])));
                    }
                }
            }
        }
        private static List<Edge>[] ReadEdges(int n, int e)
        {
            var edges = new List<Edge>[n];

            for (int i = 0; i < n; i++)
            {
                edges[i] = new List<Edge>();
            }

            for (int i = 0; i < e; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeData[0];
                var secondNode = edgeData[1];
                var weight = edgeData[2];

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
