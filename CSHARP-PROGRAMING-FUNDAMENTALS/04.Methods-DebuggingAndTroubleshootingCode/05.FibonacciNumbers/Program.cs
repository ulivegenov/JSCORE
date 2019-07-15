using System;

namespace _05.FibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong countOfFibonacciNumber = ulong.Parse(Console.ReadLine());

            Console.WriteLine(FibonaciNumberValue(countOfFibonacciNumber));
        }

        static ulong FibonaciNumberValue(ulong countOfSign)
        {

            ulong valueOfSignOne = 0;
            ulong valueOfSignTwo = 1;
            ulong valueOfNewSign = 0;
            if (countOfSign == 0)
            {
                valueOfNewSign = 1;
            }
            else
            {
                for (ulong i = 1; i <= countOfSign; i++)
                {
                    valueOfNewSign = valueOfSignOne + valueOfSignTwo;
                    valueOfSignOne = valueOfSignTwo;
                    valueOfSignTwo = valueOfNewSign;
                }
            }
            return valueOfNewSign;
        }
    }
}
