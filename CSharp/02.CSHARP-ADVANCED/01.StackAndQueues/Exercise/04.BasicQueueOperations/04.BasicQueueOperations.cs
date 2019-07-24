using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dataComands = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            int[] dataNums = Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();


            int countOfEnqueue = dataComands[0];
            int countOfDequeue = dataComands[1];
            int elementToContains = dataComands[2];
            Queue<int> numbers = new Queue<int>();

            for (int i = 0; i < countOfEnqueue; i++)
            {
                numbers.Enqueue(dataNums[i]);
            }

            for (int i = 0; i < countOfDequeue; i++)
            {
                numbers.Dequeue();
            }


            if (numbers.Count != 0)
            {
                if (numbers.Contains(elementToContains))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numbers.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
