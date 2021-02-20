using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Wintellect.PowerCollections;

namespace EmergencyPlan
{
    class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public TimeSpan Weight { get; set; }
    }

    class Program
    {
        private static List<Edge>[] _edgesByNode;
        private static TimeSpan[] _distances;

        static void Main()
        {
            var rooms = int.Parse(Console.ReadLine());
            var exitRooms = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var edges = int.Parse(Console.ReadLine());

            _edgesByNode = ReadEdges(rooms, edges);

            var timeCap = TimeSpan.ParseExact(Console.ReadLine(), "mm\\:ss", CultureInfo.InvariantCulture);

            _distances = new TimeSpan[rooms];
            var bestDistances = new TimeSpan[rooms];

            for (int node = 0; node < bestDistances.Length; node++)
            {
                bestDistances[node] = TimeSpan.MaxValue;
            }

            FindEvacuationTimes(rooms, exitRooms, bestDistances);

            PrintEvacuationTimes(exitRooms, timeCap, bestDistances);
        }

        private static void FindEvacuationTimes(int rooms, int[] exitRooms, TimeSpan[] bestDistances)
        {
            for (int i = 0; i < rooms; i++)
            {
                if (exitRooms.Contains(i))
                {
                    continue;
                }

                for (int node = 0; node < _distances.Length; node++)
                {
                    _distances[node] = TimeSpan.MaxValue;
                }

                _distances[i] = new TimeSpan();

                GetShortestPath(i);

                foreach (var room in exitRooms)
                {
                    if (_distances[room] < bestDistances[i])
                    {
                        bestDistances[i] = _distances[room];
                    }
                }
            }
        }

        private static void PrintEvacuationTimes(int[] exitRooms, TimeSpan timeCap, TimeSpan[] bestDistances)
        {
            for (int i = 0; i < bestDistances.Length; i++)
            {
                if (exitRooms.Contains(i))
                {
                    continue;
                }

                if (bestDistances[i] == TimeSpan.MaxValue)
                {
                    Console.WriteLine($"Unreachable {i} (N/A)");
                }
                else if (bestDistances[i] <= timeCap)
                {
                    Console.WriteLine($"Safe {i} ({bestDistances[i]:hh\\:mm\\:ss})");
                }
                else
                {
                    Console.WriteLine($"Unsafe {i} ({bestDistances[i]:hh\\:mm\\:ss})");
                }
            }
        }

        private static void GetShortestPath(int start)
        {
            var queue = new OrderedBag<int>(
                Comparer<int>.Create((f, s) => _distances[f].CompareTo(_distances[s])));

            queue.Add(start);

            while (queue.Count > 0)
            {
                var minNode = queue.RemoveFirst();

                //if (exitRooms.Contains(minNode))
                //{
                //    break;
                //}

                var children = _edgesByNode[minNode];

                foreach (var child in children)
                {
                    var childNode = child.First == minNode ? child.Second : child.First;

                    if (_distances[childNode] == TimeSpan.MaxValue)
                    {
                        queue.Add(childNode);
                    }

                    var newDistance = child.Weight + _distances[minNode];

                    if (newDistance < _distances[childNode])
                    {
                        _distances[childNode] = newDistance;

                        queue = new OrderedBag<int>(
                            queue,
                            Comparer<int>.Create((f, s) => _distances[f].CompareTo(_distances[s])));
                    }
                }
            }
        }

        private static List<Edge>[] ReadEdges(int rooms, int edges)
        {
            var result = new List<Edge>[rooms];

            for (int node = 0; node < rooms; node++)
            {
                result[node] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine().Split();

                var firstNode = int.Parse(edgeData[0]);
                var secondNode = int.Parse(edgeData[1]);
                var weight = TimeSpan.ParseExact(edgeData[2], "mm\\:ss", CultureInfo.InvariantCulture);

                var edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = weight
                };

                result[firstNode].Add(edge);
                result[secondNode].Add(edge);
            }

            return result;
        }
    }
}
