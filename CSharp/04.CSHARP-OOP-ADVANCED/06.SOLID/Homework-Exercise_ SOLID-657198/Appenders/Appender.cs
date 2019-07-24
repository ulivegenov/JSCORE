using Solid.Logger.Appenders.Contracts;
using Solid.Logger.Layouts.Contracts;
using Solid.Logger.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Logger.Appenders
{
    public abstract class Appender : IAppender
    {
        private readonly ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        protected ILayout Layout => this.layout;

        public ReportLevel ReportLevel { get; set; }

        public int messageCount { get; protected set; }

        public abstract void Append(string dateTime, ReportLevel errorLevel, string message);
    }
}
