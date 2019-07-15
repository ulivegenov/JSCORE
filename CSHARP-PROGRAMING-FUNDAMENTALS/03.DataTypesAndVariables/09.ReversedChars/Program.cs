using System;

namespace _09.ReversedChars
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstSymbol = char.Parse(Console.ReadLine());
            char secondSymbol = char.Parse(Console.ReadLine());
            char thirdSymbol = char.Parse(Console.ReadLine());

            Console.WriteLine($"{thirdSymbol}{secondSymbol}{firstSymbol}");
        }
    }
}

