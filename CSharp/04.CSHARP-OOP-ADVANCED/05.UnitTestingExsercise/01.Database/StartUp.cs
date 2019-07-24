using _01Database;
using System;

namespace UnitTestingExsercise
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Database<int> database = new Database<int>(1, 2, 45, 3249, 21, 419, 42);
                Console.WriteLine(database.Capacity);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
