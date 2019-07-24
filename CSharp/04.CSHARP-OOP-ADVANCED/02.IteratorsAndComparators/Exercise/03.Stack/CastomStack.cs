using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class CastomStack<T> : IEnumerable<T>
{
    private readonly IList<T> elements;


    public CastomStack()
    {
        this.elements = new List<T>();
    }

    public void Push(params T[] elements)
    {
        for (int i = 0; i < elements.Length; i++)
        {
            this.elements.Insert(0, elements[i]);
        }
    }

    public void Pop()
    {
        if (this.elements.Count == 0)
        {
            Console.WriteLine("No elements");
        }
        else
        {
            this.elements.RemoveAt(0);
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

