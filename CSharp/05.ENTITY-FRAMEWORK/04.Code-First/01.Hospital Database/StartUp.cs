namespace P01_HospitalDatabase
{
    using P01_HospitalDatabase.Core;
    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new HospitalContext())
            {
                Console.WriteLine("Welcome guest! Do you have an account?");
                Console.Write("Please write Y/N: ");
                string answer = Console.ReadLine();
                var commandUI = new CommandUserInterface();

                try
                {
                    if (answer.ToUpper() == "Y")
                    {
                        commandUI.Login(context);
                    }
                    else if (true)
                    {
                        commandUI.Register(context);
                    }
                    else
                    {
                        throw new ArgumentException("Incorrect answer!");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }
    }
}
