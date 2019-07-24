using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                             .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                             .Select(int.Parse)
                             .ToList();
            Stack<int> stack = new Stack<int>();

            foreach (var number in nums)
            {
                stack.Push(number);
            }

            for (int i = 0; i < nums.Count; i++)
            {
                Console.Write($"{stack.Pop()} ");
            }
            
            Console.WriteLine();
        }
    }
}
