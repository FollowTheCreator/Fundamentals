using System.Collections.Generic;
using System.Collections;
using System.IO;
using System;

namespace ITechart.Fundamentals.CsvEnumerable.Implementations
{
    class CsvEnumerable<T> : IEnumerable<T> where T : new()
    {
        private readonly StreamReader _reader;

        public CsvEnumerable(StreamReader reader)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CsvEnumerator<T>(_reader);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
