﻿using LoggerApp.Models.Contracts;
using LoggerApp.Models.Factories;
using System;

namespace LoggerApp.Models
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger, ErrorFactory errorFactory)
        {
            this.logger = logger;
            this.errorFactory = errorFactory;
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] errorArgs = input.Split('|');
                string stringReportLevel = errorArgs[0];
                string stringDateTime = errorArgs[1];
                string message = errorArgs[2];

                IError error = errorFactory.CreateError(stringDateTime, stringReportLevel, message);
                this.logger.Log(error);
            }

            Console.WriteLine("Logger info");
            foreach (IAppender appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
