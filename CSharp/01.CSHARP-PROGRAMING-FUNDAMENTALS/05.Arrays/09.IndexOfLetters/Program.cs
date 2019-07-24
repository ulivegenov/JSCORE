using System;

namespace _09.IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] arrayAlphabet = new char[26];

            char ch = 'a';

            for (int i = 0; i < arrayAlphabet.Length; i++, ch++)
            {
                arrayAlphabet[i] = ch;
            }

            string inputLetersArray = Console.ReadLine().ToLower();

            for (int i = 0; i < inputLetersArray.Length; i++)
            {
                for (int j = 0; j < arrayAlphabet.Length; j++)
                {
                    if (inputLetersArray[i] == arrayAlphabet[j])
                    {
                        Console.WriteLine($"{inputLetersArray[i]} -> {j}");
                    }
                }
            }
        }
    }
}
