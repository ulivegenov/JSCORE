using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class BlackBoxIntegerTests
{
    private StringBuilder result;

    public BlackBoxIntegerTests()
    {
        this.result = new StringBuilder();
    }

    public string Run(Type type)
    {
        var classInstance = Activator.CreateInstance(type, true);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputArgs = input.Split('_');
            string command = inputArgs[0];
            int intArg = int.Parse(inputArgs[1]);

            methods.FirstOrDefault(m => m.Name == command)?.Invoke(classInstance, new object[] { intArg });

            foreach (var field in fields)
            {
                this.result.AppendLine(field.GetValue(classInstance).ToString());
            }
        }

        return this.result.ToString().Trim();
    }
}

