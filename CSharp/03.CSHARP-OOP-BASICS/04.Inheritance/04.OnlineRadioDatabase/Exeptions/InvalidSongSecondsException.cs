using System;
using System.Collections.Generic;
using System.Text;


public class InvalidSongSecondsException : InvalidSongLengthException
{
    private const int MIN_LENGTH = 0;
    private const int MAX_LENGTH = 59;

    public override string Message => $"Song seconds should be between {MIN_LENGTH} and {MAX_LENGTH}.";

    public InvalidSongSecondsException() : base()
    {

    }
}

