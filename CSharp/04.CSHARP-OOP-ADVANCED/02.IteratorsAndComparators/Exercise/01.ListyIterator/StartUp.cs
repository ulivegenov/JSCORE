using System;
using System.Linq;


public class StartUp
{
    static void Main(string[] args)
    {
        string[] startCommand = Console.ReadLine().Split();
        string create = startCommand[0];
        string[] inputParams = null;
        if (startCommand.Length > 1)
        {
            inputParams = startCommand.Skip(1).ToArray();
        }

        ListyIterator<string> listyIterator = new ListyIterator<string>(create, inputParams);

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] inputArgs = input.Split();
            string command = inputArgs[0];
            bool result;
            switch (command)
            {
                case "Move":
                    result = listyIterator.Move();
                    Console.WriteLine(result);
                    break;
                case "HasNext":
                    result = listyIterator.HasNext();
                    Console.WriteLine(result);
                    break;
                case "Print":
                    listyIterator.Print();
                    break;
                default:
                    break;
            }
        }
    }
}

