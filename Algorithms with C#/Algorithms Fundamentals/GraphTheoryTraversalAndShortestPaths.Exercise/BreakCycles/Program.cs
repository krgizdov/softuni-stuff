using System;
using System.Collections.Generic;
using System.Linq;

namespace BreakCycles
{
    class Edge
    {
        public Edge(string first, string second)
        {
            First = first;
            Second = second;
        }

        public string First { get; set; }

        public string Second { get; set; }

        public override string ToString()
        {
            return $"{First} - {Second}";
        }

        public string ToStringReversed()
        {
            return $"{Second} - {First}";
        }
    }

    class Program
    {
        private static readonly Dictionary<string, List<string>> _graph = new Dictionary<string, List<string>>();
        private static List<Edge> _edges = new List<Edge>();

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            ProcessInput(n);

            _edges = _edges
                .OrderBy(e => e.First)
                .ThenBy(e => e.Second)
                .ToList();

            var removedEdges = new List<Edge>();
            var blackListed = new HashSet<string>();

            foreach (var edge in _edges)
            {
                var first = edge.First;
                var second = edge.Second;

                _graph[first].Remove(second);
                _graph[second].Remove(first);

                if (HasPath(first, second))
                {
                    if (blackListed.Contains(edge.ToString()))
                    {
                        continue;
                    }

                    removedEdges.Add(edge);
                    blackListed.Add(edge.ToStringReversed());
                }
                else
                {
                    _graph[first].Add(second);
                    _graph[second].Add(first);
                }
            }

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");
            foreach (var edge in removedEdges)
            {
                Console.WriteLine($"{edge.First} - {edge.Second}");
            }
        }

        private static bool HasPath(string source, string destination)
        {
            var visited = new HashSet<string>();
            var queue = new Queue<string>();

            queue.Enqueue(source);
            visited.Add(source);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return true;
                }

                foreach (var child in _graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }

            return false;
        }

        private static void ProcessInput(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                var parent = parts[0];
                var children = parts[1].Split().ToList();

                _graph[parent] = children;

                foreach (var child in children)
                {
                    _edges.Add(new Edge(parent, child));
                }
            }
        }
    }
}
