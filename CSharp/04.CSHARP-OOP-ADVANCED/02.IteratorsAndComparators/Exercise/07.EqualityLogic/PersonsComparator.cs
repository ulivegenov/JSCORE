using System;
using System.Collections.Generic;
using System.Text;


public class PersonsComparator : IEqualityComparer<Person>
{
    public bool Equals(Person x, Person y)
    {
        return x.Name.Equals(y.Name, StringComparison.InvariantCulture) && x.Age.Equals(y.Age);
    }

    public int GetHashCode(Person obj)
    {
        return obj.Age.GetHashCode();
    }
}

