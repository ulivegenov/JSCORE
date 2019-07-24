using System;
using System.Collections.Generic;
using System.Text;


public interface IBuyer
{
    string  Name { get; set; }

    int Food { get; set; }

    int BuyFood();
}

