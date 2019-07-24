using System;
using System.Collections.Generic;
using System.Text;


public abstract class Food
{
    public int PointsOfHappines { get; private set; }

    public Food(int pointsOfHappiness)
    {
        this.PointsOfHappines = pointsOfHappiness;
    }
}

