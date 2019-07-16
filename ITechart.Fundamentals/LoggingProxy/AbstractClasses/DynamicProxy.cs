using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechart.Fundamentals.LoggingProxy.AbstractClasses
{
    abstract class DynamicProxy<T> : DynamicObject
    {
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

        abstract protected void PreAction(InvokeMemberBinder binder);

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            PreAction(binder);
            result = Instance.GetType().GetMethod(binder.Name).Invoke(Instance, args);
            return true;
        }
    }
}
