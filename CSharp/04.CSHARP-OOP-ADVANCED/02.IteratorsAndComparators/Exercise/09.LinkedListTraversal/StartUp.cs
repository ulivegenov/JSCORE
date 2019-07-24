using System;


public class StartUp
{
    static void Main(string[] args)
    {
        CustomLinkedList<string> customLinkedList = new CustomLinkedList<string>();
        int countOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfCommands; i++)
        {
            string[] inputArgs = Console.ReadLine().Split();
            string command = inputArgs[0];
            string element = inputArgs[1];

            switch (command)
            {
                case "Add":
                    customLinkedList.Add(element);
                    break;
                case "Remove":
                    customLinkedList.Remove(element);
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine(customLinkedList.Count);
        foreach (var element in customLinkedList)
        {
            Console.Write($"{element} ");
        }
        Console.WriteLine();
    }
}

