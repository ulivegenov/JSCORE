using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);

        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(n => n.AttributeType == typeof(SoftUniAttribute)))
            {
                var attribytes = method.GetCustomAttributes(false);
                foreach (SoftUniAttribute attribyte in attribytes)
                {
                    Console.WriteLine($"{method.Name} is written by {attribyte.Name}");
                }
            }
        }
    }
}

