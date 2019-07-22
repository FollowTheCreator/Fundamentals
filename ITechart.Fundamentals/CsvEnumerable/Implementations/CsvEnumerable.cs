using System.Collections.Generic;
using System.Collections;
using System.IO;
using System;
using ITechart.Fundamentals.Utils;
using System.Reflection;
using System.Linq;

namespace ITechart.Fundamentals.CsvEnumerable.Implementations
{
    class CsvEnumerable<T> : IEnumerable<T> where T : new()
    {
        private readonly StreamReader _reader;

        public char Delimiter { get; set; }

        public CsvEnumerable(StreamReader reader, char delimiter = ',')
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
            Delimiter = delimiter;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CsvEnumerator(_reader, Delimiter);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class CsvEnumerator : IEnumerator<T>
        {
            private static readonly PropertyInfo[] _properties;

            private readonly StreamReader _reader;

            private readonly char _delimiter;

            private string _currentLine;

            private bool _isFirst;

            public CsvEnumerator(StreamReader reader, char delimiter)
            {
                _reader = reader ?? throw new ArgumentNullException(nameof(reader));
                _currentLine = default;
                _isFirst = true;
                _delimiter = delimiter;
            }

            static CsvEnumerator()
            {
                _properties = typeof(T).GetProperties();
            }

            public T Current
            {
                get
                {
                    if (_currentLine == null)
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
                _currentLine = _reader.ReadLine();

                return _currentLine != null;
            }

            public void Reset()
            {
                _isFirst = true;
                _reader.DiscardBufferedData();
                _reader.BaseStream.Seek(0, SeekOrigin.Begin);
                _currentLine = null;
            }

            public void Dispose() { }

            private T GetCurrentRecord()
            {
                T _currentRecord = new T();

                string[] currentRow = ConvertFromCsv(_currentLine).ToArray();

                try
                {
                    for (int i = 0; i < _properties.Length; i++)
                    {
                        _properties[i].SetValue(
                            _currentRecord,
                            Convert.ChangeType(currentRow[i], _properties[i].PropertyType)
                        );
                    }
                    _isFirst = false;
                }
                catch (FormatException)
                {
                    if (_isFirst)
                    {
                        MoveNext();
                        return GetCurrentRecord();
                    }
                }

                return _currentRecord;
            }

            private IEnumerable<string> ConvertFromCsv(string line)
            {
                if (string.IsNullOrEmpty(line))
                {
                    return null;
                }
                const char dQuotes = '"';

                var answer = line.Split(_delimiter).Select(col =>
                {
                    if (!String.IsNullOrEmpty(col) && col.First() == dQuotes && col.Last() == dQuotes)
                    {
                        col = col.Substring(1, col.Length - 2);
                    }
                    return col.Replace("\"\"", "\"");
                });

                return answer;
            }
        }
    }
}
