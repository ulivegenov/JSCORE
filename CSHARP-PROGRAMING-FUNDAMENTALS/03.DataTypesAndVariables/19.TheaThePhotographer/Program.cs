using System;

namespace _19.TheaThePhotographer
{
    class Program
    {
        static void Main(string[] args)
        {
            long numberOfTakenPictures = long.Parse(Console.ReadLine());
            long timeToFlterForSinglePicture = long.Parse(Console.ReadLine());
            long percentageOfGoodPictures = long.Parse(Console.ReadLine());
            long timeToUploadSingleGoodPicture = long.Parse(Console.ReadLine());

            long timeToFilteredAllPictures = numberOfTakenPictures * timeToFlterForSinglePicture;
            long numberOfGoodPictures = (long)Math.Ceiling(numberOfTakenPictures * (percentageOfGoodPictures / 100.0));
            long timeToUploadingAllGoodPictures = numberOfGoodPictures * timeToUploadSingleGoodPicture;
            long totalTimeInSeconds = timeToFilteredAllPictures + timeToUploadingAllGoodPictures;

            TimeSpan neededTime = TimeSpan.FromSeconds(totalTimeInSeconds);

            Console.WriteLine($"{neededTime.Days:D1}:{neededTime.Hours:D2}:{neededTime.Minutes:D2}:{neededTime.Seconds:D2}");
        }
    }
}
