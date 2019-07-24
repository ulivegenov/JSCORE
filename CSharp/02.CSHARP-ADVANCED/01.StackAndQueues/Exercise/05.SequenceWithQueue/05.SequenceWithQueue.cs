using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long currentElement = long.Parse(Console.ReadLine());
            Queue<long> elements = new Queue<long>();
            Queue<long> result = new Queue<long>();
            elements.Enqueue(currentElement);
            long newElement = currentElement+1;

            for (int i = 0; i < 50; i++)
            { 
                elements.Enqueue(elements.Peek() + 1);
                elements.Enqueue(2 * elements.Peek() + 1);
                elements.Enqueue(elements.Peek()+2);
                result.Enqueue(elements.Dequeue());
            }

            foreach (var element in result)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
