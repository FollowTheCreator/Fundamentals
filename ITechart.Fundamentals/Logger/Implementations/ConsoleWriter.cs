using ITechart.Fundamentals.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.Logger.Implementations
{
    class ConsoleWriter : ILogWriter
    {
        public void WriteLog(string type, string message)
        {
            Console.WriteLine($"{type}: \"{message}\" {DateTime.Now}");
        }
    }
}
