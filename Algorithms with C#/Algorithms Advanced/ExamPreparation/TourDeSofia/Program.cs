using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace TourDeSofia
{
    class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Distance { get; set; }
    }

    class Program
    {
        private static List<Edge>[] _graph;
        private static double[] _distance;
        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());
            var startNode = int.Parse(Console.ReadLine());

            _graph = ReadGraph(nodes, edges);

            _distance = new double[nodes];

            for (int node = 0; node < _distance.Length; node++)
            {
                _distance[node] = double.PositiveInfinity;
            }

            var visitedNodes = new HashSet<int> { startNode };

            FindShortestPath(startNode, visitedNodes);

            if (double.IsPositiveInfinity(_distance[startNode]))
            {
                Console.WriteLine(visitedNodes.Count);
            }
            else
            {
                Console.WriteLine(_distance[startNode]);
            }
        }

        private static void FindShortestPath(int startNode, HashSet<int> visitedNodes)
        {
            var queue = new OrderedBag<int>(
                            Comparer<int>.Create((f, s) => _distance[f].CompareTo(_distance[s])));

            foreach (var child in _graph[startNode])
            {
                _distance[child.To] = child.Distance;
                queue.Add(child.To);
            }

            while (queue.Count > 0)
            {
                var node = queue.RemoveFirst();
                visitedNodes.Add(node);

                if (node == startNode)
                {
                    break;
                }

                foreach (var edge in _graph[node])
                {
                    var child = edge.To;

                    if (double.IsPositiveInfinity(_distance[child]))
                    {
                        queue.Add(child);
                    }

                    var newDistance = _distance[node] + edge.Distance;

                    if (newDistance < _distance[child])
                    {
                        _distance[child] = newDistance;

                        queue = new OrderedBag<int>(
                            queue,
                            Comparer<int>.Create((f, s) => _distance[f].CompareTo(_distance[s])));
                    }
                }
            }
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

                var from = edgeData[0];
                var to = edgeData[1];
                var distance = edgeData[2];

                graph[from].Add(new Edge
                {
                    From = from,
                    To = to,
                    Distance = distance
                });
            }

            return graph;
        }
    }
}
