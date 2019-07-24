using System;

namespace _04.SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool[] numsArray = new bool[n + 1];

            numsArray[0] = numsArray[1] = false;


            for (int i = 2; i <= n; i++)
            {
                numsArray[i] = true;
            }

            for (int i = 0; i <= n; i++)
            {
                if (numsArray[i] == true)
                {
                    Console.WriteLine(i + " ");

                    int p = i;
                    int multiplier = 1;

                    while (p <= n)
                    {
                        numsArray[p] = false;
                        multiplier++;
                        p = multiplier * i;
                    }
                }
            }
        }
    }
}
