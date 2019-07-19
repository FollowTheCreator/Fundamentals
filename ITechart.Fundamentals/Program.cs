using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechart.Fundamentals.CsvEnumerable;
using ITechart.Fundamentals.CsvToDatabase;
using ITechart.Fundamentals.Logger;
using ITechart.Fundamentals.LoggingProxy;

namespace ITechart.Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            //RunSample("Logger", LoggerUsage.UseLogger);

            //RunSample("Logging proxy", LoggingProxyUsage.UseLoggingProxy);

            //RunSample("Csv Enumerable", CsvEnumerableUsage.UseCsvEnumerable);

            RunSample("Csv to database", CsvToDatabaseUsage.UseCsvToDatabase);

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
