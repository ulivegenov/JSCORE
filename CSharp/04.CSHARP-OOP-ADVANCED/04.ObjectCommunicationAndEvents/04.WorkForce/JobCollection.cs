namespace _04WorkForce
{
    using Contracts;
    using System.Collections.Generic;
    using System;
    using System.Text;

    public class JobCollection
    {
        public delegate void PastWeekEventHandler();

        private List<IJob> jobs;

        public JobCollection(List<IJob> jobs)
        {
            this.jobs = jobs;
        }

        public IReadOnlyCollection<IJob> Jobs { get { return this.jobs; } }

        public event PastWeekEventHandler PastWeekEvent;

        public void Add(IJob jobToAdd)
        {
            this.jobs.Add(jobToAdd);
            this.PastWeekEvent += jobToAdd.Update;
            jobToAdd.JobDoneEvent += this.OnJobDone;
        }

        public void PastWeek()
        {
            if (this.PastWeekEvent != null)
            {
                this.PastWeekEvent.Invoke();
            }
        }

        public void OnJobDone(object sender)
        {
            this.jobs.Remove((IJob)sender);  
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var job in this.Jobs)
            {
                sb.AppendLine(job.ToString());
            }

            string result = sb.ToString().Trim();

            return result;
        }
    }
}
