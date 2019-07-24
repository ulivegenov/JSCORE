using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            long countOfPumps = long.Parse(Console.ReadLine());
            Queue<long> circle = new Queue<long>();
            long check = 0;

            for (long i = 0; i < countOfPumps; i++)
            {
                long[] data = Console.ReadLine()
                             .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(long.Parse)
                             .ToArray();

                long amountOfPetrol = data[0];
                long distance = data[1];

                circle.Enqueue(amountOfPetrol - distance);
                check += (amountOfPetrol - distance);
            }
            if (check < 0) return;
            

            long index = 0;
            long counter = 0;
            long currentDistance = 0;

            while (counter < circle.Count)
            {
                long currentAmountOfPetrol = circle.Dequeue();
                currentDistance += currentAmountOfPetrol;

                if (currentDistance < 0)
                {
                    circle.Enqueue(currentAmountOfPetrol);
                    index++;
                    counter = 0;
                    currentDistance = 0;
                }
                else
                {
                    counter++;
                    index++;
                    circle.Enqueue(currentAmountOfPetrol);
                }
            }

            if (index >= circle.Count)
            {
                Console.WriteLine(index - circle.Count);
            }
            else
            {
                Console.WriteLine(index);
            }  
        }
    }
}
