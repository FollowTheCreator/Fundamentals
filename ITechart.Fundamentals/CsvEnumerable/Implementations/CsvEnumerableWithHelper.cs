using CsvHelper;
using ITechart.Fundamentals.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            return new CsvEnumeratorWithHelper(_reader);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class CsvEnumeratorWithHelper : Disposable, IEnumerator<T>
        {
            private readonly StreamReader _reader;

            private readonly CsvReader _csvReader;

            private readonly T[] _records;

            private int _index;

            public CsvEnumeratorWithHelper(StreamReader reader)
            {
                _reader = reader ?? throw new ArgumentNullException(nameof(reader));
                _csvReader = new CsvReader(reader);
                _records = _csvReader.GetRecords<T>().ToArray();
                _index = -1;
            }

            public T Current
            {
                get
                {
                    return _records[_index];
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                _index++;
                return (_index < _records.Length);
            }

            public void Reset()
            {
                _reader.DiscardBufferedData();
                _reader.BaseStream.Seek(0, SeekOrigin.Begin);
                _index = -1;
            }

            protected override void FreeResources()
            {
                _csvReader.Dispose();
            }
        }
    }
}
