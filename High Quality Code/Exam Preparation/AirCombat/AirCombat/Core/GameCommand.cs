using AirCombat.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirCombat.Core
{
    public class GameCommand : ICommand
    {
        public GameCommand(ICommandInterpreter interpreter, IList<string> inputParameters)
        {
            this.InputParameters = inputParameters;
            this.Interpreter = interpreter;
        }

        public IList<string> InputParameters { get; set; }

        public ICommandInterpreter Interpreter { get; set; }
        public string Execute()
        {
            return this.Interpreter.ProcessInput(this.InputParameters);
        }
    }
}
