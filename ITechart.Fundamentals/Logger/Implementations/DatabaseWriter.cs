using ITechart.Fundamentals.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechart.Fundamentals.Logger.Contexts;
using ITechart.Fundamentals.Logger.Models;

namespace ITechart.Fundamentals.Logger.Implementations
{
    class DatabaseWriter : ILogWriter
    {
        public IEnumerable<LogType> LogTypes { get; private set; }

        public LogContext Context { get; set; }

        public DatabaseWriter(IEnumerable<LogType> logTypes, LogContext context)
        {
            LogTypes = logTypes;
            Context = context;
        }

        public void WriteLog(LogRecord logRecord)
        {
            if (!LogTypes.Contains(logRecord.Type))
            {
                return;
            }

            Context.Logs.Add(
                new Log()
                {
                    Type = logRecord.Type.ToString(),
                    Message = logRecord.Message,
                    Date = DateTime.Now
                }
            );
            Context.SaveChanges();
        }
    }
}
