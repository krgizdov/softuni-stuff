using System;
using System.Collections.Generic;

namespace MaximumTasksAssignment
{
    class Program
    {
        private static int[,] _graph;
        private static int[] _parents;

        static void Main()
        {
            var people = int.Parse(Console.ReadLine());
            var tasks = int.Parse(Console.ReadLine());

            _graph = ReadGraph(people, tasks);

            var nodes = people + tasks + 2;

            _parents = new int[nodes];
            Array.Fill(_parents, -1);

            var start = 0;
            var target = nodes - 1;

            while (BFS(start, target))
            {
                GetAssignedTasks(start, target);
            }

            PrintAssignments(people, tasks);
        }

        private static void PrintAssignments(int people, int tasks)
        {
            for (int person = 1; person <= people; person++)
            {
                for (int task = people + 1; task <= people + tasks; task++)
                {
                    if (_graph[task, person] > 0)
                    {
                        Console.WriteLine($"{(char)(64 + person)}-{task - people}");
                        break;
                    }
                }
            }
        }

        private static void GetAssignedTasks(int source, int target)
        {
            var node = target;

            while (node != source)
            {
                var parent = _parents[node];

                _graph[parent, node] = 0;
                _graph[node, parent] = 1;

                node = parent;
            }
        }

        private static bool BFS(int source, int target)
        {
            var queue = new Queue<int>();
            var visited = new bool[_graph.GetLength(0)];

            queue.Enqueue(source);
            visited[source] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == target)
                {
                    return true;
                }

                for (int child = 0; child < _graph.GetLength(1); child++)
                {
                    if (!visited[child] && _graph[node, child] > 0)
                    {
                        visited[child] = true;
                        queue.Enqueue(child);
                        _parents[child] = node;
                    }
                }
            }

            return false;
        }

        private static int[,] ReadGraph(int people, int tasks)
        {
            var nodes = people + tasks + 2;

            var graph = new int[nodes, nodes];

            var start = 0;
            var target = nodes - 1;

            for (int person = 1; person <= people; person++)
            {
                graph[start, person] = 1;
            }

            for (int task = people + 1; task <= people + tasks; task++)
            {
                graph[task, target] = 1;
            }

            for (int person = 1; person <= people; person++)
            {
                var line = Console.ReadLine();

                for (int t = 0; t < line.Length; t++)
                {
                    if (line[t] == 'Y')
                    {
                        graph[person, people + 1 + t] = 1;
                    }
                }
            }

            return graph;
        }
    }
}
