using _07InfernoInfinity.Commands;
using _07InfernoInfinity.Contracts;
using _07InfernoInfinity.Enums;
using _07InfernoInfinity.Factories;
using _07InfernoInfinity.Models;
using _07InfernoInfinity.Models.Gems;
using _07InfernoInfinity.Models.Weapons;
using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main(string[] args)
    {
        IRepository repository = new Repository();
        ICommandInterpreter commandInterpreter = new CommandInterpreter(repository);
        IRunable engine = new Engine(commandInterpreter);
        engine.Run();
    }
}

