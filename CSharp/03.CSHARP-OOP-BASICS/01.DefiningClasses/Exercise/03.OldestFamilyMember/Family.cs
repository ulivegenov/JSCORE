using System;
using System.Collections.Generic;
using System.Linq;


public class Family
{
    Person currentMember;
    Dictionary<string, int> familyMembers = new Dictionary<string, int>();

    public void AddMember(Dictionary<string,int> familyMembers, Person currentMember)
    {
        if (!familyMembers.ContainsKey(currentMember.Name))
        {
            familyMembers.Add(currentMember.Name, new int());
        }
        familyMembers[currentMember.Name] = currentMember.Age;
    }

    public Person GetOldestMember(Dictionary<string, int> familyMembers)
    {
        Person oldestMember = new Person();
        oldestMember.Name = familyMembers.OrderByDescending(x => x.Value).First().Key;
        oldestMember.Age = familyMembers.OrderByDescending(x => x.Value).First().Value;

        return oldestMember;
    }
}

