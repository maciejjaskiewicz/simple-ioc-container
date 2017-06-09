using Shouldly;
using SimpleIoc.Container;
using SimpleIoc.Container.Exceptions;
using SimpleIoc.Tests.Resources;
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

        [Fact]
        public void given_registered_interface_should_resolve_implementation_with_dependency()
        {
            _container.Register<Dependency, Dependency>();
            _container.Register<ITestInterface, TestImplementationWithDependency>();

            var resolveObject = act();

            resolveObject.ShouldBeOfType<TestImplementationWithDependency>();
        }

        [Fact]
        public void throws_when_component_has_multiple_ctors()
        {
            _container.Register<Dependency, Dependency>();
            _container.Register<ITestInterface, TestImplementationWithMultipleCtors>();

            var exception = Record.Exception(() => act());

            exception.ShouldBeOfType<ComponentHasMultipleConstructorsException>();
        }
    }
}