using System.Collections.Generic;

namespace Zombow.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string ProcessInput(IList<string> inputParameters);
    }
}