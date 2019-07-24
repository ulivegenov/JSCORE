using _06Twitter.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06Twitter.Models
{
    public class Server : IServer
    {
        private List<ITwitter> twitters;

        public Server()
        {
            this.twitters = new List<ITwitter>();
        }

        public IReadOnlyCollection<ITwitter> Twitters
        {
            get { return this.twitters; }
        }

        public void AddMethod(ITwitter twitter)
        {
            this.twitters.Add(twitter);
        }
    }
}
