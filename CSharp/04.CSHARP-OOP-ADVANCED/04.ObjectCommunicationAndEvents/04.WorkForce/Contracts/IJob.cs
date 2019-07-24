namespace _04WorkForce.Contracts
{
    public delegate void JobDoneEventHandler(object sender);

    public interface IJob
    {
        IEmployee Employee { get; }

        bool IsComplete { get; }

        event JobDoneEventHandler JobDoneEvent;

        void Update();
    }
}
