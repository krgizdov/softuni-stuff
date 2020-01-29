using System;
using System.Collections.Generic;
using System.Linq;
using ViceCity.Core;
using Zombow.Core.Contracts;
using Zombow.IO;
using Zombow.IO.Contracts;

namespace Zombow.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandInterpreter commandInterpreter;

        public Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
            this.commandInterpreter = new CommandInterpreter();
        }


        public void Run()
        {
            //Can put each command in the list to print the output after each command is given
            //var commands = new List<GameCommand>();

            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    IList<string> args = input.ToList();

                    var command = new GameCommand(this.commandInterpreter, args);

                    this.writer.WriteLine(command.Execute());
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}