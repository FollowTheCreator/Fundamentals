using ITechart.Fundamentals.LoggingProxy.Implementations;
using ITechart.Fundamentals.LoggingProxy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.LoggingProxy
{
    class LoggingProxyUsage
    {
        public static void UseLoggingProxy()
        {
            var writer = new LoggingProxy<IWriter>().CreateInstance(new Writer());
            writer.Write("Method Execution...");
        }
    }
}
