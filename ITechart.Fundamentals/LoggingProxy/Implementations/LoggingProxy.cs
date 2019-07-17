using ImpromptuInterface;
using ITechart.Fundamentals.Logger;
using System;
using System.Dynamic;
using ITechart.Fundamentals.LoggingProxy.AbstractClasses;
using ITechart.Fundamentals.Utils;

namespace ITechart.Fundamentals.LoggingProxy.Implementations
{
    class LoggingProxy<T> : DynamicProxy<T> where T : class
    {
        private readonly Logger.Implementations.Logger _logger;

        public LoggingProxy(Logger.Implementations.Logger logger)
        {
            _logger = logger;
        }

        private LoggingProxy(T obj, Logger.Implementations.Logger logger)
            :base(obj)
        {
            _logger = logger;
        }

        public override T CreateInstance(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return new LoggingProxy<T>(obj, _logger).ActLike<T>();
        }

        protected override void BeforeTryInvokeMember(InvokeMemberBinder binder)
        {
            _logger.Info($"Method name: '{binder.Name}' Class name: '{Instance.GetType().Name}'");
        }

        protected override void FreeResources()
        {
            _logger.Dispose();
        }
    }
}
