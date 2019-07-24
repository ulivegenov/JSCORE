using _06Twitter.Models;
using NUnit.Framework;
using System;

namespace _06Twitter.Tests
{
    [TestFixture]
    public class MessageTests
    {
        [Test]
        public void ConstructorCreateMessage()
        {
            Message message = new Message("Set StopWatch to 03:00");

            Assert.That(message.Text, Is.EqualTo("Set StopWatch to 03:00"));
        }
    }
}
