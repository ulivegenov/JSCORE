using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.MathPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();
            Queue<string> queue = new Queue<string>();
            Queue<string> primesQueue = new Queue<string>();
            int countOfToss = int.Parse(Console.ReadLine());
            int counter = 1;
            int moveCounter = 1;

            while (input.Count > 1)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    if ((counter == countOfToss) && (input.Count > 1))
                    {
                        if (IsPrime(moveCounter))
                        {
                            primesQueue.Enqueue(input[i]);
                            i--;
                            counter = 0;
                        }
                        else
                        {
                            queue.Enqueue(input[i]);
                            input.Remove(input[i]);
                            i--;
                            counter = 0;  
                        }
                        moveCounter++;
                    }
                    counter++;
                }
            }
            moveCounter = 1;

            while (queue.Count != 0)
            {
                if (IsPrime(moveCounter))
                {
                    Console.WriteLine($"Prime {primesQueue.Dequeue()}");
                }
                else
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }
                moveCounter++;
            }
            Console.WriteLine($"Last is {input[0]}");
        }

        static bool IsPrime(int n)
        {
            int sqrtN = (int)Math.Sqrt(n);
            if (n <= 1)
            {
                return false;
            }
            else if (n > 2)
            {
                for (int cnt = 2; cnt <= sqrtN; cnt++)
                {
                    if (n % cnt == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
