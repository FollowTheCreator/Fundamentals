using ITechart.Fundamentals.Common.Models;
using ITechart.Fundamentals.CsvEnumerable.Data;
using ITechart.Fundamentals.CsvEnumerable.Implementations;
using ITechart.Fundamentals.Utils;
using System;
using System.IO;
using System.Linq;

namespace ITechart.Fundamentals.CsvEnumerable
{
    class CsvEnumerableUsage
    {
        public static void UseCsvEnumerable()
        {
            string path = Config.CsvFilePath;
            using (var reader = new StreamReader(path))
            {
                var data = new CsvEnumerable<Record>(reader)
                    .Select(row => row.ToString());

                Console.WriteLine(string.Join("\n", data));
            }
        }
    }
}
