using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using TestHarness.Tests;
using TestRunnerApi.Models;

namespace TestRunnerApi.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class TestResolver : ITestResolver
    {
        private readonly IServiceProvider _provider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        public TestResolver(IServiceProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ListTests()
        {
            var tests = _provider.GetServices<ITest>();

            return tests.Select(test => test.GetType().Name).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="executionRequest"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public ITest TestNameToType(ScheduleExecutionRequest executionRequest)
        {
            if (string.IsNullOrWhiteSpace(executionRequest.TestName))
            {
                throw new ArgumentNullException(nameof(executionRequest.TestName),
                    "A TestName must be provided.");
            }

            var tests = _provider.GetServices<ITest>();

            return tests.FirstOrDefault(test =>
                test.GetType().Name.Equals(executionRequest.TestName));
        }
    }
}