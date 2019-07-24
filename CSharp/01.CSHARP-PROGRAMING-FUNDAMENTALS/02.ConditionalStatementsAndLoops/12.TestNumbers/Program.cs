using System;

namespace _12.TestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int boundaryOfTheSum = int.Parse(Console.ReadLine());

            int sum = 0;
            int countOfCombinations = 0;

            for (int currentFirstDigit = numberOne; currentFirstDigit >= 1; currentFirstDigit--)
            {
                for (int currentSecondDigit = 1; currentSecondDigit <= numberTwo; currentSecondDigit++)
                {
                    sum += 3 * (currentFirstDigit * currentSecondDigit);
                    countOfCombinations++;

                    if (sum >= boundaryOfTheSum)
                    {
                        break;
                    }
                }
                if (sum >= boundaryOfTheSum)
                {
                    break;
                }
            }

            if (sum >= boundaryOfTheSum)
            {
                Console.WriteLine($"{countOfCombinations} combinations");
                Console.WriteLine($"Sum: {sum} >= {boundaryOfTheSum}");
            }
            else
            {
                Console.WriteLine($"{countOfCombinations} combinations");
                Console.WriteLine($"Sum: {sum}");
            }
        }
    }
}
