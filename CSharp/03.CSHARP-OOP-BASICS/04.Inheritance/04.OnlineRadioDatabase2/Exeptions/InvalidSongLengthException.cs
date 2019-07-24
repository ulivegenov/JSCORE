using System;
using System.Collections.Generic;
using System.Text;

namespace _04OnlineRadioDatabase2.Exeptions
{
    public class InvalidSongLengthException : InvalidSongException
    {
        public InvalidSongLengthException() : base()
        {
        }

        public override string Message => "Invalid song length.";
    }
}
