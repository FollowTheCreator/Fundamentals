using System;
using ITechart.Fundamentals.Logger;
using ITechart.Fundamentals.LoggingProxy;

namespace ITechart.Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSample("Logger", LoggerUsage.UseLogger);

            RunSample("Logging proxy", LoggingProxyUsage.UseLoggingProxy);

            Console.ReadKey();
        }

        private static void RunSample(string name, Action action)
        {
            Console.WriteLine("--{0}", name);
            action();
            Console.WriteLine();
        }
    }
}
