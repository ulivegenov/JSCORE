using LoggerApp.Enums;
using LoggerApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LoggerApp.Models.Factories
{
    public class ErrorFactory
    {
        const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string stringDateTime, string stringReportLevel, string message)
        {
            DateTime dateTime = DateTime.ParseExact(stringDateTime, DateFormat, CultureInfo.InvariantCulture);
            ReportLevel level = ParseReportLevel(stringReportLevel);
            IError error = new Error(dateTime, message, level);

            return error;
        }

        private ReportLevel ParseReportLevel(string stringReportLevel)
        {
            try
            {
                object levelObj = Enum.Parse(typeof(ReportLevel), stringReportLevel);
                return (ReportLevel)levelObj;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Invalid Level Type!", e);
            }
        }
    }
}
