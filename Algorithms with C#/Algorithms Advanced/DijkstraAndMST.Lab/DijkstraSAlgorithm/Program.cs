using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace DijkstraSAlgorithm
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
        private static int[] _distances;
        private static int[] _prev;

        static void Main()
        {
            var e = int.Parse(Console.ReadLine());

            _edgesByNode = ReadEdges(e);

            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            var maxNode = _edgesByNode.Keys.Max();

            _distances = new int[maxNode + 1];
            _prev = new int[maxNode + 1];

            InitializeDistances();
            _distances[start] = 0;

            GetShortestPath(start, end);

            PrintResult(start, end);
        }

        private static void PrintResult(int start, int end)
        {
            if (_distances[end] == int.MaxValue)
            {
                Console.WriteLine("There is no such path.");
            }
            else
            {
                var stack = new Stack<int>();
                var node = end;

                stack.Push(node);

                while (node != start)
                {
                    node = _prev[node];
                    stack.Push(node);
                }

                Console.WriteLine(_distances[end]);
                Console.WriteLine(string.Join(" ", stack));
            }
        }

        private static void InitializeDistances()
        {
            for (int i = 0; i < _distances.Length; i++)
            {
                _distances[i] = int.MaxValue;
            }
        }

        private static void GetShortestPath(int start, int end)
        {
            var queue = new OrderedBag<int>(
                Comparer<int>.Create((f, s) => _distances[f] - _distances[s]));

            queue.Add(start);

            while (queue.Count > 0)
            {
                var minNode = queue.RemoveFirst();

                if (minNode == end)
                {
                    break;
                }

                var children = _edgesByNode[minNode];

                //This could be extracted in another method.
                foreach (var child in children)
                {
                    var childNode = child.First == minNode ? child.Second : child.First;

                    if (_distances[childNode] == int.MaxValue)
                    {
                        queue.Add(childNode);
                    }

                    var newDistance = child.Weight + _distances[minNode];

                    if (newDistance < _distances[childNode])
                    {
                        _distances[childNode] = newDistance;
                        _prev[childNode] = minNode;

                        queue = new OrderedBag<int>(
                            queue,
                            Comparer<int>.Create((f, s) => _distances[f] - _distances[s]));
                    }
                }
            }
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
