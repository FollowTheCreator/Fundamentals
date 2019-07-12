using ITechart.Fundamentals.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.Logger.Implementations
{
    class TextFileWriter : ILogWriter
    {
        public void WriteLog(string type, string message)
        {
            using (StreamWriter writer = new StreamWriter(@"..\..\Logger\Data\log.txt", true))
            {
                writer.WriteLine($"{type}: \"{message}\" {DateTime.Now}");
            }
        }
    }
}
