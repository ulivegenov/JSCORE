using System;
using System.Collections.Generic;
using System.Text;


public abstract class Mood
{
    public string MoodName { get; private set; }

    public Mood(string moodName)
    {
        this.MoodName = moodName;
    }

    public override string ToString()
    {
        return this.MoodName.ToString();
    }
}

