using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<long> fibonacciNum = new Stack<long>();
            long getNum = long.Parse(Console.ReadLine());
            fibonacciNum.Push(0);
            fibonacciNum.Push(1);

            for (int i = 1; i < getNum; i++)
            {
                long currentNum = fibonacciNum.Pop();
                long previousCurrentNum = fibonacciNum.Peek();
                fibonacciNum.Push(currentNum);
                long newCurrentNum = currentNum + previousCurrentNum;
                fibonacciNum.Push(newCurrentNum);
            }

            Console.WriteLine(fibonacciNum.Pop());
        }
    }
}
