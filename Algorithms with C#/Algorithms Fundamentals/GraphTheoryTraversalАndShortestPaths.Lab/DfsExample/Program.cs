using System;
using System.Collections.Generic;

namespace DfsExample
{
    class Program
    {
        private static Dictionary<int, List<int>> _graph;
        private static HashSet<int> _visited = new HashSet<int>();
        static void Main()
        {
            _graph = new Dictionary<int, List<int>>
            {
                { 1, new List<int> { 19, 21, 14 } },
                { 19, new List<int> { 7, 12, 31, 21 } },
                { 21, new List<int> { 14 } },
                { 14, new List<int> { 6, 23 } },
                { 7, new List<int> { 1 } },
                { 12, new List<int>() },
                { 31, new List<int> { 21 } },
                { 23, new List<int> { 21 } },
                { 6, new List<int>() }
            };

            foreach (var node in _graph.Keys)
            {
                DFS(node);
            }
        }

        private static void DFS(int node)
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

            Console.WriteLine(node);
        }
    }
}
