using ITechart.Fundamentals.Logger.Models;
using System.Collections.Generic;

namespace ITechart.Fundamentals.Logger.Interfaces
{
    interface ILogWriter
    {
        IEnumerable<LogLevel> LogTypes { get; }

        void WriteLog(LogRecord logRecord);
    }
}
