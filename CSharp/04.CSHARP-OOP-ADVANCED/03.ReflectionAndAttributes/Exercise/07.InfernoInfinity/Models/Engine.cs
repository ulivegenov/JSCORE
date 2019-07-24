using _07InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Models
{
    public class Engine : IRunable
    {
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.CommandInterpreter = commandInterpreter;
        }

        public ICommandInterpreter CommandInterpreter { get; private set; }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    this.CommandInterpreter.InterpredCommand(input).Execute();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }   
            }
        }
    }
}
