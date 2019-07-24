using LoggerApp.Enums;

namespace LoggerApp.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel Level { get; }

        void Append(IError error);
    }
}
