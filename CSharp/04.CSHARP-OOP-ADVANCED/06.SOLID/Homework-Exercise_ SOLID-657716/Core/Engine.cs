namespace Solid.Core
{
    using Solid.Core.Contracts;

    using System;    
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }      

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                this.commandInterpreter.AddAppender(inputArgs);
            }
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArg = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                this.commandInterpreter.AddMessage(inputArg);
                input = Console.ReadLine();
            }
            this.commandInterpreter.PrintInfo();
        }
    }
}
