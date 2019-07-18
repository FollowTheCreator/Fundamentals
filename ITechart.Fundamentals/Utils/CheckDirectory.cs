using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.Utils
{
    class CheckDirectory
    {
        public static void CreateDirectoryIfNOtExists(string path)
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
