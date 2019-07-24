using System;
using System.Collections.Generic;
using System.Text;

public abstract class Vehichle : IVehichle
{
    private double fuelQuantity;
    private double fuelConsumptionPerKm;
    private double tankCapacity;

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        set { fuelQuantity = value; }
    }

    public double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        set { fuelConsumptionPerKm = value; }
    }

    public double TankCapacity
    {
        get { return tankCapacity; }
        set { tankCapacity = value; }
    }

    public Vehichle(double fuelQuantity, double fuelConsumptionPerKm , double tankCapacity)
    {
        if (tankCapacity < fuelQuantity)
        {
            this.FuelQuantity = 0;
        }
        else
        {
            this.FuelQuantity = fuelQuantity;
        }
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.TankCapacity = tankCapacity;
    }

    public abstract string Drive(double distance);

    public virtual void Refuel(double liters)
    {
        if (liters <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        else if(liters > this.TankCapacity-this.FuelQuantity)
        {
            throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
        }
        else
        {
            this.FuelQuantity += liters;
        }
    }
}