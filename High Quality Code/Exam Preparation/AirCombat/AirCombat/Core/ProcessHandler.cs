using AirCombat.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirCombat.Core
{
    public class ProcessHandler
    {
        private readonly IManager aircraftManager;
        
        public ProcessHandler(IList<string> inputParameters, IManager tankManager)
        {
            this.InputParameters = inputParameters;
            this.aircraftManager = tankManager;
            this.Kvps = new Dictionary<string, Func<string>>()
            {
                { "AirCraft", () => aircraftManager.AddAircraft(InputParameters)},
                { "Part", () => aircraftManager.AddPart(InputParameters)},
                { "Inspect", () => aircraftManager.Inspect(InputParameters)},
                { "Battle", () => aircraftManager.Battle(InputParameters)},
                { "Terminate", () => aircraftManager.Terminate(InputParameters)},
            };
        }

        public Dictionary<string, Func<string>> Kvps { get; set; }

        public IList<string> InputParameters { get; set; }

        public string HandleCommand(string command)
        {
            string result = this.Kvps[command]();

            return result;
        }
    }
}
