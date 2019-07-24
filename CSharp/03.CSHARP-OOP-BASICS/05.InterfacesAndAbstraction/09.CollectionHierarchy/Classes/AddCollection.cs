using System;
using System.Collections.Generic;
using System.Text;


public class AddCollection : IAdd
{
    private List<string> collection;
    private List<int> collectionAdds;

    public List<int> CollectionAdds
    {
        get { return collectionAdds; }
        set { collectionAdds = value; }
    }

    public AddCollection()
    {
        this.Collection = new List<string>();
        this.CollectionAdds = new List<int>();
    }

    public List<string> Collection
    {
        get { return collection; }
        set { collection = value; }
    }

    public virtual void AddItem(string item)
    {
        this.Collection.Add(item);
        this.CollectionAdds.Add(this.Collection.Count - 1);    
    }
}

