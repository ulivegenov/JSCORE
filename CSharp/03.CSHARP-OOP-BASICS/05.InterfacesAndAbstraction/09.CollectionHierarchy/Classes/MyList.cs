using System;
using System.Collections.Generic;
using System.Text;


public class MyList : AddRemoveCollection
{
    public MyList():base()
    {

    }

    public override void RemoveItem()
    {
        string removedItem = this.Collection[0];
        this.CollectionRemovedItems.Add(removedItem);
        this.Collection.RemoveAt(0);
    }
}

