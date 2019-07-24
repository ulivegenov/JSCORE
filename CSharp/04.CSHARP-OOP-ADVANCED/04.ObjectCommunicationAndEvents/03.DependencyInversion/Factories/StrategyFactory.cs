namespace _03DependencyInversion.Factories
{
    using Contracts;
    using Strategies;
    using System;

    public class StrategyFactory
    {
        public StrategyFactory()
        {
        }

        public IStrategy CreateStrategy(string @operator)
        {
            switch (@operator)
            {
                case "+":
                    return new AdditionStrategy();
                case "-":
                    return new SubtractionStrategy();
                case "*":
                    return new MultiplicationStrategy();
                case "/":
                    return new DivisionStrategy();
                default:
                    return new AdditionStrategy();
            }
        }
    }
}
