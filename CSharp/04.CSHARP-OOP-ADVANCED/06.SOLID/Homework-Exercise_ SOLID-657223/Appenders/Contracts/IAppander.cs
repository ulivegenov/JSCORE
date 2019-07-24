
using Solid.Loggers.Enums;

namespace Solid.Appenders.Contracts
{
    public interface IAppander
    {
        void Append(string dateTime, ReportLevel reportLevel, string message);

        ReportLevel reportLevel { get; set; }

        int MessagesCount { get;}
    }
}
