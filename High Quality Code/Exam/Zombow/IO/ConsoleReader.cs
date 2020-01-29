using System;
using Zombow.IO.Contracts;

namespace Zombow.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}