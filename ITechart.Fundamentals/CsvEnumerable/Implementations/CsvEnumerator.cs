using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Reflection;
using ITechart.Fundamentals.Utils;

namespace ITechart.Fundamentals.CsvEnumerable.Implementations
{
    class CsvEnumerator<T> : Disposable, IEnumerator<T> where T : new()
    {
        private readonly StreamReader _reader;

        private string[] _currentRow;

        private readonly T _currentRecord;

        private readonly PropertyInfo[] _properties;

        public CsvEnumerator(StreamReader reader)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
            _currentRow = default;
            _currentRecord = new T();
            _properties = typeof(T).GetProperties();
        }

        public T Current
        {
            get
            {
                if (_currentRow == null)
                {
                    throw new NullReferenceException(nameof(_currentRow));
                }

                for(int i = 0; i < _properties.Length; i++)
                {
                    _properties[i].SetValue(
                        _currentRecord,
                        Convert.ChangeType(_currentRow[i], _properties[i].PropertyType)
                    );
                }

                return _currentRecord;
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            _currentRow = _reader.ReadLine()?.Split(',');
            if (_currentRow == null)
            {
                return false;
            }

            return true;
        }

        public void Reset()
        {
            _reader.DiscardBufferedData();
            _reader.BaseStream.Seek(0, SeekOrigin.Begin);
            _currentRow = null;
        }

        protected override void FreeResources()
        {
            _reader.Dispose();
        }
    }
}
