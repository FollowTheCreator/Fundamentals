using ITechart.Fundamentals.CsvEnumerable.Data;
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
            const string path = @"file.csv";
            CreateCsv.Create(path);
            var data = new CsvEnumerableWithHelper<Record>(new StreamReader(path))
                .Select(row => row.ToString());

            Console.WriteLine(string.Join("\n", data));
        }
    }
}
