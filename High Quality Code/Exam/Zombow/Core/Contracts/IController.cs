using System.Collections.Generic;

namespace Zombow.Core.Contracts
{
    public interface IController
    {
        string AddZombie(IList<string> args);

        string AddBow(IList<string> args);

        string AddBowToPlayer(IList<string> args);

        string Fight();
    }
}