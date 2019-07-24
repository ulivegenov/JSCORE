namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == unitType);

            if (type == null)
            {
                throw new ArgumentException("Invalid Unit Type!");
            }

            if (!typeof(IUnit).IsAssignableFrom(type))
            {
                throw new ArgumentException($"{type} is not Unit Type!");
            }

            return (IUnit)Activator.CreateInstance(type);
        }
    }
}
