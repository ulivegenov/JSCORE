using System;
using System.Numerics;

namespace _14.FactorialTrailingZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());

            BigInteger factorial = 1;

            for (int currentNumber = 1; currentNumber <= number; currentNumber++)
            {
                factorial *= currentNumber;
            }
            Console.WriteLine(CountOfTrailingZeroes(factorial));
        }

        static BigInteger CountOfTrailingZeroes(BigInteger number)
        {
            BigInteger countOfTrailingZeroes = 0;
            BigInteger lastDigit = 0;

            while (lastDigit == 0)
            {
                lastDigit = number % 10;
                if (lastDigit == 0)
                {
                    countOfTrailingZeroes++;
                }
                number = number / 10;
            }
            return countOfTrailingZeroes;
        }
    }
}
