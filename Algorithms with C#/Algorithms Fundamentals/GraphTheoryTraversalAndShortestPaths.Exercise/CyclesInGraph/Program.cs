using System;
using System.Collections.Generic;

namespace CyclesInGraph
{
    class Program
    {
        private static Dictionary<string, List<string>> _graph;
        private static readonly HashSet<string> _visited = new HashSet<string>();
        private static readonly HashSet<string> _cycles = new HashSet<string>();

        static void Main()
        {
            _graph = ReadGraph();

            foreach (var node in _graph.Keys)
            {
                try
                {
                    DFS(node);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Acyclic: No");
                    return;
                }
            }

            Console.WriteLine("Acyclic: Yes");
        }

        private static void DFS(string node)
        {
            if (_cycles.Contains(node))
            {
                throw new InvalidOperationException();
            }

            if (_visited.Contains(node))
            {
                return;
            }

            _cycles.Add(node);
            _visited.Add(node);

            foreach (var child in _graph[node])
            {
                DFS(child);
            }

            _cycles.Remove(node);
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var graph = new Dictionary<string, List<string>>();

            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                var parts = line.Split("-", StringSplitOptions.RemoveEmptyEntries);

                var parent = parts[0];
                var child = parts[1];

                if (!graph.ContainsKey(parent))
                {
                    graph[parent] = new List<string>();
                }

                if (!graph.ContainsKey(child))
                {
                    graph[child] = new List<string>();
                }

                graph[parent].Add(child);
            }

            return graph;
        }
    }
}
