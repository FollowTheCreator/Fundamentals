using ITechart.Fundamentals.Logger.Interfaces;
using System;
using ITechart.Fundamentals.Logger.Contexts;
using ITechart.Fundamentals.Logger.Models;

namespace ITechart.Fundamentals.Logger.Implementations
{
    class DatabaseWriter : BaseLogger, IDisposableLogWriter
    {
        private readonly LogContext _context;

        public DatabaseWriter(string databaseName, params LogLevel[] types)
            :base(types)
        {
            databaseName = databaseName ?? throw new ArgumentNullException(nameof(databaseName));
            _context = new LogContext(databaseName);
        }

        protected override void WriteData(LogRecord logRecord)
        {
            _context.Logs.Add(
                new Log()
                {
                    Type = logRecord.Type.ToString(),
                    Message = logRecord.Message,
                    Date = DateTime.UtcNow
                }
            );
            _context.SaveChanges();
        }

        protected override void FreeResources()
        {
            _context.Dispose();
        }
    }
}
