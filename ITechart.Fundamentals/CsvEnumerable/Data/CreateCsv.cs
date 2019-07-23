using ITechart.Fundamentals.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.CsvEnumerable.Data
{
    class CreateCsv
    {
        public static void Create(string path)
        {
            CheckDirectory.CreateDirectoryIfNotExists(path);
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                var rows = new[]
                {
                    "Id,Name,Age",
                    "1, first, 1",
                    "2, second, 2",
                    "3, third, 3",
                    "4,\"test data\", 4"
                };

                foreach (var row in rows) streamWriter.WriteLine(row);
            }
        }
    }
}
