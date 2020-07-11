using System;

namespace ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            const int timeForOneProject = 3;

            string architectName = Console.ReadLine();
            int projectAmount = int.Parse(Console.ReadLine());

            Console.WriteLine($"The architect {architectName} will need " +
                $"{projectAmount * timeForOneProject} hours to complete {projectAmount} project/s.");
        }
    }
}
