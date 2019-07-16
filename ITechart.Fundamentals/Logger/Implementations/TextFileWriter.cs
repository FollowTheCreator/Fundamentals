using ITechart.Fundamentals.Logger.Interfaces;
using ITechart.Fundamentals.Logger.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.Logger.Implementations
{
    class TextFileWriter : BaseLogger, IDisposableLogger
    {
        private readonly StreamWriter _writer;

        public TextFileWriter(string path, params LogType[] types)
            : base(types)
        {
            path = path ?? throw new ArgumentNullException(nameof(path));
            CreateDirectoryIfNOtExists(path);
            _writer = new StreamWriter(path, append: true);
        }

        private static void CreateDirectoryIfNOtExists(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            var fi = new FileInfo(path);
            if (!fi.Directory.Exists)
            {
                Directory.CreateDirectory(fi.DirectoryName);
            }
        }

        protected override void WriteData(LogRecord logRecord)
        {
            _writer.WriteLine($"{logRecord.Type}: \"{logRecord.Message}\" {DateTime.UtcNow}");
        }

        protected override void FreeResources()
        {
            _writer.Dispose();
        }
    }
}
