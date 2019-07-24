using System;
using System.Collections.Generic;
using System.Text;


public class Bus : Vehichle
{
    public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity):base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {
    }

    public override string Drive(double distance)
    {
        if (this.FuelQuantity >= (distance * (this.FuelConsumptionPerKm + 1.4)))
        {
            this.FuelQuantity -= distance * (this.FuelConsumptionPerKm + 1.4);
            return $"Bus travelled {distance} km";
        }
        else
        {
            return "Bus needs refueling";
        }
    }

    public string DriveEmpty(double distance)
    {
        if (this.FuelQuantity >= (distance * this.FuelConsumptionPerKm))
        {
            this.FuelQuantity -= distance * this.FuelConsumptionPerKm;
            return $"Bus travelled {distance} km";
        }
        else
        {
            return "Bus needs refueling";
        }
    }

    public override string ToString()
    {
        return $"Bus: {this.FuelQuantity:f2}";
    }
}

