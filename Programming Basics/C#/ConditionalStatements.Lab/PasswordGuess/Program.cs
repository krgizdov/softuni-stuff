using System;

namespace PasswordGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            const string correctPassword = "s3cr3t!P@ssw0rd";
            string inputPassword = Console.ReadLine();

            if (inputPassword == correctPassword)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
