using System;
using System.Collections.Generic;
using System.Text;


public class InvalidSongExeption : Exception
{
    public override string Message => "Invalid song.";

    public InvalidSongExeption():base()
    {

    }
    
}

