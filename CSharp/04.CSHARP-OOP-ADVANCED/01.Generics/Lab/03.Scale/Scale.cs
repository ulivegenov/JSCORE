using System;


public class Scale<T>
    where T : IComparable<T>
{
    private T leftElement;

    private T rightElement;


    public Scale(T leftElement, T rightElement)
    {
        this.leftElement = leftElement;
        this.rightElement = rightElement;
    }

    public T GetHeavier()
    {
        if (this.leftElement.CompareTo(this.rightElement) > 0)
        {
            return this.leftElement;
        }
        else if (this.leftElement.CompareTo(this.rightElement) < 0)
        {
            return this.rightElement;
        }
        else
        {
            return default(T);
        }
    }
}

