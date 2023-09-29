using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace FactoryMethodStarterCode
{
    class Program
    {
        private static ILoggerFactory LoadFactory(string factoryName)
        {
            string factoryTypeAsString = ConfigurationManager.AppSettings[factoryName];
            Type factoryType = Type.GetType(factoryTypeAsString);
            return (ILoggerFactory)Activator.CreateInstance(factoryType);
        }

        static void Main(string[] args)
        {
            ILoggerFactory cfactory = LoadFactory("ConsoleFactory");
            ILoggerFactory ffactory = LoadFactory("FileFactory");

            ILogger logger1 = cfactory.CreateLogger();
            logger1.Log("Log message");

            ILogger logger2 = cfactory.CreateLogger(LogLevel.ERROR);
            logger2.Log(LogLevel.WARN, "Should not see this");
            logger2.Log(LogLevel.ERROR, "Error Message");
            logger2.Log(LogLevel.FATAL, "Fatal Message");

            ILogger flogger1 = ffactory.CreateLogger();
            flogger1.Log("Log message");

            ILogger flogger2 = ffactory.CreateLogger(LogLevel.ERROR);
            flogger2.Log(LogLevel.WARN, "Should not see this");
            flogger2.Log(LogLevel.ERROR, "Error Message");
            flogger2.Log(LogLevel.FATAL, "Fatal Message");
        }
    }
}
