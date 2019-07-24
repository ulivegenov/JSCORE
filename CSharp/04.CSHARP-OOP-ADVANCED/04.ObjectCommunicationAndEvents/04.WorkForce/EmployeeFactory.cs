namespace _04WorkForce
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class EmployeeFactory
    {
        public IEmployee CreateEmployee(string employeeType, string employeeName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == employeeType);

            if (type == null)
            {
                throw new ArgumentException("Invalid Employee Type!");
            }

            return (IEmployee)Activator.CreateInstance(type, new object[] { employeeName, });
        }
    }
}
