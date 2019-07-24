using System;
using System.Collections.Generic;
using System.Text;

namespace _04OnlineRadioDatabase2.Exeptions
{
    public class InvalidSongMinutesException : InvalidSongLengthException
    {
        public const int MIN_MINUTES = 0;
        public const int MAX_MINUTES = 14;

        public InvalidSongMinutesException() : base()
        {
        }

        public override string Message => $"Song minutes should be between {MIN_MINUTES} and {MAX_MINUTES}.";
    }
}
