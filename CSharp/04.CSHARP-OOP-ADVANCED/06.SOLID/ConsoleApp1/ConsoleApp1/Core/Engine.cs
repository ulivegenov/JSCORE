

namespace Solid.Core
{
    using Solid.Appenders.Contracts;
    using Solid.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Engine : IEngine
    {
        //private ICollection<IAppander> appenders;
        private ICommand commands;

        public Engine(ICommand commands)
        {
            this.commands = commands;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                this.commands.AddAppender(input);

            }

            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                string[] args = inputLine.Split('|');
                this.commands.AddMessage(args);

                inputLine = Console.ReadLine();
            }
            this.commands.Print();
        }
    }
}
