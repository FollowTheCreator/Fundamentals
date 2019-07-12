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
    class DatabaseWriter : ILogWriter
    {
        public void WriteLog(string type, string message)
        {
            using (var context = new LogContext())
            {
                context.Logs.Add(
                    new Log()
                    {
                        Type = type,
                        Message = message,
                        Date = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
