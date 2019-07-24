using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<long> fibonacciNums = new Queue<long>();
            int getNum = int.Parse(Console.ReadLine());
            long[] result = new long[getNum];

            long currentNum = 1;
            long previousCurrentNum = 0;

            for (int i = 0; i < getNum; i++)
            {
                result[i] = currentNum;
                //fibonacciNums.Enqueue(currentNum);
                long newCurrentNum = currentNum + previousCurrentNum;
                previousCurrentNum = currentNum;
                currentNum = newCurrentNum;
            }

            //for (int i = 0; i < getNum; i++)
            //{
            //    result[i] = fibonacciNums.Dequeue();
            //}
            //
            Console.WriteLine(result[getNum -1]);
        }
    }
}
