
namespace Solid
{
    using Solid.Appenders;
    using Solid.Appenders.Contracts;
    using Solid.Core;
    using Solid.Core.Contracts;
    using Solid.Layouts;
    using Solid.Layouts.Contracts;
    using Solid.Loggers;
    using Solid.Loggers.Contracts;
    using Solid.Loggers.Enums;

    public class StartUp
    {
        static void Main(string[] args)
        {
            ICommand commands = new Command();
            Engine engine = new Engine(commands);
            engine.Run();
        }
    }
}
