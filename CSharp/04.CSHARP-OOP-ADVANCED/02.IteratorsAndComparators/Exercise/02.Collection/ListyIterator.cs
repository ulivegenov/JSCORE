using System;
using System.Collections;
using System.Collections.Generic;


public class ListyIterator<T> : IEnumerable<T>
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

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.elements.Count; i++)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

