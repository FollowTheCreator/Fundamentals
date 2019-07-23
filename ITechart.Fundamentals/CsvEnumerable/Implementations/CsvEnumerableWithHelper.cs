using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ITechart.Fundamentals.CsvEnumerable.Implementations
{
    class CsvEnumerableWithHelper<T> : IEnumerable<T> where T : new()
    {
        private readonly StreamReader _reader;

        public CsvEnumerableWithHelper(StreamReader reader)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CsvEnumeratorWithHelper<T>(_reader);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
