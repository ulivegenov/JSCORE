using System;
using System.Linq;

namespace _08.MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int currentCountOfFrequentElements = 0;
            int maxCountOfFrequentElements = 1;
            int mostFrequentElement = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        currentCountOfFrequentElements++;

                        if (currentCountOfFrequentElements > maxCountOfFrequentElements)
                        {
                            maxCountOfFrequentElements = currentCountOfFrequentElements;
                            mostFrequentElement = array[i];
                        }
                    }
                }

                currentCountOfFrequentElements = 0;
            }

            Console.WriteLine(mostFrequentElement);
        }
    }
}
