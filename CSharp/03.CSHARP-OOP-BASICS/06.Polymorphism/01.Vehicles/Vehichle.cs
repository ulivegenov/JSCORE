using System;
using System.Collections.Generic;
using System.Text;


public abstract class Vehichle : IVehichle
{
    private double fuelQuantity;
    private double fuelConsumptionPerKm;

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

    public Vehichle(double fuelQuantity, double fuelConsumptionPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public abstract string Drive(double distance);

    public abstract void Refuel(double liters);
}

