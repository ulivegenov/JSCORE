using System;
using System.Collections.Generic;
using System.Text;


public class OverThirty
{
    SortedDictionary<string, int> overThirthyList = new SortedDictionary<string, int>();
    Person currentMember;

    public void AddMember(SortedDictionary<string, int> overThirthy, Person currentMember)
    {
        if (currentMember.Age > 30)
        {
            if (!overThirthy.ContainsKey(currentMember.Name))
            {
                overThirthy.Add(currentMember.Name, new int());
            }
            overThirthy[currentMember.Name] = currentMember.Age;
        }
        
    }
}

