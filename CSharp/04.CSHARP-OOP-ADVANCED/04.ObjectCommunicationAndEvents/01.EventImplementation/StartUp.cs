namespace _01EventImplementation
{
    using System;
    using Contracts;
    using Models;

    public class Program
    {
        static void Main(string[] args)
        {
            INameChangeable dispatcher = new Dispatcher("Pesho");
            INamechangeHandler handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                dispatcher.Name = input;
            }
        }
    }
}
