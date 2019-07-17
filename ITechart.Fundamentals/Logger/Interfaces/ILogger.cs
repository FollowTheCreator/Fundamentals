﻿using System;

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
