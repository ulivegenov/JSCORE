using System;


class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputDataStudent = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] inputDataWorker = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Student student = new Student(inputDataStudent[0], inputDataStudent[1], inputDataStudent[2]);
            Worker worker = new Worker(inputDataWorker[0], inputDataWorker[1], decimal.Parse(inputDataWorker[2]), decimal.Parse(inputDataWorker[3]));

            Console.WriteLine(student + Environment.NewLine);
            Console.WriteLine(worker);
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
       
    }
}

