using Zombow.Core;
using Zombow.Core.Contracts;

namespace Zombow
{
    public class StartUp
    {
        private static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}