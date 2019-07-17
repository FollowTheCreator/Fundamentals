using System;
using System.Dynamic;

namespace ITechart.Fundamentals.LoggingProxy.AbstractClasses
{
    abstract class DynamicProxy<T> : DynamicObject, IDisposable
    {
        private bool _disposed = false;

        public T Instance { get; private set; }

        protected DynamicProxy() { }

        public DynamicProxy(T obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            Instance = obj;
        }

        abstract public T CreateInstance(T obj);

        abstract protected void BeforeTryInvokeMember(InvokeMemberBinder binder);

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            BeforeTryInvokeMember(binder);
            result = Instance.GetType().GetMethod(binder.Name).Invoke(Instance, args);
            return true;
        }

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
