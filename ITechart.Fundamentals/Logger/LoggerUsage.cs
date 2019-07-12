using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechart.Fundamentals.Logger;
using ITechart.Fundamentals.Logger.Interfaces;
using ITechart.Fundamentals.Logger.Implementations;
using ITechart.Fundamentals.Logger.Contexts;

namespace ITechart.Fundamentals.Logger
{
    class LoggerUsage
    {
        public static void UseLogger()
        {
            ILogger logger = new Implementations.Logger(new ConsoleWriter());
            CallMethods(logger);

            logger = new Implementations.Logger(new TextFileWriter());
            CallMethods(logger);

            logger = new Implementations.Logger(new DatabaseWriter());
            CallMethods(logger);

            logger = new Implementations.Logger();
            CallMethods(logger);
        }

        private static void CallMethods(ILogger logger)
        {
            logger.Error("Error message");
            logger.Error(new Exception("Exception error message"));
            logger.Warning("Warning message");
            logger.Info("Info message");
        }
    }
}
