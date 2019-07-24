using _04OnlineRadioDatabase2.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04OnlineRadioDatabase2
{
    public class SongFactory
    {
        private const int MIN_ARTIST_NAME_LENGTH = 3;
        private const int MAX_ARTIST_NAME_LENGTH = 20;
        private const int MIN_SONG_NAME_LENGTH = 3;
        private const int MAX_SONG_NAME_LENGTH = 30;
        public const int MIN_MINUTES = 0;
        public const int MAX_MINUTES = 14;
        public const int MIN_SECONDS = 0;
        public const int MAX_SECONDS = 59;

        public Song CreateSong(string input)
        {
            string[] tokens = input.Split(';');
            if (tokens.Length != 3)
            {
                throw new InvalidSongException();
            }

            string artistName = ValidateArtistName(tokens[0]);
            string songName = ValidateSongName(tokens[1]);

            string[] songLengthArguments = tokens[2].Split(':');
            if (songLengthArguments.Length != 2)
            {
                throw new InvalidSongLengthException();
            }

            int minutes = ValidateSongMinutes(TimeFormatChecker(songLengthArguments[0]));
            int seconds = ValidateSongSeconds(TimeFormatChecker(songLengthArguments[1]));

            Song song = new Song(artistName, songName, minutes, seconds);

            return song;
        }

        private string ValidateArtistName(string artistName)
        {
            if (artistName == null)
            {
                throw new InvalidSongException();
            }
            else if (artistName.Length < MIN_ARTIST_NAME_LENGTH || artistName.Length > MAX_ARTIST_NAME_LENGTH)
            {
                throw new InvalidArtistNameException();
            }

            return artistName;
        }

        private string ValidateSongName(string songName)
        {
            if (songName == null)
            {
                throw new InvalidSongException();
            }
            else if (songName.Length < MIN_SONG_NAME_LENGTH || songName.Length > MAX_SONG_NAME_LENGTH)
            {
                throw new InvalidSongNameException();
            }

            return songName;
        }

        public static int TimeFormatChecker(string input)
        {
            int minutesOrSeconds;
            if (int.TryParse(input, out minutesOrSeconds))
            {
                return minutesOrSeconds;
            }
            else
            {
                throw new InvalidSongLengthException();
            }
        }

        private int ValidateSongMinutes(int minutes)
        {
            if (minutes < MIN_MINUTES || minutes > MAX_MINUTES)
            {
                throw new InvalidSongMinutesException();
            }

            return minutes;
        }

        private int ValidateSongSeconds(int seconds)
        {
            if (seconds < MIN_SECONDS || seconds > MAX_SECONDS)
            {
                throw new InvalidSongSecondsException();
            }

            return seconds;
        }
    }
}
