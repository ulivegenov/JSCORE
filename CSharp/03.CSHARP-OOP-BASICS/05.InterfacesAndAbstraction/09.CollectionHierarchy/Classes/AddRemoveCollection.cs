using System;
using System.Collections.Generic;
using System.Text;


public class AddRemoveCollection : AddCollection, IRemove
{
    private List<string> collectionRemovedIems;

    public AddRemoveCollection():base()
    {
        this.CollectionRemovedItems = new List<string>();
    }

    public List<string> CollectionRemovedItems
    {
        get { return collectionRemovedIems; }
        set { collectionRemovedIems = value; }
    }

    public virtual void RemoveItem()
    {
        string removedItem = this.Collection[this.Collection.Count - 1];
        this.CollectionRemovedItems.Add(removedItem);
        this.Collection.RemoveAt(this.Collection.Count - 1);
    }

    public override void AddItem(string item)
    {
        this.Collection.Insert(0, item);
        this.CollectionAdds.Add(0);
    }
}

