using ITechart.Fundamentals.Logger.Models;
using System.Collections.Generic;

namespace ITechart.Fundamentals.Logger.Interfaces
{
    interface ILogWriter
    {
        IEnumerable<LogType> LogTypes { get; }

        void WriteLog(LogRecord logRecord);
    }
}
