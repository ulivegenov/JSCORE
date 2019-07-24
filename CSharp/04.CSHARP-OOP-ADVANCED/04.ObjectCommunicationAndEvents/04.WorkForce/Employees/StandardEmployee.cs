namespace _04WorkForce.Employees
{
    using Contracts;

    public class StandardEmployee : Employee
    {
        private const int defaultWorHoursPerWeek = 40;

        public StandardEmployee(string name):base(name)
        {
            this.workHoursPerWeek = defaultWorHoursPerWeek;
        }
    }
}
