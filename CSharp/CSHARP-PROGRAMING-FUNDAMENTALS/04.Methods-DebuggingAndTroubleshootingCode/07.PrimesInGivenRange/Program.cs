using System;

namespace _07.PrimesInGivenRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            if (firstNumber > secondNumber)
            {
                Console.WriteLine("(empty list)");
            }
            PrintListOfPrimeIntegers(firstNumber, secondNumber);
            Console.WriteLine();
        }

        static void PrintListOfPrimeIntegers(int startNumber, int endNumber)
        {
            int secondStartNumber = 0;
            for (int currentNumber = startNumber; currentNumber <= endNumber; currentNumber++)
            {
                if (IsPrime(currentNumber) == true)
                {
                    Console.Write($"{currentNumber}");
                }
                if (IsPrime(currentNumber) == true)
                {
                    secondStartNumber = currentNumber + 1;
                    break;
                }
            }
            for (int currentNumber = secondStartNumber; currentNumber <= endNumber; currentNumber++)
            {
                if (IsPrime(currentNumber) == true)
                {
                    Console.Write($", {currentNumber}");
                }
            }
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
                        break;
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
