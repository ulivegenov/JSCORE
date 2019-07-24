namespace _04WorkForce
{
    using Contracts;
    using System;

    public class Job : IJob
    {
        private string name;
        private int hoursOfWorkRequired;

        public Job(string name, int hoursOfWorkRequired, IEmployee employee)
        {
            this.name = name;
            this.hoursOfWorkRequired = hoursOfWorkRequired;
            this.Employee = employee;

            this.IsComplete = false;
        }

        public IEmployee Employee { get; private set; }

        public bool IsComplete { get; private set; }

        public event JobDoneEventHandler JobDoneEvent;

        public void Update()
        {
            this.hoursOfWorkRequired -= this.Employee.WorkHoursPerWeek;

            if (this.hoursOfWorkRequired <= 0 && !IsComplete)
            {
                IsComplete = true;
                Console.WriteLine($"Job {this.name} done!");

                if (this.JobDoneEvent != null)
                {
                    this.JobDoneEvent.Invoke(this);
                }
            }
        }

        public override string ToString()
        {
            return $"Job: {this.name} Hours Remaining: {this.hoursOfWorkRequired}";
        }
    }
}
