using ITechart.Fundamentals.Logger.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.Logger.Contexts
{
    class LogContext : DbContext
    {
        public LogContext(string dbName)
            : base(dbName) { }

        public DbSet<Log> Logs { get; set; }
    }
}
