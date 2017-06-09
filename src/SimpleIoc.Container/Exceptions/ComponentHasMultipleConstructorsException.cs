using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleIoc.Container.Exceptions
{
    public class ComponentHasMultipleConstructorsException : IocException
    {
        public ComponentHasMultipleConstructorsException(Type type) : base(type)
        { }
    }
}
