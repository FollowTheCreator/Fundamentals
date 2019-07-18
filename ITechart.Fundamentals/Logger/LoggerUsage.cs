using System;
using ITechart.Fundamentals.Logger.Interfaces;
using ITechart.Fundamentals.Logger.Implementations;

namespace ITechart.Fundamentals.Logger
{
    class LoggerUsage
    {
        public static void UseLogger()
        {
            using (var logger = new Implementations.Logger(
                new ConsoleWriter(LogType.Error,
                                  LogType.Info)
            ))
            {
                CallMethods(logger);
            }

            const string Path = @"Logs\log.txt";
            using (var logger = new Implementations.Logger(
                new TextFileWriter(Path,
                                   LogType.Warning,
                                   LogType.Info)
            ))
            {
                CallMethods(logger);
            }

            const string ConnectionName = "Log";
            using (var logger = new Implementations.Logger(
                new DatabaseWriter(ConnectionName,
                                   LogType.Error,
                                   LogType.Info)
            ))
            {
                CallMethods(logger);
            }

            using (var logger = new Implementations.Logger( LogType.Error, LogType.Warning ))
            {
                CallMethods(logger);
            }
        }

        private static void CallMethods(ILogger logger)
        {
            logger.Error("Error message");
            logger.Error(new Exception("Exception message"));
            logger.Warning("Warning message");
            logger.Info("Info message");
        }
    }
}
