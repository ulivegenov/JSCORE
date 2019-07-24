using System;
using System.Collections.Generic;
using System.Text;

namespace _04OnlineRadioDatabase2
{
    public class Engine
    {
        private PlayList playList;
        private SongFactory songFactory;

        public Engine()
        {
            this.playList = new PlayList();
            this.songFactory = new SongFactory();
        }

        public void Run()
        {
            int countOfSongs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfSongs; i++)
            {
                string input = Console.ReadLine();

                try
                {
                    Song song = this.songFactory.CreateSong(input);
                    this.playList.AddSong(song);

                    Console.WriteLine("Song added.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(this.playList);
        }
    }
}
