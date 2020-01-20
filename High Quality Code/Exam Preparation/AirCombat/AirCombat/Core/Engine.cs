namespace AirCombat.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AirCombat.Utils;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;
            //StringBuilder builder = new StringBuilder();

            var commands = new List<GameCommand>();

            while (this.isRunning)
            {
                var line = this.reader.ReadLine();
                var cmds = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var commandName = cmds[0];
                var command = new GameCommand(this.commandInterpreter, cmds);

                commands.Add(command);

                if (commandName == GlobalConstants.TerminateCommand)
                {
                    this.isRunning = false;
                }
            }
            commands.ForEach(c => Console.WriteLine(c.Execute()));
        }
    }
}