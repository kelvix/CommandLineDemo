using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestHarness;
using TestHarness.Tests;

namespace TestRunnerApi.Services
{
    public class ApiTestExecutor : IApiTestExecutor
    {
        private readonly ITestExecutor _executor;

        private ConcurrentDictionary<string, TestTaskHolder> _testDictionary =
            new ConcurrentDictionary<string, TestTaskHolder>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="executor"></param>
        public ApiTestExecutor(ITestExecutor executor)
        {
            _executor = executor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public async Task ExecuteAsync(ITest test)
        {
            var taskId = Guid.NewGuid().ToString();
            var cancellationToken = new CancellationToken();
            var taskHolder = new TestTaskHolder
            {
                Task = _executor.ExecuteTestAsync(test, cancellationToken),
                Token = cancellationToken
            };

            _testDictionary.TryAdd(taskId, taskHolder);
            await taskHolder.Task;
            _testDictionary.Remove(taskId, out var value);
        }
    }

    public class TestTaskHolder
    {
        public Task<bool> Task { get; set; }
        public CancellationToken Token { get; set; }
    }
}