using System;
using System.Collections.Generic;
using System.Text;


public class Ferari : ICar
{
    private string model;
    private string driversName;

    public Ferari(string driversName)
    {
        this.Model = "488-Spider";
        this.DriversName = driversName;
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public string DriversName
    {
        get { return driversName; }
        set { driversName = value; }
    }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public string PushTheGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.UseBrakes()}/{this.PushTheGasPedal()}/{this.DriversName}";
    }
}

