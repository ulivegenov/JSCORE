using System;

namespace _04.BeverageLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            string productName = Console.ReadLine();
            int productVolume = int.Parse(Console.ReadLine());
            int productEnergyContentPer100ml = int.Parse(Console.ReadLine());
            int productSugarContentPer100ml = int.Parse(Console.ReadLine());

            double productEnergyContent = (double)productVolume * productEnergyContentPer100ml / 100;
            double productSugarContent = (double)productVolume * productSugarContentPer100ml / 100;

            Console.WriteLine($"{productVolume}ml {productName}:");
            Console.WriteLine($"{productEnergyContent}kcal, {productSugarContent}g sugars");
        }
    }
}
