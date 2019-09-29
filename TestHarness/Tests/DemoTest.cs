using System.Threading;
using Microsoft.Extensions.Logging;

namespace TestHarness.Tests
{
    public class DemoTest : ITest
    {
        private readonly ILogger<DemoTest> _logger;

        public DemoTest(ILogger<DemoTest> logger)
        {
            _logger = logger;
        }

        public void Arrange()
        {
            _logger.LogDebug("Running arrange.");
            Thread.Sleep(10000);
        }

        public void Act()
        {
            _logger.LogDebug("Running act.");
            Thread.Sleep(20000);
        }

        public bool Assert()
        {
            _logger.LogDebug("Running assert.");
            Thread.Sleep(30000);
            return true;
        }
    }
}