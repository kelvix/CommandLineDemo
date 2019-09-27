using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TestHarness.Tests;
using TestRunnerApi.Models;

namespace TestRunnerApi.Services
{
    public class TestResolver : ITestResolver
    {
        private readonly IServiceProvider _provider;

        public TestResolver(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ActionResult<IEnumerable<string>> ListTests()
        {
            var tests = _provider.GetServices<ITest>();

            return tests.Select(test => test.GetType().Name).ToList();
        }

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