﻿using System;
using System.Collections.Generic;

namespace _8QueensPuzzle
{
    class Program
    {
        //private static readonly HashSet<int> attackedRows = new HashSet<int>();
        private static readonly HashSet<int> attackedCols = new HashSet<int>();
        private static readonly HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static readonly HashSet<int> attackedRightDiagonals = new HashSet<int>();

        static void Main()
        {
            var board = new bool[8, 8];

            PutQueens(board, 0);
        }

        private static void PutQueens(bool[,] board, int row)
        {
            if (row == board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (!IsAttacked(row, col))
                {
                    SetQueenPosition(board, row, col);

                    PutQueens(board, row + 1);

                    RemoveQueenPosition(board, row, col);
                }
            }
        }

        private static void SetQueenPosition(bool[,] board, int row, int col)
        {
            board[row, col] = true;
            //attackedRows.Add(row);
            attackedCols.Add(col);
            attackedLeftDiagonals.Add(row - col);
            attackedRightDiagonals.Add(row + col);
        }

        private static void RemoveQueenPosition(bool[,] board, int row, int col)
        {
            board[row, col] = false;
            //attackedRows.Remove(row);
            attackedCols.Remove(col);
            attackedLeftDiagonals.Remove(row - col);
            attackedRightDiagonals.Remove(row + col);
        }

        private static bool IsAttacked(int row, int col)
        {
            return /*attackedRows.Contains(row) ||*/
                attackedCols.Contains(col) ||
                attackedLeftDiagonals.Contains(row - col) ||
                attackedRightDiagonals.Contains(row + col);
        }

        private static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}