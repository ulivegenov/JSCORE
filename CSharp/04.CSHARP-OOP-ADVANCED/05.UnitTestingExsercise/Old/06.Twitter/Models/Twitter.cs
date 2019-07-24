using _06Twitter.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06Twitter.Models
{
    public class Twitter : ITwitter
    {
        public Twitter(IMessage message)
        {
            this.Message = message;
        }

        public IMessage Message { get; private set; }
    }
}
