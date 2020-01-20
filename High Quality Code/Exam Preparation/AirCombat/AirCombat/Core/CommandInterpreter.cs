namespace AirCombat.Core
{
    using System.Collections.Generic;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager aircraftManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.aircraftManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            inputParameters.RemoveAt(0);

            /*
            Tried to create a ProcessHandling Class 
            ProcessHandler testing = new ProcessHandler(inputParameters, this.aircraftManager);
            string result = testing.HandleCommand(command);
            */

            //Processing the command using a switch statement.
            string result = string.Empty;
            switch (command)
            {
                case "AirCraft":
                    result = this.aircraftManager.AddAircraft(inputParameters);
                    break;
                case "Part":
                    result = this.aircraftManager.AddPart(inputParameters);
                    break;
                case "Inspect":
                    result = this.aircraftManager.Inspect(inputParameters);
                    break;
                case "Battle":
                    result = this.aircraftManager.Battle(inputParameters);
                    break;
                case "Terminate":
                    result = this.aircraftManager.Terminate(inputParameters);
                    break;
            }

            return result;
        }
    }
}