using CsvHelper;
using ITechart.Fundamentals.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ITechart.Fundamentals.CsvEnumerable.Implementations
{
    class CsvEnumeratorWithHelper<T> : Disposable, IEnumerator<T> where T : new()
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
            if (_index < _records.Length - 1)
            {
                _index++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _reader.DiscardBufferedData();
            _reader.BaseStream.Seek(0, SeekOrigin.Begin);
            _index = -1;
        }

        protected override void FreeResources()
        {
            _reader.Dispose();
            _csvReader.Dispose();
        }
    }
}
