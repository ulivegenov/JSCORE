namespace _03DependencyInversion
{
    using System;
    using Strategies;

    public class StartUp
    {
        static void Main(string[] args)
        {
            PrimitiveCalculator calculator = new PrimitiveCalculator(new AdditionStrategy());
            Engine engine = new Engine(calculator);
            engine.Run();
        }
    }
}
