using ITechart.Fundamentals.Logger.Interfaces;
using ITechart.Fundamentals.Logger.Models;
using ITechart.Fundamentals.Utils;
using System;

namespace ITechart.Fundamentals.Logger.Implementations
{
    class Logger : Disposable, ILogger
    {
        private readonly ILogWriter _destination;

        public Logger(params LogLevel[] logTypes)
        {
            if (logTypes == null)
            {
                throw new ArgumentNullException(nameof(logTypes));
            }

            _destination = new ConsoleWriter(logTypes);
        }

        public Logger(ILogWriter destination)
        {
            _destination = destination ?? throw new ArgumentNullException(nameof(destination));
        }

        public void Error(string message)
        {
            _destination.WriteLog(new LogRecord() { Type = LogLevel.Error, Message = message });
        }

        public void Error(Exception ex)
        {
            _destination.WriteLog(new LogRecord() { Type = LogLevel.Error, Message = ex.Message });
        }

        public void Warning(string message)
        {
            _destination.WriteLog(new LogRecord() { Type = LogLevel.Warning, Message = message });
        }

        public void Info(string message)
        {
            _destination.WriteLog(new LogRecord() { Type = LogLevel.Info, Message = message });
        }

        protected override void FreeResources()
        {
            (_destination as IDisposableLogWriter)?.Dispose();
        }
    }
}
