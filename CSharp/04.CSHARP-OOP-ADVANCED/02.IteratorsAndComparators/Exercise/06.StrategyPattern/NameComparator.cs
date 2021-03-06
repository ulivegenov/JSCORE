﻿using System.Collections.Generic;

public class NameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if (x.Name.Length.CompareTo(y.Name.Length) == 0)
        {
            return x.Name.Substring(0, 1).ToLower().CompareTo(y.Name.Substring(0, 1).ToLower());
        }

        return x.Name.Length.CompareTo(y.Name.Length);
    }
}

