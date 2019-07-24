using _06Twitter.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06Twitter.Tests
{
    [TestFixture]
    public class TwitterTests
    {
        [Test]
        public void ConstructorCreateTwitter()
        {
            Message message = new Message("TurnOn");
            Twitter twitter = new Twitter(message);

            Assert.That(twitter.Message.Text, Is.EqualTo("TurnOn"));
        }
    }
}
