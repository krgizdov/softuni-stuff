using System;
using System.Collections.Generic;
using System.Linq;

namespace BfsExample
{
    class Program
    {
        private static Dictionary<int, List<int>> _graph;
        private static HashSet<int> _visited = new HashSet<int>();

        static void Main()
        {
            _graph = new Dictionary<int, List<int>>
            {
                { 7, new List<int> { 19, 21, 14 } },
                { 19, new List<int> { 1, 12, 31, 21 } },
                { 21, new List<int> { 14 } },
                { 14, new List<int> { 6, 23 } },
                { 1, new List<int> { 7 } },
                { 12, new List<int>() },
                { 31, new List<int> { 21 } },
                { 6, new List<int>() },
                { 23, new List<int> { 21 } }
            };

            BFS(_graph.FirstOrDefault().Key);
        }

        private static void BFS(int key)
        {
            var queue = new Queue<int>();
            queue.Enqueue(key);
            _visited.Add(key);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                Console.WriteLine(node);

                foreach (var child in _graph[node])
                {
                    if (!_visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        _visited.Add(child);
                    }
                }
            }
        }
    }
}
