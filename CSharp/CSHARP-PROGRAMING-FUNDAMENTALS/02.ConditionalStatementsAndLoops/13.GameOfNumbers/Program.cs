using System;

namespace _13.GameOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int magicalNumber = int.Parse(Console.ReadLine());

            int lastCombinationFirstNumber = 0;
            int lastCombinationSecondNumber = 0;
            int countOfCombinations = 0;

            for (int currentFirstNum = firstNumber; currentFirstNum <= secondNumber; currentFirstNum++)
            {
                for (int currentSecondNum = firstNumber; currentSecondNum <= secondNumber; currentSecondNum++)
                {
                    countOfCombinations++;

                    if ((currentFirstNum + currentSecondNum) == magicalNumber)
                    {
                        lastCombinationFirstNumber = currentFirstNum;
                        lastCombinationSecondNumber = currentSecondNum;
                    }
                }
            }

            if ((lastCombinationFirstNumber + lastCombinationSecondNumber) == magicalNumber)
            {
                Console.WriteLine($"Number found! {lastCombinationFirstNumber} + {lastCombinationSecondNumber} = {magicalNumber}");
            }
            else
            {
                Console.WriteLine($"{countOfCombinations} combinations - neither equals {magicalNumber}");
            }
        }
    }
}
