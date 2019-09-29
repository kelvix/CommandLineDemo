using TestHarness.Models;
using TestHarness.Tests;

namespace TestRunnerApi.Services
{
    public interface IApiTestExecutor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        TestMeta Execute(ITest test);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TestMeta FindTest(string id);
    }
}