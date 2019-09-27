using System.Threading;
using System.Threading.Tasks;
using TestHarness.Tests;

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

        public async Task<bool> ExecuteTestAsync(ITest test)
        {
            return await Task.Run(() =>
            {
                return ExecuteTest(test);
            });
        }

        public async Task<bool> ExecuteTestAsync(ITest test, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                return ExecuteTest(test);
            }, cancellationToken);
        }
    }
}