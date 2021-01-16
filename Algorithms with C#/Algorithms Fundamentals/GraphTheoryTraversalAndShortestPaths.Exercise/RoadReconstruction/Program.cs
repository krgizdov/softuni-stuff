using System;
using System.Collections.Generic;

namespace RoadReconstruction
{
    class Street
    {
        public Street(int firstBuilding, int secondBuilding)
        {
            FirstBuilding = firstBuilding;
            SecondBuilding = secondBuilding;
        }

        public int FirstBuilding { get; set; }

        public int SecondBuilding { get; set; }

        public override string ToString()
        {
            if (FirstBuilding < SecondBuilding)
            {
                return $"{FirstBuilding} {SecondBuilding}";
            }
            else
            {
                return $"{SecondBuilding} {FirstBuilding}";
            }
        }
    }

    class Program
    {
        private static Dictionary<int, List<int>> _graph;
        private static readonly List<Street> _streets = new List<Street>();

        static void Main()
        {
            var buildingsCount = int.Parse(Console.ReadLine());
            var streetsCount = int.Parse(Console.ReadLine());

            _graph = ReadGraph(streetsCount);

            var importantStreets = new List<Street>();

            foreach (var street in _streets)
            {
                var firstBuilding = street.FirstBuilding;
                var secondBuilding = street.SecondBuilding;

                _graph[firstBuilding].Remove(secondBuilding);
                _graph[secondBuilding].Remove(firstBuilding);

                if (IsImportant(firstBuilding, secondBuilding))
                {
                    importantStreets.Add(street);
                }

                _graph[firstBuilding].Add(secondBuilding);
                _graph[secondBuilding].Add(firstBuilding);
            }

            Console.WriteLine("Important streets:");
            foreach (var street in importantStreets)
            {
                Console.WriteLine(street);
            }
        }

        private static bool IsImportant(int firstBuilding, int secondBuilding)
        {
            var queue = new Queue<int>();
            queue.Enqueue(firstBuilding);

            var visited = new HashSet<int> { firstBuilding };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == secondBuilding)
                {
                    return false;
                }

                foreach (var child in _graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }

            return true;
        }

        private static Dictionary<int, List<int>> ReadGraph(int streetsCount)
        {
            var result = new Dictionary<int, List<int>>();

            for (int i = 0; i < streetsCount; i++)
            {
                var input = Console.ReadLine()
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                var firstBulding = int.Parse(input[0]);
                var secondBulding = int.Parse(input[1]);

                if (!result.ContainsKey(firstBulding))
                {
                    result[firstBulding] = new List<int>();
                }

                if (!result.ContainsKey(secondBulding))
                {
                    result[secondBulding] = new List<int>();
                }

                result[firstBulding].Add(secondBulding);
                result[secondBulding].Add(firstBulding);

                _streets.Add(new Street(firstBulding, secondBulding));
            }

            return result;
        }
    }
}
