using System;
using System.Collections.Generic;


public class ListyIterator<T>
{
    private IList<T> elements;

    private int currentIndex;

    public ListyIterator(string create, params T[] elements)
    {
        this.elements = new List<T>(elements);
        currentIndex = 0;
    }

    public bool Move()
    {
        if (currentIndex < this.elements.Count - 1)
        {
            currentIndex++;
            return true;
        }


        return false;
    }

    public bool HasNext()
    {
        if (currentIndex < this.elements.Count - 1)
        {
            return true;
        }

        return false;
    }

    public void Print()
    {
        if (this.elements.Count == 0)
        {
            Console.WriteLine("Invalid Operation!");
        }
        else
        {
            Console.WriteLine(this.elements[currentIndex]);
        }
    }
}

