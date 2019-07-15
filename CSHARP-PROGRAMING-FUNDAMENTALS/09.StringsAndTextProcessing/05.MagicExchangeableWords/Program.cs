using System;
using System.Collections.Generic;

namespace _05.MagicExchangeableWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().ToLower().Split(' ');
            string firstString = input[0];
            string secondString = input[1];
            int firstStringDifferentCharsCount = 1;
            int secondStringDifferentCharsCount = 1;
            Dictionary<char, int> firstDict = new Dictionary<char, int>();
            Dictionary<char, int> secondDict = new Dictionary<char, int>();


            for (int i = 0; i < firstString.Length; i++)
            {
                if (!firstDict.ContainsKey(firstString[i]))
                {
                    firstDict.Add(firstString[i], firstStringDifferentCharsCount);
                    firstStringDifferentCharsCount++;
                }
            }
            for (int i = 0; i < secondString.Length; i++)
            {
                if (!secondDict.ContainsKey(secondString[i]))
                {
                    secondDict.Add(secondString[i], secondStringDifferentCharsCount);
                    secondStringDifferentCharsCount++;
                }
            }

            if (firstStringDifferentCharsCount == secondStringDifferentCharsCount)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
