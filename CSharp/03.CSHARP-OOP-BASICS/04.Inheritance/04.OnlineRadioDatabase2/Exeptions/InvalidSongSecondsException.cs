using System;
using System.Collections.Generic;
using System.Text;

namespace _04OnlineRadioDatabase2.Exeptions
{
    public class InvalidSongSecondsException : InvalidSongLengthException
    {
        public const int MIN_SECONDS = 0;
        public const int MAX_SECONDS = 59;

        public InvalidSongSecondsException() : base()
        {
        }

        public override string Message => $"Song seconds should be between {MIN_SECONDS} and {MAX_SECONDS}.";
    }
}
