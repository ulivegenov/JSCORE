using System;
using System.Collections.Generic;
using System.Text;


public class InvalidSongLengthException : InvalidSongExeption
{
    public override string Message => "Invalid song length.";

    public InvalidSongLengthException():base()
    {

    }
}

