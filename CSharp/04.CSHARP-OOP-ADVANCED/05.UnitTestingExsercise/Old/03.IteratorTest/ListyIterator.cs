using System;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T> : IListyIterator
{
    private IList<string> elements;

    private int currentIndex;

    public ListyIterator(string create, string inputElements)
    {
        if (string.IsNullOrWhiteSpace(inputElements))
        {
            throw new ArgumentNullException("Invalid Operation!");
        }
        this.elements = Create(inputElements);
        currentIndex = 0;
    }

    private List<string> Create(string inputElements)
    {
        List<string> temp = new List<string>();
        string[] inputArgs = inputElements.Split();
        for (int i = 0; i < inputArgs.Length; i++)
        {
            temp.Add(inputArgs[i]);
        }

        return temp;
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


    //Must be a void Type. Only for Unit test is string Type!!!!
    public string Print()
    {
        if (this.elements.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        else
        {
            Console.WriteLine(this.elements[currentIndex]);
            return this.elements[currentIndex];
        }
    }
}

