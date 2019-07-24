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
                Tuple<StringBuilder, string> tuple = new Tuple<StringBuilder, string>(itemOne, itemTwo);
                Console.WriteLine(tuple);
            }
            else if (i == 1)
            {
                string itemOne = inputItemArg[0];
                int itemTwo = int.Parse(inputItemArg[1]);
                Tuple<string, int> tuple = new Tuple<string, int>(itemOne, itemTwo);
                Console.WriteLine(tuple);
            }
            else
            {
                int itemOne = int.Parse(inputItemArg[0]);
                double itemTwo = double.Parse(inputItemArg[1]);
                Tuple<int, double> tuple = new Tuple<int, double>(itemOne, itemTwo);
                Console.WriteLine(tuple);
            }
        }
    }
}

