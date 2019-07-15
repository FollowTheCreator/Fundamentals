using ITechart.Fundamentals.Logger.Interfaces;
using ITechart.Fundamentals.Logger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.Logger.Implementations
{
    class Logger : ILogger
    {
        public ILogWriter Destination { get; set; }

        public Logger(IEnumerable<LogType> logTypes)
        {
            Destination = new ConsoleWriter(logTypes);
        }

        public Logger(ILogWriter destination)
        {
            Destination = destination;
        }

        public void Error(string message)
        {
            Destination?.WriteLog(new LogRecord() { Type = LogType.Error, Message = message });
        }

        public void Error(Exception ex)
        {
            Destination?.WriteLog(new LogRecord() { Type = LogType.Error, Message = ex.Message });
        }

        public void Warning(string message)
        {
            Destination?.WriteLog(new LogRecord() { Type = LogType.Warning, Message = message });
        }

        public void Info(string message)
        {
            Destination?.WriteLog(new LogRecord() { Type = LogType.Info, Message = message });
        }
    }
}
