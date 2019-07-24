using System;
using System.Linq;

namespace _11.EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int leftSum = 0;
            int raightSum = 0;
            int countOfEqualSums = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    leftSum += array[j];
                }

                for (int k = i + 1; k < array.Length; k++)
                {
                    raightSum += array[k];
                }

                if (leftSum == raightSum)
                {
                    countOfEqualSums++;
                    Console.WriteLine(i);
                    break;
                }

                leftSum = 0;
                raightSum = 0;
            }
            if (countOfEqualSums == 0)
            {
                Console.WriteLine("no");
            }
        }
    }
}
