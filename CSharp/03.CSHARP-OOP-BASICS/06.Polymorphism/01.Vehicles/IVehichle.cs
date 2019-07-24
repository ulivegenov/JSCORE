using System;
using System.Collections.Generic;
using System.Text;


public interface IVehichle
{
    double FuelQuantity { get; set; }
    double FuelConsumptionPerKm { get; set; }
    string Drive(double distance);
    void Refuel(double liters);
}

