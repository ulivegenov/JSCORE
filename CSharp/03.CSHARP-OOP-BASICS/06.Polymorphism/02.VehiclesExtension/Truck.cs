using System;
using System.Collections.Generic;
using System.Text;

public class Truck : Vehichle
{
    public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {
    }

    public override string Drive(double distance)
    {
        if (this.FuelQuantity >= (distance * (this.FuelConsumptionPerKm + 1.6)))
        {
            this.FuelQuantity -= distance * (this.FuelConsumptionPerKm + 1.6);
            return $"Truck travelled {distance} km";
        }
        else
        {
            return "Truck needs refueling";
        }
    }

    public override void Refuel(double liters)
    {
        if (liters <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        else if (liters > this.TankCapacity - this.FuelQuantity)
        {
            throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
        }
        else
        {
            this.FuelQuantity += liters * 0.95;
        }
    }

    public override string ToString()
    {
        return $"Truck: {this.FuelQuantity:f2}";
    }
}
