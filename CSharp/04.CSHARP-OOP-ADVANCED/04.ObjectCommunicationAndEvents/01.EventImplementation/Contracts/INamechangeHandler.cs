namespace _01EventImplementation.Contracts
{
    using Models;

    public interface INamechangeHandler
    {
        void OnDispatcherNameChange(object sender, NameChangeEventArgs args);
    }
}
