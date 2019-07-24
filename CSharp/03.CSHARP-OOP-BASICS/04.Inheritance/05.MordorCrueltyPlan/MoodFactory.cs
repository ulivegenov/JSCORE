using System;
using System.Collections.Generic;
using System.Text;


public class MoodFactory
{
    public Mood GetMood(int pointsOfHappiness)
    {
        if (pointsOfHappiness < -5)
        {
            return new Angry();
        }
        else if (pointsOfHappiness <= 0)
        {
            return new Sad();
        }
        else if (pointsOfHappiness <= 15)
        {
            return new Happy();
        }
        else
        {
            return new JavaScript();
        }
    }
}

