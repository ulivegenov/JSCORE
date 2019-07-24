

namespace Solid.Core.Factory.Contracts
{
    using Solid.Appenders.Contracts;
    using Solid.Layouts.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IAppenderFactory
    {
        IAppander CreateAppender(string type, ILayout layOut);
    }
}
