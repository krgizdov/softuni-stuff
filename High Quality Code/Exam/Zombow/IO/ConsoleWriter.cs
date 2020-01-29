using System;
using Zombow.IO.Contracts;

namespace Zombow.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}