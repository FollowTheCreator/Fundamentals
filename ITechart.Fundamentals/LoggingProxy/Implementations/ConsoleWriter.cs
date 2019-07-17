using ITechart.Fundamentals.LoggingProxy.Interfaces;
using System;

namespace ITechart.Fundamentals.LoggingProxy.Implementations
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
