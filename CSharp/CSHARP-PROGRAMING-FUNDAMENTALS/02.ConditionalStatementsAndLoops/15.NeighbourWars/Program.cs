using System;

namespace _15.NeighbourWars
{
    class Program
    {
        static void Main(string[] args)
        {
            int damageOfPeshoAttack = int.Parse(Console.ReadLine());
            int damageOfGoshoAttack = int.Parse(Console.ReadLine());
            string playerOneName = "Pesho";
            string playerTwoName = "Gosho";
            int HealthOfPesho = 100;
            int HealthOfGosho = 100;
            int currentRound = 0;

            while ((HealthOfPesho > 0) && (HealthOfGosho > 0))
            {
                currentRound++;

                if (currentRound % 2 != 0)
                {
                    HealthOfGosho -= damageOfPeshoAttack;
                    if (HealthOfGosho <= 0)
                    {
                        break;
                    }
                    Console.WriteLine($"{playerOneName} used Roundhouse kick and reduced {playerTwoName} to {HealthOfGosho} health.");
                }
                else
                {
                    HealthOfPesho -= damageOfGoshoAttack;
                    if (HealthOfPesho <= 0)
                    {
                        break;
                    }
                    Console.WriteLine($"{playerTwoName} used Thunderous fist and reduced {playerOneName} to {HealthOfPesho} health.");
                }
                if (currentRound % 3 == 0)
                {
                    HealthOfPesho += 10;
                    HealthOfGosho += 10;
                }
            }

            if (HealthOfPesho > 0)
            {
                Console.WriteLine($"{playerOneName} won in {currentRound}th round.");
            }
            else if (HealthOfGosho > 0)
            {
                Console.WriteLine($"{playerTwoName} won in {currentRound}th round.");
            }
        }
    }
}
