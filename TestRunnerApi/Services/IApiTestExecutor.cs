using System.Threading.Tasks;
using TestHarness.Tests;

namespace TestRunnerApi.Services
{
    public interface IApiTestExecutor
    {
        Task ExecuteAsync(ITest test);
    }
}