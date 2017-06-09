using System;

namespace SimpleIoc.Container.Exceptions
{
    public abstract class IocException : Exception
    {
        public Type Type { get; }

        public IocException(Type type)
        {
            Type = type;
        }
    }
}