using ITechart.Fundamentals.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.Logger.Implementations
{
    class Logger : ILogger
    {
        public ILogWriter Destination { private get; set; }

        public Logger()
        {
            Destination = new ConsoleWriter();
        }

        public Logger(ILogWriter logWriter)
        {
            Destination = logWriter;
        }

        private void WriteLog(string type, string message)
        {
            Destination.WriteLog(type, message);
        }

        public void Error(string message)
        {
            WriteLog("Error", message);
        }

        public void Error(Exception ex)
        {
            WriteLog("Error", ex.Message);
        }

        public void Warning(string message)
        {
            WriteLog("Warning", message);
        }

        public void Info(string message)
        {
            WriteLog("Info", message);
        }
    }
}
