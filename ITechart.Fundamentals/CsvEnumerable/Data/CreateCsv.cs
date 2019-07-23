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
            CheckDirectory.CreateDirectoryIfNOtExists(path);
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.Write("Id,Name,Age\n1, first, 1\n2, second, 2\n3, third, 3\n4,\"test data\", 4");
            }
        }
    }
}
