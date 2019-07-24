using System;

namespace _03.UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            foreach (var symbol in input)
            {
                Console.Write($@"\u{(int)symbol:x4}");
            }
            Console.WriteLine();
        }
    }
}
