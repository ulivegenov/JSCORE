using System;

namespace _04.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            var stringOne = input[0];
            var stringTwo = input[1];
            long result = 0;

            int minStringLenght = Math.Min(stringOne.Length, stringTwo.Length);

            for (int i = 0; i < minStringLenght; i++)
            {
                result += stringOne[i] * stringTwo[i];
            }

            if (stringOne.Length - minStringLenght > 0)
            {
                for (int i = minStringLenght; i < stringOne.Length; i++)
                {
                    result += stringOne[i];
                }
            }
            else if (stringTwo.Length - minStringLenght > 0)
            {
                for (int i = minStringLenght; i < stringTwo.Length; i++)
                {
                    result += stringTwo[i];
                }
            }

            Console.WriteLine(result);
        }
    }
}

