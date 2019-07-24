using LoggerApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LoggerApp.Models
{
    public class SimpleLayout : ILayout
    {
        const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public string FormateError(IError error)
        {
            return $"{error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture)} - {error.Level} - {error.Message}";
        }
    }
}
