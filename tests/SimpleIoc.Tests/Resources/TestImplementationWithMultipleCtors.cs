namespace SimpleIoc.Tests.Resources
{
    public class TestImplementationWithMultipleCtors : ITestInterface
    {
        public TestImplementationWithMultipleCtors()
        { }

        public TestImplementationWithMultipleCtors(Dependency dependency)
        { }
    }
}
