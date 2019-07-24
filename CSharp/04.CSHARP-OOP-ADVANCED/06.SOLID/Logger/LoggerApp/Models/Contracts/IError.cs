using LoggerApp.Enums;
using System;

namespace LoggerApp.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        ReportLevel Level { get; }
    }
}