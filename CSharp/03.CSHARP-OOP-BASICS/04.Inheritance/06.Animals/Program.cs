using System;


public class Program
{
    static void Main(string[] args)
    {
        string animalType;

        while ((animalType = Console.ReadLine()) != "Beast!")
        {
            string[] animalData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                if (animalData.Length < 3)
                {
                    throw new ArgumentException("Invalid input!");
                }
                var animal = CreateAnimal(animalType, animalData[0], int.Parse(animalData[1]), animalData[2]);
                Console.WriteLine(animal);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }

    public static Animal CreateAnimal(string animalType, string name, int age, string gender)
    {
        Animal animal = new Animal(name, age, gender);
        if (string.IsNullOrWhiteSpace(animalType))
        {
            throw new ArgumentException("Invalid input!");
        }
        switch (animalType)
        {
            case "Dog":
                animal = new Dog(name, age, gender);
                break;
            case "Cat":
                animal = new Cat(name, age, gender);
                break;
            case "Frog":
                animal = new Frog(name, age, gender);
                break;
            case "Kitten":
                animal = new Kitten(name, age, gender);
                break;
            case "Tomcat":
                animal = new Tomcat(name, age, gender);
                break;
            default:
                throw new ArgumentException("Invalid input!");
        }

        return animal;
    }
}

