using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        int countOfSongs = int.Parse(Console.ReadLine());
        PlayList playList = new PlayList();

        for (int i = 0; i < countOfSongs; i++)
        {
            string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                if (input.Length != 3)
                {
                    throw new InvalidSongExeption();
                }
                else
                {
                    if (!input[2].Contains(":"))
                    {
                        throw new InvalidSongExeption();
                        //throw new InvalidSongLengthException();
                    }
                    string[] inputTime = input[2].Split(':', StringSplitOptions.RemoveEmptyEntries);
                    Song currentSong = new Song(input[0], input[1], TimeFormatChecker(inputTime[0]), TimeFormatChecker(inputTime[1]));
                    playList.Songs.Push(currentSong);
                    Console.WriteLine("Song added.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine(playList);
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
}


