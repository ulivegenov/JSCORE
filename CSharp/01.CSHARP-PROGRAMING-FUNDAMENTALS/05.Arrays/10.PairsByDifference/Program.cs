using System;
using System.Linq;

namespace _10.PairsByDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int diff = int.Parse(Console.ReadLine());
            int countOfPairs = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (Math.Abs(array[i] - array[j]) == diff)
                    {
                        countOfPairs++;
                    }
                }
            }

            Console.WriteLine(countOfPairs);
        }
    }
}
