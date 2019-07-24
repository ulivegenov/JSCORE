using System;
using System.Collections.Generic;
using System.Text;


public class InvalidSongNameException : InvalidSongExeption
{
    private const int MIN_LENGTH = 3;
    private const int MAX_LENGTH = 20;

    public override string Message => $"Song name should be between {MIN_LENGTH} and {MAX_LENGTH} symbols.";

    public InvalidSongNameException() : base()
    {

    }
}

