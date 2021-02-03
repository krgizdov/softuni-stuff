using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxFlow
{
    class Program
    {
        private static int[,] _graph;
        private static int[] _parents;

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());

            _graph = ReadGraph(nodes);

            var source = int.Parse(Console.ReadLine());
            var target = int.Parse(Console.ReadLine());

            _parents = new int[nodes];
            Array.Fill(_parents, -1);

            var maxFlow = FindMaxFlow(source, target);

            Console.WriteLine($"Max flow = {maxFlow}");
        }

        private static int FindMaxFlow(int source, int target)
        {
            var maxFlow = 0;

            while (BFS(source, target))
            {
                var currentFlow = GetCurrentFlow(source, target);

                maxFlow += currentFlow;

                ApplyCurrentFlow(source, target, currentFlow);
            }

            return maxFlow;
        }

        private static void ApplyCurrentFlow(int source, int target, int currentFlow)
        {
            var node = target;

            while (node != source)
            {
                var parent = _parents[node];

                _graph[parent, node] -= currentFlow;

                node = parent;
            }
        }

        private static int GetCurrentFlow(int source, int target)
        {
            var node = target;
            var minFlow = int.MaxValue;

            while (node != source)
            {
                var parent = _parents[node];

                var flow = _graph[parent, node];

                if (flow < minFlow)
                {
                    minFlow = flow;
                }

                node = parent;
            }

            return minFlow;
        }

        private static bool BFS(int source, int target)
        {
            var queue = new Queue<int>();
            var visited = new bool[_graph.GetLength(0)];

            queue.Enqueue(source);
            visited[source] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == target)
                {
                    return true;
                }

                for (int child = 0; child < _graph.GetLength(1); child++)
                {
                    if (!visited[child] && _graph[node, child] > 0)
                    {
                        visited[child] = true;
                        queue.Enqueue(child);
                        _parents[child] = node;
                    }
                }
            }

            return false;
        }

        private static int[,] ReadGraph(int nodes)
        {
            var graph = new int[nodes, nodes];

            for (int node = 0; node < nodes; node++)
            {
                var capacities = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int child = 0; child < capacities.Length; child++)
                {
                    graph[node, child] = capacities[child];
                }
            }

            return graph;
        }
    }
}
