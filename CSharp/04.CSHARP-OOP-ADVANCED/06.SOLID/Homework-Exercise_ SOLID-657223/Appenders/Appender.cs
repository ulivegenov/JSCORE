

namespace Solid.Appenders
{
    using Solid.Appenders.Contracts;
    using Solid.Layouts.Contracts;
    using Solid.Loggers.Enums;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Appender : IAppander
    {

        private ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }
        protected ILayout Layout => this.layout;

        public ReportLevel reportLevel { get; set; }

        public int MessagesCount { get; protected set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);
      
    }
}
