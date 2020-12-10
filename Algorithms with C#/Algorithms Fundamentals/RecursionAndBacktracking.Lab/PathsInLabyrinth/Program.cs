using System;
using System.Collections.Generic;

namespace PathsInLabyrinth
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            var lab = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    lab[row, col] = line[col];
                }
            }

            var paths = new List<char>();

            FindAllPaths(lab, 0, 0, paths, '\0');
        }

        private static void FindAllPaths(char[,] lab, int row, int col, List<char> paths, char direction)
        {
            if (IsOutside(lab, row, col) || IsWall(lab, row, col) || IsVisited(lab, row, col))
            {
                return;
            }

            paths.Add(direction);

            if (IsEnd(lab, row, col))
            {
                Console.WriteLine(string.Join("", paths));
                paths.RemoveAt(paths.Count - 1);
                return;
            }

            lab[row, col] = 'v';

            FindAllPaths(lab, row, col + 1, paths, 'R');
            FindAllPaths(lab, row - 1, col, paths, 'U');
            FindAllPaths(lab, row + 1, col, paths, 'D');
            FindAllPaths(lab, row, col - 1, paths, 'L');

            paths.RemoveAt(paths.Count - 1);
            lab[row, col] = '-';
        }

        private static bool IsEnd(char[,] lab, int row, int col)
        {
            return lab[row, col] == 'e';
        }

        private static bool IsVisited(char[,] lab, int row, int col)
        {
            return lab[row, col] == 'v';
        }

        private static bool IsWall(char[,] lab, int row, int col)
        {
            return lab[row, col] == '*';
        }

        private static bool IsOutside(char[,] lab, int row, int col)
        {
            return row < 0 ||
                row >= lab.GetLength(0) ||
                col < 0 ||
                col >= lab.GetLength(1);
        }
    }
}
