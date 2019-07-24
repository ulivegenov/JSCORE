using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream system = new FileStream("../Resources/text.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader readStream = new StreamReader(system))
                {
                    int counter = 0;
                    string line = readStream.ReadLine();

                    while (line != null)
                    {
                        if (counter % 2 == 1)
                        {
                            Console.WriteLine(line);
                        }
                        counter++;
                        line = readStream.ReadLine();
                    }
                }
            }
        }
    }
}