using System;
using System.Collections.Generic;
using System.Text;


public class DateModifier
{
    DateTime dateOne;
    DateTime dateTwo;
    
    public DateTime DateOne
    {
        get { return dateOne; }
        set { dateOne = value; }
    }

    public DateTime DateTwo
    {
        
        get { return dateTwo; }
        set { dateTwo = value; }
    }
    
    public string DaysDiff(DateTime dateOne, DateTime dateTwo)
    {
        return (dateOne.Date - dateTwo.Date).TotalDays.ToString();
    }
}

