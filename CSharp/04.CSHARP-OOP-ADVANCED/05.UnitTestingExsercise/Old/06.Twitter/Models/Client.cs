using _06Twitter.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06Twitter.Models
{
    public class Client : IClient
    {
        public Client(ITwitter twitter)
        {
            this.Twitter = twitter;
        }

        public ITwitter Twitter { get; private set; }

        //It must be a void type!!! It is string type only for unit testing
        public string Execute(IServer server)
        {
            this.WriteToConsole();
            this.SentToServer(server);

            return $"{this.WriteToConsole()} {this.SentToServer(server)}";
        }

        //It must be a void type and private acces!!! It is public string type only for unit testing
        public string SentToServer(IServer server)
        {
            server.AddMethod(this.Twitter);

            return $"SentToServerInvoked -> sends \"{this.Twitter.Message.Text}\"";
        }

        //It must be a void type and private acces!!! It is public string type only for unit testing
        public string WriteToConsole()
        {
            Console.WriteLine(this.Twitter.Message.Text);

            return $"WriteToConsoleInvoked -> writes \"{this.Twitter.Message.Text}\"";
        }
    }
}
