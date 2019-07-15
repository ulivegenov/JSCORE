using System;

namespace _06.PrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());

            Console.WriteLine(IsPrime(number));

        }

        static bool IsPrime(long num)
        {
            bool isPrime = false;
            int sqrtNum = (int)Math.Sqrt(num);

            if ((num == 2) || (num == 3))
            {
                isPrime = true;
            }
            else if (num > 2)
            {
                for (int currentNum = 2; currentNum <= sqrtNum; currentNum++)
                {
                    if (num % currentNum == 0)
                    {
                        isPrime = false;
                    }
                    else
                    {
                        isPrime = true;
                    }
                }
            }
            return isPrime;
        }
    }
}
