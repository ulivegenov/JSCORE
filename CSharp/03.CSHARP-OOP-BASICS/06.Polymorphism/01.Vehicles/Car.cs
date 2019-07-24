using System;
using System.Collections.Generic;
using System.Text;


public class Car : Vehichle
{ 
    public Car(double fuelQuantity, double fuelConsumptionPerKm) :base(fuelQuantity, fuelConsumptionPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public override string Drive(double distance)
    {
        if (this.FuelQuantity >= (distance * (this.FuelConsumptionPerKm + 0.9)))
        {
            this.FuelQuantity -= distance * (this.FuelConsumptionPerKm + 0.9);
            return $"Car travelled {distance} km";
        }
        else
        {
            return "Car needs refueling";
        }
    }

    public override void Refuel(double liters)
    {
        this.FuelQuantity += liters;
    }

    public override string ToString()
    {
        return $"Car: {this.FuelQuantity:f2}";
    }
}

