using LoggerApp.Enums;
using LoggerApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Models
{
    public class Error : IError
    {
        public Error(DateTime dateTime, string message, ReportLevel level)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public ReportLevel Level { get; }
    }
}
