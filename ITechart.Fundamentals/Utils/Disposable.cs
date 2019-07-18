using System;

namespace ITechart.Fundamentals.Utils
{
    class Disposable : IDisposable
    {
        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                FreeResources();
            }

            _disposed = true;
        }

        protected virtual void FreeResources()
        {

        }
    }
}