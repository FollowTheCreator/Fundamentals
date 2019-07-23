using System;
using System.IO;

namespace ITechart.Fundamentals.Utils
{
    static class CheckDirectory
    {
        public static void CreateDirectoryIfNotExists(string path)
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
    }
}
