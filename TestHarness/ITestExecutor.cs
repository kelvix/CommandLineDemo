using System.Threading;
using System.Threading.Tasks;
using TestHarness.Models;
using TestHarness.Tests;

namespace TestHarness
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITestExecutor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        bool ExecuteTest(ITest test);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        Task<bool> ExecuteTestAsync(ITest test);
        
        /// <summary>
        /// Submits a test for execution. The asynchronous code can be cancelled
        /// by providing a <see cref="CancellationToken"/>. The responsibility
        /// belongs to the to maintain this token.
        /// </summary>
        /// <param name="test"></param>
        /// <param name="testMeta"></param>
        /// <returns></returns>
        Task<bool> ExecuteTestAsync(ITest test, TestMeta testMeta);
    }
}