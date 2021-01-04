using System;
using System.Collections.Generic;
using System.Linq;

namespace TopologicalSorting
{
    class Program
    {
        private static Dictionary<string, List<string>> _graph;
        private static Dictionary<string, int> _dependencies;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            _graph = ReadGraph(n);
            _dependencies = ExtractDependencies();

            var sorted = TopologicalSorting();

            if (sorted == null)
            {
                Console.WriteLine("Invalid topological sorting");
            }
            else
            {
                Console.WriteLine($"Topological sorting: { string.Join(", ", sorted)}");
            }
        }

        private static List<string> TopologicalSorting()
        {
            var sorted = new List<string>();

            while (_dependencies.Count > 0)
            {
                var nodeToRemove = _dependencies.FirstOrDefault(n => n.Value == 0);

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

            if (_dependencies.Count > 0)
            {
                return null;
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

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var graphResult = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);

                var key = parts[0].Trim();
                //if parts[1] != " " is before the other check the program will throw an exception
                var children = parts.Length > 1 && parts[1] != " " ? parts[1].Trim().Split(", ") : new string[0];

                graphResult[key] = new List<string>(children);
            }

            return graphResult;
        }
    }
}
