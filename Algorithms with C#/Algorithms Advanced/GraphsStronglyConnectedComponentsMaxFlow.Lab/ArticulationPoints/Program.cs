using System;
using System.Collections.Generic;
using System.Linq;

namespace ArticulationPoints
{
    class Program
    {
        private static List<int>[] _graph;
        private static int[] _depth;
        private static int[] _lowPoint;
        private static int[] _parent;
        private static bool[] _visited;
        private static List<int> _articulationPoints;

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var lines = int.Parse(Console.ReadLine());

            _graph = ReadGraph(nodes, lines);
            _depth = new int[nodes];
            _lowPoint = new int[nodes];
            _parent = new int[nodes];
            _visited = new bool[nodes];
            _articulationPoints = new List<int>();

            Array.Fill(_parent, -1);

            for (int node = 0; node < _graph.Length; node++)
            {
                if (!_visited[node])
                {
                    FindArticulationPoint(node, 1);
                }
            }

            Console.WriteLine($"Articulation points: {string.Join(", ", _articulationPoints)}");
        }

        private static void FindArticulationPoint(int node, int depth)
        {
            _visited[node] = true;
            _lowPoint[node] = depth;
            _depth[node] = depth;

            var childCount = 0;
            var isArticulationPoint = false;

            foreach (var child in _graph[node])
            {
                if (!_visited[child])
                {
                    _parent[child] = node;
                    FindArticulationPoint(child, depth + 1);
                    childCount++;

                    if (_lowPoint[child] >= depth)
                    {
                        isArticulationPoint = true;
                    }

                    _lowPoint[node] = Math.Min(_lowPoint[node], _lowPoint[child]);
                }
                else if (_parent[node] != child)
                {
                    _lowPoint[node] = Math.Min(_lowPoint[node], _depth[child]);
                }
            }

            if (_parent[node] == -1 && childCount > 1 || 
                _parent[node] != -1 && isArticulationPoint)
            {
                _articulationPoints.Add(node);
            }
        }

        private static List<int>[] ReadGraph(int nodes, int lines)
        {
            var graph = new List<int>[nodes];

            for (int node = 0; node < nodes; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < lines; i++)
            {
                var line = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = line[0];

                for (int child = 1; child < line.Length; child++)
                {
                    graph[firstNode].Add(line[child]);
                }
            }

            return graph;
        }
    }
}
