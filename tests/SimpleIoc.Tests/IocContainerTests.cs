using Shouldly;
using SimpleIoc.Container;
using SimpleIoc.Tests.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SimpleIoc.Tests
{
    public class IocContainerTests
    {
        private readonly IocContainer _container;

        public IocContainerTests()
        {
            _container = new IocContainer();
        }

        private ITestInterface act()
        {
            return _container.Resolve<ITestInterface>();
        }

        [Fact]
        public void given_registered_interface_should_resolve_implementation()
        {
            _container.Register<ITestInterface, TestImplementation>();

            var resolveObject = act();

            resolveObject.ShouldBeOfType<TestImplementation>();
        }
    }
}
