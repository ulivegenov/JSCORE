using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        string[] phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] sites = Console.ReadLine().Split(' ');

        Smartphone phone = new Smartphone();

        foreach (var phoneNumber in phoneNumbers)
        {
            Console.WriteLine(phone.Calling(phoneNumber));
        }
       
        foreach (var site in sites)
        {
            Console.WriteLine(phone.Browsing(site));
        }
    }
}

