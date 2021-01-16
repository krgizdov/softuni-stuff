using System;
using System.Collections.Generic;
using System.Linq;

namespace DistanceBetweenVertices
{
    class Program
    {
        private static Dictionary<int, List<int>> _graph;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            _graph = ReadGraph(n);

            for (int i = 0; i < p; i++)
            {
                var pair = Console.ReadLine().Split("-").Select(int.Parse).ToArray();

                var source = pair[0];
                var destination = pair[1];

                var steps = GetShortestPath(source, destination);

                Console.WriteLine($"{{{source}, {destination}}} -> {steps}");
            }
        }

        private static int GetShortestPath(int source, int destination)
        {
            var queue = new Queue<int>();
            var steps = new Dictionary<int, int> { { source, 0 } };

            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return steps[node];
                }

                foreach (var child in _graph[node])
                {
                    if (!steps.ContainsKey(child))
                    {
                        queue.Enqueue(child);
                        steps[child] = steps[node] + 1;
                    }
                }
            }

            return -1;
        }

        private static Dictionary<int, List<int>> ReadGraph(int n)
        {
            var graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);

                var key = int.Parse(parts[0]);
                var children = parts.Length > 1 ? parts[1].Split().Select(int.Parse).ToList() : new List<int>();

                graph[key] = children;
            }

            return graph;
        }
    }
}
