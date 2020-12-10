using System;

namespace RecursiveDrawing
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            DrawFigure(size);
        }

        private static void DrawFigure(int size)
        {
            if (size == 0) 
            { 
                return;
            }

            Console.WriteLine(new string('*', size));
            DrawFigure(size - 1);
            Console.WriteLine(new string('#', size));
        }
    }
}
