using System;
using System.Collections.Generic;
using System.Text;


public class Song
{
    private const int MIN_ARTIST_NAME_LENGTH = 3;
    private const int MAX_ARTIST_NAME_LENGTH = 20;
    private const int MIN_SONG_NAME_LENGTH = 3;
    private const int MAX_SONG_NAME_LENGTH = 20;
    private const int MIN_MINUTES = 0;
    private const int MAX_MINUTES = 14;
    private const int MIN_SECONDS = 0;
    private const int MAX_SECONDS = 59;

    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public string ArtistName
    {
        get { return artistName; }
        set
        {
            if (value.Length < MIN_ARTIST_NAME_LENGTH || value.Length > MAX_ARTIST_NAME_LENGTH)
            {
                throw new InvalidArtistNameException();
            }
            else
            {
                artistName = value;
            }
        }
    }

    public string SongName
    {
        get { return songName; }
        set
        {
            if (value.Length < MIN_SONG_NAME_LENGTH || value.Length > MAX_SONG_NAME_LENGTH)
            {
                throw new InvalidSongNameException();
            }
            else
            {
                songName = value;
            }
        }
    }

    public int Minutes
    {
        get { return minutes; }
        set
        {
            if (value < MIN_MINUTES || value > MAX_MINUTES)
            {
                throw new InvalidSongMinutesException();
            }
            else
            {
                minutes = value;
            }
        }
    }

    public int Seconds
    {
        get { return seconds; }
        set
        {
            if (value < MIN_SECONDS || value > MAX_SECONDS)
            {
                throw new InvalidSongSecondsException();
            }
            else
            {
                seconds = value;
            }
        }
    }
    public Song(string artistName)
    {
        this.ArtistName = artistName;
    }

    public Song(string artistName, string songName):this(artistName)
    {
        this.SongName = songName;
    }
    public Song(string artistName, string songName, int minutes, int seconds)
    {
        this.Minutes = minutes;
        this.Seconds = seconds;
    }
}

