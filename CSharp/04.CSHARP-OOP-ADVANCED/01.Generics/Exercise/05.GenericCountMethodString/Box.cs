
using System;
using System.Collections.Generic;
using System.Text;


public class Box<T> where T : IComparable<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public int Compare(Box<T> elementToCompare)
    {
        int counter = 0;
        if (this.value.CompareTo(elementToCompare.value) < 0)
        {
            counter = 1;
        }

        return counter;
    }

    public override string ToString()
    {
        return $"{this.value.GetType().FullName}: {this.value}";
    }
}

