using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger 
{
    public class ConsoleLogger : ILogger
    {
        private LogLevel logLevel;

        public ConsoleLogger()
        {
            logLevel = LogLevel.INFO;
        }

        public ConsoleLogger(LogLevel level)
        {
            logLevel = level;
        }

        public void Log(string text)
        {
            Console.WriteLine(text);
        }

        public void Log(LogLevel level, string text)
        {
            if (level >= logLevel)
                Console.WriteLine(text);
        }
    }
}
