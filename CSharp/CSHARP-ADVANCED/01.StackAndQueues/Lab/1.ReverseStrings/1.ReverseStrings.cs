using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> result = new Stack<char>();

            foreach (var ch in input)
            {
                result.Push(ch);
            }

            while (result.Count != 0)
            {
                Console.Write(result.Pop());
            }
            Console.WriteLine();
        }
    }
}
