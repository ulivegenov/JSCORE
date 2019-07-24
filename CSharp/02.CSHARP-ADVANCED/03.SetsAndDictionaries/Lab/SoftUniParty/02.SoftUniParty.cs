using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParty
{
    class SoftUniParty
    {
        static void Main(string[] args)
        {
            SortedSet<string> guestList = new SortedSet<string>();
            string inputLine = Console.ReadLine();

            while (inputLine != "PARTY")
            {
                guestList.Add(inputLine);
                inputLine = Console.ReadLine();
            }

            while (inputLine != "END")
            {
                guestList.Remove(inputLine);
                inputLine = Console.ReadLine();
            }

            Console.WriteLine(guestList.Count);
            foreach (string guest in guestList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
