using System;
using System.Collections.Generic;
using System.Text;

namespace _04OnlineRadioDatabase2.Exeptions
{
    public class InvalidSongException : Exception
    {
        public InvalidSongException():base()
        {
        }

        public override string Message => "Invalid song.";
    }
}
