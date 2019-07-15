using System;

namespace _04.Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string monthName = Console.ReadLine();
            int countOfNights = int.Parse(Console.ReadLine());

            double studioPricePerNight = 0;
            double doublePricePerNight = 0;
            double suitePricePerNight = 0;

            if (monthName == "May" || monthName == "October")
            {
                studioPricePerNight = 50;
                doublePricePerNight = 65;
                suitePricePerNight = 75;
                if (countOfNights > 7)
                {
                    studioPricePerNight *= 0.95;
                }
            }
            else if (monthName == "June" || monthName == "September")
            {
                studioPricePerNight = 60;
                doublePricePerNight = 72;
                suitePricePerNight = 82;
                if (countOfNights > 14)
                {
                    doublePricePerNight *= 0.90;
                }
            }
            else if (monthName == "July" || monthName == "August" || monthName == "December")
            {
                studioPricePerNight = 68;
                doublePricePerNight = 77;
                suitePricePerNight = 89;
                if (countOfNights > 14)
                {
                    suitePricePerNight *= 0.85;
                }
            }

            double priceForStayInDouble = doublePricePerNight * countOfNights;
            double priceForStayInSuite = suitePricePerNight * countOfNights;

            if (countOfNights > 7 && (monthName == "September" || monthName == "October"))
            {
                countOfNights--;
            }

            double priceForStayInStudio = studioPricePerNight * countOfNights;


            Console.WriteLine($"Studio: {priceForStayInStudio:f2} lv.");
            Console.WriteLine($"Double: {priceForStayInDouble:f2} lv.");
            Console.WriteLine($"Suite: {priceForStayInSuite:f2} lv.");
        }
    }
}
