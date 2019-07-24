namespace _03DependencyInversion
{
    using System;
    using Factories;
    using Contracts;

    public class Engine
    {
        private PrimitiveCalculator calculator;

        public Engine(PrimitiveCalculator calculator)
        {
            this.calculator = calculator;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                if (tokens[0] == "mode")
                {
                    string @operator = tokens[1];
                    StrategyFactory strategyFactory = new StrategyFactory();
                    IStrategy strategy = strategyFactory.CreateStrategy(@operator);
                    this.calculator.ChangeStrategy(strategy);
                }
                else
                {
                    int firstOperand = int.Parse(tokens[0]);
                    int secondOperand = int.Parse(tokens[1]);

                    Console.WriteLine(this.calculator.performCalculation(firstOperand, secondOperand));
                }
            }
        }
    }
}
