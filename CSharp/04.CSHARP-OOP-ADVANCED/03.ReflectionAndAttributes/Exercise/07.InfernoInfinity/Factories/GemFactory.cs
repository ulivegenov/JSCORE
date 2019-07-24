using _07InfernoInfinity.Contracts;
using _07InfernoInfinity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _07InfernoInfinity.Factories
{
    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(ClarityEnum clarity, string gemName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == gemName);

            if (type == null)
            {
                throw new InvalidOperationException("Invalid Gem Type!");
            }

            if (!typeof(IGem).IsAssignableFrom(type))
            {
                throw new InvalidOperationException($"{type} is not a Gem!");
            }

            return (IGem)Activator.CreateInstance(type, new object[] { clarity });
        }
    }
}
