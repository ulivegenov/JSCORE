using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int countToPush = inputData[0];
            int countToPop = inputData[1];
            int numToPresent = inputData[2];

            Stack<int> stack = new Stack<int>();
            int[] inputNums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < countToPush; i++)
            {
                stack.Push(inputNums[i]);
            }

            for (int i = 0; i < countToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(numToPresent))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
