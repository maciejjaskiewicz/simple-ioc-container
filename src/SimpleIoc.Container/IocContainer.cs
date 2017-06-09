using SimpleIoc.Container.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

            var ctors = actualType.GetConstructors();

            ThrowIfConstructorsAreMoreThanOne(actualType, ctors);

            var ctor = ctors.First();

            IEnumerable<Type> paramiterTypes = ctor.GetParameters()
                .Select(p => p.ParameterType);

            var dependencies = paramiterTypes
                .Select(p => Resolve(p))
                .ToArray();

            var instance = Activator.CreateInstance(actualType, dependencies);

            return instance;
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private static void ThrowIfConstructorsAreMoreThanOne(Type actualType, ConstructorInfo[] ctors)
        {
            if (ctors.Length > 1)
            {
                throw new ComponentHasMultipleConstructorsException(actualType);
            }
        }
    }
}
