using System;


public class Program
{
    static void Main(string[] args)
    {
        string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] truckData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Car car = new Car(double.Parse(carData[1]), double.Parse(carData[2]));
        Truck truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]));

        int countOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfCommands; i++)
        {
            string[] inputComand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch (inputComand[0])
            {
                case "Drive":
                    if (inputComand[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(double.Parse(inputComand[2])));
                    }
                    else
                    {
                        Console.WriteLine(truck.Drive(double.Parse(inputComand[2])));
                    }
                    break;
                case "Refuel":
                    if (inputComand[1] == "Car")
                    {
                        car.Refuel(double.Parse(inputComand[2]));
                    }
                    else
                    {
                        truck.Refuel(double.Parse(inputComand[2]));
                    }
                    break;
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
    }
}

