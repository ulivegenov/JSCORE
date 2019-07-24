﻿namespace Solid
{
    using Solid.Core;
    using Solid.Core.Contracts;
    
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();

        }
    }
}
