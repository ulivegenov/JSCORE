using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class CustomList<T> : IEnumerable<T> where T : IComparable<T>
{
    private T[] elements;

    public CustomList()
    {
        this.elements = new T[4];
    }

    public int Count { get; private set; }

    public int InnerArraySize => this.elements.Length;

    public T this[int index]
    {
        get
        {
            return this.elements[index];
        }
        set
        {
            this.elements[index] = value;
        }
    }
    

    public void Add(T element)
    {
        this.Count++;

        if (this.Count > this.InnerArraySize)
        {
            T[] newData = new T[this.InnerArraySize * 2];
            Array.Copy(this.elements, newData ,this.InnerArraySize);
            this.elements = newData;
        }

        this.elements[this.Count - 1] = element;
    }

    public T Remove(int index)
    {
        this.Count--;
        T elementToRemove = this.elements[index];

        for (int i = index; i < this.Count; i++)
        {
            this.elements[i] = this.elements[i + 1];
        }

        this.elements[this.Count] = default(T);

        if (this.Count < this.InnerArraySize/3)
        {
            T[] newData = new T[this.InnerArraySize / 2];
            Array.Copy(this.elements, newData ,this.Count);
            this.elements = newData;
        }

        return elementToRemove;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (this.elements[i].Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        T tempElement = this.elements[firstIndex];
        this.elements[firstIndex] = this.elements[secondIndex];
        this.elements[secondIndex] = tempElement;
    }

    public int CounterGreaterThan(T element)
    {
        int counter = 0;

        for (int i = 0; i < this.Count; i++)
        {
            if (this.elements[i].CompareTo(element) > 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public T Max()
    {
        T maxValue = this.elements[0];

        for (int i = 1 ; i < this.Count; i++)
        {
            if (this.elements[i].CompareTo(maxValue) > 0)
            {
                maxValue = this.elements[i];
            }
        }

        return maxValue;
    }

    public T Min()
    {
        T minValue = this.elements[0];

        for (int i = 1; i < this.Count; i++)
        {
            if (this.elements[i].CompareTo(minValue) < 0)
            {
                minValue = this.elements[i];
            }
        }

        return minValue;
    }

    public void Sort()
    {
        Array.Sort(this.elements, 0, this.Count);
    }

    public void Print()
    {
        for (int i = 0; i < this.Count; i++)
        {
            Console.WriteLine(this.elements[i]);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

