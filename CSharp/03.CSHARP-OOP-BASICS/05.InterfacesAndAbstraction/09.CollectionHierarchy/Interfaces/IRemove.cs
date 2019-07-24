using System;
using System.Collections.Generic;
using System.Text;


public interface IRemove
{
    List<string> CollectionRemovedItems { get; set; }
    List<string> Collection { get; set; }
    void RemoveItem();
}

