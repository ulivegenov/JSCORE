using System;
using System.Collections.Generic;
using System.Text;

namespace _04OnlineRadioDatabase2
{
    public class PlayList
    {
        private List<Song> songs;
        private int lenght;

        public PlayList()
        {
            this.songs = new List<Song>();
            this.lenght = 0;
        }

        public void AddSong(Song song)
        {
            this.songs.Add(song);
            this.lenght += song.SongLength;
        }

        public override string ToString()
        {
            int hours = lenght / 3600;
            int minutes = (lenght % 3600) / 60;
            int seconds = (lenght % 3600) % 60;

            return $"Songs added: {songs.Count}" +
                $"{Environment.NewLine}Playlist length: {hours}h {minutes}m {seconds}s";
        }
    }
}
