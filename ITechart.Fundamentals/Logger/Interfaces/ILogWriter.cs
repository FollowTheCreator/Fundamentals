using ITechart.Fundamentals.Logger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.Logger.Interfaces
{
    interface ILogWriter
    {
        IEnumerable<LogType> LogTypes { get; }

        void WriteLog(LogRecord logRecord);
    }
}
