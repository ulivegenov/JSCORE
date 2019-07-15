using System;

namespace _02.MaxMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMax(GetMax(firstNumber, secondNumber), thirdNumber));

        }

        static int GetMax(int numOne, int numTwo)
        {
            if (numOne > numTwo)
            {
                return numOne;
            }
            else
            {
                return numTwo;
            }
        }
    }
}
