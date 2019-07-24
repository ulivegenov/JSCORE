using System;
using System.Collections.Generic;
using System.Text;


public class PlayList
{
    private Stack<Song> songs;

    public Stack<Song> Songs
    {
        get { return songs; }
        set { songs = value; }
    }

    public int Hours
    {
        get => GetPlaylistTime(this.Songs)[0];
    }

    public int Minutes
    {
        get => GetPlaylistTime(this.Songs)[1];
    }

    public int Seconds
    {
        get => GetPlaylistTime(this.Songs)[2];
    }

    public PlayList()
    {
        this.Songs = new Stack<Song>();
    }

    private static List<int> GetPlaylistTime(Stack<Song> songs)
    {
        List<int> timeParameters = new List<int>();
        int tottalSecondsTime = 0;
        int hours = 0;
        int minutes = 0;
        int seconds = 0;

        if (songs.Count != 0)
        {
            foreach (var song in songs)
            {
                tottalSecondsTime += song.Seconds;
                tottalSecondsTime += song.Minutes * 60;
            }

            hours = tottalSecondsTime / 3600;
            tottalSecondsTime -= hours * 3600;
            minutes = tottalSecondsTime / 60;
            tottalSecondsTime -= minutes * 60;
            seconds = tottalSecondsTime;
        }
        
        timeParameters.Add(hours);
        timeParameters.Add(minutes);
        timeParameters.Add(seconds);

        return timeParameters;
    }

    public override string ToString()
    {
        return $"Songs added: {this.Songs.Count}{Environment.NewLine}Playlist length: {this.Hours}h {this.Minutes}m {this.Seconds}s";
    }
}

