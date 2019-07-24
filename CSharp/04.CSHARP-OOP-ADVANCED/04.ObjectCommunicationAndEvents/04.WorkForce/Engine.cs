namespace _04WorkForce
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private List<IEmployee> employees;

        public Engine(JobCollection jobCollection, List<IEmployee> employees)
        {
            this.JobCollection = jobCollection;
            this.employees = employees;
        }

        public JobCollection JobCollection { get; private set; }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] args = input.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(this.JobCollection);
                }
                else if (args.Length == 2)
                {
                    if (args[0] == "Pass")
                    {
                        this.JobCollection.PastWeek();
                    }
                    else
                    {
                        string employeeType = args[0];
                        string employeeName = args[1];
                        EmployeeFactory factory = new EmployeeFactory();
                        IEmployee employee = factory.CreateEmployee(employeeType, employeeName);
                        this.employees.Add(employee);
                    }
                }
                else
                {
                    string jobName = args[1];
                    int hoursOfWorkRequired = int.Parse(args[2]);
                    string employeeName = args[3];
                    IEmployee employee = this.employees.First(e => e.Name == employeeName);

                    IJob job = new Job(jobName, hoursOfWorkRequired, employee);
                    this.JobCollection.Add(job);
                }
            }
        }
    }
}
