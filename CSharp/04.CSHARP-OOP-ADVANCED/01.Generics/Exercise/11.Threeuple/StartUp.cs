using System;
using System.Text;


public class StartUp
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 3; i++)
        {
            string[] inputItemArg = Console.ReadLine().Split();
            if (i == 0)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(inputItemArg[0]);
                builder.Append(' ');
                builder.Append(inputItemArg[1]);
                StringBuilder itemOne = builder;
                string itemTwo = inputItemArg[2];
                string itemThree = inputItemArg[3];
                Threeuple<StringBuilder, string, string> threeuple = new Threeuple<StringBuilder, string, string>(itemOne, itemTwo, itemThree);
                Console.WriteLine(threeuple);
            }
            else if (i == 1)
            {
                string itemOne = inputItemArg[0];
                int itemTwo = int.Parse(inputItemArg[1]);
                bool itemThree = IsDrunk(inputItemArg[2]);
                Threeuple<string, int, bool> threeuple = new Threeuple<string, int, bool>(itemOne, itemTwo, itemThree);
                Console.WriteLine(threeuple);
            }
            else
            {
                string itemOne = inputItemArg[0];
                double itemTwo = double.Parse(inputItemArg[1]);
                string itemThree = inputItemArg[2];
                Threeuple<string, double, string> threeuple = new Threeuple<string, double, string>(itemOne, itemTwo, itemThree);
                Console.WriteLine(threeuple);
            }
        }
    }

    private static bool IsDrunk(string command)
    {
        if (command == "drunk")
        {
            return true;
        }

        return false;
    }
}

