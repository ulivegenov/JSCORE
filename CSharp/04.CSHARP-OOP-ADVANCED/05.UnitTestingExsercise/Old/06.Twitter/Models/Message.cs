using _06Twitter.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06Twitter.Models
{
    public class Message : IMessage
    {

        public Message(string text)
        {
            this.Text = text;
        }

        public string Text { get; private set; }
    }
}
