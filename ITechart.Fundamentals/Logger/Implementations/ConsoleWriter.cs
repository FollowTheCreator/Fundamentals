using ITechart.Fundamentals.Logger.Interfaces;
using ITechart.Fundamentals.Logger.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.Logger.Implementations
{
    class ConsoleWriter : ILogWriter
    {
        public IEnumerable<LogType> LogTypes { get; private set; }

        public ConsoleWriter(params LogType[] logTypes)
        {
            LogTypes = logTypes ?? throw new ArgumentNullException(nameof(logTypes));
        }

        public void WriteLog(LogRecord logRecord)
        {
            if (!LogTypes.Contains(logRecord.Type))
            {
                return;
            }

            Console.WriteLine($"{logRecord.Type}: \"{logRecord.Message}\" {DateTime.UtcNow}");
        }
    }
}
