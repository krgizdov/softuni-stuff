using System.Collections.Generic;
using Zombow.Core.Contracts;

namespace Zombow.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IController controller;

        public CommandInterpreter()
        {
            this.controller = new Controller();
        }
        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            inputParameters.RemoveAt(0);

            string result = string.Empty;
            switch (command)
            {
                case "AddZombie":
                    result = this.controller.AddZombie(inputParameters);
                    break;
                case "AddBow":
                    result = this.controller.AddBow(inputParameters);
                    break;
                case "AddBowToPlayer":
                    result = this.controller.AddBowToPlayer(inputParameters);
                    break;
                case "Fight":
                    result = this.controller.Fight();
                    break;
            }

            return result;
        }
    }
}