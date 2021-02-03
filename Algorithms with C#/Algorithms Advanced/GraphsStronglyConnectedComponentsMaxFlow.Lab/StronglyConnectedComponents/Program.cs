using System;
using System.Collections.Generic;
using System.Linq;

namespace StronglyConnectedComponents
{
    class Program
    {
        private static List<int>[] _graph;
        private static List<int>[] _reverseGraph;
        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var lines = int.Parse(Console.ReadLine());

            (_graph, _reverseGraph) = ReadGraph(nodes, lines);

            var sorted = TopologicalSorting();

            var visited = new bool[nodes];

            Console.WriteLine("Strongly Connected Components:");

            FindStronglyConnectedComponents(visited, sorted);
        }

        private static void FindStronglyConnectedComponents(bool[] visited, Stack<int> sorted)
        {
            while (sorted.Count > 0)
            {
                var node = sorted.Pop();

                if (visited[node])
                {
                    continue;
                }

                var component = new Stack<int>();

                DFS(_reverseGraph, node, visited, component);

                Console.WriteLine($"{{{string.Join(", ", component)}}}");
            }
        }

        private static Stack<int> TopologicalSorting()
        {
            var result = new Stack<int>();
            var visited = new bool[_graph.Length];

            for (int node = 0; node < _graph.Length; node++)
            {
                DFS(_graph, node, visited, result);
            }

            return result;
        }

        private static void DFS(List<int>[] source, int node, bool[] visited, Stack<int> result)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in source[node])
            {
                DFS(source, child, visited, result);
            }

            result.Push(node);
        }

        private static (List<int>[] original, List<int>[] reversed) ReadGraph(int nodes, int lines)
        {
            var graph = new List<int>[nodes];
            var reversed = new List<int>[nodes];

            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<int>();
                reversed[i] = new List<int>();
            }

            for (int i = 0; i < lines; i++)
            {
                var data = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                var node = data[0];

                for (int j = 1; j < data.Length; j++)
                {
                    var child = data[j];
                    graph[node].Add(child);
                    reversed[child].Add(node);
                }
            }

            return (graph, reversed);
        }
    }
}
