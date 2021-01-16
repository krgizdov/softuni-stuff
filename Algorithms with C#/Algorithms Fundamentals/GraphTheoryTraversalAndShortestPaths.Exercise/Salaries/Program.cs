using System;
using System.Collections.Generic;

namespace Salaries
{
    class Program
    {
        private static List<int>[] _graph;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            _graph = ReadGraph(n);

            var totalSalary = 0;
            for (int node = 0; node < _graph.Length; node++)
            {
                var salary = GetSalary(node);

                totalSalary += salary;
            }

            Console.WriteLine(totalSalary);
        }

        private static int GetSalary(int node)
        {
            //Algorithm could be optimised using memorization since each node may occur more than once.
            if (_graph[node].Count == 0)
            {
                return 1;
            }

            var salary = 0;

            foreach (var child in _graph[node])
            {
                salary += GetSalary(child);
            }

            return salary;
        }

        private static List<int>[] ReadGraph(int n)
        {
            var graph = new List<int>[n];

            for (int node = 0; node < n; node++)
            {
                var children = new List<int>();

                var sequence = Console.ReadLine();

                for (int i = 0; i < sequence.Length; i++)
                {
                    if (sequence[i] == 'Y')
                    {
                        children.Add(i);
                    }
                }

                graph[node] = children;
            }

            return graph;
        }
    }
}
