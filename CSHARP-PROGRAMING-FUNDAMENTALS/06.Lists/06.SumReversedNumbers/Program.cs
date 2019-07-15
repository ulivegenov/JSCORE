using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SumReversedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int sum = 0;


            for (int i = 0; i < numbers.Count; i++)
            {
                int reversedNum = 0;

                while (numbers[i] > 0)
                {
                    int lastDigit = numbers[i] % 10;
                    reversedNum = reversedNum * 10 + lastDigit;
                    numbers[i] = numbers[i] / 10;
                }

                sum += reversedNum;
            }

            Console.WriteLine(sum);
        }
    }
}
