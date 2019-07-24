using System;


public class StartUp
{
    static void Main(string[] args)
    {
        HarvestingFieldsTest test = new HarvestingFieldsTest();

        string command;
        
        while ((command =Console.ReadLine()) != "HARVEST")
        {
            test.Print(command);
        }
    }
}

