namespace _04WorkForce.Employees
{
    using Contracts;
    public abstract class Employee : IEmployee
    {
        protected int workHoursPerWeek;

        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public int WorkHoursPerWeek { get { return this.workHoursPerWeek; } }
    }
}
