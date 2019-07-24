using System;
using System.Linq;

namespace _03.FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numsArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = numsArray.Length / 4;
            int[] upFoldItNumsArray = new int[k * 2];
            int[] downFoldItNumsArray = new int[k * 2];

            for (int i = 0; i < k; i++)
            {
                upFoldItNumsArray[i] = numsArray[k - i - 1];
                upFoldItNumsArray[upFoldItNumsArray.Length - i - 1] = numsArray[numsArray.Length - k + i];
                downFoldItNumsArray[2 * i] = numsArray[2 * i + k];
                downFoldItNumsArray[2 * i + 1] = numsArray[2 * i + k + 1];
            }

            int[] sumOfFoldArrays = new int[k * 2];

            for (int i = 0; i < sumOfFoldArrays.Length; i++)
            {
                sumOfFoldArrays[i] = upFoldItNumsArray[i] + downFoldItNumsArray[i];
            }
            Console.WriteLine(string.Join(" ", sumOfFoldArrays));
        }
    }
}