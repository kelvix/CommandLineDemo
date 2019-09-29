using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestHarness;
using TestHarness.Models;
using TestHarness.Tests;

namespace TestRunnerApi.Services
{
    public class ApiTestExecutor : IApiTestExecutor
    {
        private readonly ITestExecutor _executor;

        private static readonly ConcurrentDictionary<string, TestMeta> TaskHolder =
            new ConcurrentDictionary<string, TestMeta>();

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
        public TestMeta Execute(ITest test)
        {
            var runningTest = new TestMeta
            {
                Id = Guid.NewGuid().ToString(),
                Status = TestStatus.Submitted,
                CancellationToken = new CancellationToken(),
            };

            Task.Run(async () =>
            {
                TaskHolder.TryAdd(runningTest.Id, runningTest);
                await _executor.ExecuteTestAsync(test, runningTest);
                TaskHolder.Remove(runningTest.Id, out var value);
            });

            return runningTest;
        }

        public TestMeta FindTest(string id)
        {
            TaskHolder.TryGetValue(id, out var testMeta);
            return testMeta;
        }
    }
}