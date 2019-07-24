using System;

namespace _10.TriangleOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int currentRow = 1; currentRow <= number; currentRow++)
            {
                for (int currentSymbol = 1; currentSymbol <= currentRow; currentSymbol++)
                {
                    Console.Write($"{currentRow} ");
                }
                Console.WriteLine();
            }
        }
    }
}
