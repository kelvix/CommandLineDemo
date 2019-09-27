using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestHarness.Tests;
using TestRunnerApi.Models;

namespace TestRunnerApi.Services
{
    public interface ITestResolver
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ActionResult<IEnumerable<string>> ListTests();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="executionRequest"></param>
        /// <returns></returns>
        ITest TestNameToType(ScheduleExecutionRequest executionRequest);
    }
}