using ITechart.Fundamentals.Logger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.Logger.Implementations
{
    abstract class BaseLogger : Disposable
    {
        public IEnumerable<LogType> LogTypes { get; private set; }

        public BaseLogger(IEnumerable<LogType> logTypes)
        {
            if (logTypes == null || !logTypes.Any())
            {
                LogTypes = new List<LogType> { LogType.Error, LogType.Info, LogType.Warning };
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
