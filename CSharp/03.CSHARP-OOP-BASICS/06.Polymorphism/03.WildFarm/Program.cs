using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();
        string inputAnimal;
        while ((inputAnimal = Console.ReadLine()) != "End")
        {
            string[] dataAnimal = inputAnimal.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] dataFood = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            switch (dataAnimal[0])
            {
                case "Owl":
                    Owl owl = new Owl(dataAnimal[1], double.Parse(dataAnimal[2]), double.Parse(dataAnimal[3]));
                    Console.WriteLine(owl.AskForFood());
                    owl.Eat(dataFood[0], int.Parse(dataFood[1]));
                    animals.Add(owl);
                    break;
                case "Hen":
                    Hen hen = new Hen(dataAnimal[1], double.Parse(dataAnimal[2]), double.Parse(dataAnimal[3]));
                    Console.WriteLine(hen.AskForFood());
                    hen.Eat(dataFood[0], int.Parse(dataFood[1]));
                    animals.Add(hen);
                    break;
                case "Mouse":
                    Mouse mouse = new Mouse(dataAnimal[1], double.Parse(dataAnimal[2]), dataAnimal[3]);
                    Console.WriteLine(mouse.AskForFood());
                    mouse.Eat(dataFood[0], int.Parse(dataFood[1]));
                    animals.Add(mouse);
                    break;
                case "Dog":
                    Dog dog = new Dog(dataAnimal[1], double.Parse(dataAnimal[2]), dataAnimal[3]);
                    Console.WriteLine(dog.AskForFood());
                    dog.Eat(dataFood[0], int.Parse(dataFood[1]));
                    animals.Add(dog);
                    break;
                case "Cat":
                    Cat cat = new Cat(dataAnimal[1], double.Parse(dataAnimal[2]), dataAnimal[3], dataAnimal[4]);
                    Console.WriteLine(cat.AskForFood());
                    cat.Eat(dataFood[0], int.Parse(dataFood[1]));
                    animals.Add(cat);
                    break;
                case "Tiger":
                    Tiger tiger = new Tiger(dataAnimal[1], double.Parse(dataAnimal[2]), dataAnimal[3], dataAnimal[4]);
                    Console.WriteLine(tiger.AskForFood());
                    tiger.Eat(dataFood[0], int.Parse(dataFood[1]));
                    animals.Add(tiger);
                    break;
            }
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}

