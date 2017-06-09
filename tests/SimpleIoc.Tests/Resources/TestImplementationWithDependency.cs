namespace SimpleIoc.Tests.Resources
{
    public class TestImplementationWithDependency : ITestInterface
    {
        public TestImplementationWithDependency(Dependency dependency)
        { }
    }
}
