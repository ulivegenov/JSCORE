namespace _04WorkForce.Employees
{
    using Contracts;
    public class PartTimeEmployee : Employee
    {
        private const int defaultWorHoursPerWeek = 20;

        public PartTimeEmployee(string name):base(name)
        {
            this.workHoursPerWeek = defaultWorHoursPerWeek;
        }
    }
}
