using System;
using System.Collections.Generic;
using System.Text;

namespace _06Twitter.Contracts
{
    public interface IClient
    {
        ITwitter Twitter { get; }

        //It must be a void type!!! It is string type Only for unit testing
        string Execute(IServer server);
    }
}
