using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Tests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

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
    }
}