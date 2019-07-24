using System;
using System.Globalization;
using System.Linq;

namespace _01.CountWorkingDays
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            DateTime startDate = DateTime.ParseExact(firstDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(secondDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            DateTime[] holidays = new DateTime[]
            {
                new DateTime ( 4, 01, 1),
                new DateTime ( 4, 03, 3),
                new DateTime ( 4, 05, 1),
                new DateTime ( 4, 05, 6),
                new DateTime ( 4, 05, 24),
                new DateTime ( 4, 09, 6),
                new DateTime ( 4, 09, 22),
                new DateTime ( 4, 11, 1),
                new DateTime ( 4, 12, 24),
                new DateTime ( 4, 12, 25),
                new DateTime ( 4, 12, 26),

            };

            int countOfWorkingDays = 0;

            for (DateTime currentDay = startDate; currentDay <= endDate; currentDay = currentDay.AddDays(1))
            {

                DayOfWeek day = currentDay.DayOfWeek;

                DateTime temp = new DateTime(4, currentDay.Month, currentDay.Day);

                if (!holidays.Contains(temp) && (!day.Equals(DayOfWeek.Saturday)) && (!day.Equals(DayOfWeek.Sunday)))
                {
                    countOfWorkingDays++;
                }
            }

            Console.WriteLine(countOfWorkingDays);

        }
    }
}
