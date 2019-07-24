using System;
using System.Collections.Generic;
using System.Text;

namespace _04OnlineRadioDatabase2.Exeptions
{
    class InvalidSongNameException : InvalidSongException
    {
        private const int MIN_NAME_LENGTH = 3;
        private const int MAX_NAME_LENGTH = 30;

        public InvalidSongNameException() : base()
        {
        }

        public override string Message => 
            $"Song name should be between {MIN_NAME_LENGTH} and {MAX_NAME_LENGTH} symbols.";
    }
}
