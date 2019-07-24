namespace _01EventImplementation.Models
{
    using Contracts;

    public class Handler : INamechangeHandler
    {
        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            System.Console.WriteLine($"{sender.GetType().Name}'s name changed to {args.Name}.");
        }
    }
}
