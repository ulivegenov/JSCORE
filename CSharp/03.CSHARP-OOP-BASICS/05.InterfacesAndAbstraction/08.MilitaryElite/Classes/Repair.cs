using System;
using System.Collections.Generic;
using System.Text;


public class Repair : IRepair
{
    //public string PartName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //public int HoursWorked { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private string partName;
    private int hoursWorked;

    public Repair(string partName, int hoursWorked)
    {
        this.PartName = partName;
        this.HoursWorked = hoursWorked;
    }

    public string PartName
    {
        get { return partName; }
        set { partName = value; }
    }

    public int HoursWorked
    {
        get { return hoursWorked; }
        set { hoursWorked = value; }
    }

    public override string ToString()
    {
        return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
    }
}

