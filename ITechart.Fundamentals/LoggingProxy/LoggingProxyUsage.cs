using ITechart.Fundamentals.Logger;
using ITechart.Fundamentals.LoggingProxy.Implementations;
using ITechart.Fundamentals.LoggingProxy.Interfaces;

namespace ITechart.Fundamentals.LoggingProxy
{
    class LoggingProxyUsage
    {
        public static void UseLoggingProxy()
        {
            var logger = new Logger.Implementations.Logger(LogType.Info);
            using (var loggingProxy = new LoggingProxy<IWriter>(logger))
            {
                var writer = loggingProxy.CreateInstance(new ConsoleWriter());
                writer.Write("Method Execution...");
            }
        }
    }
}
