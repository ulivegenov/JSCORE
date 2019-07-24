using System;
using System.Collections.Generic;
using System.Text;


public class InvalidSongMinutesException : InvalidSongLengthException
{
    private const int MIN_LENGTH = 0;
    private const int MAX_LENGTH = 14;

    public override string Message => $"Song minutes should be between {MIN_LENGTH} and {MAX_LENGTH}.";

    public InvalidSongMinutesException() : base()
    {

    }
}

