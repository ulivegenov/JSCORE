using System;
using System.Collections.Generic;
using System.Linq;


public class Box<T>
{
    private List<T> elements;

    public int Count => this.elements.Count;

    public Box()
    {
        this.elements = new List<T>();
    }

    public void Add(T element)
    {
        this.elements.Add(element);
    }

    public T Remove()
    {
        T element = this.elements.Last();
        this.elements.RemoveAt(this.elements.Count - 1);

        return element;
    }
}

