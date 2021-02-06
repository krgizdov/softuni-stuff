using System;
using System.Collections.Generic;
using System.Linq;

namespace FindBi_ConnectedComponents
{
    class Program
    {
        private static List<int>[] _graph;
        private static int[] _depth;
        private static int[] _lowPoint;
        private static int[] _parents;
        private static bool[] _visited;
        private static Stack<int> _stack;
        private static List<HashSet<int>> _components;

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            _graph = ReadGraph(nodes, edges);

            _depth = new int[nodes];
            _lowPoint = new int[nodes];
            _parents = new int[nodes];
            _visited = new bool[nodes];
            _stack = new Stack<int>();
            _components = new List<HashSet<int>>();

            Array.Fill(_parents, -1);

            for (int node = 0; node < _graph.Length; node++)
            {
                if (!_visited[node])
                {
                    FindArticulationPoint(node, 1);

                    var component = new HashSet<int>();

                    while (_stack.Count > 1)
                    {
                        var stackChild = _stack.Pop();
                        var stackNode = _stack.Pop();

                        component.Add(stackNode);
                        component.Add(stackChild);
                    }

                    _components.Add(component);
                }
            }

            Console.WriteLine($"Number of bi-connected components: {_components.Count}");
            //With this foreach we can see which exactly are the bi-connected components.
            //foreach (var component in _components)
            //{
            //    Console.WriteLine(string.Join(" ", component));
            //}
        }

        private static void FindArticulationPoint(int node, int depth)
        {
            _visited[node] = true;
            _depth[node] = depth;
            _lowPoint[node] = depth;

            var childCount = 0;

            foreach (var child in _graph[node])
            {
                if (!_visited[child])
                {
                    _stack.Push(node);
                    _stack.Push(child);

                    _parents[child] = node;
                    childCount++;
                    FindArticulationPoint(child, depth + 1);

                    if ((_parents[node] == -1 && childCount > 1) ||
                        (_parents[node] != -1 && _lowPoint[child] >= depth))
                    {
                        var component = new HashSet<int>();

                        while (true)
                        {
                            var stackChild = _stack.Pop();
                            var stackNode = _stack.Pop();

                            component.Add(stackNode);
                            component.Add(stackChild);

                            if (stackNode == node && stackChild == child)
                            {
                                break;
                            }
                        }

                        _components.Add(component);
                    }

                    _lowPoint[node] = Math.Min(_lowPoint[node], _lowPoint[child]);
                }
                else if (_parents[node] != child && _depth[child] < _lowPoint[node])
                {
                    _lowPoint[node] = _depth[child];

                    _stack.Push(node);
                    _stack.Push(child);
                }
            }
        }

        private static List<int>[] ReadGraph(int nodes, int edges)
        {
            var graph = new List<int>[nodes];

            for (int node = 0; node < nodes; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edge = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var first = edge[0];
                var second = edge[1];

                graph[first].Add(second);
                graph[second].Add(first);
            }

            return graph;
        }
    }
}
