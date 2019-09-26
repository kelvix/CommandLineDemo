using ConsoleApp.Tests;

namespace TestHarness
{
    public class TestExecutor : ITestExecutor
    {
        public TestExecutor()
        {
        }

        public bool ExecuteTest(ITest test)
        {
            test.Arrange();
            test.Act();
            return test.Assert();
        }
    }
}