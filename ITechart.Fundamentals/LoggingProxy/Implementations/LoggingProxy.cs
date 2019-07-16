using ImpromptuInterface;
using ITechart.Fundamentals.Logger.Implementations;
using ITechart.Fundamentals.Logger;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechart.Fundamentals.LoggingProxy.AbstractClasses;

namespace ITechart.Fundamentals.LoggingProxy.Implementations
{
    class LoggingProxy<T> : DynamicProxy<T> where T : class
    {
        public override T CreateInstance(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return new LoggingProxy<T>(obj).ActLike<T>();
        }

        public LoggingProxy() { }

        private LoggingProxy(T obj)
            :base(obj) { }

        protected override void PreAction(InvokeMemberBinder binder)
        {
            using (var logger = new Logger.Implementations.Logger(LogType.Info))
            {
                logger.Info($"Method name: '{binder.Name}' Class name: '{Instance.GetType().Name}'");
            }
        }
    }
}
