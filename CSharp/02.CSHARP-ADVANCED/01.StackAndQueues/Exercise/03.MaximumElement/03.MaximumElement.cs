using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfQueries = int.Parse(Console.ReadLine());
            Stack<int> inputQueries = new Stack<int>();
            Stack<int> maxValues = new Stack<int>();
            int currentMaxValue = int.MinValue;



            for (int i = 0; i < countOfQueries; i++)
            {
                int[] currentQuery = Console.ReadLine()
                                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();
                
                if (currentQuery[0] == 1)
                {
                    inputQueries.Push(currentQuery[1]);

                    if (currentMaxValue <= currentQuery[1])
                    {
                        currentMaxValue = currentQuery[1];
                        maxValues.Push(currentMaxValue);
                    }  
                }
                else if (currentQuery[0] == 2)
                {
                    if (inputQueries.Pop() == currentMaxValue)
                    {
                        maxValues.Pop();
                        if (maxValues.Count != 0)
                        {
                            currentMaxValue = maxValues.Peek();
                        }
                        else
                        {
                            currentMaxValue = int.MinValue;
                        }
                    }
                    
                }
                else if (currentQuery[0] == 3)
                {
                    Console.WriteLine(currentMaxValue);
                }
            }
        }
    }
}
