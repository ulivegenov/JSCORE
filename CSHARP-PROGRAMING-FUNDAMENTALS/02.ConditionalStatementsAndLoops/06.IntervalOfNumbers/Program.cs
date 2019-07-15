using System;

namespace _06.IntervalOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());

            if (numberOne < numberTwo)
            {
                for (int currentNumber = numberOne; currentNumber <= numberTwo; currentNumber++)
                {
                    Console.WriteLine(currentNumber);
                }
            }
            else
            {
                for (int currentNumber = numberTwo; currentNumber <= numberOne; currentNumber++)
                {
                    Console.WriteLine(currentNumber);
                }
            }
        }
    }
}
