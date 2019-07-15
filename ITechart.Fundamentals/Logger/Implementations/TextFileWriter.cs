using ITechart.Fundamentals.Logger.Interfaces;
using ITechart.Fundamentals.Logger.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.Logger.Implementations
{
    class TextFileWriter : ILogWriter
    {
        public IEnumerable<LogType> LogTypes { get; private set; }

        public StreamWriter Writer { get; set; }

        public TextFileWriter(IEnumerable<LogType> logTypes, StreamWriter writer)
        {
            LogTypes = logTypes;
            Writer = writer;
        }

        public void WriteLog(LogRecord logRecord)
        {
            if (!LogTypes.Contains(logRecord.Type))
            {
                return;
            }

            Writer.WriteLine($"{logRecord.Type}: \"{logRecord.Message}\" {DateTime.Now}");
        }
    }
}
