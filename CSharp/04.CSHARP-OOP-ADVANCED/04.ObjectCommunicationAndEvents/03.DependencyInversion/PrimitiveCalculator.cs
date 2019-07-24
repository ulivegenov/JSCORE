namespace _03DependencyInversion
{
    using Contracts;

    public class PrimitiveCalculator
    {
        private IStrategy currentStrategy;

        public PrimitiveCalculator(IStrategy strategy)
        {
            this.ChangeStrategy(strategy);
        }

        public void ChangeStrategy(IStrategy strategy)
        {
            this.currentStrategy = strategy;
        }

        public int performCalculation(int firstOperand, int secondOperand)
        {
            return this.currentStrategy.Calculate(firstOperand, secondOperand);
        }
    }
}
