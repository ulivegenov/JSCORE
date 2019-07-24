using System;

namespace _02.LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            using (System.IO.StreamReader readStream = new System.IO.StreamReader("../Resources/text.txt"))
            {
                int counter = 1;
                string line;

                using (System.IO.StreamWriter writeStream = new System.IO.StreamWriter("output.txt"))
                {
                    while ((line = readStream.ReadLine()) != null)
                    {
                        writeStream.WriteLine($"Line {counter++}: {line}");
                    }
                }
            }
        }
    }
}

