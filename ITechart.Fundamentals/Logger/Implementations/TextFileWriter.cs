using ITechart.Fundamentals.Logger.Interfaces;
using ITechart.Fundamentals.Logger.Models;
using ITechart.Fundamentals.Utils;
using System;
using System.IO;

namespace ITechart.Fundamentals.Logger.Implementations
{
    class TextFileWriter : BaseLogger, IDisposableLogger
    {
        private readonly StreamWriter _writer;

        public TextFileWriter(string path, params LogType[] types)
            : base(types)
        {
            path = path ?? throw new ArgumentNullException(nameof(path));
            CheckDirectory.CreateDirectoryIfNOtExists(path);
            _writer = new StreamWriter(path, append: true);
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
