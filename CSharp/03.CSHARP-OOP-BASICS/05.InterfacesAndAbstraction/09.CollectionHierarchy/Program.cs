using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int countOfRemoves = int.Parse(Console.ReadLine());
        

        AddCollection addCollection = new AddCollection();
        AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
        MyList myList = new MyList();

        foreach (var item in input)
        {
            addCollection.AddItem(item);
            addRemoveCollection.AddItem(item);
            myList.AddItem(item);
        }

        for (int i = 0; i < countOfRemoves; i++)
        {
            addRemoveCollection.RemoveItem();
            myList.RemoveItem();
        }

        Console.WriteLine(string.Join (" ", addCollection.CollectionAdds));
        Console.WriteLine(string.Join (" ", addRemoveCollection.CollectionAdds));
        Console.WriteLine(string.Join (" ", myList.CollectionAdds));
        Console.WriteLine(string.Join(" ", addRemoveCollection.CollectionRemovedItems));
        Console.WriteLine(string.Join(" ", myList.CollectionRemovedItems));
    }
}

