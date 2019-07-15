using System;
using System.Numerics;

namespace ConsoleApp1
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
            Console.WriteLine(factorial);
        }
    }
}
