using System;

namespace _11.ConvertSpeedUnits
{
    class Program
    {
        static void Main(string[] args)
        {
            int distanceInMeters = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            float takenTimeInHours = (float)(hours + minutes / 60.0 + seconds / 3600.0);
            float takenTimeInSeconds = hours * 3600 + minutes * 60 + seconds;

            float speedInMetersPerSecond = distanceInMeters / takenTimeInSeconds;
            float speedInKilometersPerHour = distanceInMeters / (1000 * takenTimeInHours);
            float speedInMilesPerHour = distanceInMeters / (1609 * takenTimeInHours);

            Console.WriteLine($"{speedInMetersPerSecond}");
            Console.WriteLine($"{speedInKilometersPerHour}");
            Console.WriteLine($"{speedInMilesPerHour}");
        }
    }
}
