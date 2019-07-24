using System;

namespace _01.LargestCommonEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            string textOne = Console.ReadLine();
            string[] arrayOne = textOne.Split(' ');
            string textTwo = Console.ReadLine();
            string[] arrayTwo = textTwo.Split(' ');

            int countOfEqualElements = 0;
            int reverseCountOfEqualElements = 0;

            if ((arrayOne.Length > arrayTwo.Length) || (arrayOne.Length == arrayTwo.Length))
            {
                for (int i = 0; i < arrayTwo.Length; i++)
                {
                    if (arrayOne[i] == arrayTwo[i])
                    {
                        countOfEqualElements++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < arrayOne.Length; i++)
                {
                    if (arrayOne[i] == arrayTwo[i])
                    {
                        countOfEqualElements++;
                    }
                }
            }

            int arraysLenghtDiff = Math.Abs(arrayOne.Length - arrayTwo.Length);

            if ((arrayOne.Length > arrayTwo.Length) || (arrayOne.Length == arrayTwo.Length))
            {
                for (int i = arrayTwo.Length - 1; i >= 0; i--)
                {
                    if (arrayOne[i + arraysLenghtDiff] == arrayTwo[i])
                    {
                        reverseCountOfEqualElements++;
                    }
                }
            }
            else
            {
                for (int i = arrayOne.Length - 1; i >= 0; i--)
                {
                    if (arrayOne[i] == arrayTwo[i + arraysLenghtDiff])
                    {
                        reverseCountOfEqualElements++;
                    }
                }
            }

            if (countOfEqualElements >= reverseCountOfEqualElements)
            {
                Console.WriteLine(countOfEqualElements);
            }
            else
            {
                Console.WriteLine(reverseCountOfEqualElements);
            }


        }
    }
}
