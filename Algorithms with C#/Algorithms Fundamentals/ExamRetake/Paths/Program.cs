using System;
using System.Collections.Generic;
using System.Linq;

namespace Paths
{
    class Program
    {
        private static List<int>[] _graph;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            _graph = ReadGraph(n);

            for (int node = 0; node < n - 1; node++)
            {
                bool[] isVisited = new bool[n];
                var pathList = new List<int> { node };

                PrintAllPaths(node, n - 1, isVisited, pathList);
            }
        }

        private static void PrintAllPaths(int source, int destination, bool[] isVisited, List<int> localPathList)
        {
            if (source == destination)
            {
                Console.WriteLine(string.Join(" ", localPathList));

                return;
            }

            isVisited[source] = true;

            foreach (var child in _graph[source])
            {
                if (child < isVisited.Length && !isVisited[child])
                {
                    localPathList.Add(child);
                    PrintAllPaths(child, destination, isVisited, localPathList);
                    localPathList.Remove(child);
                }
            }

            isVisited[source] = false;
        }

        private static List<int>[] ReadGraph(int n)
        {
            var graph = new List<int>[n];

            for (int i = 0; i < n - 1; i++)
            {
                var parent = i;
                var children = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                graph[parent] = children;
            }

            return graph;
        }
    }
}
