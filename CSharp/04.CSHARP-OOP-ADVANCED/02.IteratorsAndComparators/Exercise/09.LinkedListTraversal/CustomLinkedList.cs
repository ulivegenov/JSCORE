using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CustomLinkedList<T> : IEnumerable<T>
{
    private IList<T> elements;

    public int Count { get; private set; }

    public CustomLinkedList()
    {
        this.elements = new List<T>();
        this.Count = 0;
    }

    public void Add(T element)
    {
        this.elements.Add(element);
        this.Count++;
    }

    public bool Remove(T elementToRemove)
    {
        if (this.elements.Any(e => e.Equals(elementToRemove)))
        {
            this.elements.Remove(elementToRemove);
            this.Count--;
            return true;
        }

        return false;
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

