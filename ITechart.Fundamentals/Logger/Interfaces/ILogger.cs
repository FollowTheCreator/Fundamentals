using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.Logger.Interfaces
{
    interface ILogger
    {
        void Error(string message);

        void Error(Exception ex);

        void Warning(string message);

        void Info(string message);
    }
}
