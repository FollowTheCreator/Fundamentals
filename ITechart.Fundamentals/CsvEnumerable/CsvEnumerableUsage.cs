using ITechart.Fundamentals.CsvEnumerable.Implementations;
using ITechart.Fundamentals.CsvEnumerable.Models;
using System;
using System.IO;
using System.Linq;

namespace ITechart.Fundamentals.CsvEnumerable
{
    class CsvEnumerableUsage
    {
        public static void UseCsvEnumerable()
        {
            var data = new CsvEnumerableWithHelper<Record>(new StreamReader(@"file.csv"))
                .Select(row => row.ToString());

            Console.WriteLine(string.Join("\n", data));
        }
    }
}
