using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class RecievList<T> : IEnumerable
{
    private List<T> elemnts;

    public RecievList()
    {
        this.elemnts = new List<T>();
    }

    public void Add(T element)
    {
        elemnts.Add(element);
    }

    public IEnumerator GetEnumerator()
    {
        return elemnts.GetEnumerator();
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        T firstElement = elemnts[firstIndex];
        T secondElement = elemnts[secondIndex];
        elemnts.Insert(firstIndex, secondElement);
        elemnts.RemoveAt(firstIndex + 1);
        elemnts.Insert(secondIndex, firstElement);
        elemnts.RemoveAt(secondIndex + 1);
    }
}

