using System;
using System.Collections.Generic;
using System.Text;


public interface IResident
{
    string Name { get; set; }
    string Country { get; set; }
    string GetName();
}

