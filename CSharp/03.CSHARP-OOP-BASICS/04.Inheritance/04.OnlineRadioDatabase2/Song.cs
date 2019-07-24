using _04OnlineRadioDatabase2.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04OnlineRadioDatabase2
{
    public class Song
    {
        public Song(string artistName, string songName, int minutes, int seconds)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.Minutes = minutes;
            this.Seconds = seconds;
            this.SongLength = this.Minutes * 60 + this.Seconds;
        }

        public string ArtistName { get; private set; }

        public string SongName { get; private set; }

        public int Minutes { get; private set; }

        public int Seconds { get; private set; }

        public int SongLength { get; private set; }
    }
}
