using ITechart.Fundamentals.Logger.Interfaces;
using ITechart.Fundamentals.Logger.Models;
using System;

namespace ITechart.Fundamentals.Logger.Implementations
{
    class ConsoleWriter : BaseLogger, ILogWriter
    {
        public ConsoleWriter(params LogType[] logTypes)
            :base(logTypes)
        { }

        protected override void WriteData(LogRecord logRecord)
        {
            Console.WriteLine($"{logRecord.Type}: \"{logRecord.Message}\" {DateTime.UtcNow}");
        }
    }
}
