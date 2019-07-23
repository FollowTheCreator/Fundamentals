using ITechart.Fundamentals.Logger.Models;
using ITechart.Fundamentals.Utils;
using System.Collections.Generic;
using System.Linq;

namespace ITechart.Fundamentals.Logger.Implementations
{
    abstract class BaseLogger : Disposable
    {
        public IEnumerable<LogLevel> LogTypes { get; private set; }

        public BaseLogger(IEnumerable<LogLevel> logTypes)
        {
            if (logTypes == null || !logTypes.Any())
            {
                LogTypes = new List<LogLevel> { LogLevel.Error, LogLevel.Info, LogLevel.Warning };
            }
            else
            {
                LogTypes = logTypes;
            }
        }

        public void WriteLog(LogRecord logRecord)
        {
            if (!LogTypes.Contains(logRecord.Type))
            {
                return;
            }

            WriteData(logRecord);
        }

        protected virtual void WriteData(LogRecord logRecord)
        {

        }
    }
}
