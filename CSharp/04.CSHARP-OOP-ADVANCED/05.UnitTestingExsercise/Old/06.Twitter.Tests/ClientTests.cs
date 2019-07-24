using _06Twitter.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06Twitter.Tests
{
    [TestFixture]
    public class ClientTests
    {
        [Test]
        public void ConstructorCreateClient()
        {
            Message message = new Message("TurnOn");
            Twitter twitter = new Twitter(message);
            Client client = new Client(twitter);

            Assert.That(client.Twitter.Message.Text, Is.EqualTo("TurnOn"));
        }

        [Test]
        public void ExecuteMethodInvoksWriteToConsoleAndSentToServerInRightOrder()
        {
            Message message = new Message("TurnOn");
            Twitter twitter = new Twitter(message);
            Client client = new Client(twitter);
            Server server = new Server();



            Assert.That(() => client.Execute(server), 
                                Is.EqualTo($"{client.WriteToConsole()} {client.SentToServer(server)}"));
        }
    }
}
