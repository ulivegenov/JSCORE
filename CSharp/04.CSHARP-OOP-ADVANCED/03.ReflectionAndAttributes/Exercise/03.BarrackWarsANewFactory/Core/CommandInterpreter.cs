using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Commands;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _03BarracksFactory.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string NamespaceAsString = "_03BarracksFactory.Core.Commands";
        private const string CommandSuffix = "Command";

        IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(commandName.Substring(0, 1).ToUpper());
            sb.Append(commandName.Substring(1));
            sb.Append(CommandSuffix);
            string commandFullName = sb.ToString();
            //string commandFullName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandSuffix;

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(c => c.Name == commandFullName);

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException($"{commandType} is not a command!");
            }

            FieldInfo[] fieldsToInject = commandType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                                    .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute)))
                                                    .ToArray();

            object[] injectedArgs = fieldsToInject.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();
            object[] constrArgs = new object[] { data }.Concat(injectedArgs).ToArray();

            IExecutable commandTypeInstance = (IExecutable)Activator.CreateInstance(commandType, constrArgs);

            return commandTypeInstance;
        }
    }
}
