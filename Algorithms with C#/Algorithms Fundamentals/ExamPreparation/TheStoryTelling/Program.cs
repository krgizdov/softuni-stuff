using System;
using System.Collections.Generic;
using System.Linq;

namespace TheStoryTelling
{
    class Program
    {
        private static Dictionary<string, List<string>> _graph;
        private static Dictionary<string, int> _dependencies;

        static void Main()
        {
            _graph = ReadGraph();
            _dependencies = ExtractDependencies();

            var sorted = TopologicalSorting();

            Console.WriteLine(string.Join(" ", sorted));
        }

        private static List<string> TopologicalSorting()
        {
            var sorted = new List<string>();

            while (_dependencies.Count > 0)
            {
                var nodeToRemove = _dependencies.Reverse().FirstOrDefault(n => n.Value == 0);

                if (nodeToRemove.Key == null)
                {
                    break;
                }

                var node = nodeToRemove.Key;
                var children = _graph[node];

                sorted.Add(node);

                foreach (var child in children)
                {
                    _dependencies[child]--;
                }

                _dependencies.Remove(node);
            }

            return sorted;
        }

        private static Dictionary<string, int> ExtractDependencies()
        {
            var dependencies = new Dictionary<string, int>();

            foreach (var kvp in _graph)
            {
                var node = kvp.Key;
                var children = kvp.Value;

                if (!dependencies.ContainsKey(node))
                {
                    dependencies[node] = 0;
                }

                foreach (var child in children)
                {
                    if (!dependencies.ContainsKey(child))
                    {
                        dependencies[child] = 0;
                    }

                    dependencies[child]++;
                }
            }

            return dependencies;
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
