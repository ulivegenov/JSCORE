using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();
            Queue<string> queue = new Queue<string>();
            int countOfToss = int.Parse(Console.ReadLine());
            int counter = 1;

            while (input.Count > 1)
            {
                for (int  i = 0;  i < input.Count;  i++)
                {
                    if ((counter == countOfToss) && (input.Count > 1))
                    {
                        queue.Enqueue(input[i]);
                        input.Remove(input[i]);
                        i--;
                        counter = 0;
                    }
                    counter++;
                }
            }

            while (queue.Count != 0)
            {
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {input[0]}");
        }
    }
}
