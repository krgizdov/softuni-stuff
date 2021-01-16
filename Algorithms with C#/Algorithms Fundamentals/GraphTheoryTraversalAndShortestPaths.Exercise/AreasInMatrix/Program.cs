using System;
using System.Collections.Generic;
using System.Linq;

namespace AreasInMatrix
{
    class Node
    {
        public int Row { get; set; }

        public int Col { get; set; }
    }

    class Program
    {
        private static char[,] _matrix;
        private static bool[,] _visited;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            _matrix = ReadMatrix(n, m);
            _visited = new bool[n, m];

            var areas = new Dictionary<char, int>();

            for (int r = 0; r < _matrix.GetLength(0); r++)
            {
                for (int c = 0; c < _matrix.GetLength(1); c++)
                {
                    if (_visited[r, c])
                    {
                        continue;
                    }

                    DFS(r, c);

                    var key = _matrix[r, c];

                    if (!areas.ContainsKey(key))
                    {
                        areas.Add(key, 1);
                    }
                    else
                    {
                        areas[key]++;
                    }
                }
            }

            Console.WriteLine($"Areas: {areas.Values.Sum()}");
            foreach (var area in areas.OrderBy(a => a.Key))
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void DFS(int row, int col)
        {
            _visited[row, col] = true;

            var children = GetChildren(row, col);

            foreach (var child in children)
            {
                DFS(child.Row, child.Col);
            }
        }

        private static List<Node> GetChildren(int row, int col)
        {
            var children = new List<Node>();

            AddChild(row, col, row - 1, col, children);
            AddChild(row, col, row + 1, col, children);
            AddChild(row, col, row, col - 1, children);
            AddChild(row, col, row, col + 1, children);

            return children;
        }

        private static void AddChild(int parentRow, int parentCol, int childRow, int childCol, List<Node> children)
        {
            if (IsInside(childRow, childCol) &&
                IsChild(parentRow, parentCol, childRow, childCol) &&
                !IsVisited(childRow, childCol))
            {
                children.Add(new Node { Row = childRow, Col = childCol });
            }
        }

        private static bool IsVisited(int row, int col)
        {
            return _visited[row, col];
        }

        private static bool IsChild(int parentRow, int parentCol, int childRow, int childCol)
        {
            return _matrix[parentRow, parentCol] == _matrix[childRow, childCol];
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 &&
                   row < _matrix.GetLength(0) &&
                   col >= 0 &&
                   col < _matrix.GetLength(1);
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            var result = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var elements = Console.ReadLine();

                for (int c = 0; c < elements.Length; c++)
                {
                    result[r, c] = elements[c];
                }
            }

            return result;
        }
    }
}
