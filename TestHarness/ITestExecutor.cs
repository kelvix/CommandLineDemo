using ConsoleApp.Tests;

namespace TestHarness
{
    public interface ITestExecutor
    {
        bool ExecuteTest(ITest test);
    }
}