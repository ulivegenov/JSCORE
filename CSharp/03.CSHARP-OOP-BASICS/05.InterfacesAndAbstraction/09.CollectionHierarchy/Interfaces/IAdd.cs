using System;
using System.Collections.Generic;
using System.Text;


public interface IAdd
{
    List<int> CollectionAdds { get; set; }
    List<string> Collection { get; set; }
    void AddItem(string item);
}

