using System;
using System.Collections.Generic;
using System.Text;

namespace _06Twitter.Contracts
{
    public interface IServer
    {
        IReadOnlyCollection<ITwitter> Twitters { get; }

        void AddMethod(ITwitter twitter);
    }
}
