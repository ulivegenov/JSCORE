using System;
using System.Collections.Generic;
using System.Text;


interface ICar
{
    string Model { get; set; }

    string DriversName { get; set; }

    string UseBrakes();

    string PushTheGasPedal();
}

