using System;
using System.Collections;
using System.Linq;

namespace _01.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bulletsArray = Console.ReadLine()
                                 .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
            int[] locksArray = Console.ReadLine()
                                 .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
            int budget = int.Parse(Console.ReadLine());

            Stack bulets = new Stack();
            Queue locks = new Queue();

            for (int currentBulet = 0; currentBulet < bulletsArray.Length; currentBulet++)
            {
                bulets.Push(bulletsArray[currentBulet]);
            }

            for (int currentLock = 0; currentLock < locksArray.Length; currentLock++)
            {
                locks.Enqueue(locksArray[currentLock]);
            }

            int shotCounter = 0;

            for (int currentShot = 1; currentShot <= bulletsArray.Length; currentShot++)
            {
                
                if (int.Parse(bulets.Peek().ToString()) <= int.Parse(locks.Peek().ToString()))
                {
                    bulets.Pop();
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                    shotCounter++;
                }
                else
                {
                    bulets.Pop();
                    Console.WriteLine("Ping!");
                    shotCounter++;
                }

                if (currentShot % gunBarrelSize == 0 && (bulets.Count > 0))
                {
                    Console.WriteLine("Reloading!");
                }
                if (locks.Count == 0)
                {
                    break;
                }
            }

            if (locks.Count == 0)
            {
                int earnedSum = budget - priceOfBullet * shotCounter;
                Console.WriteLine($"{bulets.Count} bullets left. Earned ${earnedSum}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
