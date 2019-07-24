using System.Collections;
using System.Collections.Generic;


public class Threeuple<T1,T2,T3>
{
    private T1 itemOne;

    private T2 itemTwo;

    private T3 itemThree;

    public T3 ItemThree
    {
        get
        {
            return itemThree;
        }
        set
        {
            itemThree = value;
        }
    }


    public Threeuple(T1 itemOne, T2 itemTwo, T3 itemThree)
    {
        this.itemOne = itemOne;
        this.itemTwo = itemTwo;
        this.ItemThree = itemThree;
    }

    public override string ToString()
    {
        return $"{this.itemOne.ToString()} -> {this.itemTwo.ToString()} -> {this.ItemThree}";
    }
}

