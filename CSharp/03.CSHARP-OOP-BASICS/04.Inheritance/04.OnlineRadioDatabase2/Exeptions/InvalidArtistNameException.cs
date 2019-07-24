using System;
using System.Collections.Generic;
using System.Text;

namespace _04OnlineRadioDatabase2.Exeptions
{
    public class InvalidArtistNameException : InvalidSongException
    {
        private const int MIN_NAME_LENGTH = 3;
        private const int MAX_NAME_LENGTH = 20;

        public InvalidArtistNameException():base()
        {
        }

        public override string Message => 
            $"Artist name should be between {MIN_NAME_LENGTH} and {MAX_NAME_LENGTH} symbols.";
    }
}
