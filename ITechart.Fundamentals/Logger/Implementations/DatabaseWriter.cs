using ITechart.Fundamentals.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechart.Fundamentals.Logger.Contexts;
using ITechart.Fundamentals.Logger.Models;

namespace ITechart.Fundamentals.Logger.Implementations
{
    class DatabaseWriter : BaseLogger, IDisposableLogger
    {
        private readonly LogContext _context;

        public DatabaseWriter(string databaseName, params LogType[] types)
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
