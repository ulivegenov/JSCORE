using _07InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _07InfernoInfinity.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSuffix = "Command";

        public CommandInterpreter(IRepository repository)
        {
            this.Repository = repository;
        }

        public IRepository Repository { get; private set; }

        public IExecutable InterpredCommand(string data)
        {
            string[] args = data.Split(';');
            string commandName = args[0];
            string commandFullName = $"{commandName}{CommandSuffix}";
            string commandData = data.Substring(commandName.Length + 1);

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(c => c.Name == commandFullName);

            if (commandType == null)
            {
                throw new ArgumentException("Invalid Command Type!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException("Invalid Command!");
            }

            return (IExecutable)Activator.CreateInstance(commandType, new object[] { commandData, this.Repository });
        }
    }
}
