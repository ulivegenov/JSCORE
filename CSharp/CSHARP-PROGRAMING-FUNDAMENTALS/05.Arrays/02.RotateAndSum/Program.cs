using System;

namespace _02.RotateAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numsArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] sumOfRotatedArrays = new int[numsArray.Length];
            int countOfRotations = int.Parse(Console.ReadLine());

            for (int currentRotatiton = 0; currentRotatiton < countOfRotations; currentRotatiton++)
            {
                int[] rotatedNumsArray = new int[numsArray.Length];
                rotatedNumsArray[0] = numsArray[numsArray.Length - 1];

                for (int i = 1; i < rotatedNumsArray.Length; i++)
                {
                    rotatedNumsArray[i] = numsArray[i - 1];
                }

                for (int i = 0; i < sumOfRotatedArrays.Length; i++)
                {
                    sumOfRotatedArrays[i] += rotatedNumsArray[i];
                }

                numsArray = rotatedNumsArray;
            }

            Console.WriteLine(string.Join(" ", sumOfRotatedArrays));
        }
    }
}
