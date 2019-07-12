using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.Logger.Interfaces
{
    interface ILogWriter
    {
        void WriteLog(string type, string message);
    }
}
