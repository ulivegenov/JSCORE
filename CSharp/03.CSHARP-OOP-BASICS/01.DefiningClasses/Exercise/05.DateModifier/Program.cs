using System;
using System.Globalization;

public class Program
{
    static void Main(string[] args)
    {
        string dateOne = Console.ReadLine();
        string dateTwo = Console.ReadLine();
        DateModifier daysDifference = new DateModifier();

        DateTime firstDate = Convert.ToDateTime(dateOne);
        DateTime secondtDate = Convert.ToDateTime(dateTwo);

        int days = (int)Math.Abs(((double.Parse)(daysDifference.DaysDiff(firstDate, secondtDate))));
        Console.WriteLine(days);
    }
}

