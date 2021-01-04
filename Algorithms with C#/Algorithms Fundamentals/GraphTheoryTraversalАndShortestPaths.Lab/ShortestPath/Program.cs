using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestPath
{
    class Program
    {
        private static List<int>[] _graph;
        private static bool[] _visited;
        private static int[] _parents;

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            _graph = ReadGraph(nodes, edges);
            _visited = new bool[_graph.Length];
            _parents = new int[_graph.Length];
            Array.Fill(_parents, -1);

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            BFS(source, destination);
        }

        private static void BFS(int startNode, int destination)
        {
            if (_visited[startNode])
            {
                return;
            }

            var queue = new Queue<int>();
            queue.Enqueue(startNode);

            _visited[startNode] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    var path = ReconstructPath(destination);

                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                    Console.WriteLine(string.Join(" ", path));

                    return;
                }

                foreach (var child in _graph[node])
                {
                    if (!_visited[child])
                    {
                        _parents[child] = node;
                        _visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }
        }

        private static Stack<int> ReconstructPath(int destination)
        {
            var path = new Stack<int>();
            var index = destination;

            while (index != -1)
            {
                path.Push(index);
                index = _parents[index];
            }

            return path;
        }

        private static List<int>[] ReadGraph(int nodes, int edges)
        {
            var graph = new List<int>[nodes + 1];

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int node = 0; node < edges; node++)
            {
                var edge = Console.ReadLine().Split().Select(int.Parse).ToList();

                var from = edge[0];
                var to = edge[1];

                if (graph[from] == null)
                {
                    graph[from] = new List<int>();
                }

                graph[from].Add(to);
            }

            return graph;
        }
    }
}
