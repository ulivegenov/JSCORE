using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.DecimalToBinaryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int binaryElement = 0;
            Stack<int> stack = new Stack<int>();

            if (input != 0)
            {
                while (input != 0)
                {
                    binaryElement = input % 2;
                    stack.Push(binaryElement);
                    input /= 2;
                }
                while(stack.Count != 0)
                {
                    Console.Write(stack.Pop());
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
