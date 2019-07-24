using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    class ParkingLot
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            SortedSet<string> carNumbers = new SortedSet<string>();

            while (inputLine != "END")
            {
                string[] tokens = inputLine
                                  .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                  .ToArray();

                string direction = tokens[0];
                string carNumber = tokens[1];

                if (direction == "IN")
                {
                    carNumbers.Add(carNumber);
                }
                else
                {
                    carNumbers.Remove(carNumber);
                }

                inputLine = Console.ReadLine();
            }

            if (carNumbers.Count != 0)
            {
                foreach (string car in carNumbers)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
