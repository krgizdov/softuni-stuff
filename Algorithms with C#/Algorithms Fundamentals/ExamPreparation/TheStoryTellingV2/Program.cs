using System;
using System.Collections.Generic;
using System.Linq;

namespace TheStoryTellingV2
{
    class Program
    {
        private static Dictionary<string, List<string>> _graph;
        private static readonly HashSet<string> _visited = new HashSet<string>();
        private static readonly Stack<string> _result = new Stack<string>();

        static void Main()
        {
            _graph = ReadGraph();

            foreach (var node in _graph.Keys)
            {
                DFS(node);
            }

            Console.WriteLine(string.Join(" ", _result));
        }

        private static void DFS(string node)
        {
            if (_visited.Contains(node))
            {
                return;
            }

            _visited.Add(node);

            foreach (var child in _graph[node])
            {
                DFS(child);
            }

            _result.Push(node);
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var graph = new Dictionary<string, List<string>>();

            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                var parts = line.Split("->", StringSplitOptions.RemoveEmptyEntries);

                var parent = parts[0].Trim();
                var children = parts.Length > 1 ? parts[1]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList() : new List<string>();

                if (!graph.ContainsKey(parent))
                {
                    graph[parent] = children;
                }
                else
                {
                    graph[parent].AddRange(children);
                }
            }

            return graph;
        }
    }
}
