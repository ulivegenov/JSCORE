using System;
using System.Collections.Generic;
using System.Text;

namespace _06Twitter.Contracts
{
    public interface ITwitter
    {
        IMessage Message { get; }
    }
}
