using System;


public class Program
{
    static void Main(string[] args)
    {
        string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] truckData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] busData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Car car = new Car(double.Parse(carData[1]), double.Parse(carData[2]), double.Parse(carData[3]));
        Truck truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]), double.Parse(truckData[3]));
        Bus bus = new Bus(double.Parse(busData[1]), double.Parse(busData[2]), double.Parse(busData[3]));

        int countOfCommands = int.Parse(Console.ReadLine());

        try
        {

        }
        catch (Exception)
        {

            throw;
        }
        for (int i = 0; i < countOfCommands; i++)
        {
            string[] inputComand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch (inputComand[0])
            {
                case "DriveEmpty":
                    Console.WriteLine(bus.DriveEmpty(double.Parse(inputComand[2])));
                    break;
                case "Drive":
                    if (inputComand[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(double.Parse(inputComand[2])));
                    }
                    else if (inputComand[1] == "Truck")
                    {
                        Console.WriteLine(truck.Drive(double.Parse(inputComand[2])));
                    }
                    else
                    {
                        Console.WriteLine(bus.Drive(double.Parse(inputComand[2])));
                    }
                    break;
                case "Refuel":
                    try
                    {
                        if (inputComand[1] == "Car")
                        {
                            car.Refuel(double.Parse(inputComand[2]));
                        }
                        else if (inputComand[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(inputComand[2]));
                        }
                        else
                        {
                            bus.Refuel(double.Parse(inputComand[2]));
                        }
                        break;
                    }
                    catch (ArgumentException argEx)
                    {
                        Console.WriteLine(argEx.Message);
                    }
                    break;
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }
}
