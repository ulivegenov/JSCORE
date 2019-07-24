namespace _04WorkForce
{
    using System.Collections.Generic;
    using Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            JobCollection jobCollection = new JobCollection(new List<IJob>());
            Engine engine = new Engine(jobCollection, new List<IEmployee>());
            engine.Run();
        }
    }
}
