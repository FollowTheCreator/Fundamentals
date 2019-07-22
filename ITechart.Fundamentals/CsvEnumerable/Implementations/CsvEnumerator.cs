using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Reflection;
using ITechart.Fundamentals.Utils;
using System.Linq;

namespace ITechart.Fundamentals.CsvEnumerable.Implementations
{
    class CsvEnumerator<T> : Disposable, IEnumerator<T> where T : new()
    {
        private readonly StreamReader _reader;

        private string[] _currentRow;

        private readonly PropertyInfo[] _properties;

        private bool _isFirst;

        public CsvEnumerator(StreamReader reader)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
            _currentRow = default;
            _properties = typeof(T).GetProperties();
            _isFirst = true;
        }

        public T Current
        {
            get
            {
                if (_currentRow == null)
                {
                    return default;
                }

                return GetCurrentRecord();
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            _currentRow = ConvertFromCsv(_reader.ReadLine()).ToArray();
            if (_currentRow == null)
            {
                return false;
            }

            return true;
        }

        public void Reset()
        {
            _isFirst = true;
            _reader.DiscardBufferedData();
            _reader.BaseStream.Seek(0, SeekOrigin.Begin);
            _currentRow = null;
        }

        protected override void FreeResources()
        {
            _reader.Dispose();
        }

        private T GetCurrentRecord()
        {
            T _currentRecord = new T();

            try
            {
                for (int i = 0; i < _properties.Length; i++)
                {
                    _properties[i].SetValue(
                        _currentRecord,
                        Convert.ChangeType(_currentRow[i], _properties[i].PropertyType)
                    );
                }
                _isFirst = false;
            }
            catch(FormatException)
            {
                if (_isFirst)
                {
                    MoveNext();
                    return GetCurrentRecord();
                }
            }

            return _currentRecord;
        }

        private static IEnumerable<string> ConvertFromCsv(string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                return null;
            }
            const char dQuotes = '"';
            
            var answer = line.Split(',').Select(col => 
            {
                if (col.First() == dQuotes && col.Last() == dQuotes)
                {
                    col = col.Substring(1, col.Length - 2);
                }
                return col.Replace("\"\"", "\"");
            });

            return answer;
        }
    }
}
