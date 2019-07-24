using System;

namespace _17.PrintPartOf_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstIndex = int.Parse(Console.ReadLine());
            int lastIndex = int.Parse(Console.ReadLine());

            for (int currentSymbol = firstIndex; currentSymbol <= lastIndex; currentSymbol++)
            {
                Console.Write($"{(char)currentSymbol} ");
            }
            Console.WriteLine();
        }
    }
}
