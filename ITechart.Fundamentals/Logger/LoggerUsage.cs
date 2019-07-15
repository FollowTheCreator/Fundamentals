using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechart.Fundamentals.Logger;
using ITechart.Fundamentals.Logger.Interfaces;
using ITechart.Fundamentals.Logger.Implementations;
using ITechart.Fundamentals.Logger.Models;
using ITechart.Fundamentals.Logger.Contexts;
using System.IO;

namespace ITechart.Fundamentals.Logger
{
    class LoggerUsage
    {
        public static void UseLogger()
        {
            ILogger logger = new Implementations.Logger(
                new ConsoleWriter(
                    new List<LogType>() { LogType.Error, LogType.Info }
                )
            );
            CallMethods(logger);

            string path = @"Logs\log.txt";
            FileInfo fi = new FileInfo(path);
            if (!fi.Directory.Exists)
            {
                Directory.CreateDirectory(fi.DirectoryName);
            }
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                logger = new Implementations.Logger(
                    new TextFileWriter(
                        new List<LogType>() { LogType.Warning, LogType.Info },
                        writer
                    )
                );
                CallMethods(logger);
            }

            using (LogContext context = new LogContext())
            {
                logger = new Implementations.Logger(
                    new DatabaseWriter(
                        new List<LogType>() { LogType.Error, LogType.Info },
                        context
                    )
                );
                CallMethods(logger);
            }

            logger = new Implementations.Logger(new List<LogType>() { LogType.Error, LogType.Warning });
            CallMethods(logger);
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
