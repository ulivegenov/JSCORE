using System;

namespace _09.CountTheIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfIntegers = 0;
            for (; ; )
            {
                try
                {
                    int integer = int.Parse(Console.ReadLine());
                    countOfIntegers++;
                }
                catch (FormatException)
                {
                    break;
                }
                catch (OverflowException)
                {
                    break;
                }
            }

            Console.WriteLine(countOfIntegers);
        }
    }
}
