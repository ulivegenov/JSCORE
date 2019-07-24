using System.Collections;
using System.Collections.Generic;


public class Tuple<T1,T2>
{
    private T1 itemOne;

    private T2 itemTwo;

    public Tuple(T1 itemOne, T2 itemTwo)
    {
        this.itemOne = itemOne;
        this.itemTwo = itemTwo;
    }

    public override string ToString()
    {
        return $"{this.itemOne.ToString()} -> {this.itemTwo.ToString()}";
    }
}

