using System;
using System.Collections.Generic;

namespace SimpleIoc.Container
{
    public class IocContainer
    {
        private readonly Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();

        public void Register<TRegistration, TImplementation>()
        {
            Type registrationType = typeof(TRegistration);
            Type implementationType = typeof(TImplementation);

            _registrations.Add(registrationType, implementationType);
        }

        public object Resolve(Type type)
        {
            Type actualType = _registrations[type];

            var instance = Activator.CreateInstance(actualType);

            return instance;
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }
    }
}
